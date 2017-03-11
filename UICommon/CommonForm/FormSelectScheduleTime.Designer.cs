namespace DS.MSClient.UICommon.CommonForm
{
    partial class FormSelectScheduleTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectScheduleTime));
            this.gc_ScheduleTime = new DS.MSClient.UIControl.CGridControl();
            this.gv_ScheduleTime = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_IsMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.checkEdit_allin = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ck_Capacity = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_ScheduleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ScheduleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_allin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_Capacity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.lcMain.Controls.Add(this.textEdit1);
            this.lcMain.Controls.Add(this.ck_Capacity);
            this.lcMain.Controls.Add(this.checkEdit_allin);
            this.lcMain.Controls.Add(this.gc_ScheduleTime);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(708, 486, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(486, 435);
            this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
            this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
            this.lcMain.Controls.SetChildIndex(this.gc_ScheduleTime, 0);
            this.lcMain.Controls.SetChildIndex(this.checkEdit_allin, 0);
            this.lcMain.Controls.SetChildIndex(this.ck_Capacity, 0);
            this.lcMain.Controls.SetChildIndex(this.textEdit1, 0);
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgMain.Name = "Root";
            this.lcgMain.Size = new System.Drawing.Size(486, 435);
            this.lcgMain.Text = "Root";
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
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.lcgContainer.Size = new System.Drawing.Size(476, 397);
            // 
            // gc_ScheduleTime
            // 
            this.gc_ScheduleTime.AdvanceSearchMethod = null;
            this.gc_ScheduleTime.CallCustomNavicationButtonClick = null;
            this.gc_ScheduleTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_ScheduleTime.GetPageSizeMethod = null;
            this.gc_ScheduleTime.GetTotalRecordCountMethod = null;
            this.gc_ScheduleTime.ImmediatelyDownLoad = false;
            this.gc_ScheduleTime.Location = new System.Drawing.Point(7, 7);
            this.gc_ScheduleTime.MainView = this.gv_ScheduleTime;
            this.gc_ScheduleTime.Name = "gc_ScheduleTime";
            this.gc_ScheduleTime.PageSortOrderSearchMethod = null;
            this.gc_ScheduleTime.ShowCustomHeaderMenu = true;
            this.gc_ScheduleTime.ShowCustomNavigationButtons = false;
            this.gc_ScheduleTime.ShowCustomRowHeightButton = true;
            this.gc_ScheduleTime.ShowImmediatelyDownLoadMenu = true;
            this.gc_ScheduleTime.Size = new System.Drawing.Size(472, 369);
            this.gc_ScheduleTime.TabIndex = 4;
            this.gc_ScheduleTime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_ScheduleTime});
            // 
            // gv_ScheduleTime
            // 
            this.gv_ScheduleTime.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Choose,
            this.gridColumn2,
            this.Column_IsMain,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4});
            this.gv_ScheduleTime.GridControl = this.gc_ScheduleTime;
            this.gv_ScheduleTime.Name = "gv_ScheduleTime";
            this.gv_ScheduleTime.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_ScheduleTime.OptionsView.EnableAppearanceOddRow = true;
            this.gv_ScheduleTime.OptionsView.ShowGroupPanel = false;
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
            this.gridColumn1.Caption = "容量";
            this.gridColumn1.FieldName = "Capacity";
            this.gridColumn1.Name = "gridColumn1";
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
            this.layoutControlItem1.Control = this.gc_ScheduleTime;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(476, 373);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // checkEdit_allin
            // 
            this.checkEdit_allin.Location = new System.Drawing.Point(7, 380);
            this.checkEdit_allin.Name = "checkEdit_allin";
            this.checkEdit_allin.Properties.Caption = "是否全选";
            this.checkEdit_allin.Size = new System.Drawing.Size(108, 19);
            this.checkEdit_allin.StyleController = this.lcMain;
            this.checkEdit_allin.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.checkEdit_allin;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 373);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(112, 24);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // ck_Capacity
            // 
            this.ck_Capacity.Location = new System.Drawing.Point(300, 380);
            this.ck_Capacity.Name = "ck_Capacity";
            this.ck_Capacity.Properties.Caption = "是否统一容量:";
            this.ck_Capacity.Size = new System.Drawing.Size(98, 19);
            this.ck_Capacity.StyleController = this.lcMain;
            this.ck_Capacity.TabIndex = 6;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ck_Capacity;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(293, 373);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(102, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(102, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(102, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(402, 380);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(77, 20);
            this.textEdit1.StyleController = this.lcMain;
            this.textEdit1.TabIndex = 7;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.textEdit1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(395, 373);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(81, 24);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(112, 373);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(181, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormSelectScheduleTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 435);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.Name = "FormSelectScheduleTime";
            this.Text = "选择时段";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_ScheduleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ScheduleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_allin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_Capacity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_ScheduleTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_ScheduleTime;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Column_IsMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.CheckEdit checkEdit_allin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.CheckEdit ck_Capacity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;

    }
}