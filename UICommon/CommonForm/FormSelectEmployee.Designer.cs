namespace DS.MSClient.UICommon
{
    partial class FormSelectEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectEmployee));
            this.gc_Employee = new DS.MSClient.UIControl.CGridControl();
            this.gv_Employee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_IsMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(236, 424);
            this.btnOK.Size = new System.Drawing.Size(107, 22);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(347, 424);
            this.btnCancel.Size = new System.Drawing.Size(104, 22);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.gc_Employee);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1335, 217, 250, 350);
            this.lcMain.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lcMain.Size = new System.Drawing.Size(458, 453);
            this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
            this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
            this.lcMain.Controls.SetChildIndex(this.gc_Employee, 0);
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgMain.Size = new System.Drawing.Size(458, 453);
            // 
            // lciOK
            // 
            this.lciOK.Location = new System.Drawing.Point(229, 417);
            this.lciOK.Size = new System.Drawing.Size(111, 26);
            // 
            // lciCancel
            // 
            this.lciCancel.Location = new System.Drawing.Point(340, 417);
            this.lciCancel.Size = new System.Drawing.Size(108, 26);
            // 
            // ssOp
            // 
            this.ssOp.Location = new System.Drawing.Point(0, 415);
            this.ssOp.Size = new System.Drawing.Size(448, 2);
            // 
            // esiOpEmpty
            // 
            this.esiOpEmpty.Location = new System.Drawing.Point(0, 417);
            this.esiOpEmpty.Size = new System.Drawing.Size(229, 26);
            // 
            // lcgContainer
            // 
            this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgContainer.Size = new System.Drawing.Size(448, 415);
            // 
            // gc_Employee
            // 
            this.gc_Employee.AdvanceSearchMethod = null;
            this.gc_Employee.GetPageSizeMethod = null;
            this.gc_Employee.GetTotalRecordCountMethod = null;
            this.gc_Employee.PageSortOrderSearchMethod = null;
            this.gc_Employee.CallCustomNavicationButtonClick = null;
            this.gc_Employee.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Employee.ImmediatelyDownLoad = false;
            this.gc_Employee.Location = new System.Drawing.Point(7, 7);
            this.gc_Employee.MainView = this.gv_Employee;
            this.gc_Employee.Name = "gc_Employee";
            this.gc_Employee.ShowCustomHeaderMenu = true;
            this.gc_Employee.ShowCustomNavigationButtons = false;
            this.gc_Employee.ShowCustomRowHeightButton = true;
            this.gc_Employee.ShowImmediatelyDownLoadMenu = true;
            this.gc_Employee.Size = new System.Drawing.Size(444, 411);
            this.gc_Employee.TabIndex = 4;
            this.gc_Employee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Employee});
            // 
            // gv_Employee
            // 
            this.gv_Employee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Choose,
            this.gridColumn1,
            this.gridColumn2,
            this.Column_IsMain});
            this.gv_Employee.GridControl = this.gc_Employee;
            this.gv_Employee.Name = "gv_Employee";
            this.gv_Employee.OptionsView.ShowGroupPanel = false;
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
            this.Column_Choose.Visible = true;
            this.Column_Choose.VisibleIndex = 0;
            this.Column_Choose.Width = 55;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "部门";
            this.gridColumn1.FieldName = "DepartmentName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 140;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "员工";
            this.gridColumn2.FieldName = "EmployeeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 141;
            // 
            // Column_IsMain
            // 
            this.Column_IsMain.AppearanceCell.Options.UseTextOptions = true;
            this.Column_IsMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_IsMain.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_IsMain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_IsMain.Caption = "是否负责人";
            this.Column_IsMain.FieldName = "IsMain";
            this.Column_IsMain.Name = "Column_IsMain";
            this.Column_IsMain.OptionsColumn.AllowEdit = false;
            this.Column_IsMain.OptionsColumn.ReadOnly = true;
            this.Column_IsMain.Visible = true;
            this.Column_IsMain.VisibleIndex = 3;
            this.Column_IsMain.Width = 90;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gc_Employee;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(448, 415);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // FormSelectEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 453);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectEmployee";
            this.Text = "选择员工";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_Employee;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Column_IsMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;

    }
}