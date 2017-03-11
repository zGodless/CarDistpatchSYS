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
using DS.MSClient.UIModule;

namespace DS.MSClient.UIControl
{
    [ToolboxItem(true)]
    public class CLookSeachTrainPlace : CSmartLookUpEditBase
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
					new LookUpColumnInfo("TrainPlaceCode", "训练场地编号"),
					new LookUpColumnInfo("TrainPlaceName", "训练场地"),
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

        public List<TrainPlace> ListIsValid { get; set; }
        public TrainPlace Currenttrainplace { get; set; }

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(5, false);
        }

        protected override void OnClearButtonClick()
        {
            ClearList(false);
        }
        #region 绑定下拉框

        /// <summary>
        ///     清空下拉控件数据集
        /// </summary>
        public void ClearList(bool getFromCache = true)
        {
            Properties.DataSource = null;
            Properties.DisplayMember = null;
            Properties.ValueMember = null;
            Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            Properties.SearchMode = SearchMode.AutoFilter;
            Properties.CaseSensitiveSearch = true;
            Properties.AutoSearchColumnIndex = 2;
        }

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList(int TrainPlaceID = 1, bool getFromCache = false)
        {
            if (getFromCache)
            {
                ListIsValid = (List<TrainPlace>)ClientCache.GetAuto("TrainPlace", () => new TrainPlaceDAO().GetList());
            }
            else
            {
                ListIsValid = (List<TrainPlace>)ClientCache.GetUpdate("TrainPlace", () => new TrainPlaceDAO().GetList());
            }
            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "TrainPlaceName";
            Properties.ValueMember = "TrainPlaceID";
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
            Currenttrainplace = EditValue == null
                   ? null
                   : ListIsValid.Find(model => model.TrainPlaceID == Convert.ToInt32(EditValue));
        }

        #endregion

        #endregion
    }
}
