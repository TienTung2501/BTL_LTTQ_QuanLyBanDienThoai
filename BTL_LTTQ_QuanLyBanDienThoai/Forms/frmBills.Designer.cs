namespace BTL_LTTQ_QuanLyBanDienThoai
{
    partial class frmBills
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new ReaLTaiizor.Controls.RichTextBoxEdit();
            this.btnSearch = new ReaLTaiizor.Controls.FoxButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Bill_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seller_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bill_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bills";
            // 
            // txtSearch
            // 
            this.txtSearch.AutoWordSelection = false;
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BaseColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSearch.EdgeColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtSearch.Location = new System.Drawing.Point(12, 81);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.Size = new System.Drawing.Size(901, 40);
            this.txtSearch.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtSearch.TabIndex = 9;
            this.txtSearch.Text = "Search";
            this.txtSearch.TextBackColor = System.Drawing.Color.Transparent;
            this.txtSearch.TextBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.TextFont = new System.Drawing.Font("Tahoma", 10F);
            this.txtSearch.WordWrap = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnSearch.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnSearch.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.btnSearch.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.btnSearch.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnSearch.EnabledCalc = true;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSearch.Location = new System.Drawing.Point(919, 81);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSearch.Size = new System.Drawing.Size(112, 40);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bill_ID,
            this.Customer_name,
            this.Seller_Name,
            this.Bill_Date,
            this.Total});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1019, 284);
            this.dataGridView1.TabIndex = 11;
            // 
            // Bill_ID
            // 
            this.Bill_ID.HeaderText = "Bill ID";
            this.Bill_ID.MinimumWidth = 6;
            this.Bill_ID.Name = "Bill_ID";
            this.Bill_ID.Width = 125;
            // 
            // Customer_name
            // 
            this.Customer_name.HeaderText = "Customer Name";
            this.Customer_name.MinimumWidth = 6;
            this.Customer_name.Name = "Customer_name";
            this.Customer_name.Width = 300;
            // 
            // Seller_Name
            // 
            this.Seller_Name.HeaderText = "Seller Name";
            this.Seller_Name.MinimumWidth = 6;
            this.Seller_Name.Name = "Seller_Name";
            this.Seller_Name.Width = 300;
            // 
            // Bill_Date
            // 
            this.Bill_Date.HeaderText = "Date";
            this.Bill_Date.MinimumWidth = 6;
            this.Bill_Date.Name = "Bill_Date";
            this.Bill_Date.Width = 150;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.Width = 125;
            // 
            // frmBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 469);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBills";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.RichTextBoxEdit txtSearch;
        private ReaLTaiizor.Controls.FoxButton btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bill_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seller_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bill_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}