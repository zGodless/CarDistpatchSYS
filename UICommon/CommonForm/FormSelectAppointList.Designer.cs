namespace DS.MSClient.UICommon
{
    partial class FormSelectAppointList
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectAppointList));
            this.groupControl_Class = new DevExpress.XtraEditors.GroupControl();
            this.gc_AppointClass = new DS.MSClient.UIControl.CGridControl();
            this.gv_AppointClass = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Checked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl_Bottom = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_Next = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Canel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_Coach = new DevExpress.XtraEditors.GroupControl();
            this.gc_Coatch = new DS.MSClient.UIControl.CGridControl();
            this.gv_Coatch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_next_coach = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Return = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_list = new DevExpress.XtraEditors.GroupControl();
            this.gc_Appoint = new DS.MSClient.UIControl.CGridControl();
            this.gv_Appoint = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridC_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.IsVip_Check = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_date = new DevExpress.XtraEditors.DateEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_sumbit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_return2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Class)).BeginInit();
            this.groupControl_Class.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_AppointClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_AppointClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).BeginInit();
            this.panelControl_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Coach)).BeginInit();
            this.groupControl_Coach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Coatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Coatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_list)).BeginInit();
            this.groupControl_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Appoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Appoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IsVip_Check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_date.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl_Class
            // 
            this.groupControl_Class.Controls.Add(this.gc_AppointClass);
            this.groupControl_Class.Controls.Add(this.panelControl_Bottom);
            this.groupControl_Class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Class.Location = new System.Drawing.Point(0, 0);
            this.groupControl_Class.Name = "groupControl_Class";
            this.groupControl_Class.Size = new System.Drawing.Size(596, 507);
            this.groupControl_Class.TabIndex = 0;
            this.groupControl_Class.Text = "选择预约大类";
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
            this.Checked});
            this.gc_AppointClass.ShowCustomHeaderMenu = true;
            this.gc_AppointClass.ShowCustomNavigationButtons = false;
            this.gc_AppointClass.ShowCustomRowHeightButton = true;
            this.gc_AppointClass.ShowImmediatelyDownLoadMenu = true;
            this.gc_AppointClass.Size = new System.Drawing.Size(592, 435);
            this.gc_AppointClass.TabIndex = 1;
            this.gc_AppointClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_AppointClass});
            // 
            // gv_AppointClass
            // 
            this.gv_AppointClass.Appearance.FocusedRow.BackColor = System.Drawing.Color.DodgerBlue;
            this.gv_AppointClass.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DodgerBlue;
            this.gv_AppointClass.Appearance.FocusedRow.BorderColor = System.Drawing.Color.DodgerBlue;
            this.gv_AppointClass.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_AppointClass.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gv_AppointClass.Appearance.FocusedRow.Options.UseFont = true;
            this.gv_AppointClass.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gv_AppointClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.gv_AppointClass.GridControl = this.gc_AppointClass;
            this.gv_AppointClass.Name = "gv_AppointClass";
            this.gv_AppointClass.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_AppointClass.OptionsView.ColumnAutoWidth = false;
            this.gv_AppointClass.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_AppointClass.OptionsView.EnableAppearanceOddRow = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "大类";
            this.gridColumn2.FieldName = "AppointClassName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "AppointClassID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            // 
            // Checked
            // 
            this.Checked.AutoHeight = false;
            this.Checked.Caption = "";
            this.Checked.Name = "Checked";
            // 
            // panelControl_Bottom
            // 
            this.panelControl_Bottom.Controls.Add(this.simpleButton_Next);
            this.panelControl_Bottom.Controls.Add(this.simpleButton_Canel);
            this.panelControl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_Bottom.Location = new System.Drawing.Point(2, 457);
            this.panelControl_Bottom.Name = "panelControl_Bottom";
            this.panelControl_Bottom.Size = new System.Drawing.Size(592, 48);
            this.panelControl_Bottom.TabIndex = 2;
            // 
            // simpleButton_Next
            // 
            this.simpleButton_Next.Location = new System.Drawing.Point(514, 16);
            this.simpleButton_Next.Name = "simpleButton_Next";
            this.simpleButton_Next.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Next.TabIndex = 1;
            this.simpleButton_Next.Text = "下一步";
            // 
            // simpleButton_Canel
            // 
            this.simpleButton_Canel.Location = new System.Drawing.Point(421, 15);
            this.simpleButton_Canel.Name = "simpleButton_Canel";
            this.simpleButton_Canel.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Canel.TabIndex = 0;
            this.simpleButton_Canel.Text = "取消";
            // 
            // groupControl_Coach
            // 
            this.groupControl_Coach.Controls.Add(this.gc_Coatch);
            this.groupControl_Coach.Controls.Add(this.panelControl1);
            this.groupControl_Coach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Coach.Location = new System.Drawing.Point(0, 0);
            this.groupControl_Coach.Name = "groupControl_Coach";
            this.groupControl_Coach.Size = new System.Drawing.Size(596, 507);
            this.groupControl_Coach.TabIndex = 1;
            this.groupControl_Coach.Text = "选择教练";
            // 
            // gc_Coatch
            // 
            this.gc_Coatch.AdvanceSearchMethod = null;
            this.gc_Coatch.GetPageSizeMethod = null;
            this.gc_Coatch.GetTotalRecordCountMethod = null;
            this.gc_Coatch.PageSortOrderSearchMethod = null;
            this.gc_Coatch.CallCustomNavicationButtonClick = null;
            this.gc_Coatch.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Coatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Coatch.ImmediatelyDownLoad = false;
            this.gc_Coatch.Location = new System.Drawing.Point(2, 22);
            this.gc_Coatch.MainView = this.gv_Coatch;
            this.gc_Coatch.Name = "gc_Coatch";
            this.gc_Coatch.ShowCustomHeaderMenu = true;
            this.gc_Coatch.ShowCustomNavigationButtons = false;
            this.gc_Coatch.ShowCustomRowHeightButton = true;
            this.gc_Coatch.ShowImmediatelyDownLoadMenu = true;
            this.gc_Coatch.Size = new System.Drawing.Size(592, 431);
            this.gc_Coatch.TabIndex = 2;
            this.gc_Coatch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Coatch});
            // 
            // gv_Coatch
            // 
            this.gv_Coatch.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gv_Coatch.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.gv_Coatch.Appearance.FocusedRow.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.gv_Coatch.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_Coatch.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gv_Coatch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4});
            this.gv_Coatch.GridControl = this.gc_Coatch;
            this.gv_Coatch.Name = "gv_Coatch";
            this.gv_Coatch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_Coatch.OptionsView.ColumnAutoWidth = false;
            this.gv_Coatch.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_Coatch.OptionsView.EnableAppearanceOddRow = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "教练名";
            this.gridColumn1.FieldName = "EmployeeName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.FieldName = "CoachID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton_next_coach);
            this.panelControl1.Controls.Add(this.simpleButton_Return);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 453);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(592, 52);
            this.panelControl1.TabIndex = 3;
            // 
            // simpleButton_next_coach
            // 
            this.simpleButton_next_coach.Location = new System.Drawing.Point(502, 20);
            this.simpleButton_next_coach.Name = "simpleButton_next_coach";
            this.simpleButton_next_coach.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_next_coach.TabIndex = 1;
            this.simpleButton_next_coach.Text = "下一步";
            // 
            // simpleButton_Return
            // 
            this.simpleButton_Return.Location = new System.Drawing.Point(397, 19);
            this.simpleButton_Return.Name = "simpleButton_Return";
            this.simpleButton_Return.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_Return.TabIndex = 0;
            this.simpleButton_Return.Text = "上一步";
            // 
            // groupControl_list
            // 
            this.groupControl_list.Controls.Add(this.gc_Appoint);
            this.groupControl_list.Controls.Add(this.panelControl2);
            this.groupControl_list.Controls.Add(this.panelControl3);
            this.groupControl_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_list.Location = new System.Drawing.Point(0, 0);
            this.groupControl_list.Name = "groupControl_list";
            this.groupControl_list.Size = new System.Drawing.Size(596, 507);
            this.groupControl_list.TabIndex = 2;
            this.groupControl_list.Text = "预约详情";
            // 
            // gc_Appoint
            // 
            this.gc_Appoint.AdvanceSearchMethod = null;
            this.gc_Appoint.GetPageSizeMethod = null;
            this.gc_Appoint.GetTotalRecordCountMethod = null;
            this.gc_Appoint.PageSortOrderSearchMethod = null;
            this.gc_Appoint.CallCustomNavicationButtonClick = null;
            this.gc_Appoint.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Appoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Appoint.ImmediatelyDownLoad = false;
            gridLevelNode1.RelationName = "Level1";
            this.gc_Appoint.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gc_Appoint.Location = new System.Drawing.Point(2, 83);
            this.gc_Appoint.MainView = this.gv_Appoint;
            this.gc_Appoint.Name = "gc_Appoint";
            this.gc_Appoint.ShowCustomHeaderMenu = true;
            this.gc_Appoint.ShowCustomNavigationButtons = false;
            this.gc_Appoint.ShowCustomRowHeightButton = true;
            this.gc_Appoint.ShowImmediatelyDownLoadMenu = true;
            this.gc_Appoint.Size = new System.Drawing.Size(592, 370);
            this.gc_Appoint.TabIndex = 1;
            this.gc_Appoint.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Appoint});
            // 
            // gv_Appoint
            // 
            this.gv_Appoint.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridC_Choose,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gv_Appoint.GridControl = this.gc_Appoint;
            this.gv_Appoint.Name = "gv_Appoint";
            this.gv_Appoint.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_Appoint.OptionsView.EnableAppearanceOddRow = true;
            // 
            // gridC_Choose
            // 
            this.gridC_Choose.Caption = "选择";
            this.gridC_Choose.FieldName = "Choose";
            this.gridC_Choose.Name = "gridC_Choose";
            this.gridC_Choose.OptionsColumn.AllowEdit = false;
            this.gridC_Choose.OptionsColumn.ReadOnly = true;
            this.gridC_Choose.Visible = true;
            this.gridC_Choose.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn5";
            this.gridColumn5.FieldName = "AppointmentID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "开始时间";
            this.gridColumn6.DisplayFormat.FormatString = "HH:mm:ss";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "BeginTime";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "结束时间";
            this.gridColumn7.DisplayFormat.FormatString = "HH:mm:ss";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "EndTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "剩余名额";
            this.gridColumn8.FieldName = "Num";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.IsVip_Check);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txt_date);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 22);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(592, 61);
            this.panelControl2.TabIndex = 0;
            // 
            // IsVip_Check
            // 
            this.IsVip_Check.Location = new System.Drawing.Point(344, 17);
            this.IsVip_Check.Name = "IsVip_Check";
            this.IsVip_Check.Properties.Caption = "是否一对一";
            this.IsVip_Check.Size = new System.Drawing.Size(87, 19);
            this.IsVip_Check.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "预约日期";
            // 
            // txt_date
            // 
            this.txt_date.EditValue = null;
            this.txt_date.Location = new System.Drawing.Point(94, 17);
            this.txt_date.Name = "txt_date";
            this.txt_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_date.Size = new System.Drawing.Size(117, 20);
            this.txt_date.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.simpleButton_sumbit);
            this.panelControl3.Controls.Add(this.simpleButton_return2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 453);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(592, 52);
            this.panelControl3.TabIndex = 2;
            // 
            // simpleButton_sumbit
            // 
            this.simpleButton_sumbit.Location = new System.Drawing.Point(502, 20);
            this.simpleButton_sumbit.Name = "simpleButton_sumbit";
            this.simpleButton_sumbit.Size = new System.Drawing.Size(80, 26);
            this.simpleButton_sumbit.TabIndex = 3;
            this.simpleButton_sumbit.Text = "提交";
            // 
            // simpleButton_return2
            // 
            this.simpleButton_return2.Location = new System.Drawing.Point(410, 20);
            this.simpleButton_return2.Name = "simpleButton_return2";
            this.simpleButton_return2.Size = new System.Drawing.Size(74, 27);
            this.simpleButton_return2.TabIndex = 0;
            this.simpleButton_return2.Text = "上一步";
            // 
            // FormSelectAppointList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 507);
            this.Controls.Add(this.groupControl_Coach);
            this.Controls.Add(this.groupControl_list);
            this.Controls.Add(this.groupControl_Class);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectAppointList";
            this.Text = "电话预约";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Class)).EndInit();
            this.groupControl_Class.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_AppointClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_AppointClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).EndInit();
            this.panelControl_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Coach)).EndInit();
            this.groupControl_Coach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Coatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Coatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_list)).EndInit();
            this.groupControl_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Appoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Appoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IsVip_Check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_date.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl_Class;
        private DevExpress.XtraEditors.GroupControl groupControl_Coach;
        private DevExpress.XtraEditors.GroupControl groupControl_list;
        private UIControl.CGridControl gc_AppointClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_AppointClass;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Checked;
        private DevExpress.XtraEditors.PanelControl panelControl_Bottom;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Next;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Canel;
        private UIControl.CGridControl gc_Coatch;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Coatch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_next_coach;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Return;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private UIControl.CGridControl gc_Appoint;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Appoint;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.CheckEdit IsVip_Check;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txt_date;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton_sumbit;
        private DevExpress.XtraEditors.SimpleButton simpleButton_return2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridC_Choose;
    }
}