using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayBillApp.WinApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class CustomerForm : Form
    {
        private readonly int borderRadius = 15;
        private readonly int borderSize = 0;
        private readonly Color borderColor = Color.Silver;

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

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }

        private void CustomerForm_Paint(object sender, PaintEventArgs e)
        {
            ReuseMethods.SetFormBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length != 10)
            {
                MessageBox.Show("Search mobile cannot be empty.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

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
                WinParamModel paramModel = new()
                {
                    ClientID = ConstantVariables.CLIENT_ID,
                    UserID = ConstantVariables.USER_ID,
                    MachineID = ConstantVariables.MACHINE_UNIQUE_ID,
                    SecurityKey = ConstantVariables.SECURITY_KEY,
                    WinQRCodeID = ConstantVariables.WIN_QRCODE_ID,
                    SearchParam = txtSearch.Text.Trim()
                };
                StringContent content = new(JsonConvert.SerializeObject(paramModel));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = httpClient.PostAsync("CheckCustomer", content).Result;
                string response = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    JObject objJson = JObject.Parse(response);
                    CustomerID = Convert.ToInt32(objJson.GetValue("CustomerId"));
                    if (CustomerID > 0)
                    {
                        this.CustomerName = $"{objJson.GetValue("CustomerName")}, {txtSearch.Text.Trim()}";
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.Height = 413;
                        this.txtMobile.Text = txtSearch.Text;
                        this.txtSearch.Text = String.Empty;
                        this.btnCancel.Location = new Point(this.btnCancel.Location.X, this.btnSave.Location.Y);
                        this.Top -= 140;
                        this.txtCustomerName.Focus();
                    }
                }
                else
                    MessageBox.Show(response.Length > 0 ? response : "Unable to connect the server. Please try again!", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Customer name cannot be empty.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            if (txtMobile.Text.Trim().Length != 10)
            {
                MessageBox.Show("Customer name cannot be empty.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobile.Focus();
                return;
            }

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
                WinParamModel paramModel = new()
                {
                    ClientID = ConstantVariables.CLIENT_ID,
                    UserID = ConstantVariables.USER_ID,
                    MachineID = ConstantVariables.MACHINE_UNIQUE_ID,
                    SecurityKey = ConstantVariables.SECURITY_KEY,
                    WinQRCodeID = ConstantVariables.WIN_QRCODE_ID
                };
                CustomerModel customerModel = new()
                {
                    CustomerID = 0,
                    CustomerName = txtCustomerName.Text.Trim(),
                    CustomerAddress = txtAddress.Text.Trim(),
                    CustomerMobile = txtMobile.Text.Trim()
                };

                List<string> listModel = new()
                {
                    JsonConvert.SerializeObject(paramModel),
                    JsonConvert.SerializeObject(customerModel)
                };

                StringContent content = new(JsonConvert.SerializeObject(listModel));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = httpClient.PostAsync("InsCustomer", content).Result;
                string response = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    JObject objJson = JObject.Parse(response);
                    CustomerID = Convert.ToInt32(objJson.GetValue("CustomerId"));
                    this.CustomerName = $"{objJson.GetValue("CustomerName")}, {txtMobile.Text.Trim()}";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Customer could not be saved. Please try again!", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }

        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
        }

        private void TxtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch.PerformClick();
        }
    }
}
