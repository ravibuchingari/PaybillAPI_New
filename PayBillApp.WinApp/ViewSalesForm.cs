using Newtonsoft.Json;
using PayBillApp.WinApp.Models;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class ViewSalesForm : Form
    {
        private readonly int borderRadius = 5;
        private readonly int borderSize = 0;
        private readonly Color borderColor = Color.Silver;
        private DataTable dataTableSales, dataTableSummary;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle |= CS_DROPSHADOW;
                return createParams;
            }
        }

        public int SalesID { get; set; }

        public ViewSalesForm()
        {
            InitializeComponent();
            total_incl_gst.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            quantity.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Trans_Amount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtpFromDate.MaxDate = ConstantVariables.SERVER_DATE;
            dtpToDate.MaxDate = ConstantVariables.SERVER_DATE;
            dtpFromDate.Value = ConstantVariables.SERVER_DATE;
            dtpToDate.Value = ConstantVariables.SERVER_DATE;
        }

        private void ViewSalesForms_Load(object sender, EventArgs e)
        {
            dataTableSummary = new();
            dataTableSummary.Columns.Add("Trans_Type", typeof(string));
            dataTableSummary.Columns.Add("Trans_Amount", typeof(double));
            btnView.PerformClick();
        }

        private void ViewSalesForms_Paint(object sender, PaintEventArgs e)
        {
            ReuseMethods.SetFormBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                MessageBox.Show("'From Date' should not be greater than the 'To Date'!", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFromDate.Focus();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            btnSummary.Visible = false;
            try
            {
                using HttpClient httpClient = new(new HttpClientHandler()
                {
                    SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
                });
                httpClient.BaseAddress = new Uri(ConstantVariables.WEB_API_URL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("basic_auth", ConstantVariables.WIN_QRCODE_BASIC_AUTH);
                httpClient.DefaultRequestHeaders.Add("Authorization", ConstantVariables.JWT_TOKEN);
                httpClient.DefaultRequestHeaders.Add("fromDate", dtpFromDate.Value.Date.ToString("dd-MMM-yyyy"));
                httpClient.DefaultRequestHeaders.Add("toDate", dtpToDate.Value.Date.ToString("dd-MMM-yyyy"));
                WinParamModel paramModel = new()
                {
                    ClientID = ConstantVariables.CLIENT_ID,
                    UserID = ConstantVariables.USER_ID,
                    MachineID = ConstantVariables.MACHINE_UNIQUE_ID,
                    SecurityKey = ConstantVariables.SECURITY_KEY,
                    WinQRCodeID = ConstantVariables.WIN_QRCODE_ID
                };
                StringContent content = new(JsonConvert.SerializeObject(paramModel));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = httpClient.PostAsync("GetSales", content).Result;
                string response = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    StringReader stringReader = new(response);
                    DataSet dataSet = new();
                    dataSet.ReadXml(stringReader);
                    dataTableSales = dataSet.Tables[0];
                    gvwSales.DataSource = dataTableSales;
                    btnSummary.Visible = dataTableSales.Rows.Count > 0;
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Unable to fetch sales details. Please try again!\n\r" + response, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GvwSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvwSales.CurrentRow != null && e.ColumnIndex == 6 && !Convert.ToBoolean(gvwSales.CurrentRow.Cells[7].Value))
            {
                SalesID = Convert.ToInt32(gvwSales.CurrentRow.Cells[0].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void GvwSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gvwSales.CurrentRow != null)
            {
                SalesID = Convert.ToInt32(gvwSales.CurrentRow.Cells[0].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void BtnSummary_Click(object sender, EventArgs e)
        {
            pnlSummary.Visible = !pnlSummary.Visible;
            if (pnlSummary.Visible)
            {
                var upiTypes = (from row in dataTableSales.AsEnumerable()
                                select row.Field<string>("upi_type_desc")).Distinct().OrderBy(upi_type_desc => upi_type_desc);

                DataRow dataRow;
                double totalAmount = 0;
                dataTableSummary.Clear();
                foreach (string item in upiTypes)
                {
                    dataRow = dataTableSummary.NewRow();
                    dataRow["Trans_Type"] = item;
                    dataRow["Trans_Amount"] = dataTableSales.Compute("SUM(total_incl_gst)", "upi_type_desc='" + item + "'");
                    totalAmount += Convert.ToDouble(dataRow["Trans_Amount"]);
                    dataTableSummary.Rows.Add(dataRow);
                }
                dataRow = dataTableSummary.NewRow();
                dataRow["Trans_Type"] = "Total";
                dataRow["Trans_Amount"] = Math.Round(totalAmount, 2);
                dataTableSummary.Rows.Add(dataRow);
                gvwSummary.DataSource = dataTableSummary;
                gvwSummary.Rows[dataTableSummary.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                gvwSummary.Rows[dataTableSummary.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Red;
                gvwSummary.Focus();
            }
        }
    }
}
