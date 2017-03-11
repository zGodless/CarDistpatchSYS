using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.MSClient.UICommon;
using DevExpress.XtraEditors;
using DS.MSClient.UICommon.MessageBox;
using DevExpress.Utils.Drawing.Helpers;
using DS.Model;
using DS.Data;
using QuickFrame.Common.Text;
using QuickFrame.Common.Converter;

namespace DS.MSClient.UICommon.CommonForm
{
    [ToolboxItem(false)]
    //付款方式
    public partial class MainEditTrainDate : FormBase
    {
        #region 初始化
        public MainEditTrainDate()
        {
            InitializeComponent();
            InitEvent();
        }

        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            this.barManager1.Images = DS.MSClient.Controls.StaticImageList.Instance.ImageList_global;
            Load += MainEditTrainDate_Load;

            //任务栏
            Btn_NewAdd.ItemClick += Btn_ItemClick;
            Btn_Del.ItemClick += Btn_ItemClick;
            Btn_Cancel.ItemClick += Btn_ItemClick;
            Btn_Apply.ItemClick += Btn_ItemClick;
            Btn_Refresh.ItemClick += Btn_ItemClick;
            Btn_Close.ItemClick += Btn_ItemClick;

            //商品规则
            this.barButtonItem_add.ItemClick += barButtonItem_add_ItemClick;
            this.barButtonItem_delete.ItemClick += barButtonItem_add_ItemClick;
            this.barButtonItem_edit.ItemClick += barButtonItem_add_ItemClick;
            this.barButtonItem_save.ItemClick += barButtonItem_add_ItemClick;

            this.gv_traindate_ticket_rule.RowClick += gv_service_ticket_rule_RowClick;
            this.gv_Commodity.RowClick += gv_Commodity_RowClick;
            this.gv_traindate_ticket_rule.FocusedRowChanged += gv_traindate_ticket_rule_FocusedRowChanged;
            this.Btn_TicketRule.ButtonClick += Btn_TicketRule_ButtonClick;

        }


        #endregion

        #region 属性

        private List<Commodity> _List;
        private List<Commodity> _CommoditydeliteList = new List<Commodity>();

        public List<TraindateCommodity> _commodity;
        private List<TraindateCommodity> _listCommodity = new List<TraindateCommodity>();
        private TraindateTicketRule _currentSTR = new TraindateTicketRule();
        private TraindateTicketRule _itemcopy = null;
        private List<TraindateTicketRule> strlist = new List<TraindateTicketRule>(); // 服务规则 数据集
        public string state = "Add";
        public int traindateID = 0;
        #endregion

        #region 方法

        private void BindTextEdit(TraindateTicketRule _currentSTR)
        {
            if (_currentSTR == null) _currentSTR = new TraindateTicketRule();
            this.Btn_TicketRule.EditValue = _currentSTR.TicketRuleCode;
            this.txt_Count.EditValue = _currentSTR.Count;
        }

        /// <summary>
        /// 数据加载
        /// </summary>
        private void BindData()
        {
            Btn_TicketRule.Enabled = false;
            txt_Count.Enabled = false;
            strlist = new TraindateTicketRuleDao().GetList(traindateID);
            this.gc_traindate_ticket_rule.DataSource = strlist;
            _listCommodity = new TrainDateCommodityDao().GetList(traindateID);
            this.gc_Commodity.DataSource = _listCommodity;

        }


        private void OpenForm()
        {
            var form = new FormSelectCommodity();
            if (form.ShowDialog(this) == DialogResult.OK)
            {

                var Commoditylist = new List<Commodity>();
                form._CommoditydeliteList.ForEach(m =>
                {
                    Commoditylist.Add(m);
                });
                _CommoditydeliteList.AddRange(Commoditylist);
                foreach (var data in Commoditylist)
                {
                    var item = new TraindateCommodity();
                    item.CommodityID = data.CommodityID;
                    item.TrainDateID = traindateID;
                    item.CommodityName = data.CommodityName;
                    item.CommoditytypeName = data.CommoditytypeName;
                    item.Note = data.Note;
                    item.OperateID = Program.CurrentEmployee.EmployeeID;
                    item.OperateTime = DateTime.Now;
                    if (new TraindateTicketRuleDao().Exist(_currentSTR.TrainDateID, _currentSTR.TicketRuleID))
                    {
                        MsgBox.ShowInfo("已经存在选中数据！");
                        return;
                    }
                    if (new TrainDateCommodityDao().Exist(item.TrainDateID, item.CommodityID))
                     {
                         MsgBox.ShowInfo("已经存在选中数据！");
                         return;
                     }
                     else
                     {
                         var result = new TrainDateCommodityDao().Add(item);
                     }
                }
            }
            this.gc_Commodity.DataSource = _CommoditydeliteList;
            gc_Commodity.RefreshDataSource();
        }

        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="state"></param>
        private void ChangeControlState(string state = "")
        {
            if (!string.IsNullOrEmpty(state))
            {
                switch (state)
                {
                    case "Init":
                        this.Btn_Cancel.Enabled = false;
                        this.Btn_Del.Enabled = true;
                        break;
                    case "New":
                        break;
                    case "CopyNew":
                        goto case "New";

                    case "ReadOnly":
                        this.Btn_Cancel.Enabled = false;
                        this.Btn_Del.Enabled = true;
                        break;
                    case "Modify":
                        this.Btn_TicketRule.Enabled = true;
                        this.txt_Count.Enabled = true;
                        break;
                }
            }
        }
        #endregion

