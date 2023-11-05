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
    public partial class MainForm : Form
    {
        frmProducts frmProducts;
        frmManageCategory frmManageCategory;
        frmSetting frmSetting;
        frmManageSellers frmSellers;
        frmBills frmBills;
        public MainForm()
        {
            InitializeComponent();
            mdiProp();
        }
        bool sidebarExpand = true;
        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232,234,237);
        }
        private void sidebarTransaction_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                flpSidebar.Width -= 10;
                if(flpSidebar.Width <= 88)
                {
                    sidebarExpand = false;
                    sidebarTransaction.Stop();
                }
            }
            else
            {
                flpSidebar.Width += 10;
                if (flpSidebar.Width >= 246)
                {
                    sidebarExpand = true; ;
                    sidebarTransaction.Stop();
                }

            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTransaction.Start();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if(frmProducts == null)
            {
                frmProducts = new frmProducts();
                frmProducts.FormClosed += FrmProducts_FormClosed;
                
                frmProducts.MdiParent = this;
                frmProducts.Dock = DockStyle.Fill;
                frmProducts.Show();
            }
            else
            {
                frmProducts.Activate();
            }
        }

        private void FrmProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducts = null;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (frmManageCategory == null)
            {
                frmManageCategory = new frmManageCategory();
                frmManageCategory.FormClosed += FrmManageCategory_FormClosed;

                frmManageCategory.MdiParent = this;
                frmManageCategory.Dock = DockStyle.Fill;
                frmManageCategory.Show();
            }
            else
            {
                frmManageCategory.Activate();
            }
        }

        private void FrmManageCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManageCategory = null;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (frmSetting == null)
            {
                frmSetting = new frmSetting();
                frmSetting.FormClosed += FrmSetting_FormClosed;

                frmSetting.MdiParent = this;
                frmSetting.Dock = DockStyle.Fill;
                frmSetting.Show();
            }
            else
            {
                frmSetting.Activate();
            }
        }

        private void FrmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSetting = null;
        }

        private void btnSellers_Click(object sender, EventArgs e)
        {
            if (frmSellers == null)
            {
                frmSellers = new frmManageSellers();
                frmSellers.FormClosed += FrmSellers_FormClosed; ;

                frmSellers.MdiParent = this;
                frmSellers.Dock = DockStyle.Fill;
                frmSellers.Show();
            }
            else
            {
                frmSellers.Activate();
            }

        }

        private void FrmSellers_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSellers = null;
        }

       

        private void btnBills_Click(object sender, EventArgs e)
        {
            if (frmBills == null)
            {
                frmBills = new frmBills();
                frmBills.FormClosed += FrmBills_FormClosed; ;

                frmBills.MdiParent = this;
                frmBills.Dock = DockStyle.Fill;
                frmBills.Show();
            }
            else
            {
                frmBills.Activate();
            }
        }

        private void FrmBills_FormClosed(object sender, FormClosedEventArgs e)
        {
           frmBills=null;
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders=new frmOrders();
            this.Hide();
            frmOrders.ShowDialog();
        }
    }
}
