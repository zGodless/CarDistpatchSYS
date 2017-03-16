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
    public partial class MainCarReport : BaseUserControl
    {
        #region 初始化
        public MainCarReport()
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
            dateApplyBegin.EditValue = ValueConvert.ToDateTime(DateTime.Now.ToString("yyyy-MM"));
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
            //申请
            if (dateApplyBegin.EditValue != null && dateApplyEnd.EditValue == null)
            {
                sql += string.Format(" and a.ApplyDate >= '{0}'", ValueConvert.ToDateTime(dateApplyBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateApplyEnd.EditValue == null && dateApplyEnd.EditValue != null)
            {
                sql += string.Format(" and a.ApplyDate <= '{0}'", ValueConvert.ToDateTime(dateApplyEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateApplyEnd.EditValue != null && dateApplyEnd.EditValue != null)
            {
                sql += string.Format(" and a.ApplyDate between '{0}' and '{1}'", ValueConvert.ToDateTime(dateApplyBegin.EditValue).ToString("yyyy-MM-dd"), ValueConvert.ToDateTime(dateApplyEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            //审批

            if (dateAuditBegin.EditValue != null && dateAuditEnd.EditValue == null)
            {
                sql += string.Format(" and a.AuditDate >= '{0}'", ValueConvert.ToDateTime(dateAuditBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateAuditEnd.EditValue == null && dateAuditEnd.EditValue != null)
            {
                sql += string.Format(" and a.AuditDate <= '{0}'", ValueConvert.ToDateTime(dateAuditEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateAuditEnd.EditValue != null && dateAuditEnd.EditValue != null)
            {
                sql += string.Format(" and a.AuditDate between '{0}' and '{1}'", ValueConvert.ToDateTime(dateAuditBegin.EditValue).ToString("yyyy-MM-dd"), ValueConvert.ToDateTime(dateAuditEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            //派车

            if (dateSendBegin.EditValue != null && dateSendEnd.EditValue == null)
            {
                sql += string.Format(" and a.RegistraDate >= '{0}'", ValueConvert.ToDateTime(dateSendBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateSendEnd.EditValue == null && dateSendEnd.EditValue != null)
            {
                sql += string.Format(" and a.RegistraDate <= '{0}'", ValueConvert.ToDateTime(dateSendEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateSendEnd.EditValue != null && dateSendEnd.EditValue != null)
            {
                sql += string.Format(" and a.RegistraDate between '{0}' and '{1}'", ValueConvert.ToDateTime(dateSendBegin.EditValue).ToString("yyyy-MM-dd"), ValueConvert.ToDateTime(dateSendEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            //回车

            if (dateReturnBegin.EditValue != null && dateReturnEnd.EditValue == null)
            {
                sql += string.Format(" and a.ReturnDate >= '{0}'", ValueConvert.ToDateTime(dateReturnBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateReturnEnd.EditValue == null && dateReturnEnd.EditValue != null)
            {
                sql += string.Format(" and a.ReturnDate <= '{0}'", ValueConvert.ToDateTime(dateReturnEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateReturnEnd.EditValue != null && dateReturnEnd.EditValue != null)
            {
                sql += string.Format(" and a.ReturnDate between '{0}' and '{1}'", ValueConvert.ToDateTime(dateReturnBegin.EditValue).ToString("yyyy-MM-dd"), ValueConvert.ToDateTime(dateReturnEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            string _sql = string.Format(@"select a.DepartmentName, b.SendCount, if(b.SendCount = 0, 0, b.SumReturn/b.SendCount) AvgReturn,  if(b.SendCount = 0, 0, b.SumAudit/b.SendCount) AvgAudit
                                                 from
                                                (select * from t_department) a 
                                                left join
                                                (
                                                select b.DepartmentID,  count(a.DispatchID) SendCount, sum(to_days(a.ReturnDate) - to_days(a.ApplyDate)) SumReturn, sum(to_days(a.AuditDate) - to_days(a.ApplyDate)) SumAudit
                                                 from t_car_dispatch a 
                                                left join t_car b on a.CarID = b.CarID 
                                                where a.Status = 4 and {0}
                                                group by b.DepartmentID  )b on a.DepartmentID = b.DepartmentID ", sql);
            _list = new CarDao().QueryGetList(_sql);

            gcCarReport.DataSource = _list;
            gcCarReport.RefreshDataSource();
        }

        #endregion
    }
}
