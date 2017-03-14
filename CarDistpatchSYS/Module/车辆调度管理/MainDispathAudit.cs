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
    public partial class MainDispathAudit : BaseUserControl
    {
        #region 初始化
        public MainDispathAudit()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += MainDispathAudit_Load;
            btnClose.ItemClick += btnClose_ItemClick;
            btnAudit.ItemClick += btnAudit_ItemClick;
            gvApply.RowClick += gvCar_RowClick;
        }

        #endregion


        #region 属性

        private List<CarDispatchApply> _list = new List<CarDispatchApply>();
        private string sql;

        #endregion

        #region 事件

        void btnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detail = gvApply.GetFocusedRow() as CarDispatchApply;
            if (detail == null)
            {
                return;
            }
            FormEditDispathAudit form = new FormEditDispathAudit();
            form.curData = detail;
            form.FormState = DS.MSClient.FormState.Modify;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _list = new CarDispatchApplyDao().GetNotAuditList();

                gcApply.DataSource = _list;
                gcApply.RefreshDataSource();
            }
        }

        void MainDispathAudit_Load(object sender, EventArgs e)
        {
            _list = new CarDispatchApplyDao().GetNotAuditList();
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
    }
}
