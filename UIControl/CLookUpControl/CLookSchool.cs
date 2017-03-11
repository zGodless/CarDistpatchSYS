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
    public class CLookSchool : CSmartLookUpEditBase
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            EditValueChanged += cLookUp_EditValueChanged;
            //Properties.Buttons.Clear();
            //Properties.Buttons.AddRange(new[]
            //{
            //    new EditorButton(ButtonPredefines.Clear, "清除") {IsDefaultButton = false}, 
            //    new EditorButton(ButtonPredefines.Combo) {IsDefaultButton = true},
            //    new EditorButton(ButtonPredefines.Redo, "刷新") {IsDefaultButton = false}
            //});
            if (Properties.Columns.Count == 0)
            {
                Properties.Columns.AddRange(new[]
				{
					new LookUpColumnInfo("SchoolCode", "学校编号"),
					new LookUpColumnInfo("SchoolName", "学校名称"),
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

        public List<School> ListIsValid { get; set; }
        public School Currentschool { get; set; }
        private int _TrainPlaceID;

	    #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(_TrainPlaceID,false);
        }
        protected override void OnNewButtonClick()
        {
            FormSchool form = new FormSchool();
            form.FormClosed += (s, e) =>
            {
                BindList(_TrainPlaceID, false);
            };
            form.Show();
        }

        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList(int TrainPlaceID = 0,bool getFromCache = true)
        {
            _TrainPlaceID = TrainPlaceID;
            if (_TrainPlaceID!=0)
            {
                if (getFromCache)
                {
                    ListIsValid = (List<School>)ClientCache.GetAuto("School" + TrainPlaceID, () => new SchoolDao().GetListByTrainPlace(TrainPlaceID));
                }
                else
                {
                    ListIsValid = (List<School>)ClientCache.GetUpdate("School" + TrainPlaceID, () => new SchoolDao().GetListByTrainPlace(TrainPlaceID));
                }
            }
            else
            {
                if (getFromCache)
                {
                    ListIsValid = (List<School>)ClientCache.GetAuto("School", () => new SchoolDao().GetAllList());
                }
                else
                {
                    ListIsValid = (List<School>)ClientCache.GetUpdate("School", () => new SchoolDao().GetAllList());
                }
            }
            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "SchoolName";
            Properties.ValueMember = "SchoolID";
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
            Currentschool = EditValue == null
                   ? null
                   : ListIsValid.Find(model => model.SchoolID == Convert.ToInt32(EditValue));
        }

        #endregion

        #endregion
    }
}
