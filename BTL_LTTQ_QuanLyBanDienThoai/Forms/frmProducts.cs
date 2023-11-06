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
    public partial class frmProducts : Form
    {
        Classes.CommonFunctions function = new Classes.CommonFunctions();
        Classes.DataBaseProcess data = new Classes.DataBaseProcess();
        public string fileAnh;
        public frmProducts()
        {
            InitializeComponent();
            LoadData();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            function.FillComboBox(cboCategory1, data.DataReader("Select * from tblCategory"), "Name", "Name");
            function.FillComboBox(cboCategory2, data.DataReader("Select * from tblCategory"), "Name", "Name");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string[] image;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPEG Images|*.jpg|PNG Images|*.png|All files|*.*";
            openFile.FilterIndex = 1;
            openFile.InitialDirectory = Application.StartupPath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFile.FileName);
                image = openFile.FileName.ToString().Split('\\');
                fileAnh = image[image.Length - 1];

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.CustomText) || string.IsNullOrEmpty(txtPrice.CustomText) ||
                string.IsNullOrEmpty(txtQuantity.CustomText) || string.IsNullOrEmpty(txtDesc.CustomText) ||
                string.IsNullOrEmpty(cboCategory1.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int categoryid = int.Parse(data.DataReader("Select id from tblCategory where name= N'" + cboCategory1.Text + "'").Rows[0]["id"].ToString());
                string query = "Insert into tblProduct (name,categoryId,quantity,price,image,description) Values(N'"+txtName.CustomText +"',"+categoryid+","+int.Parse(txtQuantity.CustomText)+","+int.Parse(txtPrice.CustomText)+",N'"+fileAnh+"',N'"+txtDesc.CustomText+"')";
                data.DataChange(query);
                MessageBox.Show("Thêm sản phẩm thành công");
                LoadData();
                ResetValue();
            }   

        }
        void LoadData()
        {
            DataTable Products = data.DataReader("Select * From tblProduct");
            dgvProducts.DataSource = Products;
            dgvProducts.Columns[0].HeaderText = "ID";
            dgvProducts.Columns[1].HeaderText = "Name";
            dgvProducts.Columns[2].HeaderText = "CategoryID";
            dgvProducts.Columns[3].HeaderText = "Quantity";
            dgvProducts.Columns[4].HeaderText = "Price";
            dgvProducts.Columns[5].HeaderText = "Image";
            dgvProducts.Columns[6].HeaderText = "Description";
        }
       void ResetValue()
        {
            // Xóa trắng các TextBox nhập liệu
            txtID.CustomText = "";
            txtName.CustomText = "";
            cboCategory1.Text = "";
            txtQuantity.Text = "";
            txtPrice.CustomText = "";
            pictureBox2.Image = null;
            fileAnh = "";
            txtName.Focus();
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Từ chối ký tự không hợp lệ
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Từ chối ký tự không hợp lệ
            }
        }
    }
}
