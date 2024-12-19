using Newtonsoft.Json.Linq;
using PayBillApp.WinApp.Models;
using System;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class LoginScanner : Form
    {
        private Timer timer;
        private string qrCodeText;
        private string machineUniqueId;
        private readonly int borderRadius = 20;
        private readonly int borderSize = 1;
        private readonly Color borderColor = Color.WhiteSmoke;

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
        public LoginScanner()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }

        private static string GenerateUniqueID()
        {
            string uniqueId = string.Empty;
            ManagementClass managementClass = new("Win32_Processor");
            ManagementObjectCollection objectCollection = managementClass.GetInstances();
            foreach (ManagementObject managementObject in objectCollection)
            {
                uniqueId = managementObject["ProcessorID"].ToString();
            }
            managementClass = new("Win32_BaseBoard");
            objectCollection = managementClass.GetInstances();
            foreach (ManagementObject managementObject in objectCollection)
            {
                uniqueId += managementObject["SerialNumber"].ToString();
            }
            return uniqueId;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "no ip address";
        }

        private void LoginScanner_Load(object sender, EventArgs e)
        {
            machineUniqueId = GenerateUniqueID();
            CallQRCodeAPI();
        }

        private async void CallQRCodeAPI()
        {
            picQRCode.Image = null;
            picRefresh.Visible = false;
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.FromArgb(0, 192, 192);
            lblMessage.Text = "Processing...";
            if (machineUniqueId.Length == 0)
            {
                lblMessage.Text = "Application Id is not genereated. Please restart the paybill.";
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
                MultipartFormDataContent content = new()
                    {
                        { new StringContent(machineUniqueId), "machineUniqueId" },
                        { new StringContent(GetLocalIPAddress()), "ipAddress" }
                    };
                var result = await httpClient.PostAsync("GenerateSignInQRCode", content);
                string response = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    JObject json = JObject.Parse(response);
                    if (json.TryGetValue("bytes", out JToken jTokenBytes))
                    {
                        qrCodeText = json.GetValue("qrCodeText").ToString();
                        byte[] bytes = Convert.FromBase64String(jTokenBytes.Value<string>());
                        lblMessage.Visible = false;
                        using MemoryStream memoryStream = new(bytes);
                        picQRCode.Image = Image.FromStream(memoryStream);
                        StartTimer();
                    }
                    else
                        lblMessage.Text = "Unable to generate the QR Code. Please try again!";
                }
                else
                    lblMessage.Text = "Unable to generate the QR Code. Please try again!";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message;
            }
            finally
            {
                picRefresh.Visible = true;
            }
        }

        private void PicRefresh_Click(object sender, EventArgs e)
        {
            CallQRCodeAPI();
        }

        private void PicExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void StartTimer()
        {
            timer = new()
            {
                Interval = 5000
            };
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            CheckAuthentication();
        }

        private void CheckAuthentication()
        {
            if (lblMessage.Visible)
                lblMessage.Visible = false;
            try
            {
                string logoPath = Path.Combine(Application.StartupPath, ConstantVariables.LOGO_NAME);
                bool downloadLogo = !File.Exists(logoPath);
                using HttpClient httpClient = new(new HttpClientHandler()
                {
                    SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
                });
                httpClient.BaseAddress = new Uri(ConstantVariables.WEB_API_URL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("basic_auth", ConstantVariables.WIN_QRCODE_BASIC_AUTH);
                MultipartFormDataContent content = new()
                    {
                        { new StringContent(machineUniqueId), "machineUniqueId" },
                        { new StringContent(qrCodeText), "qrCode" },
                        { new StringContent(downloadLogo.ToString()), "downloadLogo" }
                    };
                var result = httpClient.PostAsync("WinQRCodeAuthentication", content).Result;
                string response = result.Content.ReadAsStringAsync().Result;

                if (result.IsSuccessStatusCode)
                {
                    JObject jsonResponse = JObject.Parse(response);
                    if (Convert.ToBoolean(jsonResponse.GetValue("status")))
                    {
                        timer.Enabled = false;
                        timer.Tick -= Timer_Tick;
                        ConstantVariables.CLIENT_ID = Convert.ToInt32(jsonResponse.GetValue("clientId"));
                        ConstantVariables.WIN_QRCODE_ID = Convert.ToInt32(jsonResponse.GetValue("winQRCodeId"));
                        ConstantVariables.JWT_TOKEN = $"Bearer {jsonResponse.GetValue("jwtToken")}";
                        ConstantVariables.CLIENT_NAME = jsonResponse.GetValue("clientName").ToString();
                        ConstantVariables.USER_ID = jsonResponse.GetValue("empUserId").ToString();
                        ConstantVariables.DISPLAY_NAME = jsonResponse.GetValue("displayName").ToString();
                        ConstantVariables.SECURITY_KEY = jsonResponse.GetValue("securityKey").ToString();
                        ConstantVariables.MACHINE_UNIQUE_ID = machineUniqueId;
                        ConstantVariables.ADD_ITEM_ON_BARCODE_SCAN = Convert.ToBoolean(jsonResponse.GetValue("addItemOnScan"));
                        ConstantVariables.REPORT_ADDRESS = jsonResponse.GetValue("reportHeader").ToString();
                        ConstantVariables.CLIENT_GSTIN = jsonResponse.GetValue("clientGSTIN").ToString();
                        ConstantVariables.IS_PRINT_LOCAL_LANGUAGE = Convert.ToBoolean(jsonResponse.GetValue("printLocalLanguage"));
                        ConstantVariables.IS_QRCODE_ON_INVOICE = Convert.ToBoolean(jsonResponse.GetValue("qrcodeOnInvoice"));
                        ConstantVariables.INVOICE_TITLE = jsonResponse.GetValue("salesInvoiceTitle").ToString();
                        ConstantVariables.IS_ADMIN = Convert.ToBoolean(jsonResponse.GetValue("isAdmin"));
                        if (jsonResponse.GetValue("terms1").ToString().Length > 0)
                            ConstantVariables.INVOICE_TERMS = $"{jsonResponse.GetValue("terms1")}\n\r{jsonResponse.GetValue("terms2")}";
                        else
                            ConstantVariables.INVOICE_TERMS = String.Empty;
                        if (jsonResponse.GetValue("logoBytes").ToString().Length > 0)
                        {
                            File.WriteAllBytes(logoPath, Convert.FromBase64String(jsonResponse.GetValue("logoBytes").ToString()));
                            ConstantVariables.LOGO_URL = logoPath;
                        }
                        else
                        {
                            if (Convert.ToBoolean(jsonResponse.GetValue("logoRequired")) && !downloadLogo)
                                ConstantVariables.LOGO_URL = logoPath;
                            else
                                ConstantVariables.LOGO_URL = String.Empty;
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        timer.Start();
                }
                else
                {
                    timer.Start();
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = response;
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
                timer.Start();
                if (ex.Message.Contains("is denied"))
                    MessageBox.Show("Please provide read and write permission on root folder.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginScanner_Paint(object sender, PaintEventArgs e)
        {
            ReuseMethods.SetFormBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void LblResetResouce_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(Application.StartupPath, ConstantVariables.SQLITE_DATABASE);
                if (!File.Exists(dbPath))
                    File.Delete(dbPath);
                string logoPath = Path.Combine(Application.StartupPath, ConstantVariables.LOGO_NAME);
                if (!File.Exists(logoPath))
                    File.Delete(logoPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
