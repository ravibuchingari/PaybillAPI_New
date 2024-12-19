using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PayBillApp.WinApp.Models
{
    internal class PrintReport : IDisposable
    {
        private int currentPageIndex;

        private IList<Stream> listStream;

        private string deviceInfo;

        public Stream CreateStream(string name, string fileNameExtension, Encoding encoding,
                     string mimeType, bool willSeek)
        {
            //Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            Stream stream = new MemoryStream();
            listStream.Add(stream);
            return stream;
        }

        private void Export(LocalReport localReport)
        {
            listStream = new List<Stream>();

            if (string.IsNullOrEmpty(deviceInfo))
            {
                ReportPageSettings rptSettings = localReport.GetDefaultPageSettings();

                deviceInfo = string.Format("<DeviceInfo>" +
                                             "  <OutputFormat>EMF</OutputFormat>" +
                                             "  <PageWidth>{0}in</PageWidth>" +
                                             "  <PageHeight>{1}in</PageHeight>" +
                                             "  <MarginTop>{2}in</MarginTop>" +
                                             "  <MarginLeft>{3}in</MarginLeft>" +
                                             "  <MarginRight>{4}in</MarginRight>" +
                                             "  <MarginBottom>{5}in</MarginBottom>" +
                                             "</DeviceInfo>", (rptSettings.PaperSize.Width / 100.00).ToString(),
                                                                (rptSettings.PaperSize.Height / 100.00).ToString(),
                                                                (rptSettings.Margins.Top / 100.00).ToString(),
                                                                (rptSettings.Margins.Left / 100.00).ToString(),
                                                                (rptSettings.Margins.Right / 100.00).ToString(),
                                                                (rptSettings.Margins.Bottom / 100.00).ToString());
            }
            localReport.Render("Image", deviceInfo, CreateStream, out Warning[] warnings);
            foreach (Stream stream in listStream)
                stream.Position = 0;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new(listStream[currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            currentPageIndex++;
            ev.HasMorePages = (currentPageIndex < listStream.Count);

        }

        private void Print(short noofcopies)
        {
            if (listStream == null || listStream.Count == 0)
                return;

            string defaultPrinterName;

            PrintDialog printDialog = new();
            if (printDialog.PrinterSettings.PrinterName.Trim().Length > 0)
                defaultPrinterName = printDialog.PrinterSettings.PrinterName;
            else
                defaultPrinterName = "Microsoft Office Document Image Writer";

            PrintDocument printDocument = new();
            printDocument.PrinterSettings.PrinterName = defaultPrinterName;
            printDocument.PrinterSettings.Copies = noofcopies;
            if (!printDocument.PrinterSettings.IsValid)
            {
                MessageBox.Show(String.Format("Can't find printer \"{0}\".", defaultPrinterName), "Print Error");
                return;
            }
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            printDocument.Print();

        }

        public void RunSalesInvoice(string reportPath, ReportDataSource reportSource, string totalQty,
                                    string itemCount, string cash, string change, string transport, string packing,
                                    string others, string invoiceNo, string invoiceDate, string saving, string userId,
                                    bool sgstRequired, bool igstRequired)
        {
            ReportParameter rptTotalQty = new("totalqty", totalQty);
            ReportParameter rptItemCount = new("itemcount", itemCount);
            ReportParameter rptCash = new("cash", cash);
            ReportParameter rptChange = new("change", change);
            ReportParameter rptTransport = new("transport", transport);
            ReportParameter rptPacking = new("packing", packing);
            ReportParameter rptOthers = new("others", others);
            ReportParameter rptAddress1 = new("address1", ConstantVariables.CLIENT_NAME);
            ReportParameter rptAddress2 = new("address2", ConstantVariables.REPORT_ADDRESS);
            ReportParameter rptGSTIN = new("gstin", ConstantVariables.CLIENT_GSTIN.Length > 0 ? "GSTIN: " + ConstantVariables.CLIENT_GSTIN : "");
            ReportParameter rptInvoiceNo = new("invoiceno", invoiceNo);
            ReportParameter rptInvoicedate = new("invoicedate", invoiceDate);
            ReportParameter rptSaving = new("saving", saving);
            ReportParameter rptUserId = new("userid", userId);
            ReportParameter rptLogourl;
            if (ConstantVariables.LOGO_URL.Length > 0)
                rptLogourl = new ReportParameter("logourl", $"file:///{ConstantVariables.LOGO_URL.Replace("\\", "//")}");
            else
                rptLogourl = new("logourl", String.Empty);
            ReportParameter rptInvoiceTitle = new("invoice_title", ConstantVariables.INVOICE_TITLE);
            ReportParameter rptSGSTRequired = new("is_sgst_required", sgstRequired.ToString());
            ReportParameter rptIGSTRequired = new("is_igst_required", igstRequired.ToString());
            ReportParameter rptTerms = new("terms", ConstantVariables.INVOICE_TERMS);
            LocalReport localReport = new()
            {
                EnableExternalImages = true,
                ReportPath = reportPath
            };
            localReport.SetParameters(new ReportParameter[] { rptTotalQty, rptItemCount, rptCash, rptChange, rptTransport, rptPacking, rptOthers, rptAddress1, rptAddress2, rptGSTIN, rptInvoiceNo, rptInvoicedate, rptSaving, rptUserId, rptLogourl, rptInvoiceTitle, rptSGSTRequired, rptIGSTRequired, rptTerms });
            localReport.DataSources.Add(reportSource);
            Export(localReport);
            currentPageIndex = 0;
            Print(1);
        }

        public void Dispose()
        {
            if (listStream != null)
            {
                foreach (Stream stream in listStream)
                    stream.Close();
                listStream = null;
            }
        }
    }
}
