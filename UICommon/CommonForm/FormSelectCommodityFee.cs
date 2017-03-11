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
    public partial class FormSelectCommodityFee : FormDlgBase
    {

        #region 初始化
        public FormSelectCommodityFee()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //加载数据
            this.Load += FormCommodity_Load;
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.gv_Commodity.RowClick += gv_Commodity_RowClick;
        }


        #endregion
        #region 属性

        public List<Commodity> _List;
        public List<Commodity> _CommoditydeliteList = new List<Commodity>(); 

        #endregion

        #region 事件

        void gv_Commodity_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_Commodity.FocusedColumn == Column_Choose)
            {
                var detail = this.gv_Commodity.GetFocusedRow() as Commodity;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_Commodity.RefreshDataSource();
                        break;
                }
            }
        }

        void FormCommodity_Load(object sender, EventArgs e)
        {
            if (ThreadExcute(BindData))
            {
                if (_List.Count>0 && _CommoditydeliteList.Count>0)
                {
                    _CommoditydeliteList.ForEach(m => _List.Remove(_List.Find(n => n.CommodityID == m.CommodityID)));
                }
                this.gc_Commodity.DataSource = _List;
                this.gc_Commodity.RefreshDataSource();
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            //if (_CommoditydeliteList==null)
            //_CommoditydeliteList = new List<Commodity>();
            _CommoditydeliteList.Clear();
            foreach (Commodity pro in this._List)
            {
                if (pro.Choose) _CommoditydeliteList.Add(pro);
            }
            if (_CommoditydeliteList.Count == 0)
            {
                MsgBox.ShowInfo("请选中数据行");
                return;
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
            _List = new CommodityDao().GetList();
        }
        #endregion
    }
}