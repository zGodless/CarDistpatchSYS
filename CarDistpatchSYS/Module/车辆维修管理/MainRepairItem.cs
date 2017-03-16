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
    public partial class MainRepairItem : BaseUserControl
    {
        #region 初始化
        public MainRepairItem()
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
            var detail = gvDepartment.GetFocusedRow() as CarRepairItem;
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

        private List<CarRepairItem> _list = new List<CarRepairItem>();
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
            _list = new CarRepairItemDao().GetList();
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
                if (new CarRepairItemDao().Delete(detail))
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
            var detail = gvDepartment.GetFocusedRow() as CarRepairItem;
            if (detail == null)
            {
                return;
            }
            FormEditRepairItem form = new FormEditRepairItem();
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
            string repairName = ValueConvert.ToString(textRepairName.EditValue);
            if (!string.IsNullOrEmpty(repairName))
            {
                sql += string.Format(" and a.RepairName like '%{0}%'", repairName);
            }
            string _sql = string.Format(@"select a.*, b.EmployeeName from t_car_repair_item a 
                                                left join t_employee b on a.OperateID = b.EmployeeID where {0}", sql);
            _list = new CarRepairItemDao().QueryGetList(_sql);
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
            FormEditRepairItem form = new FormEditRepairItem();
            form.curData = new CarRepairItem();
            form.FormState = DS.MSClient.FormState.New;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion
    }
}
