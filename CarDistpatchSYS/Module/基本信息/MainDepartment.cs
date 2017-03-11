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
    public partial class MainDepartment : BaseUserControl
    {
        #region 初始化
        public MainDepartment()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += MainCar_Load;
            btnSearch.Click += btnSearch_Click;
            btnAdd.ItemClick += btnAdd_ItemClick;
            btnEdit.ItemClick += btnEdit_ItemClick;
            btnDel.ItemClick += btnDel_ItemClick;
            btnClose.ItemClick +=btnClose_ItemClick;

            gvDepartment.RowClick += gvCar_RowClick;
        }

        void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TabRemove(this, Name);
            FormPageOperation.RemoveTabPage(this);
        }

        void gvCar_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = gvDepartment.GetFocusedRow() as Department;
            if (detail == null)
            {
                return;
            }
            if (this.gvDepartment.FocusedColumn == Column_choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        _list[gvDepartment.FocusedRowHandle].Choose = !detail.Choose;
                        gcDepartment.DataSource = _list;
                        gcDepartment.RefreshDataSource();
                        break;
                }
            }
        }

        #endregion


        #region 属性

        private List<Department> _list = new List<Department>();
        private string sql;

        #endregion

        #region 事件

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainCar_Load(object sender, EventArgs e)
        {
            _list = new DepartmentDao().GetList();
            if (_list.Count > 0)
            {
                gcDepartment.DataSource = _list;
                gcDepartment.RefreshDataSource();
            }
        }

        /// <summary>
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
                if (new DepartmentDao().Delete(detail))
                {
                    _list.Remove(detail);
                }
            }
            gcDepartment.DataSource = _list;
            gcDepartment.RefreshDataSource();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detail = gvDepartment.GetFocusedRow() as Department;
            if (detail == null)
            {
                return;
            }
            FormEditDepartment form = new FormEditDepartment();
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
            string departName = ValueConvert.ToString(textDepartmentName.EditValue);

            if (!string.IsNullOrEmpty(departName))
            {
                sql += string.Format(" and a.DepartmentName like '%{0}%'", departName);
            }

            if (cLInChargeID.EditValue != null)
            {
                sql += string.Format(" and a.InChargeID = {0}", ValueConvert.ToInt32(cLInChargeID.EditValue));
            }

            string _sql = string.Format(@"select a.*, b.DepartmentName ParentName, c.EmployeeName InChargeName
                                                 from t_department a 
                                                left join t_department b on a.ParentID = b.DepartmentID
                                                left join t_employee c on a.InChargeID = c.EmployeeID where {0}", sql);
            _list = new DepartmentDao().QueryGetList(_sql);
            if (_list.Count > 0)
            {
                gcDepartment.DataSource = _list;
                gcDepartment.RefreshDataSource();
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormEditDepartment form = new FormEditDepartment();
            form.curData = new Department();
            form.FormState = DS.MSClient.FormState.New;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion
    }
}
