using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            LoadData();
            ResetValue();
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
                // Thư mục đích để sao chép ảnh đến
                string destinationFolder = Application.StartupPath + "\\images\\";

                // Tạo đường dẫn hoàn chỉnh đến tệp ảnh đích
                string destinationPath = Path.Combine(destinationFolder, fileAnh);

                // Sao chép tệp ảnh từ vị trí hiện tại đến thư mục đích
                File.Copy(openFile.FileName, destinationPath);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.CustomText) || string.IsNullOrEmpty(txtPrice.Text) ||
                string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtDesc.CustomText) ||
                string.IsNullOrEmpty(cboCategory1.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int categoryid = int.Parse(data.DataReader("Select id from tblCategory where name= N'" + cboCategory1.Text + "'").Rows[0]["id"].ToString());
                string query = "Insert into tblProduct (name,categoryId,quantity,price,image,description) Values(N'"+txtName.CustomText +"',"+categoryid+","+int.Parse(txtQuantity.Text)+","+int.Parse(txtPrice.Text)+",N'"+fileAnh+"',N'"+txtDesc.CustomText+"')";
                data.DataChange(query);

                MessageBox.Show("Thêm sản phẩm thành công");
                LoadData();
                ResetValue();
            }   

        }
        void LoadData()
        {
            DataTable Products = data.DataReader("Select tblProduct.id,tblProduct.name,tblProduct.price,tblProduct.quantity,tblCategory.name,tblProduct.image,tblproduct.description From tblProduct inner join tblCategory on tblProduct.CategoryId =tblCategory.id");
            dgvProducts.DataSource = Products;
            dgvProducts.Columns[0].HeaderText = "ID";
            dgvProducts.Columns[1].HeaderText = "Name";
            dgvProducts.Columns[2].HeaderText = "Price";
            dgvProducts.Columns[3].HeaderText = "Quantity";
            dgvProducts.Columns[4].HeaderText = "Category";
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
            txtPrice.Text = "";
            txtDesc.CustomText = "";
            cboCategory2.Text = "";
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.CustomText) || string.IsNullOrEmpty(txtPrice.Text) ||
                string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtDesc.CustomText) ||
                string.IsNullOrEmpty(cboCategory1.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int categoryid = int.Parse(data.DataReader("Select id from tblCategory where name= N'" + cboCategory1.Text + "'").Rows[0]["id"].ToString());
                string query = "Update tblProduct set name = N'" + txtName.CustomText + "',categoryId=" + categoryid + ",quantity=" + int.Parse(txtQuantity.Text) + ",price =" + int.Parse(txtPrice.Text) + ",image=N'" + fileAnh + "',description=N'" + txtDesc.CustomText + "'";
                data.DataChange(query);
                MessageBox.Show("Thay đổi thông tin sản phẩm thành công");
                LoadData();
                ResetValue();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.CustomText = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtName.CustomText = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            txtQuantity.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            cboCategory1.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
            fileAnh = dgvProducts.CurrentRow.Cells[5].Value.ToString();
            txtDesc.CustomText = dgvProducts.CurrentRow.Cells[6].Value.ToString();
   
            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\images\\" + fileAnh); //Application.StartupPath là một thuộc tính của ứng dụng Windows Forms
                                                                                                 //cho biết thư mục trong đó ứng dụng được khởi chạy.
            }
            catch
            {
                pictureBox2.Image = null;
            }
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Delete Products",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    data.DataChange("delete tblProduct where id='" + int.Parse(txtID.CustomText) + "'");
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

        private void cboCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Products = data.DataReader("Select tblProduct.id,tblProduct.name,tblProduct.price,tblProduct.quantity,tblCategory.name,tblProduct.image,tblproduct.description From tblProduct inner join tblCategory on tblProduct.CategoryId =tblCategory.id where tblCategory.name='"+cboCategory2.Text+"'");
            dgvProducts.DataSource = Products;
            dgvProducts.Columns[0].HeaderText = "ID";
            dgvProducts.Columns[1].HeaderText = "Name";
            dgvProducts.Columns[2].HeaderText = "Price";
            dgvProducts.Columns[3].HeaderText = "Quantity";
            dgvProducts.Columns[4].HeaderText = "Category";
            dgvProducts.Columns[5].HeaderText = "Image";
            dgvProducts.Columns[6].HeaderText = "Description";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Từ chối ký tự không hợp lệ
            }
        }

        private void txtQuantity_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Từ chối ký tự không hợp lệ
            }
        }
    }
}
