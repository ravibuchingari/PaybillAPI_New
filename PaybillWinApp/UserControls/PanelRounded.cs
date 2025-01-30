using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace PayBillApp.WinApp.UserControls
{
    public class PanelRounded : Panel
    {
        private int edge = 20;
        private Color borderColor = Color.White;
        private readonly float penWidth = 2.0F;
        private Pen pen = new(Color.White, 2.0F);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Edge
        {
            get
            {
                return edge;
            }
            set
            {
                edge = value;
                Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                pen = new Pen(borderColor, penWidth);
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ExtendedDraw(e);
            DrawBorder(e.Graphics);
        }
        private void ExtendedDraw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new();
            path.StartFigure();
            path.StartFigure();
            path.AddArc(GetLeftUpper(Edge), 180, 90);
            path.AddLine(Edge, 0, Width - Edge, 0);
            path.AddArc(GetRightUpper(Edge), 270, 90);
            path.AddLine(Width, Edge, Width, Height - Edge);
            path.AddArc(GetRightLower(Edge), 0, 90);
            path.AddLine(Width - Edge, Height, Edge, Height);
            path.AddArc(GetLeftLower(Edge), 90, 90);
            path.AddLine(0, Height - Edge, 0, Edge);
            path.CloseFigure();
            Region = new Region(path);
        }
        private Rectangle GetLeftUpper(int e)
        {
            return new Rectangle(0, 0, e, e);
        }
        private Rectangle GetRightUpper(int e)
        {
            return new Rectangle(Width - e, 0, e, e);
        }
        private Rectangle GetRightLower(int e)
        {
            return new Rectangle(Width - e, Height - e, e, e);
        }
        private Rectangle GetLeftLower(int e)
        {
            return new Rectangle(0, Height - e, e, e);
        }
        private void DrawBorder(Graphics graphics)
        {
            graphics.DrawArc(pen, new Rectangle(0, 0, Edge, Edge), 180, 90);
            graphics.DrawArc(pen, new Rectangle(Width - Edge - 1, -1, Edge, Edge), 270, 90);
            graphics.DrawArc(pen, new Rectangle(Width - Edge - 1, Height - Edge - 1, Edge, Edge), 0, 90);
            graphics.DrawArc(pen, new Rectangle(0, Height - Edge - 1, Edge, Edge), 90, 90);
            graphics.DrawRectangle(pen, 0.0F, 0.0F, Width - 1, Height - 1);
        }

    }
}
