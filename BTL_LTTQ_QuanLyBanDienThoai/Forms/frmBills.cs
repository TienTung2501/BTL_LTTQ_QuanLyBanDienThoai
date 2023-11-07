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
    public partial class frmBills : Form
    {
        Classes.DataBaseProcess data = new Classes.DataBaseProcess();
        public frmBills()
        {
            InitializeComponent();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                LoadData();
                return;
            }
            string searchString = txtSearch.Text;
            string query = "select tblBill.id, tblCustomer.name as Customer_Name, tblSeller.name as Seller_Name, date, total from tblBill inner join tblCustomer on customer_id = tblCustomer.id inner join tblSeller on seller_id=tblSeller.id";
            DataTable dt = data.DataReader(query);

            // Tạo một DataTable mới
            DataTable filteredData = new DataTable();

            // Định nghĩa cấu trúc của DataTable
            filteredData.Columns.Add("ID");
            filteredData.Columns.Add("Customer Name");
            filteredData.Columns.Add("Seller Name");
            filteredData.Columns.Add("Date");
            filteredData.Columns.Add("Total");
            foreach (DataRow row in dt.Rows)
            {
                if (row["id"].ToString().Contains(searchString) || row["Customer_Name"].ToString().Contains(searchString) || row["Seller_Name"].ToString().Contains(searchString))
                {
                     filteredData.Rows.Add(
                                row["id"].ToString(),
                                row["Customer_Name"].ToString(),
                                row["Seller_Name"].ToString(),
                                row["date"].ToString(),
                                row["total"].ToString()
                    );
                } 
            }
            dgvBills.DataSource = filteredData;


            dgvBills.Columns[0].HeaderText = "ID";
            dgvBills.Columns[1].HeaderText = "Customer Name";
            dgvBills.Columns[2].HeaderText = "Seller Name";
            dgvBills.Columns[3].HeaderText = "Date";
            dgvBills.Columns[4].HeaderText = "Total";
        }

        private void frmBills_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            string query = "select tblBill.id, tblCustomer.name as Customer_Name, tblSeller.name as Seller_Name, date, total from tblBill inner join tblCustomer on customer_id = tblCustomer.id inner join tblSeller on seller_id=tblSeller.id";
            DataTable Bills = data.DataReader(query);
            dgvBills.DataSource =Bills;
            dgvBills.Columns[0].HeaderText = "ID";
            dgvBills.Columns[1].HeaderText = "Customer Name";
            dgvBills.Columns[2].HeaderText = "Seller Name";
            dgvBills.Columns[3].HeaderText = "Date";
            dgvBills.Columns[4].HeaderText = "Total";
        }
    }
}
