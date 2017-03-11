namespace DS.MSClient.UICommon
{
    partial class FormSelectStudentAppointClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectStudentAppointClass));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_AppointClass = new DS.MSClient.UIControl.CGridControl();
            this.gv_AppointClass = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Checked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Choose = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl_Bottom = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl_Class = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_AppointClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_AppointClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Choose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).BeginInit();
            this.panelControl_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Class)).BeginInit();
            this.groupControl_Class.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gc_AppointClass;
            this.gridView4.Name = "gridView4";
            // 
            // gc_AppointClass
            // 
            this.gc_AppointClass.AdvanceSearchMethod = null;
            this.gc_AppointClass.GetPageSizeMethod = null;
            this.gc_AppointClass.GetTotalRecordCountMethod = null;
            this.gc_AppointClass.PageSortOrderSearchMethod = null;
            this.gc_AppointClass.CallCustomNavicationButtonClick = null;
            this.gc_AppointClass.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_AppointClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_AppointClass.ImmediatelyDownLoad = false;
            this.gc_AppointClass.Location = new System.Drawing.Point(2, 22);
            this.gc_AppointClass.MainView = this.gv_AppointClass;
            this.gc_AppointClass.Name = "gc_AppointClass";
            this.gc_AppointClass.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Checked,
            this.Choose});
            this.gc_AppointClass.ShowCustomHeaderMenu = true;
            this.gc_AppointClass.ShowCustomNavigationButtons = false;
            this.gc_AppointClass.ShowCustomRowHeightButton = true;
            this.gc_AppointClass.ShowImmediatelyDownLoadMenu = true;
            this.gc_AppointClass.Size = new System.Drawing.Size(424, 268);
            this.gc_AppointClass.TabIndex = 1;
            this.gc_AppointClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_AppointClass,
            this.gridView6,
            this.gridView4});
            // 
            // gv_AppointClass
            // 
            this.gv_AppointClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Choose,
            this.gridColumn2});
            this.gv_AppointClass.GridControl = this.gc_AppointClass;
            this.gv_AppointClass.Name = "gv_AppointClass";
            this.gv_AppointClass.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gv_AppointClass.OptionsDetail.EnableMasterViewMode = false;
            this.gv_AppointClass.OptionsView.ColumnAutoWidth = false;
            this.gv_AppointClass.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_AppointClass.OptionsView.EnableAppearanceOddRow = true;
            this.gv_AppointClass.OptionsView.ShowDetailButtons = false;
            // 
            // gridColumn_Choose
            // 
            this.gridColumn_Choose.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_Choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Choose.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Choose.Caption = "选择";
            this.gridColumn_Choose.FieldName = "Choose";
            this.gridColumn_Choose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn_Choose.Name = "gridColumn_Choose";
            this.gridColumn_Choose.Visible = true;
            this.gridColumn_Choose.VisibleIndex = 0;
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
            this.gridColumn2.Width = 125;
            // 
            // Checked
            // 
            this.Checked.AutoHeight = false;
            this.Checked.Caption = "";
            this.Checked.Name = "Checked";
            // 
            // Choose
            // 
            this.Choose.AutoHeight = false;
            this.Choose.Caption = "Check";
            this.Choose.Name = "Choose";
            // 
            // gridView6
            // 
            this.gridView6.GridControl = this.gc_AppointClass;
            this.gridView6.Name = "gridView6";
            // 
            // panelControl_Bottom
            // 
            this.panelControl_Bottom.Controls.Add(this.layoutControl1);
            this.panelControl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_Bottom.Location = new System.Drawing.Point(2, 290);
            this.panelControl_Bottom.Name = "panelControl_Bottom";
            this.panelControl_Bottom.Size = new System.Drawing.Size(424, 50);
            this.panelControl_Bottom.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Btn_Cancel);
            this.layoutControl1.Controls.Add(this.Btn_OK);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(977, 154, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(420, 46);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(312, 12);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(96, 22);
            this.Btn_Cancel.StyleController = this.layoutControl1;
            this.Btn_Cancel.TabIndex = 5;
            this.Btn_Cancel.Text = "取消";
            // 
            // Btn_OK
            // 
            this.Btn_OK.Location = new System.Drawing.Point(204, 12);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(104, 22);
            this.Btn_OK.StyleController = this.layoutControl1;
            this.Btn_OK.TabIndex = 4;
            this.Btn_OK.Text = "确定";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(420, 46);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(192, 26);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(192, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(192, 26);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Btn_OK;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(192, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(108, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Btn_Cancel;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(300, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // groupControl_Class
            // 
            this.groupControl_Class.Controls.Add(this.gc_AppointClass);
            this.groupControl_Class.Controls.Add(this.panelControl_Bottom);
            this.groupControl_Class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Class.Location = new System.Drawing.Point(0, 0);
            this.groupControl_Class.Name = "groupControl_Class";
            this.groupControl_Class.Size = new System.Drawing.Size(428, 342);
            this.groupControl_Class.TabIndex = 3;
            this.groupControl_Class.Text = "选择预约大类";
            // 
            // FormSelectStudentAppointClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 342);
            this.Controls.Add(this.groupControl_Class);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectStudentAppointClass";
            this.Text = "预约大类配置";
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_AppointClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_AppointClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Choose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).EndInit();
            this.panelControl_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Class)).EndInit();
            this.groupControl_Class.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private UIControl.CGridControl gc_AppointClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_AppointClass;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Checked;
        private DevExpress.XtraEditors.PanelControl panelControl_Bottom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraEditors.GroupControl groupControl_Class;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Choose;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Choose;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton Btn_OK;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;

    }
}