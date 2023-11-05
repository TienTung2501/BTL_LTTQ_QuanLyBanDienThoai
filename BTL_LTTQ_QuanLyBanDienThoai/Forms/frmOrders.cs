using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_QuanLyBanDienThoai
{
    public partial class frmOrders : Form
    {
        MainForm mainForm = new MainForm();
        public frmOrders()
        {
            InitializeComponent();
        }

        public static implicit operator frmOrders(frmManageSellers v)
        {
            throw new NotImplementedException();

        }

        private void btn_backtoHome_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            mainForm.ShowDialog();
        }

        private void airButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
