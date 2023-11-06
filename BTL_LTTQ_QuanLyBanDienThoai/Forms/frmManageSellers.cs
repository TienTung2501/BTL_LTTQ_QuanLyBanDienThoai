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
    public partial class frmManageSellers : Form
    {
        DataBaseProcess process=new DataBaseProcess();
        public frmManageSellers()
        {
            InitializeComponent();
        }

        private void foxButton4_Click(object sender, EventArgs e)
        {

            string name = txtBoxName.CustomText;
            string userAccount = txtBoxUserAccount.CustomText;
            string password = txtBoxPassword.CustomText;
            string phoneNumber = txtBoxPhone.CustomText;
            string address = txtBoxAddress.CustomText;
            string insertQuery = "INSERT INTO tblSeller (name, userAccount, password, phone, address) VALUES (N'" + name + "', N'" + userAccount + "', '" + password + "', '" + phoneNumber + "', '" + address + "')";
            excuteSql(insertQuery);

        }
        private void foxButton2_Click(object sender, EventArgs e)
        {
            string name = txtBoxName.CustomText;
            string userAccount = txtBoxUserAccount.CustomText;
            string password = txtBoxPassword.CustomText;
            string phoneNumber = txtBoxPhone.CustomText;
            string address = txtBoxAddress.CustomText;
            string updateSQL = "update tblSeller set name='" + name + "','" + userAccount + "','" + password + "','" + phoneNumber + "','" + address + "' where id='"+txtBoxUserID.CustomText+"'";
            excuteSql(updateSQL);

        }
        public int CheckValidPhone(string phoneNumber)
        {
            string pattern = @"^(03|09)\d{8}$";
            if (Regex.IsMatch(phoneNumber, pattern))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public int checkValidPassword(string password)
        {
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).{8,}$";

            if (Regex.IsMatch(password, pattern))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public  void excuteSql(string query)
        {
            if (txtBoxName.CustomText.Trim() == "" || txtBoxUserAccount.CustomText.Trim() == "" || txtBoxPassword.CustomText.Trim() == "" || txtBoxPhone.CustomText.Trim() == "" || txtBoxAddress.CustomText.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin của nhân viên");
            }
            else
            {
                DataTable dt = process.DataReader("Select userAccount from tblSeller where UserAccount='" + txtBoxUserAccount.CustomText + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại vui lòng nhập tên tài khoản khác");
                }
                else if (CheckValidPhone(txtBoxPhone.CustomText) == -1)
                {
                    MessageBox.Show("Bạn cần nhập đúng định dạng số điện thoại. Số điện thoại hợp lệ phải bắt đầu là 03 hoặc 09 và có chiều dài 10");
                }
                else if (checkValidPassword(txtBoxPassword.CustomText) == -1)
                {
                    MessageBox.Show("Bạn cần nhập mật khẩu có tối thiểu 1 kí tự viết hoa, 1 kí tự thường, 1 số và chứ kí tự đặc biệt và có độ dài tối thiểu 8");
                }
                else
                {
                    process.DataChange(query);
                    MessageBox.Show("Thao tác thành công");
                }
            }
        }
       
    }
}
