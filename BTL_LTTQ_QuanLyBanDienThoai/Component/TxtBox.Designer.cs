namespace BTL_LTTQ_QuanLyBanDienThoai.Component
{
    partial class TxtBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOnUserControl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOnUserControl
            // 
            this.txtOnUserControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOnUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOnUserControl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtOnUserControl.Location = new System.Drawing.Point(6, 6);
            this.txtOnUserControl.Name = "txtOnUserControl";
            this.txtOnUserControl.Size = new System.Drawing.Size(388, 20);
            this.txtOnUserControl.TabIndex = 0;
            // 
            // TxtBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtOnUserControl);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TxtBox";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(400, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOnUserControl;
    }
}