        #region 事件
        private void gv_traindate_ticket_rule_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this._currentSTR = this.gv_traindate_ticket_rule.GetFocusedRow() as TraindateTicketRule;
            this.BindTextEdit(_currentSTR);
        }


        void gv_Commodity_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_Commodity.FocusedColumn == Column_choose)
            {
                var detail = this.gv_Commodity.GetFocusedRow() as TraindateCommodity;
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
        private void gv_service_ticket_rule_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_traindate_ticket_rule.FocusedColumn == Column_choose)
            {
                var detail = this.gv_traindate_ticket_rule.GetFocusedRow() as TraindateTicketRule;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_traindate_ticket_rule.RefreshDataSource();
                        break;
                }
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainEditTrainDate_Load(object sender, EventArgs e)
        {
            Btn_TicketRule.Enabled = false;
            txt_Count.Enabled = false;
            BindData();
        }

        private void Btn_TicketRule_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormSelectTraindateTicketRule form = new FormSelectTraindateTicketRule();
            form._TraindateTicketList = strlist;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form._CommoditydeliteList.Count != 1)
                {
                    MsgBox.ShowInfo("请选择且只选择一条记录");
                    return;
                }
                var ChooseRow = form._CommoditydeliteList.FindAll(m => m.Choose == true);
                ChooseRow.ForEach(item =>
                {
                    this.Btn_TicketRule.Tag = item.TicketRuleID;
                    this.Btn_TicketRule.Text = item.TicketRuleCode;
                }
                );
            }
        }

        /// <summary>
        /// 任务栏按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item == this.Btn_NewAdd)
            {
                OpenForm();
            }
            else if (e.Item == this.Btn_Del)
            {
                if (_listCommodity == null)
                {
                    MsgBox.ShowInfo("请选中数据行");
                    return;
                }
                var chooseRow = _listCommodity.FindAll(m => m.Choose == true);
                if (chooseRow.Count == 0) return;
                chooseRow.ForEach(item =>
                {
                    if (new TrainDateCommodityDao().Delete(item.TrainDateID, item.CommodityID))
                    {
                        _listCommodity.Remove(item);
                    }
                });
                this.gc_Commodity.RefreshDataSource();
            }
            else if (e.Item == this.Btn_Cancel)
            {

            }
            else if (e.Item == this.Btn_Close)
            {
                this.Close();
            }
        }
        private void barButtonItem_add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item == barButtonItem_add)
            {
                txt_Count.Enabled = true;
                Btn_TicketRule.Enabled = true;
                TraindateTicketRule ticket = new TraindateTicketRule();
                ticket.TicketRuleID = -1;
                this._currentSTR.TicketRuleID = ticket.TicketRuleID;
                this.strlist.Add(ticket);
                this.gc_traindate_ticket_rule.DataSource = this.strlist;
                this.gc_traindate_ticket_rule.RefreshDataSource();
                this.gv_traindate_ticket_rule.FocusedRowHandle = this.gv_traindate_ticket_rule.GetRowHandle(this.strlist.Count - 1);
                this.formState = FormState.New;
            }
            else if (e.Item == barButtonItem_delete)
            {
                if (strlist.Count == 0)
                {
                    MsgBox.ShowInfo("请选中一条数据");
                    return;
                }
                else
                {
                    TraindateTicketRule item = (TraindateTicketRule)gv_traindate_ticket_rule.GetFocusedRow();
                    new TraindateTicketRuleDao().Delete(item.TrainDateID, item.TicketRuleID);
                    strlist.Remove(item);
                    MsgBox.ShowInfo("删除成功");
                }
                this.gc_traindate_ticket_rule.RefreshDataSource();
            }
            else if (e.Item == barButtonItem_edit)
            {
                this._currentSTR = this.gv_traindate_ticket_rule.GetFocusedRow() as TraindateTicketRule;
                if (this._currentSTR != null)
                {
                    this._itemcopy = (TraindateTicketRule)this._currentSTR.Copy();//保存副本，防止取消编辑 
                    if (this._itemcopy != null)
                    {
                        this.ChangeControlState("Modify");
                    }
                }
            }
            else if (e.Item == barButtonItem_save)
            {
                if (txt_Count.Text == "")
                {
                    MsgBox.ShowInfo("赠送数量不为空");
                    return;
                }
                if (Btn_TicketRule.Text == null)
                {
                    MsgBox.ShowInfo("规则编号不为空");
                    return;
                }
                this._currentSTR.TicketRuleCode = Btn_TicketRule.Text;
                this._currentSTR.Count = Convert.ToInt32(txt_Count.Text);
                this._currentSTR.TrainDateID = traindateID;
                _currentSTR.OperateID = Program.CurrentEmployee.EmployeeID;
                _currentSTR.OperateTime = DateTime.Now;
                bool result = false;
                if (this.formState == FormState.New)
                {
                    if (_currentSTR.TicketRuleID == -1)
                    {
                        _currentSTR.TicketRuleID = Convert.ToInt32(this.Btn_TicketRule.Tag);
                    }
                    if (new TraindateTicketRuleDao().Exist(_currentSTR.TrainDateID, _currentSTR.TicketRuleID))
                    {
                        MsgBox.ShowInfo("已经存在选中数据！");
                        return;
                    }
                    else
                    {
                        result = new TraindateTicketRuleDao().Add(_currentSTR);
                    }
                }
                else //保存修改
                {
                    result = new TraindateTicketRuleDao().Update(_currentSTR);
                }
                if (result)
                {
                    this.formState = FormState.Normal;
                    int _index = this.gv_traindate_ticket_rule.GetFocusedDataSourceRowIndex();
                    this.gc_traindate_ticket_rule.RefreshDataSource();
                    this.gv_traindate_ticket_rule.FocusedRowHandle = _index;
                    MsgBox.ShowInfo("保存成功");
                }
                else
                {
                    MsgBox.ShowInfo("保存失败");
                }
            }
        }
        #endregion

    }
}