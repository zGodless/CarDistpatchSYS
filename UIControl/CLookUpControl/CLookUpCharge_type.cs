using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using CrmClient.UIControl;
using DevExpress.XtraTreeList.Columns;
using DS.MSClient.UIControl;
using DS.Model;
using DS.MSClient.UICommon;
using DS.Data;


namespace CrmClient.UIControl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(true)]
    public class CLookUpCharge_type : CSmartTreeListLookUpEditBase
    {
        private RepositoryItemTreeListLookUpEdit fProperties;
        private DevExpress.XtraTreeList.TreeList fPropertiesTreeList;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            EditValueChanged += cLookUp_EditValueChanged;
			//Properties.Buttons.Clear();
			//Properties.Buttons.AddRange(new[]
			//{
			//	new EditorButton(ButtonPredefines.Combo) {IsDefaultButton = true},
			//	new EditorButton(ButtonPredefines.Redo, "刷新") {IsDefaultButton = false} 
			//});
            Properties.TreeList.Columns.Clear();
            if (Properties.TreeList.Columns.Count == 0)
            {
                Properties.TreeList.Columns.AddRange(new[]
				{ 
                    new TreeListColumn()
                    {
                        Name="gridcol_ChargeTypeName",
                        Caption="名称",
                        FieldName="ChargeTypeName",
                        Visible=true,
                        VisibleIndex=1
                    },
                     new TreeListColumn()
                    {
                        Name="gridcol_MnemonicCode",
                        Caption="助记码",
                        FieldName="MnemonicCode",
                        Visible=true,
                        VisibleIndex=3
                    },
                     new TreeListColumn()
                    {
                        Name="gridcol_ChargeTypeID",
                        Caption="ChargeTypeID",
                        FieldName="ChargeTypeID",
                        Visible=false
                    }
				});
            }
            Properties.CharacterCasing = CharacterCasing.Upper;
            Properties.NullText = string.Empty;
            Properties.NullValuePrompt = string.Empty;
            Properties.NullValuePromptShowForEmptyValue = true;
            Properties.PopupSizeable = true;
            Properties.ShowFooter = true;
            Properties.TreeList.OptionsView.ShowHorzLines = false;
            Properties.TreeList.OptionsView.ShowVertLines = false;
            Properties.TreeList.OptionsFind.AllowFindPanel = true;
            Properties.TreeList.OptionsFind.AlwaysVisible = true;
            Properties.TreeList.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always;
            Properties.TreeList.OptionsFind.FindDelay = 200;
            Properties.TreeList.OptionsBehavior.AllowIncrementalSearch = true;
            Properties.TreeList.OptionsBehavior.EnableFiltering = true;
            Properties.PopupFormMinSize = new System.Drawing.Size(400, 300);

            Properties.TreeList.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always;
            Refresh(true);
        }

        #region 属性

        public List<ChargeType> ListIsValid { get; set; }
        public ChargeType CurrentCommerce_type { get; set; }

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(false);
        }
        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList(bool getFromCache = true)
        {
            if (getFromCache)
            {
                ListIsValid = (List<ChargeType>)ClientCache.GetAuto("ChargeType", () => new ChargeTypeDAO().GetList());
            }
            else
            {
                ListIsValid = (List<ChargeType>)ClientCache.GetUpdate("ChargeType", () => new ChargeTypeDAO().GetList());
            }

            Properties.TreeList.DataSource = ListIsValid;
            Properties.TreeList.KeyFieldName = "ChargeTypeID";
            Properties.TreeList.ParentFieldName = "ParentChargeTypeID";
            Properties.DisplayMember = "ChargeTypeName";
            Properties.ValueMember = "ChargeTypeID";
            Properties.TreeList.RefreshDataSource();
            Properties.DataSource = ListIsValid;

            Properties.TreeList.ExpandToLevel(1);
            if (ListIsValid.Count > 0)
            {
                Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            }
        }

        /// <summary>
        ///     值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cLookUp_EditValueChanged(object sender, EventArgs e)
        {
            if (ListIsValid == null) return;
            CurrentCommerce_type = EditValue == null
                    ? null
                    : ListIsValid.Find(model => model.ChargeTypeID == Convert.ToInt32(EditValue));
        }
        #endregion

        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemTreeListLookUpEdit();
            this.fPropertiesTreeList = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "刷新", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "新增", null, null, true)});
            this.fProperties.Name = "fProperties";
            this.fProperties.TreeList = this.fPropertiesTreeList;
            // 
            // fPropertiesTreeList
            // 
            this.fPropertiesTreeList.Location = new System.Drawing.Point(0, 0);
            this.fPropertiesTreeList.Name = "fPropertiesTreeList";
            this.fPropertiesTreeList.OptionsBehavior.EnableFiltering = true;
            this.fPropertiesTreeList.OptionsView.ShowHorzLines = false;
            this.fPropertiesTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.fPropertiesTreeList.OptionsView.ShowPreview = true;
            this.fPropertiesTreeList.OptionsView.ShowVertLines = false;
            this.fPropertiesTreeList.Size = new System.Drawing.Size(400, 200);
            this.fPropertiesTreeList.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesTreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
