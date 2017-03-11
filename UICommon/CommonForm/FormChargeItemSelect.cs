using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.Data;
using DS.Model;

namespace DS.MSClient.UIModule
{
    public partial class FormChargeItemSelect : FormDlgBase
    {
        #region 初始化
        public FormChargeItemSelect()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.Load += FormChargeItemSelect_Load;
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.gv_chargeitem.RowClick += gv_chargeitem_RowClick;
        }



        #endregion

        #region 属性

        private List<ChargeItem> _items = null;
        public List<ChargeItem> _ChooseItems = null;
        #endregion

        #region 事件

        void FormChargeItemSelect_Load(object sender, EventArgs e)
        {
            _items = new ChargeItemDAO().GetList();
            this.gc_chargeitem.DataSource = _items;
            this.gc_chargeitem.RefreshDataSource();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void gv_chargeitem_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = this.gv_chargeitem.GetFocusedRow() as ChargeItem;
            if (detail == null) return;
            if (gv_chargeitem.FocusedColumn == gridColumn_Choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_chargeitem.RefreshDataSource();
                        break;
                }
            }
        }
        void btnOK_Click(object sender, EventArgs e)
        {
            _ChooseItems= new List<ChargeItem>();
            _ChooseItems = _items.FindAll(m => m.Choose == true);
            this.DialogResult = DialogResult.OK;
        }
        #endregion


        #region 方法

        #endregion
    }
}
