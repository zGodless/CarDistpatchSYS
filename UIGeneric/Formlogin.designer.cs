namespace DS.MSClient.UIGeneric
{
    partial class Formlogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formlogin));
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtUserName = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.lblVersion = new DevExpress.XtraEditors.LabelControl();
			this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
			this.btnClose = new DevExpress.XtraEditors.SimpleButton();
			this.lblTipTitle = new DevExpress.XtraEditors.LabelControl();
			this.lblTipContent = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtPassword
			// 
			this.txtPassword.EditValue = "";
			this.txtPassword.Location = new System.Drawing.Point(355, 410);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.White;
			this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
			this.txtPassword.Properties.Appearance.Options.UseFont = true;
			this.txtPassword.Properties.AutoHeight = false;
			this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtPassword.Properties.PasswordChar = '▪';
			this.txtPassword.Properties.UseSystemPasswordChar = true;
			this.txtPassword.Size = new System.Drawing.Size(123, 24);
			this.txtPassword.TabIndex = 1;
			// 
			// txtUserName
			// 
			this.txtUserName.EditValue = "";
			this.txtUserName.EnterMoveNextControl = true;
			this.txtUserName.Location = new System.Drawing.Point(355, 377);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Properties.Appearance.BorderColor = System.Drawing.Color.Transparent;
			this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserName.Properties.Appearance.Options.UseBorderColor = true;
			this.txtUserName.Properties.Appearance.Options.UseFont = true;
			this.txtUserName.Properties.AutoHeight = false;
			this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtUserName.Size = new System.Drawing.Size(123, 24);
			this.txtUserName.TabIndex = 0;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.ForeColor = System.Drawing.Color.LightSteelBlue;
			this.labelControl1.Location = new System.Drawing.Point(627, 550);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(44, 14);
			this.labelControl1.TabIndex = 24;
			this.labelControl1.Text = "Version:";
			// 
			// lblVersion
			// 
			this.lblVersion.Appearance.ForeColor = System.Drawing.Color.LightSteelBlue;
			this.lblVersion.Location = new System.Drawing.Point(677, 550);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(40, 14);
			this.lblVersion.TabIndex = 24;
			this.lblVersion.Text = "1.0.0.0";
			// 
			// btnLogin
			// 
			this.btnLogin.Appearance.BackColor = System.Drawing.Color.Aqua;
			this.btnLogin.Appearance.BackColor2 = System.Drawing.Color.Cyan;
			this.btnLogin.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnLogin.Appearance.Options.UseBackColor = true;
			this.btnLogin.Appearance.Options.UseFont = true;
			this.btnLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
			this.btnLogin.Location = new System.Drawing.Point(329, 446);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(70, 23);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "登录";
			// 
			// btnClose
			// 
			this.btnClose.Appearance.BackColor = System.Drawing.Color.Aqua;
			this.btnClose.Appearance.BackColor2 = System.Drawing.Color.Cyan;
			this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnClose.Appearance.Options.UseBackColor = true;
			this.btnClose.Appearance.Options.UseFont = true;
			this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
			this.btnClose.Location = new System.Drawing.Point(411, 446);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(70, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "取消";
			// 
			// lblTipTitle
			// 
			this.lblTipTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTipTitle.Location = new System.Drawing.Point(175, 238);
			this.lblTipTitle.Name = "lblTipTitle";
			this.lblTipTitle.Size = new System.Drawing.Size(56, 19);
			this.lblTipTitle.TabIndex = 26;
			this.lblTipTitle.Text = "正在登录";
			this.lblTipTitle.Visible = false;
			// 
			// lblTipContent
			// 
			this.lblTipContent.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTipContent.Location = new System.Drawing.Point(175, 261);
			this.lblTipContent.Name = "lblTipContent";
			this.lblTipContent.Size = new System.Drawing.Size(68, 17);
			this.lblTipContent.TabIndex = 26;
			this.lblTipContent.Text = "正在加载……";
			this.lblTipContent.Visible = false;
			// 
			// Formlogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
			this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
			this.ClientSize = new System.Drawing.Size(800, 576);
			this.Controls.Add(this.lblTipContent);
			this.Controls.Add(this.lblTipTitle);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.txtPassword);
			this.DoubleBuffered = true;
			this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.LookAndFeel.SkinName = "Office 2010 Silver";
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 576);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 576);
			this.Name = "Formlogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用户登录";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblVersion;
		private DevExpress.XtraEditors.SimpleButton btnLogin;
		private DevExpress.XtraEditors.SimpleButton btnClose;
		private DevExpress.XtraEditors.LabelControl lblTipTitle;
		private DevExpress.XtraEditors.LabelControl lblTipContent;
    }
}