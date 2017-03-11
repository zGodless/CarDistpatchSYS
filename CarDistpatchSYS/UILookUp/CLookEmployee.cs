using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using CarDistpatchSYS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DS.MSClient.UIControl;
using DS.Model;
using DS.Data;

namespace DS.MSClient.UIControl
{
    [ToolboxItem(true)]
    public class CLookEmployee : CSmartLookUpEditBase
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
                    new LookUpColumnInfo("EmployeeCode", "员工编号"),
                    new LookUpColumnInfo("EmployeeName", "员工姓名"),
                    new LookUpColumnInfo("DepartmentName", "所属部门")
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

        public List<Employee> ListIsValid { get; set; }
        public Employee Currentduty { get; set; }

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
            ListIsValid = new EmployeeDao().GetList();
            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "EmployeeName";
            Properties.ValueMember = "EmployeeID";
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
                   : ListIsValid.Find(model => model.EmployeeID == Convert.ToInt32(EditValue));
        }

        #endregion

        #endregion
    }
}
