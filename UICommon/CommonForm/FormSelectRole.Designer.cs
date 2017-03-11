namespace DS.MSClient.UICommon
{
    partial class FormSelectRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectRole));
            this.gc_Role = new DS.MSClient.UIControl.CGridControl();
            this.gv_Role = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_AllSelect = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pagingControl1 = new DS.MSClient.UIControl.PagingControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Role)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Role)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(576, 335);
            this.btnOK.MaximumSize = new System.Drawing.Size(93, 22);
            this.btnOK.MinimumSize = new System.Drawing.Size(93, 22);
            this.btnOK.Size = new System.Drawing.Size(93, 22);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(673, 335);
            this.btnCancel.MaximumSize = new System.Drawing.Size(93, 22);
            this.btnCancel.MinimumSize = new System.Drawing.Size(93, 22);
            this.btnCancel.Size = new System.Drawing.Size(93, 22);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.pagingControl1);
            this.lcMain.Controls.Add(this.btn_AllSelect);
            this.lcMain.Controls.Add(this.gc_Role);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1335, 217, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(773, 364);
            this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
            this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
            this.lcMain.Controls.SetChildIndex(this.gc_Role, 0);
            this.lcMain.Controls.SetChildIndex(this.btn_AllSelect, 0);
            this.lcMain.Controls.SetChildIndex(this.pagingControl1, 0);
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.lcgMain.Size = new System.Drawing.Size(773, 364);
            // 
            // lciOK
            // 
            this.lciOK.Location = new System.Drawing.Point(569, 328);
            this.lciOK.Size = new System.Drawing.Size(97, 26);
            // 
            // lciCancel
            // 
            this.lciCancel.Location = new System.Drawing.Point(666, 328);
            this.lciCancel.Size = new System.Drawing.Size(97, 26);
            // 
            // ssOp
            // 
            this.ssOp.Location = new System.Drawing.Point(0, 326);
            this.ssOp.Size = new System.Drawing.Size(763, 2);
            // 
            // esiOpEmpty
            // 
            this.esiOpEmpty.Location = new System.Drawing.Point(0, 328);
            this.esiOpEmpty.Size = new System.Drawing.Size(472, 26);
            // 
            // lcgContainer
            // 
            this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.lcgContainer.Size = new System.Drawing.Size(763, 326);
            // 
            // gc_Role
            // 
            this.gc_Role.AdvanceSearchMethod = null;
            this.gc_Role.GetPageSizeMethod = null;
            this.gc_Role.GetTotalRecordCountMethod = null;
            this.gc_Role.PageSortOrderSearchMethod = null;
            this.gc_Role.CallCustomNavicationButtonClick = null;
            this.gc_Role.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Role.ImmediatelyDownLoad = false;
            this.gc_Role.Location = new System.Drawing.Point(7, 7);
            this.gc_Role.MainView = this.gv_Role;
            this.gc_Role.Name = "gc_Role";
            this.gc_Role.ShowCustomHeaderMenu = true;
            this.gc_Role.ShowCustomNavigationButtons = false;
            this.gc_Role.ShowCustomRowHeightButton = true;
            this.gc_Role.ShowImmediatelyDownLoadMenu = true;
            this.gc_Role.Size = new System.Drawing.Size(759, 291);
            this.gc_Role.TabIndex = 4;
            this.gc_Role.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Role});
            // 
            // gv_Role
            // 
            this.gv_Role.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Choose,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gv_Role.GridControl = this.gc_Role;
            this.gv_Role.Name = "gv_Role";
            this.gv_Role.OptionsView.ColumnAutoWidth = false;
            this.gv_Role.OptionsView.ShowDetailButtons = false;
            // 
            // gridColumn_Choose
            // 
            this.gridColumn_Choose.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_Choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Choose.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Choose.Caption = "选择";
            this.gridColumn_Choose.FieldName = "Choose";
            this.gridColumn_Choose.Name = "gridColumn_Choose";
            this.gridColumn_Choose.OptionsColumn.AllowEdit = false;
            this.gridColumn_Choose.OptionsColumn.ReadOnly = true;
            this.gridColumn_Choose.Visible = true;
            this.gridColumn_Choose.VisibleIndex = 0;
            this.gridColumn_Choose.Width = 39;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "角色编号";
            this.gridColumn2.FieldName = "RoleCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 178;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "角色名称";
            this.gridColumn3.FieldName = "RoleName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 146;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "备注";
            this.gridColumn4.FieldName = "Note";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 191;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gc_Role;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(763, 295);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // btn_AllSelect
            // 
            this.btn_AllSelect.Image = ((System.Drawing.Image)(resources.GetObject("btn_AllSelect.Image")));
            this.btn_AllSelect.Location = new System.Drawing.Point(479, 335);
            this.btn_AllSelect.MaximumSize = new System.Drawing.Size(93, 22);
            this.btn_AllSelect.MinimumSize = new System.Drawing.Size(93, 22);
            this.btn_AllSelect.Name = "btn_AllSelect";
            this.btn_AllSelect.Size = new System.Drawing.Size(93, 22);
            this.btn_AllSelect.StyleController = this.lcMain;
            this.btn_AllSelect.TabIndex = 5;
            this.btn_AllSelect.Text = "全选";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_AllSelect;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(472, 328);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(97, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // pagingControl1
            // 
            this.pagingControl1.Location = new System.Drawing.Point(7, 302);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.Size = new System.Drawing.Size(759, 27);
            this.pagingControl1.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pagingControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 295);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(763, 31);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // FormSelectRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 364);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectRole";
            this.Text = "选择角色";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Role)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Role)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_Role;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Role;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_AllSelect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private UIControl.PagingControl pagingControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}