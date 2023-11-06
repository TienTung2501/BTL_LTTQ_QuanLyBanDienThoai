using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_LTTQ_QuanLyBanDienThoai.Component
{
    public partial class TxtBox : UserControl
    {
        public TxtBox()
        {
            InitializeComponent();
        }
        private Color borderColor = Color.DeepSkyBlue;
        private int borderSize = 2;
        private bool underLineStyle = false;

        public Color BorderColor1
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate(); // Khi màu viền thay đổi, vẽ lại UserControl
            }
        }

        public int BorderSize1
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Invalidate(); // Khi độ dày viền thay đổi, vẽ lại UserControl
            }
        }

        public bool UnderLineStyle
        {
            get => underLineStyle;
            set
            {
                underLineStyle = value;
                Invalidate(); // Khi chế độ viền thay đổi, vẽ lại UserControl
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (underLineStyle)
            {
                using (Pen pen = new Pen(borderColor, borderSize))
                {
                    e.Graphics.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);
                }
            }
        }
        public string CustomText
        {
            get { return txtOnUserControl.Text; }
            set { txtOnUserControl.Text = value; }
        }

    }
}
