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
    public partial class MainDuty : BaseUserControl
    {
        #region 初始化
        public MainDuty()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += MainDuty_Load;
            btnSearch.Click += btnSearch_Click;
            btnAdd.ItemClick += btnAdd_ItemClick;
            btnEdit.ItemClick += btnEdit_ItemClick;
            btnDel.ItemClick += btnDel_ItemClick;
            btnClose.ItemClick +=btnClose_ItemClick;

            gvDuty.RowClick += gvCar_RowClick;
        }

        void MainDuty_Load(object sender, EventArgs e)
        {
            _list = new DutyDao().GetList();
            if (_list.Count > 0)
            {
                gcDuty.DataSource = _list;
                gcDuty.RefreshDataSource();
            }
        }

        void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TabRemove(this, Name);
            FormPageOperation.RemoveTabPage(this);
        }

        void gvCar_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = gvDuty.GetFocusedRow() as Duty;
            if (detail == null)
            {
                return;
            }
            if (this.gvDuty.FocusedColumn == Column_choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        _list[gvDuty.FocusedRowHandle].Choose = !detail.Choose;
                        gcDuty.DataSource = _list;
                        gcDuty.RefreshDataSource();
                        break;
                }
            }
        }

        #endregion


        #region 属性

        private List<Duty> _list = new List<Duty>();
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
                if (new DutyDao().Delete(detail))
                {
                    _list.Remove(detail);
                }
            }
            gcDuty.DataSource = _list;
            gcDuty.RefreshDataSource();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detail = gvDuty.GetFocusedRow() as Duty;
            if (detail == null)
            {
                return;
            }
            FormEditDuty form = new FormEditDuty();
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
            string departName = ValueConvert.ToString(textDutyName.EditValue);

            if (!string.IsNullOrEmpty(departName))
            {
                sql += string.Format(" and a.DutyName like '%{0}%'", departName);
            }

            string _sql = string.Format(@"select a.*, c.EmployeeName OperateName
                                                 from t_duty a 
                                                left join t_employee c on a.OperateID = c.EmployeeID where {0}", sql);
            _list = new DutyDao().QueryGetList(_sql);
            if (_list.Count > 0)
            {
                gcDuty.DataSource = _list;
                gcDuty.RefreshDataSource();
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormEditDuty form = new FormEditDuty();
            form.curData = new Duty();
            form.FormState = DS.MSClient.FormState.New;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion
    }
}
