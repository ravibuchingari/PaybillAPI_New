using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PaybillWinApp.UserControls
{
    public class RoundedForm : Form
    {
        private int borderRadius = 20; 

        public RoundedForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += new EventHandler(RoundedForm_Load);
            this.Resize += new EventHandler(RoundedForm_Resize);
        }

        private void RoundedForm_Load(object sender, EventArgs e)
        {
            SetFormRegion();
        }

        private void RoundedForm_Resize(object sender, EventArgs e)
        {
            SetFormRegion();
        }

        private void SetFormRegion()
        {
            GraphicsPath path = new();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
            path.AddArc(new Rectangle(this.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
            path.AddArc(new Rectangle(this.Width - borderRadius, this.Height - borderRadius, borderRadius, borderRadius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - borderRadius, borderRadius, borderRadius), 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using Pen pen = new(Color.Silver, 1);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, GetRoundedRectanglePath(this.ClientRectangle, borderRadius));
        }

        private static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new();
            path.StartFigure();
            path.AddArc(new Rectangle(rect.X, rect.Y, radius, radius), 180, 90);
            path.AddArc(new Rectangle(rect.Right - radius, rect.Y, radius, radius), 270, 90);
            path.AddArc(new Rectangle(rect.Right - radius, rect.Bottom - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(rect.X, rect.Bottom - radius, radius, radius), 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
