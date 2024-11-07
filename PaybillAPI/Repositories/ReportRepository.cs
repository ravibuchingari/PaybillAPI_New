﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaybillAPI.Data;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System.Data;

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


            foreach (var party in registeredList)
            {
                party.Data = await (from itm in dbContext.SalesItems
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

            if (registeredList.Count > 0)
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

        public async Task<List<GSTHSNSummary>> GetGSTHSNSummary(DateTime fromDate, DateTime toDate)
        {
            List<GSTHSNSummary> listSummary = [];
            var hsnCodes = await dbContext.SalesItems.Where(col => col.Sales.InvoiceDate.Date >= fromDate.Date &&
                                                                    col.Sales.InvoiceDate.Date <= toDate.Date &&
                                                                    col.Item.Hsncode != null &&
                                                                    col.Item.Hsncode.Trim().Length > 0).Select(row => row.Item.Hsncode).Distinct().ToListAsync();
            foreach (var hCode in hsnCodes)
            {
                var summary = new GSTHSNSummary
                {
                    HsnCode = hCode!,
                    Data = await (from sls_itm in dbContext.SalesItems
                                  join sls in dbContext.Sales on sls_itm.SalesId equals sls.SalesId
                                  join itm in dbContext.Items on sls_itm.ItemId equals itm.ItemId
                                  where itm.Hsncode == hCode
                                  group new { sls_itm } by new { sls_itm.GstPer, sls_itm.IgstPer, sls_itm.CgstPer, sls_itm.SgstPer } into grp
                                  select new GSTData()
                                  {
                                      IgstPer = grp.Key.IgstPer,
                                      CgstPer = grp.Key.CgstPer,
                                      SgstPer = grp.Key.SgstPer,
                                      GstPer = grp.Key.GstPer,
                                      TaxableAmount = Math.Round(grp.Sum(sm => (sm.sls_itm.Rate - sm.sls_itm.PurchasePrice) * sm.sls_itm.Quantity), 2),
                                      IgstAmount = Math.Round(grp.Sum(sm => (sm.sls_itm.Rate - sm.sls_itm.PurchasePrice) * sm.sls_itm.Quantity * sm.sls_itm.IgstPer / 100), 2),
                                      CgstAmount = Math.Round(grp.Sum(sm => (sm.sls_itm.Rate - sm.sls_itm.PurchasePrice) * sm.sls_itm.Quantity * sm.sls_itm.CgstPer / 100), 2),
                                      SgstAmount = Math.Round(grp.Sum(sm => (sm.sls_itm.Rate - sm.sls_itm.PurchasePrice) * sm.sls_itm.Quantity * sm.sls_itm.SgstPer / 100), 2),
                                      GstAmount = Math.Round(grp.Sum(sm => (sm.sls_itm.Rate - sm.sls_itm.PurchasePrice) * sm.sls_itm.Quantity * sm.sls_itm.GstPer / 100), 2)
                                  }).ToListAsync()
                };
                listSummary.Add(summary);
            }

            return listSummary;
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
                                                   Summary = new InvoiceSummary
                                                   {
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

        public async Task<List<PurchaseVM>> GetPurchaseDetails(ReportParam reportParam)
        {

            var list = await dbContext.Purchases.Include(itm => itm.PurchaseItems).Where(col => col.InvoiceDate.Date >= DateTime.Parse(reportParam.FromDate!).Date &&
                                               col.InvoiceDate <= DateTime.Parse(reportParam.ToDate!).Date &&
                                               col.PurchaseType == (reportParam.TransactionType.IsNullOrEmpty() ? col.PurchaseType : reportParam.TransactionType) &&
                                               col.PaymentMode == (reportParam.PaymentMode.IsNullOrEmpty() ? col.PaymentMode : reportParam.PaymentMode) &&
                                               col.UpiType == (reportParam.UpiType.IsNullOrEmpty() ? col.UpiType : reportParam.UpiType)).OrderBy(ord => ord.InvoiceDate).Select(row => new PurchaseVM
                                               {
                                                   PurchaseId = row.PurchaseId,
                                                   InvoiceNo = row.InvoiceNo,
                                                   InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                                                   PurchaseType = row.PurchaseType,
                                                   PaymentMode = row.PaymentMode,
                                                   UpiType = row.UpiType,
                                                   Summary = new InvoiceSummary
                                                   {
                                                       TotalAmount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.Amount),
                                                       TotalDiscount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.DiscountInRs),
                                                       TotalTaxableAmount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.TaxableAmount),
                                                       TotalGSTAmount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.GstAmount),
                                                       TotalInvoiceAmount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.TotalAmount)
                                                   },
                                                   PartyModel = new PartyVM
                                                   {
                                                       PartyId = row.Party.PartyId,
                                                       PartyName = row.Party.PartyName
                                                   }
                                               }).ToListAsync();
            return list;
        }

    }
}
