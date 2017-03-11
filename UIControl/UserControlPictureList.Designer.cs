namespace DS.MSClient.UIControl
{
    partial class UserControlPictureList
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

       /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gc_picture = new DevExpress.XtraGrid.GridControl();
            this.gv_picture = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colCaption = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colYear = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colPlotoutLine = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colRunTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colPhoto = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rItem_picture = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemHyperLinkEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.layoutViewField_colPhoto = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colPlotoutLine = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colCaption = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colYear = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colRunTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.gc_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rItem_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPlotoutLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colRunTime)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_picture
            // 
            this.gc_picture.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_picture.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gc_picture.Location = new System.Drawing.Point(0, 0);
            this.gc_picture.MainView = this.gv_picture;
            this.gc_picture.Name = "gc_picture";
            this.gc_picture.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit3,
            this.rItem_picture,
            this.repositoryItemHyperLinkEdit3,
            this.repositoryItemMemoEdit3});
            this.gc_picture.Size = new System.Drawing.Size(466, 324);
            this.gc_picture.TabIndex = 9;
            this.gc_picture.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_picture});
            // 
            // gv_picture
            // 
            this.gv_picture.Appearance.CardCaption.Options.UseTextOptions = true;
            this.gv_picture.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_picture.Appearance.CardCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gv_picture.Appearance.FocusedCardCaption.Options.UseFont = true;
            this.gv_picture.Appearance.FocusedCardCaption.Options.UseTextOptions = true;
            this.gv_picture.Appearance.FocusedCardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_picture.Appearance.FocusedCardCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gv_picture.Appearance.HideSelectionCardCaption.Options.UseTextOptions = true;
            this.gv_picture.Appearance.HideSelectionCardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_picture.Appearance.HideSelectionCardCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gv_picture.Appearance.SelectedCardCaption.Options.UseTextOptions = true;
            this.gv_picture.Appearance.SelectedCardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_picture.Appearance.SelectedCardCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gv_picture.CardCaptionFormat = "{2}";
            this.gv_picture.CardMinSize = new System.Drawing.Size(185, 151);
            this.gv_picture.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colCaption,
            this.colYear,
            this.colPlotoutLine,
            this.colRunTime,
            this.colPhoto});
            this.gv_picture.GridControl = this.gc_picture;
            this.gv_picture.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colCaption,
            this.layoutViewField_colYear,
            this.layoutViewField_colRunTime});
            this.gv_picture.Name = "gv_picture";
            this.gv_picture.OptionsCarouselMode.BottomCardAlphaLevel = 100F;
            this.gv_picture.OptionsCarouselMode.BottomCardScale = 0.4F;
            this.gv_picture.OptionsCarouselMode.PitchAngle = 1F;
            this.gv_picture.OptionsHeaderPanel.EnableCustomizeButton = false;
            this.gv_picture.OptionsHeaderPanel.ShowCustomizeButton = false;
            this.gv_picture.OptionsItemText.TextToControlDistance = 2;
            this.gv_picture.OptionsView.AllowHotTrackFields = false;
            this.gv_picture.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.NeverAnimate;
            this.gv_picture.OptionsView.ShowCardExpandButton = false;
            this.gv_picture.OptionsView.ShowCardLines = false;
            this.gv_picture.OptionsView.ShowFieldHints = false;
            this.gv_picture.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gv_picture.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.gv_picture.TemplateCard = this.layoutViewCard1;
            // 
            // colCaption
            // 
            this.colCaption.Caption = "Caption";
            this.colCaption.ColumnEdit = this.repositoryItemTextEdit3;
            this.colCaption.CustomizationCaption = "Caption";
            this.colCaption.FieldName = "PictureName";
            this.colCaption.LayoutViewField = this.layoutViewField_colCaption;
            this.colCaption.Name = "colCaption";
            this.colCaption.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCaption.OptionsFilter.AllowFilter = false;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // colYear
            // 
            this.colYear.Caption = "状态";
            this.colYear.CustomizationCaption = "状态";
            this.colYear.FieldName = "MyStatus";
            this.colYear.LayoutViewField = this.layoutViewField_colYear;
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colYear.OptionsFilter.AllowFilter = false;
            // 
            // colPlotoutLine
            // 
            this.colPlotoutLine.FieldName = "sNote";
            this.colPlotoutLine.LayoutViewField = this.layoutViewField_colPlotoutLine;
            this.colPlotoutLine.Name = "colPlotoutLine";
            this.colPlotoutLine.OptionsColumn.AllowEdit = false;
            this.colPlotoutLine.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPlotoutLine.OptionsFilter.AllowFilter = false;
            // 
            // colRunTime
            // 
            this.colRunTime.FieldName = "Note";
            this.colRunTime.LayoutViewField = this.layoutViewField_colRunTime;
            this.colRunTime.Name = "colRunTime";
            this.colRunTime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRunTime.OptionsFilter.AllowFilter = false;
            // 
            // colPhoto
            // 
            this.colPhoto.Caption = "Img";
            this.colPhoto.ColumnEdit = this.rItem_picture;
            this.colPhoto.CustomizationCaption = "Img";
            this.colPhoto.FieldName = "Img";
            this.colPhoto.LayoutViewField = this.layoutViewField_colPhoto;
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPhoto.OptionsColumn.ReadOnly = true;
            this.colPhoto.OptionsFilter.AllowFilter = false;
            // 
            // rItem_picture
            // 
            this.rItem_picture.CustomHeight = 70;
            this.rItem_picture.InitialImage = null;
            this.rItem_picture.Name = "rItem_picture";
            this.rItem_picture.NullText = "无图片数据";
            this.rItem_picture.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // repositoryItemHyperLinkEdit3
            // 
            this.repositoryItemHyperLinkEdit3.AutoHeight = false;
            this.repositoryItemHyperLinkEdit3.Name = "repositoryItemHyperLinkEdit3";
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colPhoto,
            this.layoutViewField_colPlotoutLine});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 2;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // layoutViewField_colPhoto
            // 
            this.layoutViewField_colPhoto.EditorPreferredWidth = 183;
            this.layoutViewField_colPhoto.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colPhoto.Name = "layoutViewField_colPhoto";
            this.layoutViewField_colPhoto.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutViewField_colPhoto.Size = new System.Drawing.Size(183, 109);
            this.layoutViewField_colPhoto.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutViewField_colPhoto.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colPhoto.TextToControlDistance = 0;
            this.layoutViewField_colPhoto.TextVisible = false;
            // 
            // layoutViewField_colPlotoutLine
            // 
            this.layoutViewField_colPlotoutLine.EditorPreferredWidth = 183;
            this.layoutViewField_colPlotoutLine.Location = new System.Drawing.Point(0, 109);
            this.layoutViewField_colPlotoutLine.Name = "layoutViewField_colPlotoutLine";
            this.layoutViewField_colPlotoutLine.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutViewField_colPlotoutLine.Size = new System.Drawing.Size(183, 20);
            this.layoutViewField_colPlotoutLine.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutViewField_colPlotoutLine.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colPlotoutLine.TextToControlDistance = 0;
            this.layoutViewField_colPlotoutLine.TextVisible = false;
            // 
            // layoutViewField_colCaption
            // 
            this.layoutViewField_colCaption.EditorPreferredWidth = 25;
            this.layoutViewField_colCaption.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colCaption.Name = "layoutViewField_colCaption";
            this.layoutViewField_colCaption.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutViewField_colCaption.Size = new System.Drawing.Size(188, 96);
            this.layoutViewField_colCaption.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutViewField_colCaption.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colCaption.TextToControlDistance = 0;
            this.layoutViewField_colCaption.TextVisible = false;
            // 
            // layoutViewField_colYear
            // 
            this.layoutViewField_colYear.EditorPreferredWidth = 20;
            this.layoutViewField_colYear.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colYear.Name = "layoutViewField_colYear";
            this.layoutViewField_colYear.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutViewField_colYear.Size = new System.Drawing.Size(188, 96);
            this.layoutViewField_colYear.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutViewField_colYear.TextSize = new System.Drawing.Size(52, 14);
            this.layoutViewField_colYear.TextToControlDistance = 6;
            // 
            // layoutViewField_colRunTime
            // 
            this.layoutViewField_colRunTime.EditorPreferredWidth = 20;
            this.layoutViewField_colRunTime.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colRunTime.Name = "layoutViewField_colRunTime";
            this.layoutViewField_colRunTime.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutViewField_colRunTime.Size = new System.Drawing.Size(188, 96);
            this.layoutViewField_colRunTime.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutViewField_colRunTime.TextSize = new System.Drawing.Size(52, 14);
            this.layoutViewField_colRunTime.TextToControlDistance = 6;
            // 
            // UserControlPictureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_picture);
            this.Name = "UserControlPictureList";
            this.Size = new System.Drawing.Size(466, 324);
            ((System.ComponentModel.ISupportInitialize)(this.gc_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rItem_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPlotoutLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colRunTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gc_picture;
        private DevExpress.XtraGrid.Views.Layout.LayoutView gv_picture;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCaption;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colYear;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPlotoutLine;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colRunTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPhoto;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rItem_picture;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCaption;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colYear;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPlotoutLine;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colRunTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPhoto;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
      
    }
}
