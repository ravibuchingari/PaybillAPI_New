using Microsoft.EntityFrameworkCore;
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
            var registeredRaw = await (from sls in dbContext.Sales
                                       join prt in dbContext.Parties on sls.PartyId equals prt.PartyId
                                       where sls.InvoiceDate.Date >= fromDate.Date && sls.InvoiceDate.Date <= toDate.Date && prt.PartyGstNo != null && prt.PartyGstNo.Trim().Length > 0
                                       orderby sls.InvoiceDate, sls.SalesId
                                       select new
                                       {
                                           sls.SalesId,
                                           sls.InvoiceNo,
                                           sls.InvoiceDate,
                                           prt.PartyName,
                                           prt.PartyGstNo
                                       }).ToListAsync();

            List<GSTReturnDetailed> registeredList = registeredRaw.Select(r => new GSTReturnDetailed
            {
                SalesId = r.SalesId,
                InvoiceNo = r.InvoiceNo,
                InvoiceDate = r.InvoiceDate.ToString("dd-MMM-yyyy"),
                PartyName = r.PartyName,
                PartyGstin = r.PartyGstNo ?? string.Empty
            }).ToList();

            foreach (var party in registeredList)
            {
                party.Data = await (from itm in dbContext.SalesItems
                                    where itm.SalesId == party.SalesId && itm.GstPer > 0
                                    group new { itm } by new { itm.SalesId, itm.GstPer, itm.IgstPer, itm.CgstPer, itm.SgstPer } into grp
                                    select new GSTData()
                                    {
                                        IgstPer = grp.Key.IgstPer,
                                        CgstPer = grp.Key.CgstPer,
                                        SgstPer = grp.Key.SgstPer,
                                        GstPer = grp.Key.GstPer,
                                        TaxableAmount = Math.Round(grp.Sum(sm => sm.itm.TaxableAmount), 2),
                                        IgstAmount = Math.Round(grp.Sum(sm => sm.itm.IgstRs), 2),
                                        CgstAmount = Math.Round(grp.Sum(sm => sm.itm.CgstRs), 2),
                                        SgstAmount = Math.Round(grp.Sum(sm => sm.itm.SgstRs), 2),
                                        GstAmount = Math.Round(grp.Sum(sm => sm.itm.GstAmount), 2)
                                    }).ToListAsync();
            }

            var unregDates = await dbContext.Sales
                .Where(col => col.InvoiceDate.Date >= fromDate.Date && col.InvoiceDate.Date <= toDate.Date && (col.Party == null || col.Party.PartyGstNo == null || col.Party.PartyGstNo.Trim().Length == 0))
                .Select(row => row.InvoiceDate.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToListAsync();

            List<GSTReturnDetailed> unRegistered = new();
            foreach (var invDate in unregDates)
            {
                var data = await (from itm in dbContext.SalesItems
                                  join sls in dbContext.Sales on itm.SalesId equals sls.SalesId
                                  where sls.InvoiceDate.Date == invDate && itm.GstPer > 0 && (sls.Party == null || sls.Party.PartyGstNo == null || sls.Party.PartyGstNo.Trim().Length == 0)
                                  group new { itm } by new { itm.GstPer, itm.IgstPer, itm.CgstPer, itm.SgstPer } into grp
                                  select new GSTData()
                                  {
                                      IgstPer = grp.Key.IgstPer,
                                      CgstPer = grp.Key.CgstPer,
                                      SgstPer = grp.Key.SgstPer,
                                      GstPer = grp.Key.GstPer,
                                      TaxableAmount = Math.Round(grp.Sum(sm => sm.itm.TaxableAmount), 2),
                                      IgstAmount = Math.Round(grp.Sum(sm => sm.itm.IgstRs), 2),
                                      CgstAmount = Math.Round(grp.Sum(sm => sm.itm.CgstRs), 2),
                                      SgstAmount = Math.Round(grp.Sum(sm => sm.itm.SgstRs), 2),
                                      GstAmount = Math.Round(grp.Sum(sm => sm.itm.GstAmount), 2)
                                  }).ToListAsync();

                unRegistered.Add(new GSTReturnDetailed
                {
                    InvoiceDate = invDate.ToString("dd-MMM-yyyy"),
                    Data = data
                });
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

        public async Task<List<GSTReturnDetailed>> GetGSTRReturnByType(string returnType, DateTime fromDate, DateTime toDate)
        {
            if (string.IsNullOrWhiteSpace(returnType))
                return await GetGSTReturnDetailed(fromDate, toDate);

            if (returnType.Contains("3B", StringComparison.OrdinalIgnoreCase))
                return await GetGstr3bSummaryAsync(fromDate, toDate);
            if (returnType.Contains("2A", StringComparison.OrdinalIgnoreCase) || returnType.Contains("2B", StringComparison.OrdinalIgnoreCase))
                return await GetGstr2aInwardDetailedAsync(fromDate, toDate);
            if (returnType.Contains("CMP", StringComparison.OrdinalIgnoreCase) || returnType.Contains("4", StringComparison.OrdinalIgnoreCase))
                return await GetCmp08SummaryAsync(fromDate, toDate);
            if (returnType.Contains("9", StringComparison.OrdinalIgnoreCase))
                return await GetGstr9AnnualSummaryAsync(fromDate, toDate);

            return await GetGSTReturnDetailed(fromDate, toDate);
        }

        private async Task<List<GSTReturnDetailed>> GetGstr3bSummaryAsync(DateTime fromDate, DateTime toDate)
        {
            var list = new List<GSTReturnDetailed>();

            var outwardItems = await (from itm in dbContext.SalesItems
                                      join sal in dbContext.Sales on itm.SalesId equals sal.SalesId
                                      where sal.InvoiceDate.Date >= fromDate.Date && sal.InvoiceDate.Date <= toDate.Date && itm.GstPer > 0
                                      select new { itm.TaxableAmount, itm.CgstRs, itm.SgstRs, itm.IgstRs, itm.GstAmount }).ToListAsync();

            list.Add(new GSTReturnDetailed { IsHeader = true, PartyName = "3.1 OUTWARD TAXABLE SUPPLIES" });
            list.Add(new GSTReturnDetailed
            {
                IsHeader = false,
                InvoiceNo = "3.1",
                InvoiceDate = "Monthly Summary",
                PartyName = "3.1 Outward Taxable Supplies",
                PartyGstin = "N/A",
                Data = new List<GSTData>
                {
                    new GSTData
                    {
                        TaxableAmount = Math.Round(outwardItems.Sum(x => x.TaxableAmount), 2),
                        CgstAmount = Math.Round(outwardItems.Sum(x => x.CgstRs), 2),
                        SgstAmount = Math.Round(outwardItems.Sum(x => x.SgstRs), 2),
                        IgstAmount = Math.Round(outwardItems.Sum(x => x.IgstRs), 2),
                        GstAmount = Math.Round(outwardItems.Sum(x => x.GstAmount), 2)
                    }
                }
            });

            var itcItems = await (from itm in dbContext.PurchaseItems
                                  join pur in dbContext.Purchases on itm.PurchaseId equals pur.PurchaseId
                                  where pur.InvoiceDate.Date >= fromDate.Date && pur.InvoiceDate.Date <= toDate.Date && itm.GstPer > 0
                                  select new { itm.TaxableAmount, itm.CgstRs, itm.SgstRs, itm.IgstRs, itm.GstAmount }).ToListAsync();

            list.Add(new GSTReturnDetailed { IsHeader = true, PartyName = "4.0 ELIGIBLE INPUT TAX CREDIT (ITC)" });
            list.Add(new GSTReturnDetailed
            {
                IsHeader = false,
                InvoiceNo = "4.0",
                InvoiceDate = "Monthly Summary",
                PartyName = "4.0 Eligible Input Tax Credit (ITC)",
                PartyGstin = "N/A",
                Data = new List<GSTData>
                {
                    new GSTData
                    {
                        TaxableAmount = Math.Round(itcItems.Sum(x => x.TaxableAmount), 2),
                        CgstAmount = Math.Round(itcItems.Sum(x => x.CgstRs), 2),
                        SgstAmount = Math.Round(itcItems.Sum(x => x.SgstRs), 2),
                        IgstAmount = Math.Round(itcItems.Sum(x => x.IgstRs), 2),
                        GstAmount = Math.Round(itcItems.Sum(x => x.GstAmount), 2)
                    }
                }
            });

            return list;
        }

        private async Task<List<GSTReturnDetailed>> GetGstr2aInwardDetailedAsync(DateTime fromDate, DateTime toDate)
        {
            var purchases = await (from pur in dbContext.Purchases
                                   join par in dbContext.Parties on pur.PartyId equals par.PartyId
                                   where pur.InvoiceDate.Date >= fromDate.Date && pur.InvoiceDate.Date <= toDate.Date
                                   orderby pur.InvoiceDate, pur.PurchaseId
                                   select new
                                   {
                                       pur.PurchaseId,
                                       pur.InvoiceNo,
                                       pur.InvoiceDate,
                                       par.PartyName,
                                       par.PartyGstNo
                                   }).ToListAsync();

            var list = new List<GSTReturnDetailed>();
            foreach (var p in purchases)
            {
                var dataList = await dbContext.PurchaseItems
                    .Where(pi => pi.PurchaseId == p.PurchaseId)
                    .GroupBy(pi => pi.GstPer)
                    .Select(g => new GSTData
                    {
                        GstPer = g.Key,
                        TaxableAmount = Math.Round(g.Sum(x => x.TaxableAmount), 2),
                        IgstAmount = Math.Round(g.Sum(x => x.IgstRs), 2),
                        CgstAmount = Math.Round(g.Sum(x => x.CgstRs), 2),
                        SgstAmount = Math.Round(g.Sum(x => x.SgstRs), 2),
                        GstAmount = Math.Round(g.Sum(x => x.GstAmount), 2)
                    }).ToListAsync();

                list.Add(new GSTReturnDetailed
                {
                    SalesId = p.PurchaseId,
                    InvoiceNo = p.InvoiceNo,
                    InvoiceDate = p.InvoiceDate.ToString("dd-MMM-yyyy"),
                    PartyName = p.PartyName,
                    PartyGstin = p.PartyGstNo ?? string.Empty,
                    Data = dataList
                });
            }

            var result = new List<GSTReturnDetailed>();
            if (list.Count > 0)
            {
                result.Add(new GSTReturnDetailed { IsHeader = true, PartyName = "INWARD SUPPLIES / PURCHASES (GSTR-2A/2B)" });
                result.AddRange(list);
            }
            return result;
        }

        private async Task<List<GSTReturnDetailed>> GetCmp08SummaryAsync(DateTime fromDate, DateTime toDate)
        {
            double totalTaxable = await (from itm in dbContext.SalesItems
                                         join sal in dbContext.Sales on itm.SalesId equals sal.SalesId
                                         where sal.InvoiceDate.Date >= fromDate.Date && sal.InvoiceDate.Date <= toDate.Date
                                         select itm.TaxableAmount).SumAsync();

            var list = new List<GSTReturnDetailed>
            {
                new GSTReturnDetailed { IsHeader = true, PartyName = "COMPOSITION TAXABLE SUPPLIES (CMP-08)" },
                new GSTReturnDetailed
                {
                    IsHeader = false,
                    InvoiceNo = "CMP-08",
                    InvoiceDate = "Quarterly Summary",
                    PartyName = "Outward Supplies (1% Composition Tax)",
                    PartyGstin = "Composition Scheme",
                    Data = new List<GSTData>
                    {
                        new GSTData
                        {
                            GstPer = 1.0f,
                            TaxableAmount = Math.Round(totalTaxable, 2),
                            CgstAmount = Math.Round(totalTaxable * 0.005, 2),
                            SgstAmount = Math.Round(totalTaxable * 0.005, 2),
                            IgstAmount = 0.0,
                            GstAmount = Math.Round(totalTaxable * 0.01, 2)
                        }
                    }
                }
            };
            return list;
        }

        private async Task<List<GSTReturnDetailed>> GetGstr9AnnualSummaryAsync(DateTime fromDate, DateTime toDate)
        {
            var salesItems = await (from itm in dbContext.SalesItems
                                    join sal in dbContext.Sales on itm.SalesId equals sal.SalesId
                                    where sal.InvoiceDate.Date >= fromDate.Date && sal.InvoiceDate.Date <= toDate.Date
                                    select new { itm.TaxableAmount, itm.CgstRs, itm.SgstRs, itm.IgstRs, itm.GstAmount }).ToListAsync();

            var purItems = await (from itm in dbContext.PurchaseItems
                                  join pur in dbContext.Purchases on itm.PurchaseId equals pur.PurchaseId
                                  where pur.InvoiceDate.Date >= fromDate.Date && pur.InvoiceDate.Date <= toDate.Date
                                  select new { itm.TaxableAmount, itm.CgstRs, itm.SgstRs, itm.IgstRs, itm.GstAmount }).ToListAsync();

            var list = new List<GSTReturnDetailed>
            {
                new GSTReturnDetailed { IsHeader = true, PartyName = "GSTR-9 ANNUAL RETURN SUMMARY" },
                new GSTReturnDetailed
                {
                    IsHeader = false,
                    InvoiceNo = "Part II",
                    InvoiceDate = "Annual Summary",
                    PartyName = "Total Outward Supplies",
                    PartyGstin = "Annual Summary",
                    Data = new List<GSTData>
                    {
                        new GSTData
                        {
                            TaxableAmount = Math.Round(salesItems.Sum(x => x.TaxableAmount), 2),
                            CgstAmount = Math.Round(salesItems.Sum(x => x.CgstRs), 2),
                            SgstAmount = Math.Round(salesItems.Sum(x => x.SgstRs), 2),
                            IgstAmount = Math.Round(salesItems.Sum(x => x.IgstRs), 2),
                            GstAmount = Math.Round(salesItems.Sum(x => x.GstAmount), 2)
                        }
                    }
                },
                new GSTReturnDetailed
                {
                    IsHeader = false,
                    InvoiceNo = "Part III",
                    InvoiceDate = "Annual Summary",
                    PartyName = "Total ITC Claimed on Purchases",
                    PartyGstin = "Annual Summary",
                    Data = new List<GSTData>
                    {
                        new GSTData
                        {
                            TaxableAmount = Math.Round(purItems.Sum(x => x.TaxableAmount), 2),
                            CgstAmount = Math.Round(purItems.Sum(x => x.CgstRs), 2),
                            SgstAmount = Math.Round(purItems.Sum(x => x.SgstRs), 2),
                            IgstAmount = Math.Round(purItems.Sum(x => x.IgstRs), 2),
                            GstAmount = Math.Round(purItems.Sum(x => x.GstAmount), 2)
                        }
                    }
                }
            };
            return list;
        }

        public async Task<List<GSTHSNSummary>> GetGSTHSNSummary(DateTime fromDate, DateTime toDate)
        {
            List<GSTHSNSummary> listSummary = [];
            var hsnCodes = await dbContext.SalesItems.Where(col => col.Sales.InvoiceDate.Date >= fromDate.Date &&
                                                                    col.Sales.InvoiceDate.Date <= toDate.Date &&
                                                                    col.Item != null &&
                                                                    col.Item.Hsncode != null &&
                                                                    col.Item.Hsncode.Trim().Length > 0).OrderBy(ord => ord.Item!.Hsncode).Select(row => row.Item!.Hsncode).Distinct().ToListAsync();
            foreach (var hCode in hsnCodes)
            {
                var data = await (from sls_itm in dbContext.SalesItems
                                  join sls in dbContext.Sales on sls_itm.SalesId equals sls.SalesId
                                  join itm in dbContext.Items on sls_itm.ItemId equals itm.ItemId
                                  where sls_itm.Item != null && itm.Hsncode == hCode && sls.InvoiceDate.Date >= fromDate.Date && sls.InvoiceDate.Date <= toDate.Date
                                  group new { sls_itm } by new { itm.Hsncode, sls_itm.GstPer } into grp
                                  select new GSTData()
                                  {
                                      GstPer = grp.Key.GstPer,
                                      Quantity = Math.Round(grp.Sum(sm => sm.sls_itm.Quantity), 2),
                                      TaxableAmount = Math.Round(grp.Sum(sm => sm.sls_itm.TaxableAmount), 2),
                                      IgstAmount = Math.Round(grp.Sum(sm => sm.sls_itm.IgstRs), 2),
                                      CgstAmount = Math.Round(grp.Sum(sm => sm.sls_itm.CgstRs), 2),
                                      SgstAmount = Math.Round(grp.Sum(sm => sm.sls_itm.SgstRs), 2),
                                      GstAmount = Math.Round(grp.Sum(sm => sm.sls_itm.GstAmount), 2)
                                  }).ToListAsync();

                var summary = new GSTHSNSummary
                {
                    HsnCode = hCode!,
                    Quantity = data.Sum(x => x.Quantity),
                    Data = data
                };
                listSummary.Add(summary);
            }

            return listSummary;
        }

        public async Task<List<GSTHSNSummary>> GetGSTSACSummary(DateTime fromDate, DateTime toDate)
        {
            List<GSTHSNSummary> listSummary = [];
            var sacCodes = await dbContext.SalesItems.Where(col => col.Sales.InvoiceDate.Date >= fromDate.Date &&
                                                                    col.Sales.InvoiceDate.Date <= toDate.Date &&
                                                                    col.ServiceType != null &&
                                                                    col.ServiceType.SacCode != null &&
                                                                    col.ServiceType.SacCode.Trim().Length > 0).OrderBy(ord => ord.ServiceType!.SacCode).Select(row => row.ServiceType!.SacCode).Distinct().ToListAsync();
            foreach (var sCode in sacCodes)
            {
                var data = await (from sls_itm in dbContext.SalesItems
                                  join sls in dbContext.Sales on sls_itm.SalesId equals sls.SalesId
                                  join itm in dbContext.ServiceTypes on sls_itm.ServiceTypeId equals itm.ServiceTypeId
                                  where sls_itm.ServiceType != null && itm.SacCode == sCode && sls.InvoiceDate.Date >= fromDate.Date && sls.InvoiceDate.Date <= toDate.Date
                                  group new { sls_itm } by new { itm.SacCode, sls_itm.GstPer } into grp
                                  select new GSTData()
                                  {
                                      GstPer = grp.Key.GstPer,
                                      Quantity = Math.Round(grp.Sum(sm => sm.sls_itm.Quantity), 2),
                                      TaxableAmount = Math.Round(grp.Sum(sm => sm.sls_itm.TaxableAmount), 2),
                                      IgstAmount = Math.Round(grp.Sum(sm => sm.sls_itm.IgstRs), 2),
                                      CgstAmount = Math.Round(grp.Sum(sm => sm.sls_itm.CgstRs), 2),
                                      SgstAmount = Math.Round(grp.Sum(sm => sm.sls_itm.SgstRs), 2),
                                      GstAmount = Math.Round(grp.Sum(sm => sm.sls_itm.GstAmount), 2)
                                  }).ToListAsync();

                var summary = new GSTHSNSummary
                {
                    HsnCode = sCode!,
                    Quantity = data.Sum(x => x.Quantity),
                    Data = data
                };
                listSummary.Add(summary);
            }

            return listSummary;
        }

        public async Task<List<SalesVM>> GetSalesDetails(ReportParam reportParam)
        {
            var list = await dbContext.Sales.Include(itm => itm.SalesItems).Where(col => col.InvoiceDate.Date >= DateTime.Parse(reportParam.FromDate!).Date &&
                                               col.InvoiceDate <= DateTime.Parse(reportParam.ToDate!).Date &&
                                               col.SalesType == (string.IsNullOrEmpty(reportParam.TransactionType) ? col.SalesType : reportParam.TransactionType) &&
                                               col.PaymentMode == (string.IsNullOrEmpty(reportParam.PaymentMode) ? col.PaymentMode : reportParam.PaymentMode) &&
                                               col.UpiType == (string.IsNullOrEmpty(reportParam.UpiType) ? col.UpiType : reportParam.UpiType)).OrderBy(ord => ord.InvoiceDate).Select(row => new SalesVM
                                               {
                                                   SalesId = row.SalesId,
                                                   InvoiceNo = row.InvoiceNo,
                                                   InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                                                   SalesType = row.SalesType,
                                                   PaymentMode = row.PaymentMode,
                                                   UpiType = row.UpiType,
                                                   RewardPointsEarned = row.RewardPointsEarned,
                                                   RewardPointsRedeemed = row.RewardPointsRedeemed,
                                                   RewardDiscountAmount = row.RewardDiscountAmount,
                                                   Summary = new InvoiceSummary
                                                   {
                                                       TotalAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.Amount),
                                                       TotalDiscount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.DiscountInRs),
                                                       TotalTaxableAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.TaxableAmount),
                                                       TotalGSTAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.GstAmount),
                                                       TotalInvoiceAmount = Math.Max(0.0, row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.TotalAmount) - row.RewardDiscountAmount)
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
                                               col.PurchaseType == (string.IsNullOrEmpty(reportParam.TransactionType) ? col.PurchaseType : reportParam.TransactionType) &&
                                               col.PaymentMode == (string.IsNullOrEmpty(reportParam.PaymentMode) ? col.PaymentMode : reportParam.PaymentMode) &&
                                               col.UpiType == (string.IsNullOrEmpty(reportParam.UpiType) ? col.UpiType : reportParam.UpiType) &&
                                               col.PartyId == (string.IsNullOrEmpty(reportParam.Id) ? col.PartyId : int.Parse(reportParam.Id!))).OrderBy(ord => ord.InvoiceDate).Select(row => new PurchaseVM
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

        public async Task<List<SalesItemVM>> GetDeletedSalesItems(DateTime fromDate, DateTime toDate)
        {
            return await dbContext.SalesItemsDeleteds.Where(col => col.DeletedDate.Date >= fromDate.Date && col.DeletedDate.Date <= toDate.Date).OrderBy(ord => ord.DeletedDate).Select(row => new SalesItemVM()
            {
                ItemModel = row.Item != null ? new ItemVM()
                {
                    ItemCode = row.Item.ItemCode,
                    ItemName = row.Item.ItemName,
                    Measure = row.Item.Measure
                } : null,
                ServiceTypeModel = row.ServiceType != null ? new ServiceTypeVM()
                {
                    ServiceTypeName = row.ServiceType.ServiceTypeName
                } : null,
                Quantity = row.Quantity,
                Rate = row.Rate,
                Amount = row.Amount,
                DiscountInRs = row.DiscountInRs,
                TaxableAmount = row.TaxableAmount,
                GstPer = row.GstPer,
                IgstPer = row.IgstPer,
                CgstPer = row.CgstPer,
                SgstPer = row.SgstPer,
                GstAmount = row.GstAmount,
                IgstRs = row.IgstRs,
                CgstRs = row.CgstRs,
                SgstRs = row.SgstRs,
                TotalAmount = row.TotalAmount,
                CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy HH:mm"),
                DeletedDate = row.DeletedDate.ToString("dd-MMM-yyyy HH:mm"),
                DeletedBy = row.DeletedByNavigation.UserId,
                DeletedRemarks = row.DeletedRemarks
            }).ToListAsync();
        }

        public async Task<List<PurchaseItemVM>> GetDeletedPurchaseItems(DateTime fromDate, DateTime toDate)
        {
            return await dbContext.PurchaseItemsDeleteds.Where(col => col.DeletedDate.Date >= fromDate.Date && col.DeletedDate.Date <= toDate.Date).OrderBy(ord => ord.DeletedDate).Select(row => new PurchaseItemVM()
            {
                ItemModel = new ItemVM()
                {
                    ItemCode = row.Item.ItemCode,
                    ItemName = row.Item.ItemName,
                    Measure = row.Item.Measure
                },
                Quantity = row.Quantity,
                Rate = row.Rate,
                Amount = row.Amount,
                DiscountInRs = row.DiscountInRs,
                TaxableAmount = row.TaxableAmount,
                GstPer = row.GstPer,
                IgstPer = row.IgstPer,
                CgstPer = row.CgstPer,
                SgstPer = row.SgstPer,
                GstAmount = row.GstAmount,
                IgstRs = row.IgstRs,
                CgstRs = row.CgstRs,
                SgstRs = row.SgstRs,
                TotalAmount = row.TotalAmount,
                CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy HH:mm"),
                DeletedDate = row.DeletedDate.ToString("dd-MMM-yyyy HH:mm"),
                DeletedBy = row.DeletedByNavigation.UserId,
                DeletedRemarks = row.DeletedRemarks
            }).ToListAsync();
        }

        public async Task<List<TransactionVM>> GetDaybook(DateTime fromDate, DateTime toDate)
        {
            var trans = await dbContext.Transactions.Where(col => col.TransactionDate.Date >= fromDate.Date && col.TransactionDate.Date <= toDate.Date).Select(row => new TransactionVM()
            {
                TransactionId = row.TransactionId,
                TransactionDate = row.TransactionDate.ToString("dd-MMM-yyyy"),
                TransactionRefNo = row.Sales != null ? row.Sales.InvoiceNo : (row.Purchase != null ? row.Purchase.InvoiceNo : row.TransactionId.ToString()),
                TransactionType = row.TransactionType,
                ReceiptAmount = row.ReceiptAmount,
                PaymentAmount = row.PaymentAmount,
                PartyModel = new PartyVM()
                {
                    PartyId = row.Party.PartyId,
                    PartyName = row.Party.PartyName
                }
            }).ToListAsync();

            var salesTrans = await dbContext.Sales.Where(col => col.Party == null &&
                                                                col.SalesType.ToLower() != "credit" &&
                                                                col.InvoiceDate.Date >= fromDate.Date && col.InvoiceDate.Date <= toDate.Date).Select(row => new TransactionVM()
                                                                {
                                                                    TransactionId = row.SalesId,
                                                                    TransactionDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                                                                    TransactionRefNo = row.InvoiceNo,
                                                                    TransactionType = TransType.SALES_CASH.ToString(),
                                                                    ReceiptAmount = Math.Max(0.0, row.SalesItems.Where(itm => itm.SalesId == row.SalesId).Sum(sm => sm.TotalAmount) - row.RewardDiscountAmount),
                                                                    PaymentAmount = 0.0
                                                                }).ToListAsync();

            var salesDeletedTrans = await dbContext.SalesItemsDeleteds.Where(col => col.DeletedDate.Date >= fromDate.Date && col.DeletedDate.Date <= toDate.Date).Select(row => new TransactionVM()
            {
                TransactionId = row.SalesDeletedItemId,
                TransactionDate = row.DeletedDate.ToString("dd-MMM-yyyy"),
                TransactionRefNo = "",
                TransactionType = TransType.SALES_DELETED.ToString(),
                ReceiptAmount = row.TotalAmount,
                PaymentAmount = row.TotalAmount
            }).ToListAsync();

            var purchaseDeletedTrans = await dbContext.PurchaseItemsDeleteds.Where(col => col.DeletedDate.Date >= fromDate.Date && col.DeletedDate.Date <= toDate.Date).Select(row => new TransactionVM()
            {
                TransactionId = row.PurchaseDeletedItemId,
                TransactionDate = row.DeletedDate.ToString("dd-MMM-yyyy"),
                TransactionRefNo = "",
                TransactionType = TransType.PURCHASE_DELETED.ToString(),
                ReceiptAmount = row.TotalAmount,
                PaymentAmount = row.TotalAmount
            }).ToListAsync();

            var allTransactions = trans.Concat(salesTrans).Concat(salesDeletedTrans).Concat(purchaseDeletedTrans).ToList();
            return allTransactions;
        }

        public async Task<IEnumerable<PurchaseOrderVM>> GetPurchaseOrderList()
        {
            return await dbContext.PurchaseOrders.Include(itm => itm.PurchaseOrderItems).Select(row => new PurchaseOrderVM()
            {
                PurchaseOrderId = row.PurchaseOrderId,
                OrderDate = row.OrderDate.ToString("dd-MMM-yyyy"),
                OrderAmount = row.PurchaseOrderItems.Where(c => c.PurchaseOrderId == row.PurchaseOrderId).Sum(sm => sm.Amount),
                PurchaseInvoiceNo = row.Purchases.Count > 0 ? row.Purchases.FirstOrDefault()!.InvoiceNo : "",
                PurchaseInvoiceDate = row.Purchases.Count > 0 ? row.Purchases.FirstOrDefault()!.InvoiceDate.ToString("dd-MMM-yyyy") : "",
                PartyModel = new PartyVM()
                {
                    PartyId = row.PartyId,
                    PartyName = row.Party.PartyName,
                    PartyMobile = row.Party.PartyMobile
                }
            }).ToListAsync();
        }

        public async Task<IEnumerable<InventoryValuation>> GetInventoryValuation(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return await dbContext.Items.OrderBy(ord => ord.ItemName).Select(row => new InventoryValuation()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.ItemCode,
                    ItemName = row.ItemName,
                    Measure = row.Measure,
                    PurchasePrice = row.PurchasePrice,
                    SalesPrice = row.SalesPrice,
                    ClosingStock = row.OpeningStock + row.ClosingStock,
                    PurchaseValue = row.PurchasePrice * (row.OpeningStock + row.ClosingStock),
                    SalesValue = row.SalesPrice * (row.OpeningStock + row.ClosingStock)
                }).ToListAsync();
            }
            else
            {
                string filterLower = filter.Trim().ToLower();
                return await dbContext.Items.Where(col => col.ItemCode.ToLower().Contains(filterLower) ||
                                                            col.ItemName.ToLower().Contains(filterLower)).OrderBy(ord => ord.ItemName).Select(row => new InventoryValuation()
                                                            {
                                                                ItemId = row.ItemId,
                                                                ItemCode = row.ItemCode,
                                                                ItemName = row.ItemName,
                                                                Measure = row.Measure,
                                                                PurchasePrice = row.PurchasePrice,
                                                                SalesPrice = row.SalesPrice,
                                                                ClosingStock = row.OpeningStock + row.ClosingStock,
                                                                PurchaseValue = row.PurchasePrice * (row.OpeningStock + row.ClosingStock),
                                                                SalesValue = row.SalesPrice * (row.OpeningStock + row.ClosingStock)
                                                            }).ToListAsync();
            }
        }

        public async Task<List<ItemVM>> GetAgedInventory(int inventoryAge)
        {
            var matchedItems = await dbContext.SalesItems.Where(col => col.Item != null && col.CreatedDate.Date <= DateTime.Now.Date.AddDays(inventoryAge * -1) && (col.Item.OpeningStock + col.Item.ClosingStock) > 0).OrderBy(ord => ord.CreatedDate).Select(row => new ItemVM()
            {
                ItemId = row.Item!.ItemId,
                ItemCode = row.Item.ItemCode,
                ItemName = row.Item.ItemName,
                Mrp = row.Item.Mrp,
                Measure = row.Item.Measure,
                PurchasePrice = row.Item.PurchasePrice,
                SalesPrice = row.Item.SalesPrice,
                ClosingStock = row.Item.ClosingStock + row.Item.OpeningStock,
                HSncode = row.Item.Hsncode,
                IsActive = row.Item.IsActive == 1,
                Age = (int)DateTime.Now.Date.Subtract(row.CreatedDate.Date).TotalDays,
                UpdatedDate = row.CreatedDate.ToString("dd-MMM-yyyy")
            }).ToListAsync();

            var unmatchedItems = await dbContext.Items.Where(col => col.SalesItems.Count == 0 && col.CreatedDate.Date <= DateTime.Now.Date.AddDays(inventoryAge * -1) && (col.OpeningStock + col.ClosingStock) > 0).OrderBy(ord => ord.CreatedDate).Select(row => new ItemVM()
            {
                ItemId = row.ItemId,
                ItemCode = row.ItemCode,
                ItemName = row.ItemName,
                Mrp = row.Mrp,
                Measure = row.Measure,
                PurchasePrice = row.PurchasePrice,
                SalesPrice = row.SalesPrice,
                ClosingStock = row.ClosingStock + row.OpeningStock,
                HSncode = row.Hsncode,
                IsActive = row.IsActive == 1,
                Age = (int)DateTime.Now.Date.Subtract(row.CreatedDate.Date).TotalDays,
                UpdatedDate = row.CreatedDate.ToString("dd-MMM-yyyy")
            }).ToListAsync();

            var allItems = matchedItems;
            allItems.AddRange(unmatchedItems);
            return allItems;
        }

        public async Task<List<ChartData>> GetDayWiseSalesSummary(DateTime fromDate, DateTime toDate)
        {
            return await (from sal in dbContext.Sales
                          join sal_itm in dbContext.SalesItems on sal.SalesId equals sal_itm.SalesId
                          where sal.InvoiceDate.Date >= fromDate && sal.InvoiceDate.Date <= toDate
                          group new { sal, sal_itm } by new { InvoiceDate = sal.InvoiceDate.Date } into grp
                          orderby grp.Key.InvoiceDate
                          select new ChartData()
                          {
                              XLabel = grp.Key.InvoiceDate.ToString("dd-MMM-yyyy"),
                              YAxis = (float)grp.Sum(x => x.sal_itm.TotalAmount)
                          }).ToListAsync();
        }

        public async Task<List<ChartData>> GetMonthWiseSalesSummary(DateTime fromDate, DateTime toDate)
        {
            return await (from sal in dbContext.Sales
                          join sal_itm in dbContext.SalesItems on sal.SalesId equals sal_itm.SalesId
                          where sal.InvoiceDate.Date >= fromDate && sal.InvoiceDate.Date <= toDate
                          group new { sal, sal_itm } by new { sal.InvoiceDate.Date.Month, sal.InvoiceDate.Date.Year } into grp
                          orderby grp.Key.Year, grp.Key.Month
                          select new ChartData()
                          {
                              XLabel = $"{grp.Key.Month}-{grp.Key.Year}",
                              YAxis = (float)grp.Sum(x => x.sal_itm.TotalAmount)
                          }).ToListAsync();
        }

        public async Task<List<ChartData>> GetItemWiseSalesSummary(DateTime fromDate, DateTime toDate)
        {
            return await (from sal in dbContext.Sales
                          join sal_itm in dbContext.SalesItems on sal.SalesId equals sal_itm.SalesId
                          join itm in dbContext.Items on sal_itm.ItemId equals itm.ItemId
                          where sal.InvoiceDate.Date >= fromDate && sal.InvoiceDate.Date <= toDate
                          group new { sal, sal_itm, itm } by new { sal_itm.ItemId, itm.ItemName, itm.SalesPrice } into grp
                          select new ChartData()
                          {
                              XLabel = $"{grp.Key.ItemName}({grp.Key.SalesPrice})",
                              YAxis = grp.Sum(x => x.sal_itm.Quantity)
                          }).OrderByDescending(ord => ord.YAxis).ToListAsync();
        }

        public async Task<List<ChartData>> GetSalesPaymentModeSummary(DateTime fromDate, DateTime toDate)
        {
            return await (from sal in dbContext.Sales
                          join sal_itm in dbContext.SalesItems on sal.SalesId equals sal_itm.SalesId
                          where sal.InvoiceDate.Date >= fromDate && sal.InvoiceDate.Date <= toDate
                          group new { sal, sal_itm } by new { sal.SalesType, sal.PaymentMode, sal.UpiType } into grp
                          orderby grp.Key.UpiType
                          select new ChartData()
                          {
                              XLabel = grp.Key.PaymentMode.Equals(PaymentMode.UPI.ToString()) ? grp.Key.UpiType : (string.IsNullOrEmpty(grp.Key.PaymentMode) ? grp.Key.SalesType : grp.Key.PaymentMode),
                              YAxis = (float)grp.Sum(x => x.sal_itm.TotalAmount)
                          }).ToListAsync();
        }

        public async Task<List<ProductMovementModel>> GetProductMovementAnalysis(ReportParam reportParam)
        {
            DateTime fromDate = DateTime.TryParse(reportParam.FromDate, out var fd) ? fd.Date : DateTime.Now.Date.AddMonths(-1);
            DateTime toDate = DateTime.TryParse(reportParam.ToDate, out var td) ? td.Date : DateTime.Now.Date;

            var items = await dbContext.Items.AsNoTracking()
                .Include(i => i.Category)
                .Where(i => i.IsActive == 1)
                .ToListAsync();

            var salesItems = await (from si in dbContext.SalesItems.AsNoTracking()
                                    join s in dbContext.Sales.AsNoTracking() on si.SalesId equals s.SalesId
                                    where si.ItemId != null && s.InvoiceDate.Date >= fromDate && s.InvoiceDate.Date <= toDate
                                    select new
                                    {
                                        ItemId = si.ItemId!.Value,
                                        s.SalesId,
                                        si.Quantity,
                                        si.TotalAmount
                                    }).ToListAsync();

            var salesByItem = salesItems
                .GroupBy(x => x.ItemId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        Frequency = g.Select(x => x.SalesId).Distinct().Count(),
                        TotalQty = g.Sum(x => x.Quantity),
                        TotalRev = g.Sum(x => x.TotalAmount)
                    });

            var result = items.Select(i =>
            {
                salesByItem.TryGetValue(i.ItemId, out var stat);
                return new ProductMovementModel
                {
                    ItemId = i.ItemId,
                    ItemCode = i.ItemCode,
                    ItemName = i.ItemName,
                    CategoryName = i.Category?.CategoryName ?? string.Empty,
                    Measure = i.Measure ?? string.Empty,
                    ClosingStock = i.OpeningStock + i.ClosingStock,
                    SalesFrequency = stat?.Frequency ?? 0,
                    TotalQuantitySold = stat?.TotalQty ?? 0.0,
                    TotalRevenue = stat?.TotalRev ?? 0.0
                };
            })
            .OrderByDescending(x => x.TotalQuantitySold)
            .ThenByDescending(x => x.SalesFrequency)
            .ToList();

            return result;
        }
    }
}
