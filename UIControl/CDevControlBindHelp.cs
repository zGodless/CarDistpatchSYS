using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.Data;
using DS.Model;
using DS.MSClient.UICommon;

namespace DS.MSClient.UIControl
{
    /// <summary>
    /// dev控件绑定帮助类
    /// </summary>
    public static class CDevControlBindHelp
    {
        /// <summary>
        /// 绑定gridColumn报销项目
        /// </summary>
        /// <param name="col">gridColumn列</param>
        /// <param name="bindType">类型</param>
        public static void BindGridReimburseItem(this GridColumn col)
        {
        }

        /// <summary>
        /// 绑定gridColumn职位
        /// </summary>
        /// <param name="col">gridColumn列</param>
        /// <param name="bindType">类型</param>
        public static void BindGridDuty(this GridColumn col)
        {
            if (col == null) throw new ArgumentNullException("GridColumn is null");
            if (col.View.GridControl == null) throw new ArgumentNullException("GridColumn.View.GridControl is null!");

            CSmartRepositoryItemLookupEdit lk = new CSmartRepositoryItemLookupEdit();
            lk.TextEditStyle = TextEditStyles.Standard;
            LookUpColumnInfo info = new LookUpColumnInfo("DutyCode", "编号");
            lk.Columns.Add(info);
            info = new LookUpColumnInfo("DutyName", "名称");
            lk.Columns.Add(info);
            info = new LookUpColumnInfo("MnemonicCode", "助记码");
            lk.Columns.Add(info);
            List<Duty> ListIsValid = (List<Duty>)ClientCache.GetAuto("Duty", () => new DutyDao().GetList());
            lk.DataSource = ListIsValid;
            lk.DisplayMember = "DutyName";
            lk.ValueMember = "DutyID";
            lk.NullText = "";
            lk.ShowHeader = true;
            lk.PopupWidth = 200;
            col.View.GridControl.RepositoryItems.Add(lk);
            col.ColumnEdit = lk;
        }
        /// <summary>
        ///     绑定gridColumn员工
        /// </summary>
        /// <param name="col">gridColumn列</param>
        public static void BindGridEmployee(this GridColumn col)
        {
            if (col == null || col.View.GridControl == null) throw new ArgumentNullException("col");

            var lk = new CSmartRepositoryItemLookupEdit();
            lk.TextEditStyle = TextEditStyles.Standard;
            var info = new LookUpColumnInfo("EmployeeCode", "工号");
            lk.Columns.Add(info);
            info = new LookUpColumnInfo("EmployeeName", "姓名");
            lk.Columns.Add(info);
            var listIsValid = (List<Employee>)ClientCache.GetAuto("Employee", () => new EmployeeDao().GetList());
            lk.DataSource = listIsValid;
            lk.DisplayMember = "EmployeeName";
            lk.ValueMember = "EmployeeID";
            lk.NullText = "";
            lk.ShowHeader = true;
            lk.PopupWidth = 150;
            col.View.GridControl.RepositoryItems.Add(lk);
            col.ColumnEdit = lk;
        }
        /// <summary>
        ///     绑定gridColumn校区
        /// </summary>
        /// <param name="col">gridColumn列</param>
        public static void BindGridSchoolZone(this GridColumn col)
        {
            if (col == null || col.View.GridControl == null) throw new ArgumentNullException("col");

            var lk = new CSmartRepositoryItemLookupEdit();
            lk.TextEditStyle = TextEditStyles.Standard;
            var info = new LookUpColumnInfo("SchoolZoneCode", "编号");
            lk.Columns.Add(info);
            info = new LookUpColumnInfo("SchoolZoneName", "校区");
            lk.Columns.Add(info);
            var listIsValid = (List<SchoolZone>)ClientCache.GetAuto("SchoolZone", () => new SchoolZoneDao().GetList());
            lk.DataSource = listIsValid;
            lk.DisplayMember = "SchoolZoneName";
            lk.ValueMember = "SchoolZoneID";
            lk.NullText = "";
            lk.ShowHeader = true;
            lk.PopupWidth = 150;
            col.View.GridControl.RepositoryItems.Add(lk);
            col.ColumnEdit = lk;
        }
    }
}
