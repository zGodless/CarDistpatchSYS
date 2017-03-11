namespace DS.MSClient.UIGeneric
{
	partial class DialogEditPassword
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogEditPassword));
			this.txt_NewPassword2 = new DevExpress.XtraEditors.TextEdit();
			this.txt_NewPassword = new DevExpress.XtraEditors.TextEdit();
			this.txt_Password = new DevExpress.XtraEditors.TextEdit();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
			this.lcMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_NewPassword2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_NewPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(99, 81);
			this.btnOK.Margin = new System.Windows.Forms.Padding(41, 21, 41, 21);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(184, 81);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(41, 21, 41, 21);
			// 
			// lcMain
			// 
			this.lcMain.AllowCustomizationMenu = false;
			this.lcMain.Controls.Add(this.txt_NewPassword);
			this.lcMain.Controls.Add(this.txt_NewPassword2);
			this.lcMain.Controls.Add(this.txt_Password);
			this.lcMain.Margin = new System.Windows.Forms.Padding(41, 21, 41, 21);
			this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1335, 217, 250, 350);
			this.lcMain.Size = new System.Drawing.Size(270, 116);
			this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
			this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
			this.lcMain.Controls.SetChildIndex(this.txt_Password, 0);
			this.lcMain.Controls.SetChildIndex(this.txt_NewPassword2, 0);
			this.lcMain.Controls.SetChildIndex(this.txt_NewPassword, 0);
			// 
			// lcgMain
			// 
			this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
			this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lcgMain.Name = "Root";
			this.lcgMain.Size = new System.Drawing.Size(270, 116);
			this.lcgMain.Text = "Root";
			// 
			// lciOK
			// 
			this.lciOK.Location = new System.Drawing.Point(92, 74);
			this.lciOK.Size = new System.Drawing.Size(85, 32);
			// 
			// lciCancel
			// 
			this.lciCancel.Location = new System.Drawing.Point(177, 74);
			this.lciCancel.Size = new System.Drawing.Size(83, 32);
			// 
			// ssOp
			// 
			this.ssOp.Location = new System.Drawing.Point(0, 72);
			this.ssOp.Size = new System.Drawing.Size(260, 2);
			// 
			// esiOpEmpty
			// 
			this.esiOpEmpty.Location = new System.Drawing.Point(0, 74);
			this.esiOpEmpty.Size = new System.Drawing.Size(92, 32);
			// 
			// lcgContainer
			// 
			this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
			this.lcgContainer.Size = new System.Drawing.Size(260, 72);
			// 
			// txt_NewPassword2
			// 
			this.txt_NewPassword2.Location = new System.Drawing.Point(66, 55);
			this.txt_NewPassword2.Margin = new System.Windows.Forms.Padding(41, 21, 41, 21);
			this.txt_NewPassword2.Name = "txt_NewPassword2";
			this.txt_NewPassword2.Properties.PasswordChar = '*';
			this.txt_NewPassword2.Size = new System.Drawing.Size(197, 20);
			this.txt_NewPassword2.StyleController = this.lcMain;
			this.txt_NewPassword2.TabIndex = 11;
			// 
			// txt_NewPassword
			// 
			this.txt_NewPassword.Location = new System.Drawing.Point(66, 31);
			this.txt_NewPassword.Margin = new System.Windows.Forms.Padding(41, 21, 41, 21);
			this.txt_NewPassword.Name = "txt_NewPassword";
			this.txt_NewPassword.Properties.PasswordChar = '*';
			this.txt_NewPassword.Size = new System.Drawing.Size(197, 20);
			this.txt_NewPassword.StyleController = this.lcMain;
			this.txt_NewPassword.TabIndex = 9;
			// 
			// txt_Password
			// 
			this.txt_Password.Location = new System.Drawing.Point(66, 7);
			this.txt_Password.Margin = new System.Windows.Forms.Padding(41, 21, 41, 21);
			this.txt_Password.Name = "txt_Password";
			this.txt_Password.Properties.PasswordChar = '*';
			this.txt_Password.Size = new System.Drawing.Size(197, 20);
			this.txt_Password.StyleController = this.lcMain;
			this.txt_Password.TabIndex = 7;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
			this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
			this.layoutControlItem1.Control = this.txt_Password;
			this.layoutControlItem1.CustomizationFormText = "*旧密码";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(260, 24);
			this.layoutControlItem1.Text = "*旧密码";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 14);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
			this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
			this.layoutControlItem2.Control = this.txt_NewPassword;
			this.layoutControlItem2.CustomizationFormText = "*新密码";
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(260, 24);
			this.layoutControlItem2.Text = "*新密码";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 14);
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
			this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
			this.layoutControlItem3.Control = this.txt_NewPassword2;
			this.layoutControlItem3.CustomizationFormText = "*确认密码";
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(260, 24);
			this.layoutControlItem3.Text = "*确认密码";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(55, 14);
			// 
			// DialogEditPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.ClientSize = new System.Drawing.Size(270, 116);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(41, 21, 41, 21);
			this.MaximizeBox = false;
			this.Name = "DialogEditPassword";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "修改密码";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
			this.lcMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_NewPassword2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_NewPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.TextEdit txt_NewPassword2;
		private DevExpress.XtraEditors.TextEdit txt_NewPassword;
		private DevExpress.XtraEditors.TextEdit txt_Password;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
	}
}
