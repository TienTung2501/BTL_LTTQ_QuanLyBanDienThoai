using BTL_LTTQ_QuanLyBanDienThoai.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_QuanLyBanDienThoai
{
    
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }
        Classes.DataBaseProcess data = new Classes.DataBaseProcess();
        
        private void frmSetting_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tblSeller WHERE id ='" + Constants.userId + "'";
            if (data.DataReader(query).Rows.Count > 0) {
                lbUser.Text += data.DataReader(query).Rows[0]["userAccount"].ToString();
                lbPass.Text += data.DataReader(query).Rows[0]["password"].ToString();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {

            if (txtNewPassword.Text.Trim() == "" || txtConfirmPassword.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mật khẩu bạn muốn thay đổi");
            }
            else
            {
                string check = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).{8,}$";

                if (Regex.IsMatch(txtNewPassword.Text, check))
                {
                    if (txtNewPassword.Text == txtConfirmPassword.Text)
                    {
                        data.DataChange("Update tblSeller set password='" + txtNewPassword.Text + "'where id='" + Constants.userId + "'");
                        MessageBox.Show("Đổi mật khẩu thành công");
                        lbPass.Text = "Password: " + txtNewPassword.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập mật khẩu có tối thiểu 1 kí tự viết hoa, 1 kí tự thường, 1 số và" +
                        " chữ kí tự đặc biệt và có độ dài tối thiểu 8");
                }
               
            }
          
        }
       
    }
}
