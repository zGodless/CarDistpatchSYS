using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DS.Data;
using DS.MSClient.UIControl;

namespace CarDistpatchSYS.UILookUp
{
    [ToolboxItem(true)]
    public class CLookDepartment : CSmartLookUpEditBase
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
                    new LookUpColumnInfo("DepartmentName", "部门名称"),
                    new LookUpColumnInfo("ParentName", "上级部门"),
                    new LookUpColumnInfo("InChargeName", "负责人")
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

        public List<Department> ListIsValid { get; set; }
        public Department Currentduty { get; set; }

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList();
        }
     

        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList()
        {
            ListIsValid = new DepartmentDao().GetList();
            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "DepartmentName";
            Properties.ValueMember = "DepartmentID";
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
            Currentduty = EditValue == null
                   ? null
                   : ListIsValid.Find(model => model.DepartmentID == Convert.ToInt32(EditValue));
        }

        #endregion

        #endregion
    }
}
