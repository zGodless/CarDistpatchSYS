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
    public class CLookSchoolZone : CSmartLookUpEditBase
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            EditValueChanged += cLookUp_EditValueChanged;

            if (Properties.Columns.Count == 0)
            {
                Properties.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo("SchoolZoneCode", "校区编号"),
                    new LookUpColumnInfo("SchoolZoneName", "学校名称"),
                    new LookUpColumnInfo("PersonInChargeName", "校区负责人")
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

        public List<SchoolZone> ListIsValid { get; set; }
        public SchoolZone Currentschool { get; set; }
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
            ListIsValid = (List<SchoolZone>)ClientCache.GetAuto("SchoolZone", () => new SchoolZoneDao().GetList());

            Properties.DataSource = ListIsValid;

            Properties.DisplayMember = "SchoolZoneName";
            Properties.ValueMember = "SchoolZoneID";
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
                   : ListIsValid.Find(model => model.SchoolZoneID == Convert.ToInt32(EditValue));
        }


        #endregion
        #endregion
    }
}
