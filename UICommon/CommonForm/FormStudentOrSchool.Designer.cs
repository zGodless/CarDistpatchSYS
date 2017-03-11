namespace DS.MSClient.UICommon
{
    partial class FormStudentOrSchool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStudentOrSchool));
            this.IsCoach = new System.Windows.Forms.RadioButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.IsStudent = new System.Windows.Forms.RadioButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(98, 119);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(183, 119);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.IsStudent);
            this.lcMain.Controls.Add(this.IsCoach);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(847, 223, 250, 350);
            this.lcMain.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lcMain.Size = new System.Drawing.Size(269, 148);
            this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
            this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
            this.lcMain.Controls.SetChildIndex(this.IsCoach, 0);
            this.lcMain.Controls.SetChildIndex(this.IsStudent, 0);
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgMain.Name = "Root";
            this.lcgMain.Size = new System.Drawing.Size(269, 148);
            this.lcgMain.Text = "Root";
            // 
            // lciOK
            // 
            this.lciOK.Location = new System.Drawing.Point(91, 112);
            // 
            // lciCancel
            // 
            this.lciCancel.Location = new System.Drawing.Point(176, 112);
            // 
            // esiOpEmpty
            // 
            this.esiOpEmpty.Location = new System.Drawing.Point(0, 112);
            this.esiOpEmpty.Size = new System.Drawing.Size(91, 26);
            // 
            // lcgContainer
            // 
            this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.ssOp,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.lcgContainer.Size = new System.Drawing.Size(259, 112);
            // 
            // IsCoach
            // 
            this.IsCoach.Location = new System.Drawing.Point(17, 7);
            this.IsCoach.Name = "IsCoach";
            this.IsCoach.Size = new System.Drawing.Size(245, 25);
            this.IsCoach.TabIndex = 4;
            this.IsCoach.TabStop = true;
            this.IsCoach.Text = "教练";
            this.IsCoach.UseVisualStyleBackColor = true;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.IsCoach;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(10, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(249, 29);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // IsStudent
            // 
            this.IsStudent.Location = new System.Drawing.Point(17, 36);
            this.IsStudent.Name = "IsStudent";
            this.IsStudent.Size = new System.Drawing.Size(245, 25);
            this.IsStudent.TabIndex = 5;
            this.IsStudent.TabStop = true;
            this.IsStudent.Text = "学员";
            this.IsStudent.UseVisualStyleBackColor = true;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.IsStudent;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(10, 29);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(249, 29);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(10, 58);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(249, 52);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 110);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormStudentOrSchool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 148);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.Name = "FormStudentOrSchool";
            this.Text = "取消人";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RadioButton IsStudent;
        public System.Windows.Forms.RadioButton IsCoach;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;

    }
}