using DocumentFormat.OpenXml.Office2010.Excel;
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
        public async Task<List<GSTReturnDetailed>> GetGSTReturnDetailed(DateTime fromDate, DateTime toDate)
        {
            List<GSTReturnDetailed> registeredList = await (from sls in dbContext.Sales
                   join prt in dbContext.Parties on sls.PartyId equals prt.PartyId
                   where sls.InvoiceDate.Date >= fromDate.Date && sls.InvoiceDate.Date <= toDate.Date && prt.PartyGstNo != null && prt.PartyGstNo.Trim().Length > 0
                   select new GSTReturnDetailed()
                   {
                       SalesId = sls.SalesId,
                       InvoiceNo = sls.InvoiceNo,
                       InvoiceDate = sls.InvoiceDate,
                       PartyName = prt.PartyName,
                       PartyGstin = prt.PartyGstNo
                   }).ToListAsync();


            foreach (var party in registeredList) {
                party.Data = await(from itm in dbContext.SalesItems
                       where itm.SalesId == party.SalesId
                       group new { itm } by new { itm.SalesId, itm.GstPer, itm.IgstPer, itm.CgstPer, itm.SgstPer } into grp
                       select new GSTData()
                       {
                           IgstPer = grp.Key.IgstPer,
                           CgstPer = grp.Key.CgstPer,
                           SgstPer = grp.Key.SgstPer,
                           GstPer = grp.Key.GstPer,
                           TaxableAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity), 2),
                           IgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.IgstPer / 100), 2),
                           CgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.CgstPer / 100), 2),
                           SgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.SgstPer / 100), 2),
                           GstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.GstPer / 100), 2)
                       }).ToListAsync();
            }



            List<GSTReturnDetailed> unRegistered = await dbContext.Sales.Where(col => col.InvoiceDate.Date >= fromDate.Date && col.InvoiceDate.Date <= toDate.Date && (col.Party == null || col.Party.PartyGstNo == null || col.Party.PartyGstNo.Trim().Length == 0)).Select(row => new GSTReturnDetailed()
            {
                InvoiceDate = row.InvoiceDate.Date
            }).ToListAsync();

            foreach (var party in unRegistered)
            {
                party.Data = await (from itm in dbContext.SalesItems
                                    join sls in dbContext.Sales on itm.SalesId equals sls.SalesId
                                    where sls.InvoiceDate.Date == party.InvoiceDate
                                    group new { itm, sls } by new { sls.InvoiceDate, itm.GstPer, itm.IgstPer, itm.CgstPer, itm.SgstPer } into grp
                                    select new GSTData()
                                    {
                                        IgstPer = grp.Key.IgstPer,
                                        CgstPer = grp.Key.CgstPer,
                                        SgstPer = grp.Key.SgstPer,
                                        GstPer = grp.Key.GstPer,
                                        TaxableAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity), 2),
                                        IgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.IgstPer / 100), 2),
                                        CgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.CgstPer / 100), 2),
                                        SgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.SgstPer / 100), 2),
                                        GstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.GstPer / 100), 2)
                                    }).ToListAsync();
            }

            List<GSTReturnDetailed> returnsDetailed = new();

            if(registeredList.Count > 0)
            {
                returnsDetailed.Add(new GSTReturnDetailed()
                {
                    IsHeader = true,
                    PartyName = "REGISTERED INVOICES"
                });

                returnsDetailed.AddRange(registeredList);
            }


            if (unRegistered.Count > 0)
            {
                returnsDetailed.Add(new GSTReturnDetailed()
                {
                    IsHeader = true,
                    PartyName = "UN REGISTERED INVOICES"
                });

                returnsDetailed.AddRange(unRegistered);
            }
            
            return returnsDetailed;
        }

        public async Task<List<GSTReturnStatement>> GetGSTReturnStatement(DateTime fromDate, DateTime toDate)
        {
            List<Gst> gstList = await dbContext.Gsts.ToListAsync();
            DataTable dataTable = new();
            dataTable.Columns.Add("InvoiceDate", typeof(string));

            List<GSTReturnStatement> listSummary = [];
            var dates = await dbContext.Sales.Where(col => col.InvoiceDate.Date >= fromDate.Date && col.InvoiceDate.Date <= toDate.Date).Select(row => row.InvoiceDate.Date).Distinct().ToListAsync();
            foreach (DateTime date in dates)
            {
                var summary = new GSTReturnStatement
                {
                    InvoiceDate = date.ToString("dd-MMM-yyyy"),
                    Data = await (from itm in dbContext.SalesItems
                                  join sls in dbContext.Sales on itm.SalesId equals sls.SalesId
                                  where sls.InvoiceDate == date
                                  group new { itm } by new { itm.GstPer, itm.IgstPer, itm.CgstPer, itm.SgstPer } into grp
                                  select new GSTData()
                                  {
                                      IgstPer = grp.Key.IgstPer,
                                      CgstPer = grp.Key.CgstPer,
                                      SgstPer = grp.Key.SgstPer,
                                      GstPer = grp.Key.GstPer,

                                      TaxableAmount = grp.Sum(sm => sm.itm.Rate - sm.itm.PurchasePrice),
                                   
                                      IgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.IgstPer / 100), 2),
                                      CgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.CgstPer / 100), 2),
                                      SgstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.SgstPer / 100), 2),
                                      GstAmount = Math.Round(grp.Sum(sm => (sm.itm.Rate - sm.itm.PurchasePrice) * sm.itm.Quantity * sm.itm.GstPer / 100),2)
                                  }).ToListAsync()
                };
                listSummary.Add(summary);
            }

            return listSummary;

           /* foreach (Gst gst in gstList)
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

                var groupValues = list.GroupBy(g => g.GstPer).Select(x => new
                {
                    GSTPer = x.Key,
                    Total = x.Sum(x => x.GstValue)
                }).ToList();

                dataRow["InvoiceDate"] = date.ToString("dd-MMM-yyyy");
                foreach (var grp in groupValues)
                {
                    dataRow[grp.GSTPer.ToString() + "%"] = Math.Round(grp.Total, 2);
                }

                dataTable.Rows.Add(dataRow);
            }*/
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
                               group new { sls, itm } by new { InvoiceMonth = sls.InvoiceDate.Month, InvoiceYear = sls.InvoiceDate.Year, sls.SalesType, sls.PaymentMode } into grp
                               select new
                               {
                                   Month = $"{grp.Key.InvoiceMonth}-{grp.Key.InvoiceYear}",
                                   grp.Key.SalesType,
                                   grp.Key.PaymentMode,
                                   TotalAmount = grp.Sum(p => p.itm.TotalAmount)
                               }).ToListAsync();

            var months = list.Select(s => s.Month).Distinct().ToList();

            foreach (var month in months)
            {
                salesSummary.Add(new SalesSummary()
                {
                    Month = month.ToString(),
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
