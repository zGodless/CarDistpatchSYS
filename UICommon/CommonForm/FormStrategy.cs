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
using DS.MSClient.UICommon;
using QuickFrame.Common.Converter;

namespace DS.MSClient.UICommon
{
    public partial class FormStrategy : FormDlgBase
    {
        #region 初始化
        public FormStrategy()
        {
            InitializeComponent();
            InitEvent();
        }
        #endregion

        #region 属性
        private List<Strategy> Strategylist = new List<Strategy>();
        private List<StrategyChargeItem> StrategyChargeItemlist = new List<StrategyChargeItem>();
        private List<ChargeItem> ChargeItemlist = new List<ChargeItem>();
        private List<ChargeItem> _list = new List<ChargeItem>();
        public List<ChargeItem> _charge = new List<ChargeItem>();
        private List<int> _repeat = new List<int>();
        public List<int> _chargeitemid = new List<int>();
        #endregion

        #region 方法
        private void InitEvent()
        {
            Load += FormStrategy_Load;
            //确定、取消
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
            //策略
            clbc_Strategy.ItemCheck += clbc_Strategy_ItemCheck;
        }
        private void clbc_Strategy_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (clbc_Strategy.GetItemChecked(this.clbc_Strategy.SelectedIndex))
            {
                var _strategyid = Strategylist.Find(m => m.StrategyName == this.clbc_Strategy.GetItemText(this.clbc_Strategy.SelectedIndex));
                if (!_repeat.Contains(_strategyid.StrategyID))
                {
                    bool _add = true;
                    _repeat.Add(_strategyid.StrategyID);
                    var _chargeitem = StrategyChargeItemlist.Where(m => m.StrategyID == _strategyid.StrategyID).ToList();
                    _chargeitem.ForEach(m =>
                    {
                        var _chargeitemlist = ChargeItemlist.Where(p => p.ChargeItemID == m.ChargeItemID).ToList();
                        _chargeitemlist.ForEach(p=>
                            {
                                _chargeitemid.ForEach(d=>
                                    {
                                    if(p.ChargeItemID == d)
                                    {
                                        _add = false;
                                    }
                                    });
                                if(_add)
                                {
                                    _list.Add(p);
                                }
                            });
                    });
                    gc_charge_item.DataSource = _list;
                    gc_charge_item.RefreshDataSource();
                }
            }
            else
            {
                bool _isnull = true;
                var _strategyid = Strategylist.Find(m => m.StrategyName == this.clbc_Strategy.GetItemText(this.clbc_Strategy.SelectedIndex));
                var _chargeitem = StrategyChargeItemlist.Where(m => m.StrategyID == _strategyid.StrategyID).ToList();
                _chargeitem.ForEach(m =>
                {
                    for (int i = 0; i < gv_charge_item.RowCount; i++)
                    {
                        var _ischecked = gv_charge_item.GetRowCellValue(i, gridColumn4);
                        var _chargename = gv_charge_item.GetRowCellValue(i, gridColumn1);
                        var _chargeid = ChargeItemlist.Find(p => p.ChargeItemName == (string)_chargename);
                        if (_chargeid.ChargeItemID == m.ChargeItemID && (bool)_ischecked == true)
                        {
                            _isnull = false;
                        }
                    }
                });
                if (_isnull == true)
                {
                    _repeat.Remove(_strategyid.StrategyID);
                    _chargeitem.ForEach(m =>
                    {
                        var _chargeitemlist = ChargeItemlist.Where(p => p.ChargeItemID == m.ChargeItemID).ToList();
                        _chargeitemlist.ForEach(p =>
                        {
                            _list.Remove(p);
                        });
                    });
                }
                else
                {
                    this.clbc_Strategy.CheckSelectedItems();
                }
                gc_charge_item.DataSource = _list;
                gc_charge_item.RefreshDataSource();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close(); ;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gv_charge_item.RowCount; i++)
            {
                var _ischecked = gv_charge_item.GetRowCellValue(i, gridColumn4);
                if ((bool)_ischecked == true)
                {
                    var _item = gv_charge_item.GetRow(i) as ChargeItem;
                    _charge.Add(_item);
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormStrategy_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void BindData()
        {
            Strategylist = new StrategyDao().GetList();
            StrategyChargeItemlist = new StrategyChargeItemDao().GetList();
            //ChargeItemlist = new ChargeItemDAO().GetList_All();
        }
        private void LoadData()
        {
            if (ThreadExcute(BindData))
            {
                clbc_Strategy.DataSource = Strategylist;
                clbc_Strategy.DisplayMember = "StrategyName";
                clbc_Strategy.ValueMember = "StrategyID";
            }
        }
        #endregion
    }
}