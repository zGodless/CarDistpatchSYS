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
    public partial class MainCarApply : BaseUserControl
    {
        #region 初始化
        public MainCarApply()
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
            _list = new CarDispatchApplyDao().GetList();
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
            var detail = gvApply.GetFocusedRow() as CarDispatchApply;
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

        private List<CarDispatchApply> _list = new List<CarDispatchApply>();
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
                if (detail.Status > 1)
                {
                    MessageBox.Show("已进入审批，禁止删除！");
                    return;
                }
                if (new CarDispatchDao().DeleteByID(ValueConvert.ToInt32(detail.DispatchID)))   //先删除总记录
                {
                    new CarDispatchApplyDao().Delete(detail);
                    _list.Remove(detail);
                }
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
            var detail = gvApply.GetFocusedRow() as Department;
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
