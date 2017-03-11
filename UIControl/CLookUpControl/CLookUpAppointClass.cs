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
using DS.MSClient.UICommon;
using DS.MSClient.UICommon.CommonForm;
using DevExpress.XtraEditors.Repository;
using DS.MSClient.UIControl;
using DS.Model;
using DS.Data;

namespace DS.MSClient.UIControl
{
    [ToolboxItem(true)]
    public class CLookUpAppointClass : CSmartLookUpEditBase
    {
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
            if (Properties.Columns.Count == 0)
            {
                Properties.Columns.AddRange(new[]
				{
					new LookUpColumnInfo("AppointClassCode", "编号"),
					new LookUpColumnInfo("AppointClassName", "名称"),
					new LookUpColumnInfo("MnemonicCode", "助记码")
				});
            }
            Properties.CharacterCasing = CharacterCasing.Upper;
            Properties.NullText = string.Empty;
            Properties.NullValuePrompt = string.Empty;
            Properties.NullValuePromptShowForEmptyValue = true;
            Properties.PopupSizeable = true;
            Properties.ShowFooter = true;
            Properties.ShowHeader = true;
            Refresh(true);
        }

        #region 属性

        public List<AppointClass> ListIsValid { get; set; }
        public AppointClass CurrentAppointClass { get; set; }

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(false);
        }
        protected override void OnNewButtonClick()
        {
            //FormAppointClass form = new FormAppointClass();
            //form.FormClosed += (s, e) =>
            //{
            //    BindList(false);
            //};
            //form.Show();
        }

        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList(bool getFromCache = true)
        {
            if (getFromCache)
            {
                ListIsValid = (List<AppointClass>)ClientCache.GetAuto("AppointClass", () => new AppointClassDao().GetList());
            }
            else
            {
                ListIsValid = (List<AppointClass>)ClientCache.GetUpdate("AppointClass", () => new AppointClassDao().GetList());
            }
            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "AppointClassName";
            Properties.ValueMember = "AppointClassID";
            Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            Properties.SearchMode = SearchMode.AutoFilter;
            Properties.CaseSensitiveSearch = true;
            Properties.AutoSearchColumnIndex = 2;
        }

        /// <summary>
        ///     值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cLookUp_EditValueChanged(object sender, EventArgs e)
        {
            if (ListIsValid == null) return;
             CurrentAppointClass = EditValue == null
                    ? null
                    : ListIsValid.Find(model => model.AppointClassID == Convert.ToInt32(EditValue));
        }

        #endregion

        #endregion
    }
}
