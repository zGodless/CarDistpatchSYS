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
    public class CLookExamPlace : CSmartLookUpEditBase
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            EditValueChanged += cLookUp_EditValueChanged;

            if (Properties.Columns.Count == 0)
            {
                Properties.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo("ExamPlaceCode", "驾管所编号"),
                    new LookUpColumnInfo("ExamPlaceName", "考试地点名")
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

        public List<ExamPlace> ListIsValid { get; set; }
        public ExamPlace CurrenteExamPlace { get; set; }
        private int _TrainPlaceID;

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(false);
        }
        protected override void OnNewButtonClick()
        {
            FormSchool form = new FormSchool();
            form.FormClosed += (s, e) =>
            {
                BindList(false);
            };
            form.Show();
        }

        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList(bool getFromCache = true)
        {
            ListIsValid = (List<ExamPlace>)ClientCache.GetAuto("ExamPlace", () => new ExamPlaceDao().GetList());

            Properties.DataSource = ListIsValid;

            Properties.DisplayMember = "ExamPlaceName";
            Properties.ValueMember = "ExamPlaceID";
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
            CurrenteExamPlace = EditValue == null
                   ? null
                   : ListIsValid.Find(model => model.ExamPlaceID == Convert.ToInt32(EditValue));
        }


        #endregion
        #endregion
    }
}
