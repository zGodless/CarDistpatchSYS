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

namespace DS.MSClient.UICommon
{    //选择商品规则
    public partial class FormSelectTraindateTicketRule : FormBase
    {
        public FormSelectTraindateTicketRule()
        {
            InitializeComponent();
            InitEvent();
        }
       #region 初始化

        private void InitEvent()
        {
            //加载数据
            this.Load += FormCommodity_Load;
            this.simpleButton_yes.Click += btnOK_Click;
            this.simpleButton_no.Click += btnCancel_Click;
            this.gv_TicketRule.RowClick += gv_TicketRule_RowClick;
        }


        #endregion
       #region 属性

        public List<TicketRule> _List;
        public List<TicketRule> _CommoditydeliteList = new List<TicketRule>();
        public List<TraindateTicketRule> _TraindateTicketList = new List<TraindateTicketRule>(); 

        #endregion
       #region 事件

        void gv_TicketRule_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_TicketRule.FocusedColumn == gridColumn_Choose)
            {
                var detail = this.gv_TicketRule.GetFocusedRow() as TicketRule;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_TicketRule.RefreshDataSource();
                        break;
                }
            }
        }

        void FormCommodity_Load(object sender, EventArgs e)
        {
            if (ThreadExcute(BindData))
            {
                if (_List.Count > 0 && _TraindateTicketList.Count>0)
                {
                    _TraindateTicketList.ForEach(m => _List.Remove(_List.Find(n => n.TicketRuleID == m.TicketRuleID)));
                }
                    this.gc_TicketRule.DataSource = _List;
                    this.gc_TicketRule.RefreshDataSource();
                
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            _CommoditydeliteList.Clear();
            foreach (TicketRule pro in this._List)
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
       
            this.Close();
        }
        #endregion
       #region 方法
        private void BindData()
        {
            _List = new TicketRuleDao().GetList();
        }
        #endregion
    }
}
