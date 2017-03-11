namespace DS.MSClient.UICommon
{
    partial class FormEmployee
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.gv_Employee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.Btn_Cancel);
            this.panelControl1.Controls.Add(this.Btn_Ok);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 452);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(447, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cancel.Location = new System.Drawing.Point(367, 5);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 1;
            this.Btn_Cancel.Text = "取消";
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Ok.Location = new System.Drawing.Point(286, 5);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ok.TabIndex = 0;
            this.Btn_Ok.Text = "确定";
            // 
            // gc_Employee
            // 
            this.gc_Employee.AdvanceSearchMethod = null;
            this.gc_Employee.GetPageSizeMethod = null;
            this.gc_Employee.GetTotalRecordCountMethod = null;
            this.gc_Employee.PageSortOrderSearchMethod = null;
            this.gc_Employee.CallCustomNavicationButtonClick = null;
            this.gc_Employee.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Employee.ImmediatelyDownLoad = false;
            this.gc_Employee.Location = new System.Drawing.Point(0, 0);
            this.gc_Employee.MainView = this.gv_Employee;
            this.gc_Employee.Name = "gc_Employee";
            this.gc_Employee.ShowCustomHeaderMenu = true;
            this.gc_Employee.ShowCustomNavigationButtons = false;
            this.gc_Employee.ShowCustomRowHeightButton = false;
            this.gc_Employee.ShowImmediatelyDownLoadMenu = true;
            this.gc_Employee.Size = new System.Drawing.Size(447, 452);
            this.gc_Employee.TabIndex = 1;
            this.gc_Employee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Employee});
            // 
            // gv_Employee
            // 
            this.gv_Employee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_choose,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gv_Employee.GridControl = this.gc_Employee;
            this.gv_Employee.Name = "gv_Employee";
            // 
            // Column_choose
            // 
            this.Column_choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_choose.Caption = "选择";
            this.Column_choose.FieldName = "Choose";
            this.Column_choose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Column_choose.Name = "Column_choose";
            this.Column_choose.Visible = true;
            this.Column_choose.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "员工编号";
            this.gridColumn1.FieldName = "EmployeeCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "员工名称";
            this.gridColumn2.FieldName = "EmployeeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "助记码";
            this.gridColumn3.FieldName = "MnemonicCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // FormSelectEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 485);
            this.Controls.Add(this.gc_Employee);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectEmployee";
            this.Text = "选择员工";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Ok;
        private DevExpress.XtraEditors.SimpleButton Btn_Cancel;
        private UIControl.CGridControl gc_Employee;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn Column_choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}