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
        string query1 = "Select * from tblSeller";
        public frmManageSellers()
        {
            InitializeComponent();
            showData(query1);
        }
        private void frmManageSellers_Load(object sender, EventArgs e)
        {
            showData(query1);
        }
        private void foxButton4_Click(object sender, EventArgs e)
        {

            string name = txtBoxName.CustomText;
            string userAccount = txtBoxUserAccount.CustomText;
            string password = txtBoxPassword.CustomText;
            string phoneNumber = txtBoxPhone.CustomText;
            string address = txtBoxAddress.CustomText;
            string insertQuery = "INSERT INTO tblSeller (name, userAccount, password, phone, address) VALUES (N'" + name + "', N'" + userAccount + "', '" + password + "', '" + phoneNumber + "', '" + address + "')";
            excuteSql(insertQuery,"isAdd"); 
            showData(query1);
        }
        private void foxButton2_Click(object sender, EventArgs e)
        {
            string name = txtBoxName.CustomText;
            string userAccount = txtBoxUserAccount.CustomText;
            string password = txtBoxPassword.CustomText;
            string phoneNumber = txtBoxPhone.CustomText;
            string address = txtBoxAddress.CustomText;
            string updateSQL = "update tblSeller set name='" + name + "',userAccount='" + userAccount + "',password='" + password + "',phone='" + phoneNumber + "',address=N'" + address + "' where id='"+txtBoxUserID.CustomText+"'";
            excuteSql(updateSQL,"isEdit");
            showData(query1); 


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
        public  void excuteSql(string query, string isAdd)
        {
            if (txtBoxName.CustomText.Trim() == "" || txtBoxUserAccount.CustomText.Trim() == "" || txtBoxPassword.CustomText.Trim() == "" || txtBoxPhone.CustomText.Trim() == "" || txtBoxAddress.CustomText.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin của nhân viên");
            }
            else
            {
                DataTable dt = process.DataReader("Select userAccount from tblSeller where UserAccount='" + txtBoxUserAccount.CustomText + "'");
                if (dt.Rows.Count > 0 && isAdd=="isAdd" )
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
                    clearData();
                    MessageBox.Show("Thao tác thành công");
                }
            }
        }
        public void showData(string query)
        {
            dataGrSeller.Rows.Clear();
            DataTable dt = process.DataReader(query);
            foreach( DataRow row in  dt.Rows )
            {
                dataGrSeller.Rows.Add(
                row["id"].ToString(),
                row["name"].ToString(),
                row["userAccount"].ToString(),
                row["password"].ToString(),
                row["phone"].ToString(),
                row["address"].ToString()
            );
            }
        }
        public void clearData()
        {
            txtBoxUserID.CustomText = "";
            txtBoxName.CustomText = "";
            txtBoxUserAccount.CustomText = "";
            txtBoxPassword.CustomText = "";
            txtBoxPhone.CustomText = "";
            txtBoxAddress.CustomText = "";
            add_seller.Enabled = true;  
            edit_seller.Enabled = false;
        }

        private void dataGrSeller_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            add_seller.Enabled = false;
            if(edit_seller.Enabled==false)
                   edit_seller.Enabled=true;
            int rowindex=e.RowIndex;
            txtBoxUserID.CustomText = dataGrSeller.Rows[rowindex].Cells[0].Value.ToString();
            txtBoxName.CustomText = dataGrSeller.Rows[rowindex].Cells[1].Value.ToString();
            txtBoxUserAccount.CustomText = dataGrSeller.Rows[rowindex].Cells[2].Value.ToString();
            txtBoxPassword.CustomText = dataGrSeller.Rows[rowindex].Cells[3].Value.ToString();
            txtBoxPhone.CustomText = dataGrSeller.Rows[rowindex].Cells[4].Value.ToString();
            txtBoxAddress.CustomText = dataGrSeller.Rows[rowindex].Cells[5].Value.ToString();

        }

        private void delete_seller_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa '" + txtBoxName.CustomText + "' ra khỏi hệ thống không?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
            if( result == DialogResult.OK)
            {

                process.DataChange("delete from tblSeller where id='" + txtBoxUserID.CustomText + "'");
                MessageBox.Show("Xóa thành công");
                clearData();
                showData(query1);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            string query = "SELECT * FROM tblSeller WHERE name = N'" + searchText + "' OR phone = N'" + searchText + "'";

            int id;
            if (int.TryParse(searchText, out id))
            {
                query = "SELECT * FROM tblSeller WHERE id = " + id + " OR name = N'" + searchText + "' OR phone = N'" + searchText + "'";
            }
            if(txtSearch.Text.Trim()=="")
                query = "SELECT * FROM tblSeller";
            showData(query);

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search";
            }
        }

    }
}
