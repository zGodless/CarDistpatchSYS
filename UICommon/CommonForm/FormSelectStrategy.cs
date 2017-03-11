using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DS.Data;
using DS.Model;

namespace DS.MSClient.UICommon.CommonForm
{
    public partial class FormSelectStrategy : FormDlgBase
    {

        #region 初始化
        public FormSelectStrategy()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //加载数据
            this.Load += FormSubjectItem_Load;
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.gv_charge_item.RowClick += gv_item_RowClick;
        }


        #endregion
        #region 属性

        public List<ChargeItem> _List;
        public int _ChargeID = -1;
        public int _ChargeItemID = -1;
        public List<ChargeItem> _SelectItems = null;
        public bool _isnoSelect = false;
        #endregion

        #region 事件

        void gv_item_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_charge_item.FocusedColumn == Column_Choose)
            {
                var detail = this.gv_charge_item.GetFocusedRow() as ChargeItem;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_charge_item.RefreshDataSource();
                        break;
                }
            }
        }

        void FormSubjectItem_Load(object sender, EventArgs e)
        {
            if (ThreadExcute(BindData))
            {
                if (_List != null)
                {
                    ChargeItem item = _List.Find(m => m.ChargeItemID == _ChargeItemID);
                    if (item != null)
                    {
                        _List.Remove(item);
                    }
                }
                this.gc_charge_item.DataSource = _List;
                this.gc_charge_item.RefreshDataSource();
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            _SelectItems = new List<ChargeItem>();
            foreach (ChargeItem pro in this._List)
            {
                if (pro.Choose) _SelectItems.Add(pro);
            }
            if (_SelectItems.Count == 0)
            {
                if (MsgBox.ShowYesNo("是否确定不选中数据") == DialogResult.Yes)
                {
                    _isnoSelect = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.DialogResult=DialogResult.OK;
            }
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;;
        }
        #endregion


        #region 方法
        private void BindData()
        {
            _List = new ChargeItemDAO().GetList();
        }
        #endregion
    }
}