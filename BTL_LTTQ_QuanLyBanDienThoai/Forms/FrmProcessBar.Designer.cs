namespace BTL_LTTQ_QuanLyBanDienThoai
{
    partial class FrmProcessBar
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.percenLoad = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(493, 686);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.progressBar1.Location = new System.Drawing.Point(377, 662);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // percenLoad
            // 
            this.percenLoad.AutoSize = true;
            this.percenLoad.BackColor = System.Drawing.Color.Transparent;
            this.percenLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.percenLoad.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percenLoad.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.percenLoad.Location = new System.Drawing.Point(692, 660);
            this.percenLoad.Name = "percenLoad";
            this.percenLoad.Size = new System.Drawing.Size(36, 19);
            this.percenLoad.TabIndex = 3;
            this.percenLoad.Text = "0 %";
            this.percenLoad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BTL_LTTQ_QuanLyBanDienThoai.Properties.Resources._23991564_6859183;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BTL_LTTQ_QuanLyBanDienThoai.Properties.Resources._23991564_6859183_1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1080, 720);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmProcessBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.percenLoad);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProcessBar";
            this.Text = "FrmProcessBar";
            this.Load += new System.EventHandler(this.FrmProcessBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label percenLoad;
    }
}