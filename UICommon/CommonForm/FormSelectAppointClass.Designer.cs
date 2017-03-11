namespace DS.MSClient.UICommon.CommonForm
{
	partial class FormSelectAppointClass
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectAppointClass));
			this.gcAppointClass = new DS.MSClient.UIControl.CGridControl();
			this.gvAppointClass = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
			this.lcMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcAppointClass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvAppointClass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(232, 262);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(317, 262);
			// 
			// lcMain
			// 
			this.lcMain.Controls.Add(this.gcAppointClass);
			this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1335, 217, 250, 350);
			this.lcMain.Size = new System.Drawing.Size(403, 291);
			this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
			this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
			this.lcMain.Controls.SetChildIndex(this.gcAppointClass, 0);
			// 
			// lcgMain
			// 
			this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
			this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lcgMain.Size = new System.Drawing.Size(403, 291);
			// 
			// lciOK
			// 
			this.lciOK.Location = new System.Drawing.Point(225, 255);
			// 
			// lciCancel
			// 
			this.lciCancel.Location = new System.Drawing.Point(310, 255);
			// 
			// ssOp
			// 
			this.ssOp.Location = new System.Drawing.Point(0, 253);
			this.ssOp.Size = new System.Drawing.Size(393, 2);
			// 
			// esiOpEmpty
			// 
			this.esiOpEmpty.Location = new System.Drawing.Point(0, 255);
			this.esiOpEmpty.Size = new System.Drawing.Size(225, 26);
			// 
			// lcgContainer
			// 
			this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.lcgContainer.Size = new System.Drawing.Size(393, 253);
			// 
			// gcAppointClass
			// 
			this.gcAppointClass.AdvanceSearchMethod = null;
			this.gcAppointClass.CallCustomNavicationButtonClick = null;
			this.gcAppointClass.Cursor = System.Windows.Forms.Cursors.Default;
			this.gcAppointClass.GetPageSizeMethod = null;
			this.gcAppointClass.GetTotalRecordCountMethod = null;
			this.gcAppointClass.ImmediatelyDownLoad = false;
			this.gcAppointClass.Location = new System.Drawing.Point(7, 7);
			this.gcAppointClass.MainView = this.gvAppointClass;
			this.gcAppointClass.Name = "gcAppointClass";
			this.gcAppointClass.PageSortOrderSearchMethod = null;
			this.gcAppointClass.ShowCustomHeaderMenu = true;
			this.gcAppointClass.ShowCustomNavigationButtons = false;
			this.gcAppointClass.ShowCustomRowHeightButton = true;
			this.gcAppointClass.ShowImmediatelyDownLoadMenu = true;
			this.gcAppointClass.Size = new System.Drawing.Size(389, 249);
			this.gcAppointClass.TabIndex = 5;
			this.gcAppointClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAppointClass});
			// 
			// gvAppointClass
			// 
			this.gvAppointClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
			this.gvAppointClass.GridControl = this.gcAppointClass;
			this.gvAppointClass.Name = "gvAppointClass";
			this.gvAppointClass.OptionsCustomization.AllowColumnMoving = false;
			this.gvAppointClass.OptionsCustomization.AllowFilter = false;
			this.gvAppointClass.OptionsCustomization.AllowGroup = false;
			this.gvAppointClass.OptionsCustomization.AllowQuickHideColumns = false;
			this.gvAppointClass.OptionsCustomization.AllowSort = false;
			this.gvAppointClass.OptionsDetail.EnableMasterViewMode = false;
			this.gvAppointClass.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
			this.gvAppointClass.OptionsSelection.MultiSelect = true;
			this.gvAppointClass.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvAppointClass.OptionsView.ColumnAutoWidth = false;
			this.gvAppointClass.OptionsView.EnableAppearanceEvenRow = true;
			this.gvAppointClass.OptionsView.EnableAppearanceOddRow = true;
			this.gvAppointClass.OptionsView.ShowDetailButtons = false;
			this.gvAppointClass.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "预约大类";
			this.gridColumn2.FieldName = "AppointClassName";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 298;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gcAppointClass;
			this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(393, 253);
			this.layoutControlItem1.Text = "layoutControlItem1";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextToControlDistance = 0;
			this.layoutControlItem1.TextVisible = false;
			// 
			// FormSelectAppointClass
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 291);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.LookAndFeel.SkinName = "Office 2010 Silver";
			this.MinimizeBox = false;
			this.Name = "FormSelectAppointClass";
			this.Text = "选择预约大类";
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
			this.lcMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcAppointClass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvAppointClass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private UIControl.CGridControl gcAppointClass;
		private DevExpress.XtraGrid.Views.Grid.GridView gvAppointClass;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
	}
}