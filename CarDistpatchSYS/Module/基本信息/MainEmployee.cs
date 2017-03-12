using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DS.Data;
using QuickFrame.Common.Converter;

namespace CarDistpatchSYS
{
    public partial class MainEmployee : BaseUserControl
    {
        #region 初始化
        public MainEmployee()
        {
            InitializeComponent();
            InitEvent();
            Init();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += MainEmployee_Load;
            btnSearch.Click += btnSearch_Click;
            btnAdd.ItemClick += btnAdd_ItemClick;
            btnEdit.ItemClick += btnEdit_ItemClick;
            btnDel.ItemClick += btnDel_ItemClick;
            btnClose.ItemClick +=btnClose_ItemClick;
            btnChangePassword.ItemClick += btnChangePassword_ItemClick;

            gvEmployee.RowClick += gvCar_RowClick;
        }

        void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            var detail = gvEmployee.GetFocusedRow() as Employee;
            if (detail == null)
            {
                return;
            }
            FormChangePassword form = new FormChangePassword();
            form.curData = detail;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        /// <summary>
        ///     初始化事件
        /// </summary>
        private void Init()
        {
            cLDepartmentID.BindList();
            if (Program.CurrentEmployee.EmployeeID != 1) 
            {
                btnChangePassword.Visibility = BarItemVisibility.Never;
                btnEdit.Visibility = BarItemVisibility.Never;
                btnAdd.Visibility = BarItemVisibility.Never;
                btnDel.Visibility = BarItemVisibility.Never;
            }
        }



        void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPageOperation.RemoveTabPage(this);
        }

        void gvCar_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = gvEmployee.GetFocusedRow() as Employee;
            if (detail == null)
            {
                return;
            }
            if (this.gvEmployee.FocusedColumn == Column_choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        _list[gvEmployee.FocusedRowHandle].Choose = !detail.Choose;
                        gcEmployee.DataSource = _list;
                        gcEmployee.RefreshDataSource();
                        break;
                }
            }
        }

        #endregion


        #region 属性


        private List<Employee> _list = new List<Employee>();
        private string sql;

        #endregion

        #region 事件

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        void MainEmployee_Load(object sender, EventArgs e)
        {
            _list = new EmployeeDao().GetList();
            if (_list.Count > 0)
            {
                gcEmployee.DataSource = _list;
                gcEmployee.RefreshDataSource();
            }
        }
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var delList = _list.FindAll(m => m.Choose);
            if (delList.Count <= 0)
            {
                return;
            }
            foreach (var detail in delList)
            {
                if (new EmployeeDao().Delete(detail))
                {
                    _list.Remove(detail);
                }
            }
            gcEmployee.DataSource = _list;
            gcEmployee.RefreshDataSource();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detail = gvEmployee.GetFocusedRow() as Employee;
            if (detail == null)
            {
                return;
            }
            FormEditEmployee form = new FormEditEmployee();
            form.curData = detail;
            form.FormState = DS.MSClient.FormState.Modify;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            sql = " 1 = 1 ";
            string employeeCode = ValueConvert.ToString(textEmployeeCode.EditValue);

            if (!string.IsNullOrEmpty(employeeCode))
            {
                sql += string.Format(" and EmployeeCode like '%{0}%'", employeeCode);
            }
            if (!string.IsNullOrEmpty(textEmployeeName.Text))
            {
                sql += string.Format(" and EmployeeName like '%{0}%'", textEmployeeName.EditValue.ToString());
            }
            if (cLDepartmentID.EditValue != null)
            {
                sql += string.Format(" and DepartmentID = {0} ", cLDepartmentID.EditValue);
            }

            string _sql = string.Format("select * from t_employee where {0}", sql);
            _list = new EmployeeDao().QueryGetList(_sql);

            gcEmployee.DataSource = _list;
            gcEmployee.RefreshDataSource();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormEditEmployee form = new FormEditEmployee();
            form.curData = new Employee();
            form.FormState = DS.MSClient.FormState.New;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion
    }
}
