using BTL_LTTQ_QuanLyBanDienThoai.Classes;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
        private bool isUpdateBill=false;
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
            showDataBill();
            dataGrBilldetail.Rows.Clear();
            dateNow.Text = DateTime.Now.ToString("dd/MM/yyyy");

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
            if (string.IsNullOrEmpty(txtProductName.CustomText) || string.IsNullOrEmpty(txtProductPrice.CustomText) || string.IsNullOrEmpty(txtCategory.CustomText) || string.IsNullOrEmpty(txtProductQuantity.CustomText) || string.IsNullOrEmpty(txtDiscount.CustomText))
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin sản phẩm");
            }
            else
            {
                bool productFound = false;// tìm xem có sản phẩm đang muốn thêm trong datagr
                int delta = int.Parse(txtProductQuantity.CustomText);
                if (dataGrBilldetail.Rows.Count > 0)// datagrid view có sản phẩm hay không
                {
                    
                    foreach (DataGridViewRow row in dataGrBilldetail.Rows)
                    {
                        if (int.TryParse(row.Cells[0].Value?.ToString(), out int productIdInRow))
                        {
                            if (productIdInRow == productCurrentID && int.TryParse(row.Cells[4].Value?.ToString(), out int numOnBill))
                            {
                                productFound = true;
                                if (checkSoLuongDu(delta, productCurrentID, numOnBill))
                                {

                                    DialogResult result = MessageBox.Show("Sản phẩm này đã có trong hóa đơn bạn có muốn thay đổi nó không?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                                    if (result == DialogResult.OK)
                                    {
                                        pushToBill(productFound);
                                    updateSoluongDataGrProduct(delta, productCurrentID, numOnBill);
                                    updatetotal();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Không còn sản phẩm 1");
                                }
                                break;
                            }
                        }
                    }

                    if (!productFound)// nếu trong datagr không có
                    {
                        if (checkSoLuongDu(delta, productCurrentID, 0))
                        {
                            pushToBill(productFound);
                            updateSoluongDataGrProduct(delta, productCurrentID, 0);
                            updatetotal();
                        }
                        else
                        {
                            MessageBox.Show("Không còn sản phẩm 2");
                        }
                    }
                }
                else// nếu trong datagr rỗng
                {
                    if (checkSoLuongDu(delta, productCurrentID, 0))
                    {
                        pushToBill(productFound);
                        updateSoluongDataGrProduct(delta, productCurrentID, 0);
                        updatetotal();
                    }
                    else
                    {
                        MessageBox.Show("Không còn sản phẩm 3");
                    }
                }
            }
        }
        public void pushToBill(bool found)
        {

            if (found)
            {
                if (dataGrBilldetail.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGrBilldetail.Rows)
                    {
                        if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int productIdInRow))
                        {
                            if (productIdInRow == productCurrentID)
                            {
                                if (int.TryParse(txtDiscount.CustomText, out int discount) && int.TryParse(txtProductQuantity.CustomText, out int quantity))
                                {
                                    row.Cells[3].Value = discount;
                                    row.Cells[4].Value = quantity;
                                    row.Cells[5].Value = int.Parse(txtTotalProduct.CustomText);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            else
            {
                dataGrBilldetail.Rows.Add(
                productCurrentID,
                txtProductName.CustomText,
                int.Parse(txtProductPrice.CustomText),
                int.Parse(txtDiscount.CustomText),
                int.Parse(txtProductQuantity.CustomText),
                int.Parse(txtTotalProduct.CustomText)
                );
            }
           
        }
        public bool checkSoLuongDu(int delta, int productId, int numOnBill)
        {
            foreach (DataGridViewRow row in dataGrProduct.Rows)
            {
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int productID))
                {
                    if (productID == productId && int.TryParse(row.Cells[3].Value.ToString(), out int currentQuantity))
                    {
                        if (currentQuantity + numOnBill < delta)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public void updateSoluongDataGrProduct(int delta, int productId, int numOnBill)
        {
            foreach (DataGridViewRow row in dataGrProduct.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (int.Parse(row.Cells[0].Value.ToString()) == productId)
                    {
                        row.Cells[3].Value = int.Parse(row.Cells[3].Value.ToString()) + numOnBill - delta;
                    }
                }
            }

        }
        // show dữ liệu của billdetail
        public void showDataBillDetail(string select)
        {
            dataGrBilldetail.Rows.Clear();
            DataTable dt = process.DataReader(select);

            foreach (DataRow row in dt.Rows)
            {
                dataGrBilldetail.Rows.Add(
                    row["id"],
                    row["name"],
                    row["price"],
                    row["discount"].ToString(),
                    row["quantity"].ToString(),
                    row["total"].ToString()
                );
            }
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
                btn_createID.Enabled = false;
            }
        }
        public void updatetotal()
        {
            int total = 0;
            if (dataGrBilldetail.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGrBilldetail.Rows)
                {
                    if (row.Cells[5].Value != null)
                    {
                        int cellValue;
                        if (int.TryParse(row.Cells[5].Value.ToString(), out cellValue))
                        {
                            total += cellValue;
                        }
                        txtTotalPay.CustomText = total.ToString();
                    }
                }
            }
        }
        public void showDataBill()
        {
            dataGrBill.Rows.Clear();
            string select = "select tblBill.id as id, tblCustomer.name as customerName,tblSeller.name as sellerName,tblBill.date as date,tblBill.total as total from tblBill inner join tblCustomer on tblBill.customer_id=tblCustomer.id inner join tblSeller on tblSeller.id=tblBill.seller_id";
            DataTable dt = process.DataReader(select);
            foreach (DataRow row in dt.Rows)
            {
                dataGrBill.Rows.Add(
                    row["id"],
                    row["customerName"],
                    row["sellerName"],
                    row["date"].ToString(),
                    row["total"].ToString()
                );
            }
        }
        private void btnSaveOder_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.CustomText == "" || txtCustomerPhone.CustomText == "" || txtCustomerAddress.CustomText == "") { 
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin bao gồm thông tin khách hàng và hàng cần mua");
            }
            else if (dataGrBilldetail.Rows.Count == 1)
            {
                MessageBox.Show("Nhập mặt hàng trước khi tạo hóa đơn");

            }
            else if (txtBillID.CustomText.Trim() == "")
            {
                MessageBox.Show("Tạo ID hóa đơn trước khi lưu");

            }
            else
            {
                if (isUpdateBill == true)
                {
                    updateBill();
                    isUpdateBill=false;
                }
                else
                {

                updateQuantityToDatabase();
                addBill();
                }
            }
            
        }
        public void updateQuantityToDatabase()
        {
            if (dataGrProduct.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGrProduct.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[3].Value != null)
                    {
                        int productId = Convert.ToInt32(row.Cells[0].Value);
                        int quantity = Convert.ToInt32(row.Cells[3].Value);

                        string updateQuantityProduct = "UPDATE tblProduct SET quantity = " + quantity + " WHERE id = " + productId;
                        process.DataChange(updateQuantityProduct);
                    }
                }
            }
        }

        public void addBill()
        {
            string billId = txtBillID.CustomText;
            int customer_Id=0;
            int seller_id = sellerId;
            int total = int.Parse(txtTotalPay.CustomText);
            string customer_name = txtCustomerName.CustomText;
            string customerPhone = txtCustomerPhone.CustomText;
            string customerAddress = txtCustomerAddress.CustomText;
            string insertCustomer = "Insert into tblCustomer (name,phone,address) values(N'" + customer_name + "','" + customerPhone + "',N'" + customerAddress + "')";
            process.DataChange(insertCustomer);
            DataTable dt = process.DataReader("select id from tblCustomer where name=N'" + customer_name + "' and phone='" + customerPhone + "' and address=N'" + customerAddress + "'");
            if (dt.Rows.Count > 0)
            {
                customer_Id = int.Parse(dt.Rows[0]["id"].ToString());
            }
            string addBill = "insert into tblBill (id,seller_id,customer_id,date,total) values('" + txtBillID.CustomText + "','" + sellerId + "','" + customer_Id + "','" + DateTime.Now.ToString() + "','" + total + "')";
            process.DataChange(addBill);
            foreach (DataGridViewRow row in dataGrBilldetail.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[3].Value != null && row.Cells[4].Value != null && row.Cells[5].Value != null)
                {
                    int product_id = int.Parse(row.Cells[0].Value.ToString());
                    int discountdetail = int.Parse(row.Cells[3].Value.ToString());
                    int quantitydetail = int.Parse(row.Cells[4].Value.ToString());
                    int totalbilldetail = int.Parse(row.Cells[5].Value.ToString());
                    string addBillDetail = "insert into tblBillDetail (bill_id,product_id,quantity,discount,total) values('" + txtBillID.CustomText + "','" + product_id + "','" + quantitydetail + "','" + discountdetail + "','" + totalbilldetail + "')";
                    process.DataChange(addBillDetail);
                }
            }

            MessageBox.Show("Tạo hóa đơn thành công");
            btn_createID.Enabled = true;
            clearDataProduct();
            clearCustomerInfor();
            showDataBill();
        }
        public void clearCustomerInfor()
        {
            txtCustomerName.CustomText = "";
            txtCustomerPhone.CustomText = "";
            txtCustomerAddress.CustomText = "";
            txtTotalPay.CustomText = "";
            txtBillID.CustomText = "";
            dataGrBilldetail.Rows.Clear();
        }

        private void dataGrBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrBilldetail.Rows.Clear();
            int rowindex = e.RowIndex;
            string billId = dataGrBill.Rows[rowindex].Cells[0].Value.ToString();
            /*DataTable datauser = process.DataReader("select tblBill.id as id tblCustomer.id as customer_id, tblCustomer.name as name,tblCustomer.phone as phone,tblCustomer.address as address from tblBill inner join tblCustomer on tblBill.customer_id=tblCustomer.id where tblBill.id=" + billId + "");*/
            DataTable datauser = process.DataReader("SELECT tblBill.id AS id, tblCustomer.id AS customer_id, tblCustomer.name AS name, tblCustomer.phone AS phone, tblCustomer.address AS address FROM tblBill INNER JOIN tblCustomer ON tblBill.customer_id = tblCustomer.id WHERE tblBill.id ='"+ billId + "'");

            if (datauser.Rows.Count > 0 )
            {
                txtCustomerName.CustomText = datauser.Rows[0]["name"].ToString();
                txtCustomerPhone.CustomText = datauser.Rows[0]["phone"].ToString();
                txtCustomerAddress.CustomText = datauser.Rows[0]["address"].ToString();
            }
            txtBillID.CustomText = billId;
            string select = "SELECT tblProduct.id as id,tblProduct.name as name,tblBillDetail.quantity as quantity,tblBillDetail.discount discount,tblProduct.price as price,total from tblBillDetail inner join tblProduct on tblProduct.id=tblBillDetail.product_id where tblBillDetail.bill_id='" + billId+"'";
            showDataBillDetail(select);
            txtTotalPay.CustomText= dataGrBill.Rows[rowindex].Cells[4].Value.ToString();
            btn_createID.Enabled = false;
            isUpdateBill = true;
        }
        public void updateBill()
        {
            string upadteBill = "update tblBill set seller_id='" + sellerId + "',date='" + DateTime.Now.ToString() + "',total='" + int.Parse(txtTotalPay.CustomText) + "'where id='"+txtBillID.CustomText+"'";
            process.DataChange(upadteBill);
            if(dataGrBilldetail.Rows.Count > 0 )
            {
                foreach (DataGridViewRow row in dataGrBilldetail.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int product_id = int.Parse(row.Cells[0].Value.ToString());
                        int discountdetail = int.Parse(row.Cells[3].Value.ToString());
                        int quantitydetail = int.Parse(row.Cells[4].Value.ToString());
                        int totalbilldetail = int.Parse(row.Cells[5].Value.ToString());
                        DataTable checkOnBill = process.DataReader("Select * from tblBillDetail where product_id='" + product_id + "'and bill_id='" + txtBillID.CustomText + "'");
                        if(checkOnBill.Rows.Count >0 )
                        {
                        string updateDetailBill = "update tblBillDetail set quantity='" + quantitydetail + "',discount='" + discountdetail + "',total='" + totalbilldetail + "'where product_id='"+product_id+"'and bill_id='"+txtBillID.CustomText+"'";
                        process.DataChange(updateDetailBill);

                        }
                        else
                        {
                            string addBillDetail = "insert into tblBillDetail (bill_id,product_id,quantity,discount,total) values('" + txtBillID.CustomText + "','" + product_id + "','" + quantitydetail + "','" + discountdetail + "','" + totalbilldetail + "')";
                            process.DataChange(addBillDetail);
                        }
                    }
                }
            }
            updateQuantityToDatabase();
            clearDataProduct();
            clearCustomerInfor();
            showDataBill();
            MessageBox.Show("Lưu hóa đơn thành công");
        }
        private void dataGrBilldetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            int productID = int.Parse(dataGrBilldetail.Rows[rowindex].Cells[0].Value.ToString());
            int quantity = int.Parse(dataGrBilldetail.Rows[rowindex].Cells[4].Value.ToString());
            dataGrBilldetail.Rows.RemoveAt(rowindex);
            foreach (DataGridViewRow row in dataGrProduct.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (int.Parse(row.Cells[0].Value.ToString()) == productID)
                    {
                        row.Cells[3].Value = int.Parse(row.Cells[3].Value.ToString()) + quantity;
                    }
                }
            }
            updatetotal();
        }
    }
}
