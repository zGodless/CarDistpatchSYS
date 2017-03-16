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
    public partial class MainRepairRecord : BaseUserControl
    {
        #region 初始化
        public MainRepairRecord()
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
            btnAdd.ItemClick += btnAdd_ItemClick;
            btnEdit.ItemClick += btnEdit_ItemClick;
            btnDel.ItemClick += btnDel_ItemClick;
            btnClose.ItemClick +=btnClose_ItemClick;

            gvApply.RowClick += gvCar_RowClick;
        }

        void MainCarApply_Load(object sender, EventArgs e)
        {
            cLCar.BindList();
            cLEmployeeID.BindList();
            _list = new CarRepairRecordDao().GetList();
            if (_list.Count > 0)
            {
                gcApply.DataSource = _list;
                gcApply.RefreshDataSource();
            }
        }

        void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPageOperation.RemoveTabPage(this);
        }

        void gvCar_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = gvApply.GetFocusedRow() as CarRepairRecord;
            if (detail == null)
            {
                return;
            }
            if (this.gvApply.FocusedColumn == Column_choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        _list[gvApply.FocusedRowHandle].Choose = !detail.Choose;
                        gcApply.DataSource = _list;
                        gcApply.RefreshDataSource();
                        break;
                }
            }
        }

        #endregion


        #region 属性

        private List<CarRepairRecord> _list = new List<CarRepairRecord>();
        private string sql;

        #endregion

        #region 事件


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
                new CarRepairRecordDao().Delete(detail);
                _list.Remove(detail);
            }
            gcApply.DataSource = _list;
            gcApply.RefreshDataSource();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detail = gvApply.GetFocusedRow() as CarRepairRecord;
            if (detail == null)
            {
                return;
            }
            FormEditRepair form = new FormEditRepair();
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
            if (cLCar.EditValue != null)
            {
                sql += string.Format(" and a.CarID = {0}", ValueConvert.ToInt32(cLCar.EditValue));
            }
            if (cLEmployeeID.EditValue != null)
            {
                sql += string.Format(" and a.CreatID = {0}", ValueConvert.ToInt32(cLEmployeeID.EditValue));
            }
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

            string _sql = string.Format(@"select a.*, b.EmployeeName CreatName, c.CarNo, d.RepairName from t_car_repair_record a 
					left join t_employee b on a.CreatID = b.EmployeeID 
					left join t_car c on a.CarID = c.CarID
					left join t_car_repair_item d on a.ItemStr = d.ItemID
                                            where {0}", sql);
            _list = new CarRepairRecordDao().QueryGetList(_sql);

            gcApply.DataSource = _list;
            gcApply.RefreshDataSource();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormEditRepair form = new FormEditRepair();
            form.curData = new CarRepairRecord();
            form.FormState = DS.MSClient.FormState.New;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion
    }
}
