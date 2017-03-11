namespace DS.MSClient.UICommon.CommonForm
{
    partial class FormSelectAppointTime
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectAppointTime));
			this.gc_AppointTime = new DS.MSClient.UIControl.CGridControl();
			this.gv_AppointTime = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.Column_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Column_IsMain = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.ck_Continuation = new DevExpress.XtraEditors.CheckEdit();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.checkEdit_allin = new DevExpress.XtraEditors.CheckEdit();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
			this.lcMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gc_AppointTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gv_AppointTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ck_Continuation.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_allin.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(315, 406);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(400, 406);
			// 
			// lcMain
			// 
			this.lcMain.Controls.Add(this.checkEdit_allin);
			this.lcMain.Controls.Add(this.ck_Continuation);
			this.lcMain.Controls.Add(this.gc_AppointTime);
			this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1335, 217, 250, 350);
			this.lcMain.Size = new System.Drawing.Size(486, 435);
			this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
			this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
			this.lcMain.Controls.SetChildIndex(this.gc_AppointTime, 0);
			this.lcMain.Controls.SetChildIndex(this.ck_Continuation, 0);
			this.lcMain.Controls.SetChildIndex(this.checkEdit_allin, 0);
			// 
			// lcgMain
			// 
			this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
			this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lcgMain.Size = new System.Drawing.Size(486, 435);
			// 
			// lciOK
			// 
			this.lciOK.Location = new System.Drawing.Point(308, 399);
			// 
			// lciCancel
			// 
			this.lciCancel.Location = new System.Drawing.Point(393, 399);
			// 
			// ssOp
			// 
			this.ssOp.Location = new System.Drawing.Point(0, 397);
			this.ssOp.Size = new System.Drawing.Size(476, 2);
			// 
			// esiOpEmpty
			// 
			this.esiOpEmpty.Location = new System.Drawing.Point(0, 399);
			this.esiOpEmpty.Size = new System.Drawing.Size(308, 26);
			// 
			// lcgContainer
			// 
			this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
			this.lcgContainer.Size = new System.Drawing.Size(476, 397);
			// 
			// gc_AppointTime
			// 
			this.gc_AppointTime.AdvanceSearchMethod = null;
			this.gc_AppointTime.CallCustomNavicationButtonClick = null;
			this.gc_AppointTime.Cursor = System.Windows.Forms.Cursors.Default;
			this.gc_AppointTime.GetPageSizeMethod = null;
			this.gc_AppointTime.GetTotalRecordCountMethod = null;
			this.gc_AppointTime.ImmediatelyDownLoad = false;
			this.gc_AppointTime.Location = new System.Drawing.Point(7, 7);
			this.gc_AppointTime.MainView = this.gv_AppointTime;
			this.gc_AppointTime.Name = "gc_AppointTime";
			this.gc_AppointTime.PageSortOrderSearchMethod = null;
			this.gc_AppointTime.ShowCustomHeaderMenu = true;
			this.gc_AppointTime.ShowCustomNavigationButtons = false;
			this.gc_AppointTime.ShowCustomRowHeightButton = true;
			this.gc_AppointTime.ShowImmediatelyDownLoadMenu = true;
			this.gc_AppointTime.Size = new System.Drawing.Size(472, 370);
			this.gc_AppointTime.TabIndex = 4;
			this.gc_AppointTime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_AppointTime});
			// 
			// gv_AppointTime
			// 
			this.gv_AppointTime.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Choose,
            this.gridColumn2,
            this.Column_IsMain,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4});
			this.gv_AppointTime.GridControl = this.gc_AppointTime;
			this.gv_AppointTime.Name = "gv_AppointTime";
			this.gv_AppointTime.OptionsView.EnableAppearanceEvenRow = true;
			this.gv_AppointTime.OptionsView.EnableAppearanceOddRow = true;
			this.gv_AppointTime.OptionsView.ShowGroupPanel = false;
			// 
			// Column_Choose
			// 
			this.Column_Choose.AppearanceCell.Options.UseTextOptions = true;
			this.Column_Choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.Column_Choose.AppearanceHeader.Options.UseTextOptions = true;
			this.Column_Choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.Column_Choose.Caption = "选择";
			this.Column_Choose.FieldName = "Choose";
			this.Column_Choose.Name = "Column_Choose";
			this.Column_Choose.OptionsColumn.AllowEdit = false;
			this.Column_Choose.OptionsColumn.ReadOnly = true;
			this.Column_Choose.Visible = true;
			this.Column_Choose.VisibleIndex = 0;
			this.Column_Choose.Width = 42;
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "开始时间";
			this.gridColumn2.DisplayFormat.FormatString = "T";
			this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn2.FieldName = "BeginTime";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 79;
			// 
			// Column_IsMain
			// 
			this.Column_IsMain.AppearanceCell.Options.UseTextOptions = true;
			this.Column_IsMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.Column_IsMain.AppearanceHeader.Options.UseTextOptions = true;
			this.Column_IsMain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.Column_IsMain.Caption = "结束时间";
			this.Column_IsMain.DisplayFormat.FormatString = "T";
			this.Column_IsMain.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.Column_IsMain.FieldName = "EndTime";
			this.Column_IsMain.Name = "Column_IsMain";
			this.Column_IsMain.OptionsColumn.AllowEdit = false;
			this.Column_IsMain.OptionsColumn.ReadOnly = true;
			this.Column_IsMain.Visible = true;
			this.Column_IsMain.VisibleIndex = 2;
			this.Column_IsMain.Width = 71;
			// 
			// gridColumn1
			// 
			this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.Caption = "费用";
			this.gridColumn1.FieldName = "Fee";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 3;
			this.gridColumn1.Width = 71;
			// 
			// gridColumn3
			// 
			this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.Caption = "VIP服务费";
			this.gridColumn3.FieldName = "VipFee";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.Width = 71;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.Caption = "周末服务费";
			this.gridColumn4.FieldName = "WeekendFee";
			this.gridColumn4.MinWidth = 50;
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.Width = 82;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gc_AppointTime;
			this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(476, 374);
			this.layoutControlItem1.Text = "layoutControlItem1";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextToControlDistance = 0;
			this.layoutControlItem1.TextVisible = false;
			// 
			// ck_Continuation
			// 
			this.ck_Continuation.EditValue = true;
			this.ck_Continuation.Location = new System.Drawing.Point(245, 381);
			this.ck_Continuation.Name = "ck_Continuation";
			this.ck_Continuation.Properties.Caption = "是否合并连续时间段";
			this.ck_Continuation.Size = new System.Drawing.Size(234, 19);
			this.ck_Continuation.StyleController = this.lcMain;
			this.ck_Continuation.TabIndex = 5;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.ck_Continuation;
			this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
			this.layoutControlItem2.Location = new System.Drawing.Point(238, 374);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(238, 23);
			this.layoutControlItem2.Text = "layoutControlItem2";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextToControlDistance = 0;
			this.layoutControlItem2.TextVisible = false;
			// 
			// checkEdit_allin
			// 
			this.checkEdit_allin.Location = new System.Drawing.Point(7, 381);
			this.checkEdit_allin.Name = "checkEdit_allin";
			this.checkEdit_allin.Properties.Caption = "是否全选";
			this.checkEdit_allin.Size = new System.Drawing.Size(234, 19);
			this.checkEdit_allin.StyleController = this.lcMain;
			this.checkEdit_allin.TabIndex = 6;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.checkEdit_allin;
			this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 374);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(238, 23);
			this.layoutControlItem3.Text = "layoutControlItem3";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextToControlDistance = 0;
			this.layoutControlItem3.TextVisible = false;
			// 
			// FormSelectAppointTime
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 435);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.LookAndFeel.SkinName = "Office 2010 Silver";
			this.Name = "FormSelectAppointTime";
			this.Text = "选择时段";
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
			this.lcMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gc_AppointTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gv_AppointTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ck_Continuation.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_allin.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_AppointTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_AppointTime;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Column_IsMain;
        private DevExpress.XtraEditors.CheckEdit ck_Continuation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit checkEdit_allin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

    }
}