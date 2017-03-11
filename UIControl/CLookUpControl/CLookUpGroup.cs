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
    public class CLookUpGroup : CSmartLookUpEditBase
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
        private int _schoolID;
        private int _trainPlaceID;

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(_schoolID, _trainPlaceID, false);
        }
        protected override void OnNewButtonClick()
        {
            FormGroup form = new FormGroup();
            form.FormClosed += (s, e) =>
            {
                BindList(_schoolID, _trainPlaceID, false);
            };
            form.Show();
        }

        #region 绑定下拉框

	    /// <summary>
	    ///     绑定下拉控件数据集
	    /// </summary>
	    public void BindList(int schoolId = 0, int trainPlaceId = 0, bool getFromCache = true)
	    {
		    _schoolID = schoolId;
		    _trainPlaceID = trainPlaceId;

		    var cacheName = "Group";
		    if (schoolId > 0) cacheName += "#Sch_" + schoolId;
		    if (trainPlaceId > 0) cacheName += "#Tp_" + trainPlaceId;

		    ClientCache.GetDataMethod method;
		    if (schoolId > 0 && trainPlaceId > 0) method = () => new GroupDao().GetListByPlaceSchool(trainPlaceId, schoolId);
			else if (schoolId > 0) method = () => new GroupDao().GetListByTrainPlace(trainPlaceId);
			else if (trainPlaceId > 0) method = () => new GroupDao().GetListBySchool(schoolId);
			else method = () => new GroupDao().GetList();

		    ListIsValid = (List<Group>) (getFromCache ? ClientCache.GetAuto(cacheName, method) : ClientCache.GetUpdate(cacheName, method));

		    Properties.DataSource = ListIsValid;
		    Properties.DisplayMember = "GroupName";
		    Properties.ValueMember = "GroupID";
		    Properties.BestFitMode = BestFitMode.BestFitResizePopup;

		    Properties.SearchMode = SearchMode.AutoFilter;
		    Properties.CaseSensitiveSearch = true;
		    Properties.AutoSearchColumnIndex = 2;
	    }

	    /// <summary>
	    ///     绑定下拉控件数据集
	    /// </summary>
	    public void BindListZY(int schoolId = 0, int trainPlaceId = 0, bool getFromCache = true)
	    {
		    _schoolID = schoolId;
		    _trainPlaceID = trainPlaceId;

		    var cacheName = "Group";
		    if (schoolId > 0) cacheName += "#Sch_" + schoolId;
		    if (trainPlaceId > 0) cacheName += "#Tp_" + trainPlaceId;

		    ClientCache.GetDataMethod method;
		    if (schoolId > 0 && trainPlaceId > 0) method = () => new GroupDao().GetListByPlaceSchool(trainPlaceId, schoolId);
			else if (schoolId > 0) method = () => new GroupDao().GetListByTrainPlace(trainPlaceId);
			else if (trainPlaceId > 0) method = () => new GroupDao().GetListBySchool(schoolId);
			else method = () => new GroupDao().GetList();

		    ListIsValid = (List<Group>) (getFromCache ? ClientCache.GetAuto(cacheName, method) : ClientCache.GetUpdate(cacheName, method));

		    ListIsValid.RemoveAll(m => m.GroupType == "挂靠");

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
