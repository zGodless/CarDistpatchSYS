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
using QuickFrame.Common.Converter;

namespace DS.MSClient.UICommon.CommonForm
{
    public partial class FormSelectAppointTime : FormDlgBase
    {

        #region 初始化
        public FormSelectAppointTime()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //加载数据
            this.Load += FormAppointTime_Load;
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.gv_AppointTime.RowClick += gv_AppointTime_RowClick;
            this.checkEdit_allin.CheckedChanged += checkEdit_allin_CheckedChanged;
        }

        void checkEdit_allin_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit_allin.Checked)
            {
                for (int i = 0; i < this.gv_AppointTime.RowCount; i++)
                {
                    this.gv_AppointTime.SetRowCellValue(i, gv_AppointTime.Columns.ColumnByFieldName("Choose"), true);
                }
            }
            else
            {
                for (int i = 0; i < this.gv_AppointTime.RowCount; i++)
                {
                    this.gv_AppointTime.SetRowCellValue(i, gv_AppointTime.Columns.ColumnByFieldName("Choose"), false);
                }
            }
         
        }

        #endregion
        #region 属性

        public List<AppointTime> _List = new List<AppointTime>();

        public List<AppointTime> _ListCopy = new List<AppointTime>();
        public List<GroupAppointClass> _DelList = new List<GroupAppointClass>();
        public int _GroupID = 0;
        public int _GroupAppointClassID = 0;
        public List<AppointTime> _AppointTimes = new List<AppointTime>();
        public DateTime BeginTime ;
        public DateTime EndTime;
        public bool IsAdd = true;
        public decimal Price=0;
	    public bool IsMergeContinuous = true;
        #endregion
        #region 事件


        void gv_AppointTime_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_AppointTime.FocusedColumn == Column_Choose)
            {
                var detail = this.gv_AppointTime.GetFocusedRow() as AppointTime;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_AppointTime.RefreshDataSource();
                        break;
                }
            }
        }

        void FormAppointTime_Load(object sender, EventArgs e)
        {
	        ck_Continuation.Checked = IsMergeContinuous;
            if (ThreadExcute(BindData))
            {
                this.gc_AppointTime.DataSource = _List;
                this.gv_AppointTime.BestFitColumns();
                this.gc_AppointTime.RefreshDataSource();
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            _AppointTimes.Clear();
            
            if (!ck_Continuation.Checked)
            {
                foreach (AppointTime pro in this._List)
                {
                    pro.Commoditylist = new AppointTimeDao().GetCommodityList(pro.AppointTimeID);
                    if (pro.Choose)
                    {
                        _AppointTimes.Add(pro);                    
                    }
                }
            }
            else
            {
                foreach (AppointTime pro in this._List)
                {
                    if (pro.Choose)
                    {
                        pro.Commoditylist = new AppointTimeDao().GetCommodityList(pro.AppointTimeID);
                        var index1 = _AppointTimes.FindIndex(m => m.EndTime == pro.BeginTime);
                        var index2 = _AppointTimes.FindIndex(m => m.BeginTime == pro.EndTime);
                        if (index1 <0 && index2  <0)
                        {
                            _AppointTimes.Add(pro);                           
                        }
                        else
                        {
                            if (index1 >= 0)
                            {
                                _AppointTimes[index1].EndTime = pro.EndTime;
                                pro.Commoditylist.ForEach(m =>
                                {
                                    var index = _AppointTimes[index1].Commoditylist.FindIndex(n => n.CommodityID == m.CommodityID);
                                    if (index < 0)
                                    {
                                        _AppointTimes[index1].Commoditylist.Add(m);
                                    }
                                    else
                                    {
                                        _AppointTimes[index1].Commoditylist[index].Price += m.Price;
                                    }
                                });
                            }
                            if (index2 >= 0)
                            {
                                _AppointTimes[index2].BeginTime = pro.BeginTime;
                                pro.Commoditylist.ForEach(m =>
                                {
                                    var index = _AppointTimes[index2].Commoditylist.FindIndex(n => n.CommodityID == m.CommodityID);
                                    if (index < 0)
                                    {
                                        _AppointTimes[index2].Commoditylist.Add(m);
                                    }
                                    else
                                    {
                                        _AppointTimes[index2].Commoditylist[index].Price += m.Price;
                                    }
                                });
                            }
                        }
                    }
                }               
            }
            if (_AppointTimes.Count == 0)
            {
                MsgBox.ShowInfo("请选中数据行");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;;
        }
        #endregion
        #region 方法
        private void BindData()
        {
            _List = new AppointTimeDao().GetFeeList();
            //_ListCopy = new AppointTimeDao().GetFeeList();
        }
        #endregion
    }
}