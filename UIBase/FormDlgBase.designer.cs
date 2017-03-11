namespace DS.MSClient
{
    partial class FormDlgBase
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
	        try
	        {
		        base.Dispose(disposing);
	        }
	        catch
	        {
		        // ignored
	        }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDlgBase));
			this.lcMain = new DevExpress.XtraLayout.LayoutControl();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOK = new DevExpress.XtraEditors.SimpleButton();
			this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lciOK = new DevExpress.XtraLayout.LayoutControlItem();
			this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
			this.ssOp = new DevExpress.XtraLayout.SimpleSeparator();
			this.esiOpEmpty = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcgContainer = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
			this.lcMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
			this.SuspendLayout();
			// 
			// lcMain
			// 
			this.lcMain.Controls.Add(this.btnCancel);
			this.lcMain.Controls.Add(this.btnOK);
			this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lcMain.Location = new System.Drawing.Point(0, 0);
			this.lcMain.Name = "lcMain";
			this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1335, 217, 250, 350);
			this.lcMain.Root = this.lcgMain;
			this.lcMain.Size = new System.Drawing.Size(534, 362);
			this.lcMain.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
			this.btnCancel.Location = new System.Drawing.Point(448, 333);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 22);
			this.btnCancel.StyleController = this.lcMain;
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "取消(&C)";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
			this.btnOK.Location = new System.Drawing.Point(363, 333);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(81, 22);
			this.btnOK.StyleController = this.lcMain;
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "确定(&O)";
			// 
			// lcgMain
			// 
			this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
			this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lcgMain.CustomizationFormText = "Root";
			this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.lcgMain.GroupBordersVisible = false;
			this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciOK,
            this.lciCancel,
            this.ssOp,
            this.esiOpEmpty,
            this.lcgContainer});
			this.lcgMain.Location = new System.Drawing.Point(0, 0);
			this.lcgMain.Name = "lcgMain";
			this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
			this.lcgMain.Size = new System.Drawing.Size(534, 362);
			this.lcgMain.Text = "lcgMain";
			this.lcgMain.TextVisible = false;
			// 
			// lciOK
			// 
			this.lciOK.Control = this.btnOK;
			this.lciOK.CustomizationFormText = "lciOK";
			this.lciOK.Location = new System.Drawing.Point(356, 326);
			this.lciOK.MaxSize = new System.Drawing.Size(85, 26);
			this.lciOK.MinSize = new System.Drawing.Size(85, 26);
			this.lciOK.Name = "lciOK";
			this.lciOK.Size = new System.Drawing.Size(85, 26);
			this.lciOK.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lciOK.Text = "lciOK";
			this.lciOK.TextSize = new System.Drawing.Size(0, 0);
			this.lciOK.TextToControlDistance = 0;
			this.lciOK.TextVisible = false;
			// 
			// lciCancel
			// 
			this.lciCancel.Control = this.btnCancel;
			this.lciCancel.CustomizationFormText = "lciCancel";
			this.lciCancel.Location = new System.Drawing.Point(441, 326);
			this.lciCancel.MaxSize = new System.Drawing.Size(83, 26);
			this.lciCancel.MinSize = new System.Drawing.Size(83, 26);
			this.lciCancel.Name = "lciCancel";
			this.lciCancel.Size = new System.Drawing.Size(83, 26);
			this.lciCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lciCancel.Text = "lciCancel";
			this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
			this.lciCancel.TextToControlDistance = 0;
			this.lciCancel.TextVisible = false;
			// 
			// ssOp
			// 
			this.ssOp.AllowHotTrack = false;
			this.ssOp.CustomizationFormText = "ssOp";
			this.ssOp.Location = new System.Drawing.Point(0, 324);
			this.ssOp.Name = "ssOp";
			this.ssOp.Size = new System.Drawing.Size(524, 2);
			this.ssOp.Text = "ssOp";
			// 
			// esiOpEmpty
			// 
			this.esiOpEmpty.AllowHotTrack = false;
			this.esiOpEmpty.CustomizationFormText = "esiOpEmpty";
			this.esiOpEmpty.Location = new System.Drawing.Point(0, 326);
			this.esiOpEmpty.Name = "esiOpEmpty";
			this.esiOpEmpty.Size = new System.Drawing.Size(356, 26);
			this.esiOpEmpty.Text = "esiOpEmpty";
			this.esiOpEmpty.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcgContainer
			// 
			this.lcgContainer.AllowDrawBackground = false;
			this.lcgContainer.AllowHide = false;
			this.lcgContainer.CustomizationFormText = "容器";
			this.lcgContainer.GroupBordersVisible = false;
			this.lcgContainer.Location = new System.Drawing.Point(0, 0);
			this.lcgContainer.Name = "lcgContainer";
			this.lcgContainer.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lcgContainer.Size = new System.Drawing.Size(524, 324);
			this.lcgContainer.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lcgContainer.Text = "容器";
			// 
			// FormDlgBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(534, 362);
			this.Controls.Add(this.lcMain);
			this.Icon = global::DS.MSClient.Properties.Resources.驾校图标;
			this.LookAndFeel.SkinName = "Office 2010 Silver";
			this.Name = "FormDlgBase";
			this.Text = "基本对话框";
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
			this.lcMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.SimpleButton btnOK;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraLayout.LayoutControl lcMain;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        protected DevExpress.XtraLayout.LayoutControlItem lciOK;
        protected DevExpress.XtraLayout.LayoutControlItem lciCancel;
        protected DevExpress.XtraLayout.SimpleSeparator ssOp;
        protected DevExpress.XtraLayout.EmptySpaceItem esiOpEmpty;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgContainer;
    }
}