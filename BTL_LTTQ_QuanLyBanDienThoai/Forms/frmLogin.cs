using BTL_LTTQ_QuanLyBanDienThoai.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_LTTQ_QuanLyBanDienThoai
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        DataBaseProcess data = new DataBaseProcess();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUsername.Text.ToString();

            string Password = txtPassword.Text;
            string query = "SELECT id FROM tblSeller WHERE userAccount ='" + UserName + "' AND password ='" + Password + "'";
           
            if (data.DataReader(query).Rows.Count > 0 )
            {
                Constants.userId = int.Parse(data.DataReader(query).Rows[0]["id"].ToString());
                Constants.isLogin = true;
             
                MainForm frmMain = new MainForm();
                frmMain.ShowDialog();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng !!!" + Password);
                txtUsername.Focus();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void airButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
