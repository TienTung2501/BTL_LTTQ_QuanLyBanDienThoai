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
        DataBaseProcess process = new DataBaseProcess();
        private int sellerId;
        private string sellerName;
        private int productCurrentID;
      /*  private bool totalProduct = false;*/
        public frmOrders()
        {
            InitializeComponent();
            DataTable dt = process.DataReader("Select id,name from tblSeller where id=" + Classes.Constants.userId + "");
            if (dt.Rows.Count > 0)
            {
                this.sellerId = (int)dt.Rows[0]["id"];
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
            string fileAnh = "";
            int rowindex = e.RowIndex;
            productCurrentID = int.Parse(dataGrProduct.Rows[rowindex].Cells[0].Value.ToString());
            txtProductName.CustomText = dataGrProduct.Rows[rowindex].Cells[1].Value.ToString();
            txtCategory.CustomText = dataGrProduct.Rows[rowindex].Cells[2].Value.ToString();
            txtProductPrice.CustomText = dataGrProduct.Rows[rowindex].Cells[4].Value.ToString();
            string debugFolder = AppDomain.CurrentDomain.BaseDirectory;
            DataTable dt = process.DataReader("Select image from tblProduct where id=" + productCurrentID + "");
            if (dt != null)
            {
                fileAnh = dt.Rows[0]["image"].ToString();
            }
            // Tên tệp tin ảnh trong thư mục "images" (thay bằng tên tệp tin thực tế)
            string imageName = "images/" + fileAnh + "";

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
            totalProduct();


        }


        public void totalProduct()
        {
            int price = 0;
            int discount = 0;
            int quantity = 0;

            if (txtProductQuantity.CustomText != "" && txtDiscount.CustomText != "")
            {
                if (int.TryParse(txtProductQuantity.CustomText, out quantity) &&
                    int.TryParse(txtDiscount.CustomText, out discount))
                {
                    if (txtProductPrice.CustomText.Trim() != "" &&
                        int.TryParse(txtProductPrice.CustomText, out price))
                    {
                        txtTotalProduct.CustomText = ((int)(quantity * (100 - discount) * price / 100)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bạn cần chọn sản phẩm");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập số lượng và giảm giá là số nguyên");
                }
            }
        }

        private void txtProductQuantity_TxtBoxTextChanged(object sender, EventArgs e)
        {
            if (!ignoreTextChange)
            {
                totalProduct();
            }
        }

        private void txtDiscount_TxtBoxTextChanged(object sender, EventArgs e)
        {
            if (!ignoreTextChange)
            {
                totalProduct();
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



        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            if (txtProductName.CustomText.Trim() == "" || txtProductPrice.CustomText.Trim() == "" || txtCategory.CustomText.Trim() == "" || txtProductQuantity.CustomText == "" || txtDiscount.CustomText == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin sản phẩm");
            }
            else
            {
                int delta = int.Parse(txtProductQuantity.CustomText);
                if (dataGrBilldetail.Rows.Count == 0)
                {
                    if (checkSoLuong(delta, productCurrentID, 0))
                    {
                        updateSoluong(delta, productCurrentID, 0);
                        showDataBillDetail();
                    }
                    else
                        MessageBox.Show("Không còn sản phẩm");

                }
                else
                {

                foreach( DataGridViewRow row in dataGrBilldetail.Rows)
                    {
                        if (int.Parse(row.Cells[0].Value.ToString()) == productCurrentID)
                        {
                            int numOnBill = int.Parse(row.Cells[4].Value.ToString());
                            if (checkSoLuong(delta, productCurrentID, numOnBill))
                            {
                                updateSoluong(delta, productCurrentID, numOnBill);
                                showDataBillDetail();
                            }  
                            else
                                MessageBox.Show("Không còn sản phẩm");
                        }
                    }
                }
            }
        }

        public void showDataBillDetail()
        {
            dataGrBilldetail.Rows.Clear();
            DataTable dt = process.DataReader("Select * from tblBillDetail");

            foreach (DataRow row in dt.Rows)
            {
                dataGrBilldetail.Rows.Add(
                    row["product_id"],
                    txtProductName.CustomText,
                    int.Parse(txtProductPrice.CustomText),
                    row["quantity"].ToString(),
                    row["price"].ToString(),
                    row["total"].ToString()
                );
            }
        }

        public bool checkSoLuong(int delta, int ProductId, int numOnBill)
        {
            foreach (DataGridViewRow row in dataGrProduct.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (int.Parse(row.Cells[0].Value.ToString()) == ProductId)
                    {
                        if (int.Parse(row.Cells[3].Value.ToString()) + numOnBill <= delta)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void updateSoluong(int delta, int ProductId, int numOnBill)
        {
                string query = "update tblProduct set quantity=" + delta + " WHERE id = " + ProductId;
                process.DataChange(query);
                showProduct();
        }

        private void btn_createID_Click(object sender, EventArgs e)
        {
            if (txtBillID.CustomText.Trim() == "")
            {
                string BillID = "Bill_";
                DateTime dt = DateTime.Now;
                int day = dt.Day;
                int month = dt.Month;
                int year = dt.Year;
                int hour = dt.Hour;
                int minute = dt.Minute;
                int second = dt.Second;
                BillID += day.ToString() + month.ToString() + year.ToString() + "_" + hour.ToString() + minute.ToString() + second.ToString();
                txtBillID.CustomText = BillID;

            }
        }
    }
}
