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
    public partial class FrmProcessBar : Form
    {
        public FrmProcessBar()
        {
            InitializeComponent();
        }

        private void FrmProcessBar_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                if (progressBar1.Value < 30)
                {
                    progressBar1.Value += 1;
                }
                else if (progressBar1.Value < 80)
                {
                    progressBar1.Value += 5;
                }
                else
                {
                    progressBar1.Value += 10;
                }
                progressBar1.ForeColor = Color.DeepSkyBlue;
                percenLoad.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                this.Hide();
                Form formLogin = new frmLogin();
                formLogin.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
