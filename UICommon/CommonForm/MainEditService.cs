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
    public partial class MainEditService : FormBase
    {
        #region 初始化
        public MainEditService()
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
            //加载数据
            Load += MainEditService_Load;
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

            this.Btn_TicketRule.ButtonClick += txt_TicketRule_Click;
            this.gv_service_ticket_rule.RowClick += gv_service_ticket_rule_RowClick;
            this.gv_Commodity.RowClick += gv_Commodity_RowClick;
            this.gv_service_ticket_rule.FocusedRowChanged +=gv_service_ticket_rule_FocusedRowChanged;
        }



        #endregion

        #region 属性

        private bool isinit = false;
        private Commodity _Commodity = null;
        private ServiceCommodity serviceCommodity = null;
        private List<ServiceCommodity> _listCommodity = new List<ServiceCommodity>();
        private List<Commodity> _list = new List<Commodity>();
        
        public string state = "Add";
        public List<ServiceTicketRule> strlist = new List<ServiceTicketRule>(); // 服务规则 数据集
        public ServiceTicketRule _currentSTR = new ServiceTicketRule();
        private ServiceTicketRule _itemcopy = null;
        public Service _current = null;
        public int  iServiceID = 0;
        #endregion

        #region 方法
        private void BindTextEdit(ServiceTicketRule _currentSTR)
        {
            if (_currentSTR == null) _currentSTR = new ServiceTicketRule();
            this.Btn_TicketRule.EditValue = _currentSTR.TicketRuleCode;
            this.txt_Count.EditValue = _currentSTR.Count;
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
                        this.barButtonItem_add.Enabled = false;
                        this.barButtonItem_edit.Enabled = true;
                        this.barButtonItem_delete.Enabled = false;
                        this.barButtonItem_save.Enabled = true;
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

        /// <summary>
        ///加载数据
        /// </summary>
        private void BindData()
        {
            Btn_TicketRule.Enabled = false;
            txt_Count.Enabled = false;

            _listCommodity = new ServiceCommodityDao().GetList(iServiceID);
            this.gc_Commodity.DataSource = _listCommodity;


            strlist = new ServiceTicketRuleDao().GetList(iServiceID);
            this.gc_service_ticket_rule.DataSource = strlist; 
        }
        #endregion

        #region 事件
        private void gv_service_ticket_rule_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this._currentSTR = this.gv_service_ticket_rule.GetFocusedRow() as ServiceTicketRule;
            this.BindTextEdit(_currentSTR);
        }

       
        void gv_Commodity_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(this.gv_Commodity.FocusedColumn==Column_choose)
            {
                var detail = this.gv_Commodity.GetFocusedRow() as ServiceCommodity;
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
            if (this.gv_service_ticket_rule.FocusedColumn == Column_choose)
            {
                var detail = this.gv_service_ticket_rule.GetFocusedRow() as ServiceTicketRule;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_service_ticket_rule.RefreshDataSource();
                        break;
                }
            }
        }
        /// <summary>
        /// 窗体加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainEditService_Load(object sender, EventArgs e)
        {
          
            BindData();
        }
        private void txt_TicketRule_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormSelectTicketRule form = new FormSelectTicketRule();
            form._ServiceList = strlist;
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
        /// 工具栏操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item == this.Btn_NewAdd)
            {
                OpenForm();
            }
            else if (e.Item == this.Btn_Del)
            {
                if (_listCommodity.Count == 0)
                {
                    MsgBox.ShowInfo("请选中数据行");
                    return;
                }
                var chooseRow = _listCommodity.FindAll(m => m.Choose == true);
                if (chooseRow.Count == 0) return;
                chooseRow.ForEach(item =>
                {
                    if (new ServiceCommodityDao().Delete(item.ServiceID,item.CommodityID))
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
                ServiceTicketRule ticket = new ServiceTicketRule();
                ticket.TicketRuleID = -1;
                this._currentSTR.TicketRuleID = ticket.TicketRuleID;
                this.strlist.Add(ticket);
                this.gc_service_ticket_rule.DataSource = this.strlist;
                this.gc_service_ticket_rule.RefreshDataSource();
                this.gv_service_ticket_rule.FocusedRowHandle = this.gv_service_ticket_rule.GetRowHandle(this.strlist.Count - 1);
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
                    ServiceTicketRule item = (ServiceTicketRule)gv_service_ticket_rule.GetFocusedRow();
                    new ServiceTicketRuleDao().Delete(item.ServiceID, item.TicketRuleID);
                    strlist.Remove(item);
                    MsgBox.ShowInfo("删除成功");
                }
                this.gc_service_ticket_rule.RefreshDataSource();
            }
            else if (e.Item == barButtonItem_edit)
            {
                this._currentSTR = this.gv_service_ticket_rule.GetFocusedRow() as ServiceTicketRule;
                if (this._currentSTR != null)
                {
                    this._itemcopy = (ServiceTicketRule)this._currentSTR.Copy();//保存副本，防止取消编辑 
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
                this._currentSTR.Count = Convert.ToInt32(txt_Count.Text);
                this._currentSTR.TicketRuleCode = ValueConvert.ToString(Btn_TicketRule.EditValue);
                _currentSTR.OperateID = Program.CurrentEmployee.EmployeeID;
                _currentSTR.OperateTime = DateTime.Now;
                _currentSTR.ServiceID = iServiceID;
                bool result = false;
                if (this.formState == FormState.New)
                {
                    if (_currentSTR.TicketRuleID == -1)
                    {
                        _currentSTR.TicketRuleID =Convert.ToInt32( this.Btn_TicketRule.Tag);
                    }
                    if (new ServiceTicketRuleDao().Exist(_currentSTR.ServiceID, _currentSTR.TicketRuleID))
                    {
                        MsgBox.ShowInfo("已经存在选中数据！");
                        return;
                    }
                    else
                    {
                        result = new ServiceTicketRuleDao().Add(_currentSTR);
                    }
                   
                }
                else //保存修改
                {
                    result = new ServiceTicketRuleDao().Update(_currentSTR);
                }
                if (result)
                {
                    this.formState = FormState.Normal;
                   
                    int _index = this.gv_service_ticket_rule.GetFocusedDataSourceRowIndex();
                    this.gc_service_ticket_rule.RefreshDataSource();
                    this.gv_service_ticket_rule.FocusedRowHandle = _index;
                    MsgBox.ShowInfo("保存成功");
                }
                else
                {
                    MsgBox.ShowInfo("保存失败");
                }
            }
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
                _list.AddRange(Commoditylist);
                foreach (var data in Commoditylist)
                {
                    var item = new ServiceCommodity();
                    item.CommodityID = data.CommodityID;
                    item.ServiceID = ValueConvert.ToInt32(iServiceID);
                    item.Note = data.Note;
                    item.CommoditytypeName = data.CommoditytypeName;
                    item.CommodityName = data.CommodityName;
                    item.ServiceName = data.ServiceName;
                    item.OperateID = Program.CurrentEmployee.EmployeeID;
                    item.OperateTime = DateTime.Now;

                    if (new ServiceTicketRuleDao().Exist(_currentSTR.ServiceID, _currentSTR.TicketRuleID))
                    {
                        MsgBox.ShowInfo("已经存在选中数据！");
                        return;
                    }
                    if (new ServiceCommodityDao().Exist(item.ServiceID, item.CommodityID))
                    {
                        MsgBox.ShowInfo("已经存在选中数据！");
                        return;
                    }
                    else
                    {
                        var result = new ServiceCommodityDao().Add(item);
                    }
                   
                }

            }
            this.gc_Commodity.DataSource = _list;
            gc_Commodity.RefreshDataSource();
        }
        #endregion


    }
}