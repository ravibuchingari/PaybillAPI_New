using PayBillApp.WinApp.Models;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class SummaryForm : Form
    {
        private readonly int borderRadius = 4;
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

        public int PaymentTypeID { get; internal set; }
        public SalesInvoiceForm SalesForm { get; internal set; }
        public int CustomerID { get; private set; }
        public int UPITypeID { get; private set; }
        public double TotalAmount { private get; set; }

        public SummaryForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }
        public void SetEditedValues(string paidAmount, string transNo, int customerID, string customerName, int paymentTypeID, int upiTypeID)
        {
            txtPaidAmount.Text = paidAmount;
            txtTransactionNo.Text = transNo;
            CustomerID = customerID;
            lblCustomer.Text = customerName;
            if (PaymentTypeID != paymentTypeID)
            {
                txtPaidAmount.Enabled = false;
                PaymentTypeID = paymentTypeID;
                DataTable dataTable = SalesForm.PaymentTypes;
                DataRow[] drArry = dataTable.Select("ValueID=" + paymentTypeID);
                if (drArry.Length > 0)
                    lblPaymentType.Text = drArry[0]["ValueName"].ToString();
                if (upiTypeID > 0)
                {
                    UPITypeID = upiTypeID;
                    dataTable = SalesForm.UPITypes;
                    drArry = dataTable.Select("ValueID=" + upiTypeID);
                    if (drArry.Length > 0)
                        lblUPIType.Text = drArry[0]["ValueName"].ToString();
                }
                txtTransactionNo.Visible = true;
                txtTransactionNo.MaxLength = 30;
                txtTransactionNo.Location = new Point(txtTransactionNo.Location.X, 69);
                btnPrintInvoice.Focus();
            }
        }
        private void SummaryForm_Paint(object sender, PaintEventArgs e)
        {
            ReuseMethods.SetFormBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (lblPaymentType.Text.ToLower().Equals("upi") && UPITypeID == 0)
            {
                btnChangeUPIType.PerformClick();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new();
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                CustomerID = customerForm.CustomerID;
                lblCustomer.Text = customerForm.CustomerName;
            }
        }

        private void BtnChangePaymentType_Click(object sender, EventArgs e)
        {
            this.CancelButton = null;
            gvwPaymentTypes.DataSource = SalesForm.PaymentTypes;
            pnlPaymentTypes.Dock = DockStyle.Fill;
            pnlPaymentTypes.Visible = true;
            gvwPaymentTypes.Focus();
        }

        private void BtnChangeUPIType_Click(object sender, EventArgs e)
        {
            this.CancelButton = null;
            gvwUPITypes.DataSource = SalesForm.UPITypes;
            pnlUPIType.Dock = DockStyle.Fill;
            pnlUPIType.Visible = true;
            gvwUPITypes.Focus();
        }

        private void GvwPaymentTypes_DoubleClick(object sender, EventArgs e)
        {
            SetPaymentType();
        }

        private void SetPaymentType()
        {
            this.CancelButton = btnCancel;
            if (gvwPaymentTypes.CurrentRow != null && gvwPaymentTypes.CurrentRow.Selected)
            {
                PaymentTypeID = Convert.ToInt32(gvwPaymentTypes.CurrentRow.Cells[0].Value);
                lblPaymentType.Text = gvwPaymentTypes.CurrentRow.Cells[1].Value.ToString();
                UPITypeID = 0;
                lblUPIType.Text = "None";
                btnChangeUPIType.Enabled = lblPaymentType.Text.ToLower().Equals("upi");
                if (lblPaymentType.Text.ToLower().Equals("card"))
                {
                    txtTransactionNo.Visible = true;
                    txtTransactionNo.MaxLength = 4;
                    txtTransactionNo.Location = new Point(txtTransactionNo.Location.X, 27);
                    txtTransactionNo.Text = "Transaction No.";
                    txtTransactionNo.SelectAll();
                    txtTransactionNo.Focus();
                }
                else
                    txtTransactionNo.Visible = false;
                if (lblPaymentType.Text.ToLower().Equals("cash"))
                {
                    txtPaidAmount.Enabled = true;
                    txtPaidAmount.Focus();
                }
                else
                {
                    txtPaidAmount.Text = String.Empty;
                    txtPaidAmount.Enabled = false;
                }
                btnPaymentTypeClose.PerformClick();
                if (btnChangeUPIType.Enabled) btnChangeUPIType.PerformClick();
            }
        }

        private void BtnPaymentTypeClose_Click(object sender, EventArgs e)
        {
            pnlPaymentTypes.Visible = false;
            pnlPaymentTypes.Dock = DockStyle.None;
        }

        private void GvwPaymentTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetPaymentType();
            else if (e.KeyCode == Keys.Escape)
            {
                this.CancelButton = btnCancel;
                pnlPaymentTypes.Visible = false;
            }
        }

        private void BtnCloseUPIType_Click(object sender, EventArgs e)
        {
            pnlUPIType.Visible = false;
            pnlUPIType.Dock = DockStyle.None;
        }

        private void GvwUPITypes_DoubleClick(object sender, EventArgs e)
        {
            SetUPIType();
        }

        private void GvwUPITypes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetUPIType();
            else if (e.KeyCode == Keys.Escape)
            {
                this.CancelButton = btnCancel;
                pnlUPIType.Visible = false;
            }
        }

        private void SetUPIType()
        {
            this.CancelButton = btnCancel;
            if (gvwUPITypes.CurrentRow != null && gvwUPITypes.CurrentRow.Selected)
            {
                UPITypeID = Convert.ToInt32(gvwUPITypes.CurrentRow.Cells[0].Value);
                lblUPIType.Text = gvwUPITypes.CurrentRow.Cells[1].Value.ToString();
                txtTransactionNo.Visible = true;
                txtTransactionNo.MaxLength = 30;
                txtTransactionNo.Location = new Point(txtTransactionNo.Location.X, 69);
                txtTransactionNo.Text = "Transaction No.";
                txtTransactionNo.SelectAll();
                txtTransactionNo.Focus();
                btnCloseUPIType.PerformClick();
            }
        }

        private void TxtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPaidAmount.Text.Length > 0)
            {
                lblBalance.Text = (TotalAmount - double.Parse(txtPaidAmount.Text)).ToString("0.00");
                if (double.Parse(lblBalance.Text) > 0)
                {
                    lblBalance.ForeColor = Color.DarkRed;
                    lblBalanceLable.ForeColor = Color.DarkRed;
                }
                else
                {
                    lblBalance.ForeColor = Color.LimeGreen;
                    lblBalanceLable.ForeColor = Color.Green;
                }
            }
            else
            {
                lblBalance.ForeColor = Color.DarkRed;
                lblBalanceLable.ForeColor = Color.DarkRed;
                lblBalance.Text = lblTotalAmount2.Text;
            }
        }

        private void TxtTransactionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPrintInvoice.PerformClick();
        }

        private void TxtPaidAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPrintInvoice.PerformClick();
        }
    }
}
