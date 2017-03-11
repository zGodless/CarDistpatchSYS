namespace DS.MSClient.UICommon
{
    partial class FormExportData
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
            this.lbl_msg = new DevExpress.XtraEditors.LabelControl();
            this.btn_cancelDownLoad = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_process = new System.Windows.Forms.Label();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_msg
            // 
            this.lbl_msg.Appearance.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbl_msg.Location = new System.Drawing.Point(10, 6);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(100, 14);
            this.lbl_msg.TabIndex = 0;
            this.lbl_msg.Text = "正在下载Excel数据";
            // 
            // btn_cancelDownLoad
            // 
            this.btn_cancelDownLoad.Appearance.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btn_cancelDownLoad.Appearance.Options.UseForeColor = true;
            this.btn_cancelDownLoad.Location = new System.Drawing.Point(159, 12);
            this.btn_cancelDownLoad.Name = "btn_cancelDownLoad";
            this.btn_cancelDownLoad.Size = new System.Drawing.Size(61, 23);
            this.btn_cancelDownLoad.TabIndex = 5;
            this.btn_cancelDownLoad.Text = "取消下载";
            // 
            // lbl_process
            // 
            this.lbl_process.AutoSize = true;
            this.lbl_process.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbl_process.Location = new System.Drawing.Point(85, 23);
            this.lbl_process.Name = "lbl_process";
            this.lbl_process.Size = new System.Drawing.Size(0, 14);
            this.lbl_process.TabIndex = 6;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(12, 26);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(70, 10);
            this.progressBarControl1.TabIndex = 7;
            // 
            // FormExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 43);
            this.Controls.Add(this.btn_cancelDownLoad);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.lbl_msg);
            this.Controls.Add(this.lbl_process);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormExportData";
            this.Text = "FormExportData";
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_msg;
        private DevExpress.XtraEditors.SimpleButton btn_cancelDownLoad;
        private System.Windows.Forms.Label lbl_process;
        public DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
    }
}