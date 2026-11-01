using Paybill.Models;
using Paybill.ViewModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;

namespace Paybill.Helpers
{
    public static class PaybillCrypto
    {
        public static readonly string[] API_AES_KEY_AND_IV = ["aptlADsyGEtotitNrGNGBeautyRaESpb", "rEPbyteH4377rfvi"];
        public static readonly string[] PAYBILL_API_AES_KEY_AND_IV = ["PgUpwEBhCapsVkScrLKEySGNSkEYPgDn", "NumPrtScnLockvhI"];

        public static string EncryptWithIV(string plainText, string[] keys)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;
            byte[] bytesPlainText = Encoding.UTF8.GetBytes(plainText);
            using Aes cipher = Aes.Create();
            cipher.Key = Encoding.UTF8.GetBytes(keys[0]);
            cipher.IV = Encoding.UTF8.GetBytes(keys[1]);
            using ICryptoTransform cryptoTransform = cipher.CreateEncryptor();
            byte[] bytesCipherText = cryptoTransform.TransformFinalBlock(bytesPlainText, 0, bytesPlainText.Length);
            return Convert.ToBase64String(bytesCipherText);
        }

        public static string DecryptWithIV(string cipherText, string[] keys)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;
            byte[] bytesCipherText = Convert.FromBase64String(cipherText);
            using Aes cipher = Aes.Create();
            cipher.Key = Encoding.UTF8.GetBytes(keys[0]);
            cipher.IV = Encoding.UTF8.GetBytes(keys[1]);
            using ICryptoTransform cryptoTransform = cipher.CreateDecryptor();
            byte[] bytesPlainText = cryptoTransform.TransformFinalBlock(bytesCipherText, 0, bytesCipherText.Length);
            return Encoding.UTF8.GetString(bytesPlainText);
        }

        /// <summary>
        /// Encrypts a plain password with PAYBILL_API_AES_KEY_AND_IV (matching Android StaticMethods.encryptData).
        /// </summary>
        public static string EncryptPassword(string plainPassword)
            => EncryptWithIV(plainPassword, PAYBILL_API_AES_KEY_AND_IV);

        /// <summary>
        /// Encodes a route parameter (ID, date, password) matching Android StaticMethods.encryptBase64 and PaybillAPI DataProtection.UrlDecode.
        /// </summary>
        public static string EncodeRouteParam(string plainText)
        {
            string encrypted = EncryptWithIV(plainText, PAYBILL_API_AES_KEY_AND_IV);
            string base64Wrapped = Convert.ToBase64String(Encoding.ASCII.GetBytes(encrypted));
            return HttpUtility.UrlEncode(base64Wrapped, Encoding.UTF8);
        }

        public static string EncodeRouteParam(int id) => EncodeRouteParam(id.ToString());
    }

    public static class GstHelper
    {
        public static readonly Dictionary<string, string> StateCodes = new()
        {
            ["01"] = "Jammu & Kashmir",
            ["02"] = "Himachal Pradesh",
            ["03"] = "Punjab",
            ["04"] = "Chandigarh",
            ["05"] = "Uttarakhand",
            ["06"] = "Haryana",
            ["07"] = "Delhi",
            ["08"] = "Rajasthan",
            ["09"] = "Uttar Pradesh",
            ["10"] = "Bihar",
            ["11"] = "Sikkim",
            ["12"] = "Arunachal Pradesh",
            ["13"] = "Nagaland",
            ["14"] = "Manipur",
            ["15"] = "Mizoram",
            ["16"] = "Tripura",
            ["17"] = "Meghalaya",
            ["18"] = "Assam",
            ["19"] = "West Bengal",
            ["20"] = "Jharkhand",
            ["21"] = "Odisha",
            ["22"] = "Chhattisgarh",
            ["23"] = "Madhya Pradesh",
            ["24"] = "Gujarat",
            ["25"] = "Daman & Diu",
            ["26"] = "Dadra & Nagar Haveli",
            ["27"] = "Maharashtra",
            ["28"] = "Andhra Pradesh (Old)",
            ["29"] = "Karnataka",
            ["30"] = "Goa",
            ["31"] = "Lakshadweep",
            ["32"] = "Kerala",
            ["33"] = "Tamil Nadu",
            ["34"] = "Puducherry",
            ["35"] = "Andaman & Nicobar Islands",
            ["36"] = "Telangana",
            ["37"] = "Andhra Pradesh",
            ["38"] = "Ladakh"
        };

        public static bool IsValidGstinFormat(string? gstin)
        {
            if (string.IsNullOrWhiteSpace(gstin))
                return true;
            string clean = gstin.Trim().ToUpperInvariant();
            if (clean.Length < 2)
                return false;
            string stateCode = clean[..2];
            return StateCodes.ContainsKey(stateCode);
        }

        public static string GetStateNameFromGstin(string? gstin)
        {
            if (string.IsNullOrWhiteSpace(gstin) || gstin.Trim().Length < 2)
                return string.Empty;
            string code = gstin.Trim()[..2];
            return StateCodes.TryGetValue(code, out var name) ? $"{code}-{name}" : code;
        }

        public static bool IsInterState(string? companyGstin, string? partyGstin)
        {
            if (string.IsNullOrWhiteSpace(companyGstin) || companyGstin.Trim().Length < 2)
                return false;
            if (string.IsNullOrWhiteSpace(partyGstin) || partyGstin.Trim().Length < 2)
                return false;
            string compState = companyGstin.Trim()[..2];
            string partyState = partyGstin.Trim()[..2];
            return !string.Equals(compState, partyState, StringComparison.OrdinalIgnoreCase);
        }

        public static string NumberToWords(double amount) => NumberToIndianWords(amount);

        public static string NumberToIndianWords(double amount)
        {
            long rupees = (long)Math.Floor(Math.Abs(amount));
            int paise = (int)Math.Round((Math.Abs(amount) - rupees) * 100);

            if (rupees == 0 && paise == 0)
                return "Zero Rupees Only";

            string words = ConvertWholeNumberToWords(rupees).Trim();
            if (paise > 0)
            {
                words += $" Rupees and {ConvertWholeNumberToWords(paise).Trim()} Paise Only";
            }
            else
            {
                words += " Rupees Only";
            }
            return words;
        }

        private static string ConvertWholeNumberToWords(long number)
        {
            if (number == 0) return "Zero";
            string[] unitsMap = ["", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"];
            string[] tensMap = ["", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];

            string words = "";
            if ((number / 10000000) > 0)
            {
                words += ConvertWholeNumberToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }
            if ((number / 100000) > 0)
            {
                words += ConvertWholeNumberToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertWholeNumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertWholeNumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "") words += "and ";
                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }
            return words.Trim();
        }

        /// <summary>
        /// Generates Indian GST Portal GSTR-1 JSON format matching Android GSTJsonManager.kt
        /// </summary>
        public static string GenerateGstr1Json(
            string companyGstin,
            string fpMonthYear,
            List<GSTReturnDetailed> gstDetailedList,
            List<GSTHSNSummary> hsnSummaryList)
        {
            string cleanGstin = string.IsNullOrWhiteSpace(companyGstin) ? "37AAAAA0000A1Z5" : companyGstin.Trim().ToUpperInvariant();
            string pos = cleanGstin.Length >= 2 ? cleanGstin[..2] : "37";

            var b2bGroups = gstDetailedList
                .Where(x => !x.IsHeader && !string.IsNullOrWhiteSpace(x.PartyGstin))
                .GroupBy(x => x.PartyGstin!.Trim().ToUpperInvariant())
                .Select(g => new
                {
                    ctin = g.Key,
                    inv = g.Select((inv, idx) =>
                    {
                        double totalTaxable = inv.Data.Sum(d => d.TaxableAmount);
                        double totalTax = inv.Data.Sum(d => d.GstAmount);
                        string invPos = g.Key.Length >= 2 ? g.Key[..2] : pos;
                        string splyTy = invPos == pos ? "INTRA" : "INTER";
                        return new
                        {
                            inum = inv.InvoiceNo ?? $"INV-{idx + 1}",
                            idt = FormatGstDate(inv.InvoiceDate),
                            val = Math.Round(totalTaxable + totalTax, 2),
                            pos = invPos,
                            rchrg = "N",
                            inv_typ = "R",
                            sply_ty = splyTy,
                            itms = inv.Data.Select((d, i) => new
                            {
                                num = i + 1,
                                itm_det = new
                                {
                                    txval = Math.Round(d.TaxableAmount, 2),
                                    rt = Math.Round(d.GstPer, 2),
                                    iamt = Math.Round(d.IgstAmount, 2),
                                    camt = Math.Round(d.CgstAmount, 2),
                                    samt = Math.Round(d.SgstAmount, 2),
                                    csamt = 0.0
                                }
                            }).ToList()
                        };
                    }).ToList()
                }).ToList();

            var b2csItems = gstDetailedList
                .Where(x => !x.IsHeader && string.IsNullOrWhiteSpace(x.PartyGstin))
                .SelectMany(x => x.Data)
                .GroupBy(d => d.GstPer)
                .Select(g => new
                {
                    sply_ty = "INTRA",
                    rt = Math.Round(g.Key, 2),
                    typ = "OE",
                    pos = pos,
                    txval = Math.Round(g.Sum(d => d.TaxableAmount), 2),
                    iamt = Math.Round(g.Sum(d => d.IgstAmount), 2),
                    camt = Math.Round(g.Sum(d => d.CgstAmount), 2),
                    samt = Math.Round(g.Sum(d => d.SgstAmount), 2),
                    csamt = 0.0
                }).ToList();

            int hsnIndex = 1;
            var hsnData = hsnSummaryList
                .SelectMany(h => h.Data.Select(d => new
                {
                    num = hsnIndex++,
                    hsn_sc = string.IsNullOrWhiteSpace(h.HsnCode) ? "0000" : h.HsnCode,
                    desc = "Goods/Services",
                    uqc = "NOS",
                    qty = Math.Round(d.Quantity, 2),
                    val = Math.Round(d.TaxableAmount + d.GstAmount, 2),
                    txval = Math.Round(d.TaxableAmount, 2),
                    iamt = Math.Round(d.IgstAmount, 2),
                    camt = Math.Round(d.CgstAmount, 2),
                    samt = Math.Round(d.SgstAmount, 2),
                    csamt = 0.0,
                    rt = Math.Round(d.GstPer, 2)
                })).ToList();

            var payload = new
            {
                gstin = cleanGstin,
                fp = fpMonthYear,
                version = "GST3.1.6",
                hash = "hash",
                b2b = b2bGroups,
                b2cs = b2csItems,
                hsn = new { data = hsnData }
            };

            return JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
        }

        private static string FormatGstDate(string dateStr)
        {
            if (DateTime.TryParse(dateStr, out var dt))
                return dt.ToString("dd-MM-yyyy");
            return dateStr;
        }
    }

    public static class RewardsCalculator
    {
        public static bool IsRewardsOperational(SettingVM? settings)
        {
            if (settings == null || !settings.IsRewardsEnabled)
                return false;

            DateTime today = DateTime.Now.Date;
            if (!string.IsNullOrWhiteSpace(settings.RewardStartDate) && DateTime.TryParse(settings.RewardStartDate, out var startDate))
            {
                if (today < startDate.Date) return false;
            }
            if (!string.IsNullOrWhiteSpace(settings.RewardEndDate) && DateTime.TryParse(settings.RewardEndDate, out var endDate))
            {
                if (today > endDate.Date) return false;
            }
            return true;
        }

        public static double GetEligibleInvoiceAmount(SettingVM settings, double invoiceTotalWithTax, double grossAmountBeforeTax, double totalDiscountInRs)
        {
            if (string.Equals(settings.RewardEligibleAmountType, "NET_TAXABLE", StringComparison.OrdinalIgnoreCase))
                return Math.Max(0.0, grossAmountBeforeTax - totalDiscountInRs);
            return Math.Max(0.0, invoiceTotalWithTax);
        }

        public static double CalculatePointsEarned(SettingVM settings, double eligibleAmount)
        {
            if (!IsRewardsOperational(settings)) return 0.0;
            if (eligibleAmount < settings.RewardMinPurchaseForEarning || eligibleAmount <= 0.0) return 0.0;

            double earned = 0.0;
            if (string.Equals(settings.RewardEarningMethod, "PERCENTAGE", StringComparison.OrdinalIgnoreCase))
            {
                double pct = settings.RewardEarningPercentage > 0 ? settings.RewardEarningPercentage : 0.0;
                double rewardRs = eligibleAmount * (pct / 100.0);
                double pointVal = settings.RewardPointValue > 0 ? settings.RewardPointValue : 1.0;
                earned = rewardRs / pointVal;
            }
            else
            {
                double unitAmount = settings.RewardEarningPurchaseAmount > 0 ? settings.RewardEarningPurchaseAmount : 100.0;
                double unitPoints = settings.RewardEarningPoints > 0 ? settings.RewardEarningPoints : 1.0;
                earned = Math.Floor(eligibleAmount / unitAmount) * unitPoints;
            }
            return Math.Round(earned, 2);
        }

        public static double CalculateMaxRedeemablePoints(SettingVM settings, double customerAvailablePoints, double eligibleAmount, double invoiceTotal)
        {
            if (!IsRewardsOperational(settings)) return 0.0;
            if (customerAvailablePoints <= 0.0 || invoiceTotal <= 0.0) return 0.0;
            if (customerAvailablePoints < settings.RewardMinPointsForRedemption) return 0.0;
            if (invoiceTotal < settings.RewardMinInvoiceForRedemption) return 0.0;

            double pointVal = settings.RewardPointValue > 0 ? settings.RewardPointValue : 1.0;
            double maxPct = settings.RewardMaxRedemptionPercentage > 0 ? settings.RewardMaxRedemptionPercentage : 100.0;
            double maxDiscountByPercentage = eligibleAmount * (maxPct / 100.0);
            double maxAllowedDiscount = Math.Min(maxDiscountByPercentage, invoiceTotal);
            double maxPointsByDiscount = Math.Floor(maxAllowedDiscount / pointVal);
            double maxPoints = Math.Min(customerAvailablePoints, maxPointsByDiscount);
            return Math.Max(0.0, Math.Round(maxPoints, 2));
        }

        public static double CalculateMonetaryValue(SettingVM settings, double points)
        {
            double pointVal = settings.RewardPointValue > 0 ? settings.RewardPointValue : 1.0;
            return Math.Round(points * pointVal, 2);
        }
    }
}


