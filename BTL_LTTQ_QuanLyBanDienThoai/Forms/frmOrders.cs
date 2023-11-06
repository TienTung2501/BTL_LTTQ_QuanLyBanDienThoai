using BTL_LTTQ_QuanLyBanDienThoai.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BTL_LTTQ_QuanLyBanDienThoai
{
    public partial class frmOrders : Form
    {
        private bool ignoreTextChange = false;
        MainForm mainForm = new MainForm();
        DataBaseProcess process=new DataBaseProcess();
        private int sellerId;
        private string sellerName;
        public frmOrders()
        {
            InitializeComponent();
            DataTable dt = process.DataReader("Select id,name from tblSeller where id="+Classes.Constants.userId+"");
            if(dt.Rows.Count > 0)
            {
                this.sellerId =(int) dt.Rows[0]["id"];
                this.sellerName = dt.Rows[0]["name"].ToString();
            }

        }
        private void frmOrders_Load(object sender, EventArgs e)
        {
            Seller_ID.Text = sellerId.ToString();
            NameSeller.Text = sellerName.ToString();
            /*string dataproduct = "Select tblProduct.id as id, tblProduct.name as productName,tblCategory.name as categoryName,quantity,price from tblProduct inner join tblCategory on tblProduct.CategoryId=tblCategory.id";*/
            txtTotalProduct.Text = "0";
            showProduct();

        }
        public void showProduct()
        {
            string dataproduct = "Select tblProduct.id as id, tblProduct.name as productName,tblCategory.name as categoryName,quantity,price from tblProduct inner join tblCategory on tblProduct.CategoryId=tblCategory.id";
            dataGrProduct.Rows.Clear();
            DataTable dt = process.DataReader(dataproduct);
            foreach (DataRow row in dt.Rows)
            {
                dataGrProduct.Rows.Add(
                row["id"],
                row["productName"].ToString(),
                row["categoryname"].ToString(),
                row["quantity"].ToString(),
                row["price"].ToString()
            );
            }
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

        private void dataGrProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string fileAnh="";
            int rowindex=e.RowIndex;
            int productId =int.Parse(dataGrProduct.Rows[rowindex].Cells[0].Value.ToString());
            txtProductName.CustomText = dataGrProduct.Rows[rowindex].Cells[1].Value.ToString();
            txtCategory.CustomText= dataGrProduct.Rows[rowindex].Cells[2].Value.ToString();
            txtProductPrice.CustomText= dataGrProduct.Rows[rowindex].Cells[4].Value.ToString();
            string debugFolder = AppDomain.CurrentDomain.BaseDirectory;
            totalProduct();
            DataTable dt = process.DataReader("Select image from tblProduct where id="+productId+"");
            if (dt != null)
            {
             fileAnh = dt.Rows[0]["image"].ToString();
            }
            // Tên tệp tin ảnh trong thư mục "images" (thay bằng tên tệp tin thực tế)
            string imageName = "images/"+fileAnh+"";

            // Tạo đường dẫn đầy đủ tới tệp tin ảnh
            string imagePath = Path.Combine(debugFolder, imageName);

            if (File.Exists(imagePath))
            {
                // Kiểm tra xem tệp tin ảnh tồn tại
                Image image = Image.FromFile(imagePath);
                pictureProduct.Image = image;
            }
            else
            {
                // Xử lý trường hợp không tìm thấy tệp tin ảnh
                MessageBox.Show("Không tìm thấy tệp tin ảnh.");
            }


        }

            
        public void totalProduct()
        {
            if(txtDiscount.CustomText.Trim()!=""&& txtProductQuantity.CustomText.Trim() != "")
            {
                int price = int.Parse(txtProductPrice.CustomText);
                int discount = int.Parse(txtDiscount.CustomText);
                int quantity = int.Parse(txtProductQuantity.CustomText);
                txtTotalProduct.CustomText = ((int)(quantity * (100 - discount) * price / 100)).ToString();
            }
               
        }

        public void clearDataProduct()
        {
            ignoreTextChange = true; // Tạm thời tắt sự kiện TextChange
            txtProductName.CustomText = "";
            txtCategory.CustomText = "";
            txtProductPrice.CustomText = "";
            txtDiscount.CustomText = "";
            txtProductQuantity.CustomText = "";
            txtTotalProduct.CustomText = "";
            pictureProduct.Image = null;
            ignoreTextChange = false; // Bật lại sự kiện TextChange
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            clearDataProduct();
        }

        private void txtProductQuantity_TxtBoxTextChanged(object sender, EventArgs e)
        {
            if (!ignoreTextChange)
            {

                if (txtDiscount.CustomText.Trim()!="")
            {
                if (txtProductName.CustomText.Trim() == "" || txtProductPrice.CustomText.Trim() == "" || txtCategory.CustomText.Trim() == "")
                {
                    MessageBox.Show("Bạn cần chọn sản phẩm");
                }
                else if (!int.TryParse(txtProductQuantity.CustomText.Trim(), out int quantity))
                {
                    MessageBox.Show("Bạn cần nhập đúng định số lượng");
                    txtProductQuantity.Focus();
                }
                else
                {
                    totalProduct();
                }

            }
            }  

        }

        private void txtDiscount_TxtBoxTextChanged(object sender, EventArgs e)
        {
            if (!ignoreTextChange)
            {

                if (txtProductQuantity.CustomText.Trim() != "")
            {
                if (txtProductName.CustomText.Trim() == "" || txtProductPrice.CustomText.Trim() == "" || txtCategory.CustomText.Trim() == "")
                {
                    MessageBox.Show("Bạn cần chọn sản phẩm");
                }
                else if (!int.TryParse(txtDiscount.CustomText.Trim(), out int discount))
                {
                    MessageBox.Show("Bạn cần nhập đúng định dạng giảm giá");
                    txtDiscount.Focus();
                }
                else
                {
                    totalProduct();
                }
            }
            }
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            if(txtProductName.CustomText.Trim() == "" || txtProductPrice.CustomText.Trim() == "" || txtCategory.CustomText.Trim() == "" || txtProductQuantity.CustomText == "" || txtDiscount.CustomText == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin sản phẩm");
            }
/*            else
            {
                int delta=int.Parse(txtProductQuantity.CustomText);
                

                updateSoluong();
            }*/
        }
        
        public void updateSoluong(int delta,int ProductId,int numOnBill)
        {
            
            foreach (DataGridViewRow row in dataGrProduct.Rows)
            {
                if (int.Parse(row.Cells[0].Value.ToString()) == ProductId)
                {
                    if (int.Parse(row.Cells[3].Value.ToString())+ numOnBill <= delta)
                    {
                        string query = "update tblProduct set quantity=" + delta + "";
                        process.DataChange(query);
                        showProduct();
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm hiện tại đã hết vui lòng chọn sản phẩm khác");
                    }
                }
            }
           
        }
    }
}
