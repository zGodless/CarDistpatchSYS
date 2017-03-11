namespace CarDistpatchSYS
{
    partial class FormEditDepartment
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.memoNote = new DevExpress.XtraEditors.MemoEdit();
            this.cLInChargeID = new DS.MSClient.UIControl.CLookEmployee();
            this.textEmployeeCount = new DevExpress.XtraEditors.TextEdit();
            this.textDepartmentCode = new DevExpress.XtraEditors.TextEdit();
            this.textDepartmentName = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.clParentID = new DS.MSClient.UIControl.CLookDepartment();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLInChargeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEmployeeCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDepartmentCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.clParentID);
            this.layoutControl1.Controls.Add(this.memoNote);
            this.layoutControl1.Controls.Add(this.cLInChargeID);
            this.layoutControl1.Controls.Add(this.textEmployeeCount);
            this.layoutControl1.Controls.Add(this.textDepartmentCode);
            this.layoutControl1.Controls.Add(this.textDepartmentName);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(548, 242);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // memoNote
            // 
            this.memoNote.Location = new System.Drawing.Point(63, 84);
            this.memoNote.Name = "memoNote";
            this.memoNote.Size = new System.Drawing.Size(473, 120);
            this.memoNote.StyleController = this.layoutControl1;
            this.memoNote.TabIndex = 22;
            this.memoNote.UseOptimizedRendering = true;
            // 
            // cLInChargeID
            // 
            this.cLInChargeID.ClearButton = false;
            this.cLInChargeID.Currentduty = null;
            this.cLInChargeID.ListIsValid = null;
            this.cLInChargeID.Location = new System.Drawing.Point(327, 36);
            this.cLInChargeID.MaximumSize = new System.Drawing.Size(0, 20);
            this.cLInChargeID.Name = "cLInChargeID";
            this.cLInChargeID.Properties.ActionButtonIndex = 1;
            this.cLInChargeID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cLInChargeID.Properties.AutoHeight = false;
            this.cLInChargeID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cLInChargeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "刷新", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "新增", null, null, true)});
            this.cLInChargeID.Properties.CaseSensitiveSearch = true;
            this.cLInChargeID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cLInChargeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeCode", "员工编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeName", "员工姓名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "所属部门")});
            this.cLInChargeID.Properties.NullText = "";
            this.cLInChargeID.Properties.NullValuePromptShowForEmptyValue = true;
            this.cLInChargeID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cLInChargeID.Size = new System.Drawing.Size(209, 20);
            this.cLInChargeID.StyleController = this.layoutControl1;
            this.cLInChargeID.TabIndex = 12;
            this.cLInChargeID.ToolTip = "清除选择:[CTRL + 0]";
            // 
            // textEmployeeCount
            // 
            this.textEmployeeCount.Location = new System.Drawing.Point(63, 60);
            this.textEmployeeCount.Name = "textEmployeeCount";
            this.textEmployeeCount.Size = new System.Drawing.Size(209, 20);
            this.textEmployeeCount.StyleController = this.layoutControl1;
            this.textEmployeeCount.TabIndex = 8;
            // 
            // textDepartmentCode
            // 
            this.textDepartmentCode.Location = new System.Drawing.Point(327, 12);
            this.textDepartmentCode.Name = "textDepartmentCode";
            this.textDepartmentCode.Size = new System.Drawing.Size(209, 20);
            this.textDepartmentCode.StyleController = this.layoutControl1;
            this.textDepartmentCode.TabIndex = 7;
            // 
            // textDepartmentName
            // 
            this.textDepartmentName.Location = new System.Drawing.Point(63, 12);
            this.textDepartmentName.Name = "textDepartmentName";
            this.textDepartmentName.Size = new System.Drawing.Size(209, 20);
            this.textDepartmentName.StyleController = this.layoutControl1;
            this.textDepartmentName.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(408, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(276, 208);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 22);
            this.btnOK.StyleController = this.layoutControl1;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定保存";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem19,
            this.layoutControlItem9,
            this.emptySpaceItem1,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(548, 242);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 196);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(264, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnOK;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(264, 196);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(132, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(396, 196);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(132, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textDepartmentName;
            this.layoutControlItem3.CustomizationFormText = "车牌号";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(264, 24);
            this.layoutControlItem3.Text = "部门名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textDepartmentCode;
            this.layoutControlItem4.CustomizationFormText = "车型";
            this.layoutControlItem4.Location = new System.Drawing.Point(264, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(264, 24);
            this.layoutControlItem4.Text = "部门编号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.textEmployeeCount;
            this.layoutControlItem5.CustomizationFormText = "发动机号";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(264, 24);
            this.layoutControlItem5.Text = "员工数量";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.memoNote;
            this.layoutControlItem19.CustomizationFormText = "   备注";
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(528, 124);
            this.layoutControlItem19.Text = "   备注";
            this.layoutControlItem19.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.cLInChargeID;
            this.layoutControlItem9.CustomizationFormText = "使用人";
            this.layoutControlItem9.Location = new System.Drawing.Point(264, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(264, 24);
            this.layoutControlItem9.Text = "负责人";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(264, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(264, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // clParentID
            // 
            this.clParentID.ClearButton = false;
            this.clParentID.Currentduty = null;
            this.clParentID.ListIsValid = null;
            this.clParentID.Location = new System.Drawing.Point(63, 36);
            this.clParentID.MaximumSize = new System.Drawing.Size(0, 20);
            this.clParentID.Name = "clParentID";
            this.clParentID.Properties.ActionButtonIndex = 1;
            this.clParentID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.clParentID.Properties.AutoHeight = false;
            this.clParentID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.clParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "刷新", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "新增", null, null, true)});
            this.clParentID.Properties.CaseSensitiveSearch = true;
            this.clParentID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.clParentID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "部门名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ParentName", "上级部门"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InChargeName", "负责人")});
            this.clParentID.Properties.NullText = "";
            this.clParentID.Properties.NullValuePromptShowForEmptyValue = true;
            this.clParentID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.clParentID.Size = new System.Drawing.Size(209, 20);
            this.clParentID.StyleController = this.layoutControl1;
            this.clParentID.TabIndex = 23;
            this.clParentID.ToolTip = "清除选择:[CTRL + 0]";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.clParentID;
            this.layoutControlItem6.CustomizationFormText = "上级部门";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(264, 24);
            this.layoutControlItem6.Text = "上级部门";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // FormEditDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 242);
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.Name = "FormEditDepartment";
            this.Text = "编辑部门";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLInChargeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEmployeeCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDepartmentCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit textEmployeeCount;
        private DevExpress.XtraEditors.TextEdit textDepartmentCode;
        private DevExpress.XtraEditors.TextEdit textDepartmentName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.MemoEdit memoNote;
        private DS.MSClient.UIControl.CLookEmployee cLInChargeID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DS.MSClient.UIControl.CLookDepartment clParentID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}