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
    public class CLookSeachGroup : CSmartLookUpEditBase
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
					new LookUpColumnInfo("SchoolName", "所属驾校"),
					new LookUpColumnInfo("GroupName", "分队名称"),
					new LookUpColumnInfo("TrainPlaceName", "训练场地")
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

        public List<Group> ListIsValid { get; set; }
        public Group Currentgroup { get; set; }

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(0, 0, false);
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

        public void BindList(int SchoolID = 0, int TrainPlaceID = 0, bool getFromCache = true)
        {
            if (getFromCache)
            {
                if (SchoolID > 0 && TrainPlaceID > 0)
                {
                    ListIsValid = (List<Group>)ClientCache.GetAuto("Group" + SchoolID + TrainPlaceID, () => new GroupDao().GetListByPlaceSchool(TrainPlaceID, SchoolID));
                }

                else
                {
                    if (TrainPlaceID > 0)
                        ListIsValid =
                            (List<Group>)
                                ClientCache.GetAuto("Group" + SchoolID + TrainPlaceID, () => new GroupDao().GetListByTrainPlace(TrainPlaceID));
                    else
                    {
                        if (SchoolID > 0)
                            ListIsValid =
                                (List<Group>)ClientCache.GetAuto("Group" + SchoolID + TrainPlaceID, () => new GroupDao().GetListBySchool(SchoolID));
                        else
                            ListIsValid = (List<Group>)ClientCache.GetAuto("Group" + SchoolID + TrainPlaceID, () => new GroupDao().GetList());
                    }
                }
            }
            else
            {
                if (SchoolID > 0 && TrainPlaceID > 0)
                {
                    ListIsValid = (List<Group>)ClientCache.GetUpdate("Group" + SchoolID + TrainPlaceID, () => new GroupDao().GetListByPlaceSchool(TrainPlaceID, SchoolID));
                }

                else
                {
                    if (TrainPlaceID > 0)
                        ListIsValid =
                            (List<Group>)
                                ClientCache.GetUpdate("Group" + SchoolID + TrainPlaceID, () => new GroupDao().GetListByTrainPlace(TrainPlaceID));
                    else
                    {
                        if (SchoolID > 0)
                            ListIsValid =
                                (List<Group>)ClientCache.GetUpdate("Group" + SchoolID + TrainPlaceID, () => new GroupDao().GetListBySchool(SchoolID));
                        else
                            ListIsValid = (List<Group>)ClientCache.GetUpdate("Group" + SchoolID + TrainPlaceID, () => new GroupDao().GetList());
                    }
                }

            }
            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "GroupName";
            Properties.ValueMember = "GroupID";
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
            Currentgroup = EditValue == null
                   ? null
                   : ListIsValid.Find(model => model.GroupID == Convert.ToInt32(EditValue));
        }

        #endregion

        #endregion
    }
}
