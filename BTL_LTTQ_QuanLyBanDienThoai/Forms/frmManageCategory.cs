using BTL_LTTQ_QuanLyBanDienThoai.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BTL_LTTQ_QuanLyBanDienThoai
{
    public partial class frmManageCategory : Form
    {
        DataBaseProcess data = new DataBaseProcess();
        public frmManageCategory()
        {
            InitializeComponent();
            LoadData();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtName.CustomText.Trim()=="" || txtDesc.CustomText.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập thông tin đầy đủ !");
            }
            else
            {
                DataTable query = data.DataReader("Select * From tblCategory where name = '" + txtName.CustomText + "'");
                if (query.Rows.Count >0)
                {
                    lbWarning.Text = "Danh mục này đã tồn tại, mời nhập danh mục khác!!!";
                    txtName.CustomText = "";
                }
                else
                {
                    string query2= "INSERT INTO tblCategory (name, description) VALUES (N'" + txtName.CustomText + "', N'" + txtDesc.CustomText +"')";
                    data.DataChange(query2);
                    MessageBox.Show("Thêm thành công !!!");
                    LoadData();
                    ResetValue();
                }

            }
        }
        void LoadData()
        {
            DataTable Category = data.DataReader("Select * From tblCategory");
            dgvCategory.DataSource= Category;
            dgvCategory.Columns[0].HeaderText = "ID";
            dgvCategory.Columns[1].HeaderText = "Name";
            dgvCategory.Columns[2].HeaderText = "Description";
        }
        void ResetValue()
        {
            txtID.CustomText = "";
            txtName.CustomText = "";
            txtDesc.CustomText = "";
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.CustomText.Trim() == "" || txtDesc.CustomText.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập thông tin đầy đủ !");
            }
            else
            {
                DataTable query = data.DataReader("Select * From tblCategory where name = '" + txtName.CustomText + "'");

                    string query2 = "Update  tblCategory  set name = N'" + txtName.CustomText + "',description= N'" + txtDesc.CustomText + "' where id='"+int.Parse(txtID.CustomText)+"'";
                    data.DataChange(query2);
                    MessageBox.Show("Sửa thành công !!!");
                    LoadData();
                    ResetValue();
                btnAdd.Enabled = true;
                btnEdit.Enabled =false;
                btnDelete.Enabled = false;


            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.CustomText = dgvCategory.CurrentRow.Cells[0].Value.ToString();
            txtName.CustomText = dgvCategory.CurrentRow.Cells[1].Value.ToString();
            txtDesc.CustomText = dgvCategory.CurrentRow.Cells[2].Value.ToString();
            btnAdd.Enabled = false; 
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    data.DataChange("delete tblCategory where id='" + int.Parse(txtID.CustomText) + "'");
                    LoadData();
                    ResetValue();
                    MessageBox.Show("Xóa thành công !!!");
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến bảng nào đó");
                }
        }
    }
}
