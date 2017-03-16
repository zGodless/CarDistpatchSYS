using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DS.Data;
using QuickFrame.Common.Converter;

namespace CarDistpatchSYS
{
    public partial class MainRepairReport : BaseUserControl
    {
        #region 初始化
        public MainRepairReport()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += MainCarApply_Load;
            btnSearch.Click += btnSearch_Click;
            btnClose.ItemClick +=btnClose_ItemClick;

        }

        void MainCarApply_Load(object sender, EventArgs e)
        {
            cLookDepartment1.BindList();
            cLItemStr.BindList();
            cLOwnerID.BindList();
            dateRepairBegin.EditValue = DateTime.Now.ToString("yyyy-MM");
            comResult.SelectedIndex = 0;
        }

        void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPageOperation.RemoveTabPage(this);
        }


        #endregion


        #region 属性

        private List<Car> _list = new List<Car>();
        private string sql;

        #endregion

        #region 事件


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            sql = " 1 = 1 ";
            if (cLookDepartment1.EditValue != null)
            {
                sql += string.Format(" and b.DepartmentID = {0}", ValueConvert.ToInt32(cLookDepartment1.EditValue));
            }
            if (cLOwnerID.EditValue != null)
            {
                sql += string.Format(" and b.OwnerID = {0}", ValueConvert.ToInt32(cLOwnerID.EditValue));
            }
            if (cLItemStr.EditValue != null)
            {
                sql += string.Format(" and a.ItemStr = {0}", ValueConvert.ToInt32(cLItemStr.EditValue));
            }
            if (!string.IsNullOrEmpty(ValueConvert.ToString(textRepairPlace.EditValue)))
            {
                sql += string.Format(" and a.RepairPlace = '{0}'", ValueConvert.ToString(textRepairPlace.EditValue));
            }
            if (!string.IsNullOrEmpty(ValueConvert.ToString(comResult.EditValue)))
            {
                sql += string.Format(" and a.Result = '{0}'", ValueConvert.ToString(comResult.EditValue));
            }
            //维修时间
            if (dateRepairBegin.EditValue != null && dateRepairEnd.EditValue == null)
            {
                sql += string.Format(" and a.RepairDate >= '{0}'", ValueConvert.ToDateTime(dateRepairBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateRepairEnd.EditValue == null && dateRepairEnd.EditValue != null)
            {
                sql += string.Format(" and a.RepairDate <= '{0}'", ValueConvert.ToDateTime(dateRepairEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateRepairEnd.EditValue != null && dateRepairEnd.EditValue != null)
            {
                sql += string.Format(" and a.RepairDate between '{0}' and '{1}'", ValueConvert.ToDateTime(dateRepairBegin.EditValue).ToString("yyyy-MM-dd"), ValueConvert.ToDateTime(dateRepairEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            string _sql = string.Format(@"select b.CarNo, a.CarID, c.DepartmentName, d.EmployeeName OwnerName, 
		                                            sum(a.RepairID) RepairCount, sum(a.PartsCost) SumCost
                                             from t_car_repair_record a 
                                            left join t_car b on a.CarID = b.CarID 
                                            left join t_department c on b.DepartmentID = c.DepartmentID 
                                            left join t_employee d on b.OwnerID = d.EmployeeID
                                            where {0} 
                                            group by a.CarID ", sql);
            _list = new CarDao().QueryGetList(_sql);

            gcCarReport.DataSource = _list;
            gcCarReport.RefreshDataSource();
        }

        #endregion
    }
}
