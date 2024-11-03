using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System.Data;
using System.Security.Cryptography;

namespace PaybillAPI.Repositories
{
    public class ReportRepository(AppDBContext dbContext) : IReportRepository
    {
        public async Task<List<GSTReturnModel>> GetGSTReturns(DateTime fromDate, DateTime toDate)
        {
            List<SalesItem> listSales = await dbContext.SalesItems.Include(itm => itm.Item).Include(sls => sls.Sales).Where(col => col.Sales.InvoiceDate.Date >= fromDate.Date && col.Sales.InvoiceDate.Date <= toDate.Date).ToListAsync();

            List<GSTReturnModel> gstReturns = [];
            foreach (SalesItem salesItem in listSales)
            {
                gstReturns.Add(new GSTReturnModel()
                {
                    ItemId = salesItem.ItemId,
                    InvoiceDate = salesItem.Sales.InvoiceDate,
                    ItemName = salesItem.Item.ItemName,
                    HSNcode = salesItem.Item.Hsncode,
                    PurchasePrice = salesItem.PurchasePrice,
                    SalesPrice = salesItem.Rate,
                    TaxableAmount = salesItem.Rate - salesItem.PurchasePrice,
                    GSTPer = salesItem.GstPer,
                    GSTValue = salesItem.GstPer * (salesItem.Rate - salesItem.PurchasePrice) / 100
                });
            }

            return gstReturns;
        }

        public async Task<DataTable> GetGSTSummary(DateTime fromDate, DateTime toDate)
        {
            List<Gst> gstList = await dbContext.Gsts.ToListAsync();
            DataTable dataTable = new();
            dataTable.Columns.Add("InvoiceDate", typeof(string));
            foreach (Gst gst in gstList)
            {
                dataTable.Columns.Add($"{gst.SgstPer + gst.CgstPer}%", typeof(double));
            }
            List<GSTReturnModel> gSTReturnModels = await GetGSTReturns(fromDate, toDate);

            var dates = gSTReturnModels.Select(r => r.InvoiceDate).Distinct().ToList();

            DataRow dataRow;

            foreach (var date in dates)
            {
                dataRow = dataTable.NewRow();

                var list = gSTReturnModels.Where(x => x.InvoiceDate == date).ToList();

                var groupValues = list.GroupBy(g => g.GSTPer).Select(x => new
                {
                    GSTPer = x.Key,
                    Total = x.Sum(x => x.GSTValue)
                }).ToList();

                dataRow["InvoiceDate"] = date.ToString("dd-MMM-yyyy");
                foreach (var grp in groupValues)
                {
                    dataRow[grp.GSTPer.ToString() + "%"] = Math.Round(grp.Total, 2);
                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        public async Task<List<SalesVM>> GetSalesDetails(ReportParam reportParam)
        {

            var list = await dbContext.Sales.Include(itm => itm.SalesItems).Where(col => col.InvoiceDate.Date >= DateTime.Parse(reportParam.FromDate!).Date && 
                                               col.InvoiceDate <= DateTime.Parse(reportParam.ToDate!).Date && 
                                               col.SalesType == (reportParam.TransactionType.IsNullOrEmpty() ? col.SalesType : reportParam.TransactionType) &&
                                               col.PaymentMode == (reportParam.PaymentMode.IsNullOrEmpty() ? col.PaymentMode : reportParam.PaymentMode) && 
                                               col.UpiType == (reportParam.UpiType.IsNullOrEmpty() ? col.UpiType : reportParam.UpiType)).OrderBy(ord => ord.InvoiceDate).Select(row => new SalesVM
                                               {
                                                   SalesId = row.SalesId,
                                                   InvoiceNo = row.InvoiceNo,
                                                   InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                                                   SalesType = row.SalesType,
                                                   PaymentMode = row.PaymentMode,
                                                   UpiType = row.UpiType,
                                                   Summary = new InvoiceSummary {
                                                       TotalAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.Amount),
                                                       TotalDiscount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.DiscountInRs),
                                                       TotalTaxableAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.TaxableAmount),
                                                       TotalGSTAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.GstAmount),
                                                       TotalInvoiceAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.TotalAmount)
                                                   },
                                                   PartyModel = row.Party != null ? new PartyVM
                                                   {
                                                       PartyId = row.Party.PartyId,
                                                       PartyName = row.Party.PartyName
                                                   } : null,
                                               }).ToListAsync();
            return list;
        }

        public async Task<List<SalesSummary>> GetSalesSummary(ReportParam reportParam)
        {
            List<SalesSummary> salesSummary = [];

            var list = await (from sls in dbContext.Sales
                   join itm in dbContext.SalesItems on sls.SalesId equals itm.SalesId
                   where sls.InvoiceDate.Date >= DateTime.Parse(reportParam.FromDate!).Date && sls.InvoiceDate <= DateTime.Parse(reportParam.ToDate!).Date
                   group new { sls, itm } by new { InvoiceMonth = sls.InvoiceDate.ToString("MM-yyyy"), sls.SalesType, sls.PaymentMode } into grp
                   select new
                   {
                       Month = grp.Key.InvoiceMonth,
                       grp.Key.SalesType,
                       grp.Key.PaymentMode,
                       TotalAmount = grp.Sum(p => p.itm.TotalAmount)
                   }).ToListAsync();

            var months = list.Select(s => s.Month).Distinct().ToList();

            foreach (var month in months)
            {
                salesSummary.Add(new SalesSummary()
                {
                    Month = month,
                    Credit = list.Where(x => x.Month == month && x.SalesType == PaymentMode.Credit.ToString()).Sum(x => x.TotalAmount),
                    Cash = list.Where(x => x.Month == month && x.SalesType == PaymentMode.Cash.ToString() && x.PaymentMode == PaymentMode.Cash.ToString()).Sum(x => x.TotalAmount),
                    Card = list.Where(x => x.Month == month && x.SalesType == PaymentMode.Cash.ToString() && x.PaymentMode == PaymentMode.Card.ToString()).Sum(x => x.TotalAmount),
                    Upi = list.Where(x => x.Month == month && x.SalesType == PaymentMode.Cash.ToString() && x.PaymentMode == PaymentMode.UPI.ToString()).Sum(x => x.TotalAmount),
                    TotalAmount = list.Where(x => x.Month == month).Sum(x => x.TotalAmount)
                });
            }
            return salesSummary;
        }
    }
}
