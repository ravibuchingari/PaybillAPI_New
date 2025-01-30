using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayBillApp.WinApp.Models;
using PayBillApp.WinApp.UserControls;
using PaybillWinApp.Models;
using PaybillWinApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class SalesInvoiceForm : Form
    {
        private bool barcodeScanOnly;
        private bool isCapsLocked = true;
        private ItemControl itemControlSelected;
        private bool isNewItem;
        private int salesID, CashPaymentTypeID;
        public DataTable PaymentTypes, UPITypes;
        private string editedPaidAmount, editedTransNo, editedCustomerName;
        private int editedCustomerID, editedPaymentID, editedUPITypeID;
        private readonly ICommonRepository commonRepository;
        private readonly ISQLiteHelper sQLiteHelper;
        private readonly ISharedRepository sharedRepository;

        public SalesInvoiceForm(ISharedRepository sharedRepository, ICommonRepository commonRepository, ISQLiteHelper sQLiteHelper)
        {
            InitializeComponent();
            pnlProcess.Dock = DockStyle.Fill;
            pnlProcess.Visible = true;
            ItemMRP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ItemPrice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void SalesInvoice_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            /* ApplicationVariables variables = ReuseMethods.DeserializeApplicationVariables();
             barcodeScanOnly = variables.BarcodeScanOnly;*/
            lblClientName.Text = AppVariables.User.Client?.ClientName!;
            lblInvoiceDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            chkBarcodeOnly.Checked = barcodeScanOnly;
            ChkBarcodeOnly_Click(sender, e);
            pnlProcess.Visible = false;
        }

        private void ChkBarcodeOnly_Click(object sender, EventArgs e)
        {
            barcodeScanOnly = chkBarcodeOnly.Checked;
            if (barcodeScanOnly)
            {
                chkBarcodeOnly.BackColor = Color.DarkGreen;
                chkBarcodeOnly.Text = "Barcode Only";
            }
            else
            {
                chkBarcodeOnly.BackColor = Color.FromArgb(63, 81, 181);
                chkBarcodeOnly.Text = "Search";
            }
            ToggleSearchEvents();
            if (gvwItems.Visible) gvwItems.Visible = false;
            txtSearch.Focus();
        }

        private void ToggleSearchEvents()
        {
            if (barcodeScanOnly)
            {
                txtSearch.MaxLength = 20;
                txtSearch.KeyDown -= TxtSearch_KeyDown;
                txtSearch.TextChanged -= TxtSearch_TextChanged;
                txtSearch.KeyDown += TxtSearch_KeyDown_Barcode;
                txtSearch.KeyPress += TxtSearch_KeyPress;
            }
            else
            {
                txtSearch.MaxLength = 50;
                txtSearch.KeyPress -= TxtSearch_KeyPress;
                txtSearch.KeyDown -= TxtSearch_KeyDown_Barcode;
                txtSearch.KeyDown += TxtSearch_KeyDown;
                txtSearch.TextChanged += TxtSearch_TextChanged;
            }
        }

        private async void GetUtilities()
        {
            //if (!pnlProcess.Visible) pnlProcess.Visible = true;
            //try
            //{
            //    dbContext.Database.ExecuteSqlRaw($"DELETE FROM {ConstantVariables.SQLITE_ITEMS_TABLE}");

            //    using HttpClient httpClient = new(new HttpClientHandler()
            //    {
            //        SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
            //    });
            //    httpClient.BaseAddress = new Uri(ConstantVariables.WEB_API_URL);
            //    httpClient.DefaultRequestHeaders.Accept.Clear();
            //    httpClient.DefaultRequestHeaders.Add("basic_auth", ConstantVariables.WIN_QRCODE_BASIC_AUTH);
            //    httpClient.DefaultRequestHeaders.Add("Authorization", ConstantVariables.JWT_TOKEN);
            //    WinParamModel paramModel = new()
            //    {
            //        ClientID = ConstantVariables.CLIENT_ID,
            //        UserID = ConstantVariables.USER_ID,
            //        MachineID = ConstantVariables.MACHINE_UNIQUE_ID,
            //        SecurityKey = ConstantVariables.SECURITY_KEY
            //    };
            //    StringContent content = new(JsonConvert.SerializeObject(paramModel));
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    var result = await httpClient.PostAsync("GetWinItems", content);
            //    string response = await result.Content.ReadAsStringAsync();
            //    if (result.IsSuccessStatusCode)
            //    {
            //        JObject jsonObject = JObject.Parse(response);
            //        ConstantVariables.SERVER_DATE = Convert.ToDateTime(jsonObject.GetValue("serverDate"));
            //        StringReader stringReader = new(jsonObject.GetValue("xmlData").ToString());
            //        DataSet dataSet = new();
            //        dataSet.ReadXml(stringReader);
            //        DataTable dataTableItems = dataSet.Tables[0];
            //        PaymentTypes = dataSet.Tables[1];
            //        UPITypes = dataSet.Tables[2];
            //        lblInvoiceDate.Text = ConstantVariables.SERVER_DATE.ToString("dd-MMM-yyyy");

            //        foreach (DataRow item in dataTableItems.Rows)
            //        {
            //            dbContext.Items.Add(new Items()
            //            {
            //                ItemId = Convert.ToInt32(item["item_id"]),
            //                ItemCode = item["item_barcode"].ToString(),
            //                ItemName = item["item_name"].ToString(),
            //                ItemAaliasNname = item["item_alias_name"].ToString(),
            //                ItemMRP = Convert.ToDouble(item["item_mrp_price"]),
            //                ItemPrice = Convert.ToDouble(item["item_sales_price"]),
            //                ItemDiscountPer = float.Parse(item["item_discount_in_per"].ToString()),
            //                ItemGSTPer = float.Parse(item["gst_per"].ToString()),
            //                LocalLanguage = item["item_name_telugu"].ToString()
            //            });
            //        }
            //        dbContext.SaveChanges();
            //        if (PaymentTypes.Rows.Count > 0)
            //            CashPaymentTypeID = Convert.ToInt32(PaymentTypes.Select("ValueName='Cash'")[0]["ValueID"]);
            //        dbContext.Items.Find(0);
            //        pnlProcess.Visible = false;
            //    }
            //    else
            //    {
            //        ShowUtilitiesError("Unable to connect the server. Please try again by clicking on refresh.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowUtilitiesError(ex.Message);
            //}
        }

        private void ShowUtilitiesError(string errorMsg)
        {
            //UtilitiesErrorForm errorForm = new(errorMsg);
            //errorForm.ShowDialog();
            //if (errorForm.DialogResult == DialogResult.OK)
            //    GetUtilities();
            //else
            //    Environment.Exit(0);
        }

        private void BtnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNumbers_Click(object sender, EventArgs e)
        {
            txtSearch.Text += ((Button)sender).Text;
            txtSearch.SelectionStart = txtSearch.Text.Length;
            if (!barcodeScanOnly)
                SearchItems();
            txtSearch.Focus();
        }

        private void BtnChars_Click(object sender, EventArgs e)
        {
            if (barcodeScanOnly) return;
            txtSearch.Text += isCapsLocked ? ((Button)sender).Text : ((Button)sender).Text.ToLower();
            txtSearch.SelectionStart = txtSearch.Text.Length;
            if (!barcodeScanOnly)
                SearchItems();
            txtSearch.Focus();
        }

        private void BtnSpace_Click(object sender, EventArgs e)
        {
            txtSearch.Text += " ";
            txtSearch.SelectionStart = txtSearch.Text.Length;
            txtSearch.Focus();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new();
            menuForm.ShowDialog();
            if (menuForm.DialogResult == DialogResult.OK)
            {
                switch (menuForm.SelectedItem)
                {
                    case (int)EnumClass.MenuItem.ViewSales:
                        btnViewSales.PerformClick();
                        break;
                    case (int)EnumClass.MenuItem.LoadUtilities:
                        GetUtilities();
                        break;
                    case (int)EnumClass.MenuItem.Reset:
                        ResetForm();
                        break;
                    case (int)EnumClass.MenuItem.Minimize:
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ResetForm()
        {
            salesID = 0;
            pnlParticulars.Controls.Clear();
            txtQuantity.Text = String.Empty;
            txtSearch.Text = String.Empty;
            lblInvoiceNo.Text = String.Empty;
            lblInvoiceNo.BackColor = Color.Transparent;
            itemControlSelected = null;
            editedPaidAmount = string.Empty;
            editedTransNo = string.Empty;
            editedCustomerID = 0;
            editedPaymentID = 0;
            editedUPITypeID = 0;
            txtSearch.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            ExitConfirmForm exitConfirm = new();
            exitConfirm.ShowDialog();
            if (exitConfirm.DialogResult == DialogResult.OK)
                Environment.Exit(0);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                int position = txtSearch.SelectionStart;
                if (position > 0)
                {
                    position -= 1;
                    txtSearch.Text = txtSearch.Text.Remove(position, 1);
                    txtSearch.Focus();
                    txtSearch.SelectionStart = position;
                    txtSearch.SelectionLength = 0;
                }
            }
        }

        private async void SearchItems()
        {
            //var queryData = await dbContext.Items.Where(item => EF.Functions.Like(item.ItemCode, txtSearch.Text + "%") ||
            //                                              EF.Functions.Like(item.ItemName, txtSearch.Text + "%") ||
            //                                              EF.Functions.Like(item.ItemAaliasNname, txtSearch.Text + "%")).ToListAsync();
            //gvwItems.DataSource = queryData;
            //if (!gvwItems.Visible)
            //    gvwItems.Visible = true;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvwItems.Visible && e.KeyCode == Keys.Down)
                MoveItem(true);
            else if (gvwItems.Visible && e.KeyCode == Keys.Up)
                MoveItem(false);
            else if (e.KeyCode == Keys.Enter)
                btnAddItem.PerformClick();
        }

        private void TxtSearch_KeyDown_Barcode(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddItem.PerformClick();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
                SearchItems();
            else
                gvwItems.Visible = false;
        }

        private void MoveItem(bool isNext)
        {
            int index = gvwItems.CurrentRow.Index;
            index = isNext ? index + 1 : index - 1;
            if (index >= gvwItems.Rows.Count)
                index = 0;
            else if (index < 0)
                index = gvwItems.Rows.Count - 1;
            gvwItems.CurrentCell = gvwItems[1, index];
            //gvwItems.FirstDisplayedScrollingRowIndex = index;
            txtSearch.SelectionStart = txtSearch.Text.Length;
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            //if (txtSearch.Text.Trim().Length > 0)
            //{
            //    if (pnlCashReceived.Visible) pnlCashReceived.Visible = false;
            //    if (!barcodeScanOnly)
            //    {
            //        if (gvwItems.Rows.Count > 0)
            //        {
            //            if (gvwItems.CurrentRow != null && gvwItems.CurrentRow.Selected)
            //                PrepareItem(dbContext.Items.Find(gvwItems.CurrentRow.Cells[0].Value));
            //            else
            //                MessageBox.Show("Item is not selected.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else
            //            MessageBox.Show("No item found.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        var queryData = dbContext.Items.Where(item => EF.Functions.Like(item.ItemCode, txtSearch.Text + "%")).ToList();
            //        if (queryData.Count > 0)
            //        {
            //            if (queryData.Count == 1)
            //                PrepareItem(queryData[0]);
            //            else
            //            {
            //                CodeItemsForm codeItemsForm = new()
            //                {
            //                    CodeItems = queryData
            //                };
            //                codeItemsForm.ShowDialog();
            //                if (codeItemsForm.DialogResult == DialogResult.OK)
            //                    PrepareItem(dbContext.Items.Find(codeItemsForm.SelectedItemId));
            //            }
            //        }
            //        else
            //            MessageBox.Show("No item found.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
        }

        private ItemControl CheckDuplicateItem(int itemId)
        {
            foreach (Control control in pnlParticulars.Controls)
            {
                if (((ItemControl)control).lblItemId.Text.Equals(itemId.ToString()))
                    return (ItemControl)control;
            }
            return null;
        }

        //private void PrepareItem(Items item)
        //{
        //    ItemControl itemControl = CheckDuplicateItem(item.ItemId);
        //    int intQty;

        //    if (itemControl == null)
        //    {
        //        isNewItem = true;
        //        itemControl = new() { Tag = 0 };
        //        intQty = (txtQuantity.Text.Trim().Length > 0 ? int.Parse(txtQuantity.Text.Trim()) : 1);
        //        itemControl.lblItemId.Text = item.ItemId.ToString();
        //        itemControl.lblItemCode.Text = item.ItemCode;
        //        itemControl.lblItemName.Text = item.ItemName;
        //        itemControl.lblQuantity.Text = intQty.ToString();
        //        itemControl.lblMRP.Text = "MRP." + item.ItemMRP.ToString("0.00");
        //        itemControl.lblRate.Text = item.ItemPrice.ToString("0.00");
        //        itemControl.lblDiscountInRs.Text = (item.ItemPrice * intQty * item.ItemDiscountPer / 100).ToString("0.00");
        //        itemControl.lblAmount.Text = ((item.ItemPrice * intQty) - double.Parse(itemControl.lblDiscountInRs.Text)).ToString("0.00");
        //        itemControl.lblGSTInRS.Text = (double.Parse(itemControl.lblAmount.Text) * item.ItemGSTPer / 100).ToString("0.00");
        //        itemControl.lblTotalAmount.Text = (double.Parse(itemControl.lblAmount.Text) + double.Parse(itemControl.lblGSTInRS.Text)).ToString("0.00");
        //        itemControl.lnkModify.Click += LnkModify_Click;
        //        itemControl.lnkRemove.Click += LnkRemove_Click;
        //        itemControl.Click += ItemControl_Click;
        //        pnlParticulars.Controls.Add(itemControl);
        //    }
        //    else
        //    {
        //        isNewItem = false;
        //        intQty = int.Parse(itemControl.lblQuantity.Text) + (txtQuantity.Text.Trim().Length > 0 ? int.Parse(txtQuantity.Text.Trim()) : 1);
        //        itemControl.lblQuantity.Text = intQty.ToString();
        //        itemControl.lblDiscountInRs.Text = (item.ItemPrice * intQty * item.ItemDiscountPer / 100).ToString("0.00");
        //        itemControl.lblAmount.Text = ((item.ItemPrice * intQty) - double.Parse(itemControl.lblDiscountInRs.Text)).ToString("0.00");
        //        itemControl.lblGSTInRS.Text = (double.Parse(itemControl.lblAmount.Text) * item.ItemGSTPer / 100).ToString("0.00");
        //        itemControl.lblTotalAmount.Text = (double.Parse(itemControl.lblAmount.Text) + double.Parse(itemControl.lblGSTInRS.Text)).ToString("0.00");
        //    }
        //    gvwItems.Visible = false;
        //    txtQuantity.Text = String.Empty;
        //    txtSearch.Text = String.Empty;
        //    //if(itemControlSelected != null)
        //    //    itemControlSelected.BackColor = Color.White;
        //    //itemControlSelected = itemControl;
        //    //itemControlSelected.BackColor = Color.WhiteSmoke;
        //    SelectItemControl(itemControl);
        //    if (isNewItem)
        //        pnlParticulars.VerticalScroll.Value = pnlParticulars.VerticalScroll.Maximum;
        //    txtSearch.Focus();
        //}

        private void ItemControl_Click(object sender, EventArgs e)
        {
            SelectItemControl((ItemControl)sender);
        }

        private void SelectItemControl(ItemControl itemControl)
        {
            if (itemControlSelected != null)
                itemControlSelected.BackColor = Color.White;
            itemControlSelected = itemControl;
            itemControlSelected.BackColor = Color.WhiteSmoke;
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void LnkRemove_Click(object sender, EventArgs e)
        {
            //LinkLabel linkLabel = ((LinkLabel)sender);
            //ItemControl itemControl = (ItemControl)linkLabel.Parent.Parent;
            //if (Convert.ToInt32(itemControl.Tag) > 0)
            //{
            //    InputBoxForm inputBoxForm = new();
            //    inputBoxForm.lblLable.Text = "Remarks";
            //    inputBoxForm.txtMessage.MaxLength = 500;
            //    if (inputBoxForm.ShowDialog() == DialogResult.OK)
            //        DelSalesItem(itemControl, inputBoxForm.txtMessage.Text.Trim());
            //}
            //else
            //{
            //    pnlParticulars.Controls.Remove(itemControl);
            //    txtSearch.Focus();
            //}
        }

        private void LnkModify_Click(object sender, EventArgs e)
        {
            EditItem((ItemControl)((LinkLabel)sender).Parent.Parent);
        }

        private void BtnExitProcess_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            Environment.Exit(0);
        }

        private void ChkCapsLock_Click(object sender, EventArgs e)
        {
            isCapsLocked = chkCapsLock.Checked;
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddItem.PerformClick();
        }

        private void GvwItems_DoubleClick(object sender, EventArgs e)
        {
            if (gvwItems.CurrentRow != null && gvwItems.CurrentRow.Selected)
                btnAddItem.PerformClick();
        }

        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            if (itemControlSelected != null)
                EditItem(itemControlSelected);
        }

        private void EditItem(ItemControl itemControl)
        {
            //EditedItemForm editedItemForm = new($"{itemControl.lblItemCode.Text} {itemControl.lblItemName.Text}")
            //{
            //    Quantity = int.Parse(itemControl.lblQuantity.Text)
            //};
            //if (editedItemForm.ShowDialog() == DialogResult.OK)
            //{
            //    int intQty = editedItemForm.Quantity;
            //    Items item = dbContext.Items.Find(int.Parse(itemControl.lblItemId.Text));
            //    itemControl.lblQuantity.Text = intQty.ToString();
            //    itemControl.lblDiscountInRs.Text = (item.ItemPrice * intQty * item.ItemDiscountPer / 100).ToString("0.00");
            //    itemControl.lblAmount.Text = ((item.ItemPrice * intQty) - double.Parse(itemControl.lblDiscountInRs.Text)).ToString("0.00");
            //    itemControl.lblGSTInRS.Text = (double.Parse(itemControl.lblAmount.Text) * item.ItemGSTPer / 100).ToString("0.00");
            //    itemControl.lblTotalAmount.Text = (double.Parse(itemControl.lblAmount.Text) + double.Parse(itemControl.lblGSTInRS.Text)).ToString("0.00");
            //    itemControl.pnlOutOfStock.Visible = false;
            //    txtSearch.Focus();
            //}
        }

        private void BtnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //if (pnlParticulars.Controls.Count == 0)
            //{
            //    MessageBox.Show("No item found to generate sales invoice.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSearch.Focus();
            //    return;
            //}

            //SaleModel saleModel = new();
            //int totalQuantity = 0;
            //double totalAmount = 0, totalDiscount = 0, totalGSTValue = 0;
            //List<SaleDetailsModel> listItems = new();
            //foreach (ItemControl control in pnlParticulars.Controls)
            //{
            //    listItems.Add(new SaleDetailsModel()
            //    {
            //        SalesDetailsID = Convert.ToInt32(control.Tag),
            //        ItemID = int.Parse(control.lblItemId.Text),
            //        Quantity = int.Parse(control.lblQuantity.Text),
            //        ExtraDiscountInRs = 0 //for extra discount in rs
            //    });
            //    totalQuantity += int.Parse(control.lblQuantity.Text);
            //    totalAmount += Math.Round(double.Parse(control.lblQuantity.Text) * double.Parse(control.lblRate.Text), 2);
            //    totalDiscount += double.Parse(control.lblDiscountInRs.Text);
            //    totalGSTValue += double.Parse(control.lblGSTInRS.Text);
            //}
            //SummaryForm summaryForm = new()
            //{
            //    PaymentTypeID = CashPaymentTypeID,
            //    SalesForm = this
            //};
            //summaryForm.lblITems.Text = listItems.Count.ToString();
            //summaryForm.lblQuantity.Text = totalQuantity.ToString();
            //summaryForm.lblAmount.Text = $"₹ {totalAmount:0.00}";
            //summaryForm.lblDiscount.Text = $"₹ {totalDiscount:0.00}";
            //summaryForm.lblTaxableAmount.Text = $"₹ {totalAmount - totalDiscount:0.00}";
            //summaryForm.lblGSTValue.Text = $"₹ {totalGSTValue:0.00}";
            //summaryForm.lblTotalAmount.Text = $"₹ {totalAmount - totalDiscount + totalGSTValue:0.00}";
            //summaryForm.lblTotalAmount2.Text = summaryForm.lblTotalAmount.Text;
            //summaryForm.lblBalance.Text = summaryForm.lblTotalAmount.Text;
            //summaryForm.TotalAmount = totalAmount - totalDiscount + totalGSTValue;
            //if (salesID > 0)
            //    summaryForm.SetEditedValues(editedPaidAmount, editedTransNo, editedCustomerID, editedCustomerName, editedPaymentID, editedUPITypeID);

            //if (summaryForm.ShowDialog() == DialogResult.OK)
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    double paidAmount = double.Parse(summaryForm.txtPaidAmount.Text.Trim().Length > 0 ? summaryForm.txtPaidAmount.Text.Trim() : "0");
            //    saleModel.ClientID = ConstantVariables.CLIENT_ID;
            //    saleModel.UserID = ConstantVariables.USER_ID;
            //    saleModel.DeviceAppID = ConstantVariables.MACHINE_UNIQUE_ID;
            //    saleModel.SecurityKey = ConstantVariables.SECURITY_KEY;
            //    saleModel.SalesID = salesID;
            //    saleModel.TransportCharge = 0;
            //    saleModel.PackingCharge = 0;
            //    saleModel.OtherCharge = 0;
            //    saleModel.PaidCash = paidAmount;
            //    saleModel.PaymentTypeID = summaryForm.PaymentTypeID;
            //    saleModel.UPITypeID = summaryForm.UPITypeID;
            //    saleModel.TransNo = summaryForm.txtTransactionNo.Text.Trim();
            //    saleModel.CustomerID = summaryForm.CustomerID;
            //    saleModel.QRTransactionID = "";
            //    saleModel.QRPayTransactionID = "";
            //    saleModel.SalesDetails = listItems;
            //    SaveSalesInvoice(saleModel);
            //}
        }

        private void PnlCashReceived(object sender, EventArgs e)
        {
            pnlCashReceived.Visible = false;
        }

        private void GvwItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddItem.PerformClick();
        }

        private void BtnViewSales_Click(object sender, EventArgs e)
        {
            //ViewSalesForm viewSalesForm = new();
            //if (viewSalesForm.ShowDialog() == DialogResult.OK)
            //{
            //    salesID = viewSalesForm.SalesID;
            //    GetSalesInvoice();
            //}
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            pnlCashReceived.Visible = false;
        }

        //private void SaveSalesInvoice(SaleModel saleModel)
        //{
        //    try
        //    {
        //        using HttpClient httpClient = new(new HttpClientHandler()
        //        {
        //            SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
        //        });
        //        httpClient.BaseAddress = new Uri(ConstantVariables.WEB_API_URL);
        //        httpClient.DefaultRequestHeaders.Accept.Clear();
        //        httpClient.DefaultRequestHeaders.Add("basic_auth", ConstantVariables.WIN_QRCODE_BASIC_AUTH);
        //        httpClient.DefaultRequestHeaders.Add("Authorization", ConstantVariables.JWT_TOKEN);
        //        httpClient.DefaultRequestHeaders.Add("WinQRCodeId", ConstantVariables.WIN_QRCODE_ID.ToString());
        //        StringContent content = new(JsonConvert.SerializeObject(saleModel));
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //        var result = httpClient.PostAsync("SaveSalesInvoice", content).Result;
        //        string response = result.Content.ReadAsStringAsync().Result;
        //        Cursor.Current = Cursors.Default;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            ResetForm();
        //            DataSet dataSet = new();
        //            StringReader stringReader = new(response);
        //            dataSet.ReadXml(stringReader);

        //            double otherAmount = Convert.ToDouble(dataSet.Tables[0].Rows[0]["TransportCharge"]) + Convert.ToDouble(dataSet.Tables[0].Rows[0]["PackingCharge"]) + Convert.ToDouble(dataSet.Tables[0].Rows[0]["OtherCharge"]);
        //            double totalInvoiceAmount = otherAmount + Convert.ToDouble(dataSet.Tables[1].Compute("SUM(TotalValueIncludeGST)", null));

        //            PrintInvoice(dataSet, totalInvoiceAmount);
        //            pnlCashReceived.Visible = true;
        //            lblInvoiceAmount.Text = totalInvoiceAmount.ToString("N2");
        //            lblCashReceived.Text = saleModel.PaidCash.ToString("N2");
        //            lblBalance.Text = (totalInvoiceAmount - saleModel.PaidCash).ToString("N2");
        //            Cursor.Current = Cursors.Default;
        //        }
        //        else if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
        //        {
        //            JObject jsonObject = JObject.Parse(response);
        //            string outOfStock = jsonObject.GetValue("jsonString").ToString();
        //            if (outOfStock.Length > 0)
        //            {
        //                List<SaleDetailsModel> listOutOfStock = JsonConvert.DeserializeObject<List<SaleDetailsModel>>(outOfStock);
        //                ItemControl tempControl;
        //                foreach (SaleDetailsModel item in listOutOfStock)
        //                {
        //                    foreach (Control control in pnlParticulars.Controls)
        //                    {
        //                        if (((ItemControl)control).lblItemId.Text.Equals(item.ItemID.ToString()))
        //                        {
        //                            tempControl = (ItemControl)control;
        //                            tempControl.pnlOutOfStock.Visible = true;
        //                            tempControl.lblRemaingQuantity.Text = $"You have only {item.AvailableQty} number(s)";
        //                        }
        //                    }
        //                }
        //            }
        //            Cursor.Current = Cursors.Default;
        //            MessageBox.Show(jsonObject.GetValue("message").ToString(), ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            Cursor.Current = Cursors.Default;
        //            MessageBox.Show(response, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor.Current = Cursors.Default;
        //        MessageBox.Show(ex.Message, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private static async void PrintInvoice(DataSet dataSet, double totalInvoiceAmount)
        {
            //try
            //{
            //    DataTable dataTableInvoice = dataSet.Tables[0];
            //    DataTable dataTableDetails = dataSet.Tables[1];
            //    string strTotalQty, strItemCount, strCash, strChange, strTransport, strPacking, strOthers, strSaving;
            //    double totalSGST = Convert.ToDouble(dataTableDetails.Compute("SUM(CGSTInRs)", null));
            //    double totalIGST = Convert.ToDouble(dataTableDetails.Compute("SUM(IGSTInRs)", null));
            //    bool sgstRequired = totalSGST > 0;
            //    bool igstRequired = totalIGST > 0;

            //    strTotalQty = dataTableDetails.Compute("SUM(Quantity)", null).ToString();
            //    strItemCount = dataTableDetails.Compute("COUNT(Quantity)", null).ToString();
            //    strCash = dataTableInvoice.Rows[0]["CashReceived"].ToString();
            //    strChange = Math.Round((totalInvoiceAmount - Convert.ToDouble(dataTableInvoice.Rows[0]["CashReceived"])), 0).ToString("0.00");
            //    strTransport = dataTableInvoice.Rows[0]["TransportCharge"].ToString();
            //    strPacking = dataTableInvoice.Rows[0]["PackingCharge"].ToString();
            //    strOthers = dataTableInvoice.Rows[0]["OtherCharge"].ToString();

            //    strSaving = $"Saving amount is {Convert.ToDouble(dataTableDetails.Compute("SUM(SavingAmount)", null)):0.00}";
            //    if (ConstantVariables.IS_PRINT_LOCAL_LANGUAGE)
            //    {
            //        foreach (DataRow item in dataTableDetails.Rows)
            //        {
            //            item["ItemName"] = item["LocalLanguage"].ToString();
            //        }
            //    }

            //    string reportPath;
            //    if (ConstantVariables.LOGO_URL.Length > 0 && File.Exists(ConstantVariables.LOGO_URL))
            //        reportPath = Path.Combine(Application.StartupPath, $"{EnumClass.SalesInvoiceReport.rptSalesInvoiceLogo}.rdlc");
            //    else
            //        reportPath = Path.Combine(Application.StartupPath, $"{EnumClass.SalesInvoiceReport.rptSalesInvoice}.rdlc");

            //    if (!File.Exists(reportPath))
            //    {
            //        MessageBox.Show("Print file not found!", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    await Task.Run(() =>
            //    {
            //        using PrintReport printReport = new();
            //        printReport.RunSalesInvoice(reportPath, new ReportDataSource("DSSalesInvoice", dataTableDetails), strTotalQty, strItemCount, strCash, strChange, strTransport, strPacking, strOthers, dataTableInvoice.Rows[0]["SalesID"].ToString(), dataTableInvoice.Rows[0]["CreatedDate"].ToString(), strSaving, dataTableInvoice.Rows[0]["CreatedBy"].ToString(), sgstRequired, igstRequired);
            //    });
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private async void GetSalesInvoice()
        {
            //if (pnlCashReceived.Visible) pnlCashReceived.Visible = false;
            //if (!pnlProcess.Visible) pnlProcess.Visible = true;
            //try
            //{
            //    using HttpClient httpClient = new(new HttpClientHandler()
            //    {
            //        SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
            //    });
            //    httpClient.BaseAddress = new Uri(ConstantVariables.WEB_API_URL);
            //    httpClient.DefaultRequestHeaders.Accept.Clear();
            //    httpClient.DefaultRequestHeaders.Add("basic_auth", ConstantVariables.WIN_QRCODE_BASIC_AUTH);
            //    httpClient.DefaultRequestHeaders.Add("Authorization", ConstantVariables.JWT_TOKEN);
            //    httpClient.DefaultRequestHeaders.Add("param_sales_id", salesID.ToString());
            //    WinParamModel paramModel = new()
            //    {
            //        ClientID = ConstantVariables.CLIENT_ID,
            //        UserID = ConstantVariables.USER_ID,
            //        MachineID = ConstantVariables.MACHINE_UNIQUE_ID,
            //        SecurityKey = ConstantVariables.SECURITY_KEY,
            //        WinQRCodeID = ConstantVariables.WIN_QRCODE_ID
            //    };
            //    StringContent content = new(JsonConvert.SerializeObject(paramModel));
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    var result = await httpClient.PostAsync("GetSalesInvoice", content);
            //    string response = await result.Content.ReadAsStringAsync();
            //    if (result.IsSuccessStatusCode)
            //    {
            //        StringReader stringReader = new(response);
            //        DataSet dataSet = new();
            //        dataSet.ReadXml(stringReader);
            //        if (dataSet.Tables[0].Rows.Count > 0)
            //        {
            //            pnlParticulars.Controls.Clear();

            //            DataRow dataRowInvoice = dataSet.Tables[0].Rows[0];

            //            lblInvoiceNo.Text = $"No.{dataRowInvoice["SalesID"]}";
            //            lblInvoiceDate.Text = dataRowInvoice["SalesDate"].ToString();
            //            lblInvoiceNo.BackColor = Color.DarkRed;

            //            editedPaidAmount = dataRowInvoice["paid_cash"].ToString();
            //            editedTransNo = dataRowInvoice["trans_no"].ToString();
            //            editedCustomerID = Convert.ToInt32(dataRowInvoice["customer_id"].ToString().Length > 0 ? dataRowInvoice["customer_id"] : "0");
            //            editedPaymentID = Convert.ToInt32(dataRowInvoice["payment_type_id"].ToString().Length > 0 ? dataRowInvoice["payment_type_id"] : "0");
            //            editedUPITypeID = Convert.ToInt32(dataRowInvoice["upi_type_id"].ToString().Length > 0 ? dataRowInvoice["upi_type_id"] : "0");
            //            editedCustomerName = editedCustomerID > 0 ? $"{dataRowInvoice["customer_name"]}, {dataRowInvoice["customer_mobile"]}" : string.Empty;

            //            ItemControl itemControl;
            //            foreach (DataRow dataRow in dataSet.Tables[1].Rows)
            //            {
            //                itemControl = new() { Tag = dataRow["SalesDetailsID"] };
            //                itemControl.lblItemId.Text = dataRow["ItemID"].ToString();
            //                itemControl.lblItemCode.Text = dataRow["ItemCode"].ToString();
            //                itemControl.lblItemName.Text = dataRow["ItemName"].ToString();
            //                itemControl.lblQuantity.Text = dataRow["Quantity"].ToString();
            //                itemControl.lblMRP.Text = "MRP." + Convert.ToDouble(dataRow["MRP"]).ToString("0.00");
            //                itemControl.lblRate.Text = Convert.ToDouble(dataRow["ItemPrice"]).ToString("0.00");
            //                itemControl.lblDiscountInRs.Text = Convert.ToDouble(dataRow["DiscountInRs"]).ToString("0.00");
            //                itemControl.lblAmount.Text = Convert.ToDouble(dataRow["TaxableValue"]).ToString("0.00");
            //                itemControl.lblGSTInRS.Text = Convert.ToDouble(dataRow["GSTValue"]).ToString("0.00");
            //                itemControl.lblTotalAmount.Text = Convert.ToDouble(dataRow["TotalValue"]).ToString("0.00");
            //                itemControl.lnkModify.Click += LnkModify_Click;
            //                itemControl.lnkRemove.Click += LnkRemove_Click;
            //                itemControl.Click += ItemControl_Click;
            //                pnlParticulars.Controls.Add(itemControl);
            //            }
            //            pnlProcess.Visible = false;
            //        }
            //        else
            //        {
            //            pnlProcess.Visible = false;
            //            MessageBox.Show("Sales invoice not found.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //    }
            //    else
            //    {
            //        pnlProcess.Visible = false;
            //        MessageBox.Show("Unable to get sales invoice. Please try again!\n\r" + response, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    pnlProcess.Visible = false;
            //    MessageBox.Show(ex.Message, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    txtSearch.Focus();
            //}
        }

        private async void DelSalesItem(ItemControl itemControl, string remarks)
        {
            //try
            //{
            //    using HttpClient httpClient = new(new HttpClientHandler()
            //    {
            //        SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
            //    });
            //    httpClient.BaseAddress = new Uri(ConstantVariables.WEB_API_URL);
            //    httpClient.DefaultRequestHeaders.Accept.Clear();
            //    httpClient.DefaultRequestHeaders.Add("basic_auth", ConstantVariables.WIN_QRCODE_BASIC_AUTH);
            //    httpClient.DefaultRequestHeaders.Add("Authorization", ConstantVariables.JWT_TOKEN);
            //    httpClient.DefaultRequestHeaders.Add("param_sales_id", salesID.ToString());
            //    httpClient.DefaultRequestHeaders.Add("param_sales_detail_id", itemControl.Tag.ToString());
            //    WinParamModel paramModel = new()
            //    {
            //        ClientID = ConstantVariables.CLIENT_ID,
            //        UserID = ConstantVariables.USER_ID,
            //        MachineID = ConstantVariables.MACHINE_UNIQUE_ID,
            //        SecurityKey = ConstantVariables.SECURITY_KEY,
            //        WinQRCodeID = ConstantVariables.WIN_QRCODE_ID,
            //        CommonParam = remarks
            //    };
            //    StringContent content = new(JsonConvert.SerializeObject(paramModel));
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    var result = await httpClient.PostAsync("DelSalesItem", content);
            //    string response = await result.Content.ReadAsStringAsync();
            //    if (result.IsSuccessStatusCode)
            //    {
            //        pnlParticulars.Controls.Remove(itemControl);
            //        if (pnlParticulars.Controls.Count == 0)
            //            ResetForm();
            //        else
            //            txtSearch.Focus();
            //    }
            //    else
            //        MessageBox.Show("Unable to delete the sales item. Please try again!\n\r" + response, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
