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
    public partial class FormSelectScheduleTime : FormDlgBase
    {

        #region 初始化
        public FormSelectScheduleTime()
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
            this.gv_ScheduleTime.RowClick += gv_AppointTime_RowClick;
            this.checkEdit_allin.CheckedChanged += checkEdit_allin_CheckedChanged;
            this.ck_Capacity.CheckStateChanged += ck_Capacity_CheckStateChanged;
            this.gv_ScheduleTime.ShowEditorByMouse();
            this.gv_ScheduleTime.RowUpdated += gv_ScheduleTime_RowUpdated;
        }

        void gv_ScheduleTime_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            int capacity = ValueConvert.ToInt32(this.gv_ScheduleTime.GetRowCellValue(e.RowHandle, gv_ScheduleTime.Columns["Capacity"]));

            int index = this.gv_ScheduleTime.GetDataSourceRowIndex(e.RowHandle);
            _List[index].Capacity = capacity;
        }

        void ck_Capacity_CheckStateChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MsgBox.ShowWarn("请输入容量数值");
                return;
            }
            if (ck_Capacity.Checked)
            {
                for (int i = 0; i < this.gv_ScheduleTime.RowCount; i++)
                {
                    if (_List[i].Choose)
                    {
                        this.gv_ScheduleTime.SetRowCellValue(i, gv_ScheduleTime.Columns.ColumnByFieldName("Capacity"), ValueConvert.ToInt32(textEdit1.EditValue));
                    }
                }
            }
        }

        void checkEdit_allin_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit_allin.Checked)
            {
                for (int i = 0; i < this.gv_ScheduleTime.RowCount; i++)
                {
                    this.gv_ScheduleTime.SetRowCellValue(i, gv_ScheduleTime.Columns.ColumnByFieldName("Choose"), true);
                }
            }
            else
            {
                for (int i = 0; i < this.gv_ScheduleTime.RowCount; i++)
                {
                    this.gv_ScheduleTime.SetRowCellValue(i, gv_ScheduleTime.Columns.ColumnByFieldName("Choose"), false);
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
        #endregion
        #region 事件


        void gv_AppointTime_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_ScheduleTime.FocusedColumn == Column_Choose)
            {
                var detail = this.gv_ScheduleTime.GetFocusedRow() as AppointTime;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        if (ck_Capacity.Checked)
                        {
                            if (detail.Choose)
                            {
                                this.gv_ScheduleTime.SetRowCellValue(e.RowHandle, gv_ScheduleTime.Columns.ColumnByFieldName("Capacity"), null);
                            }
                            else
                            {
                                this.gv_ScheduleTime.SetRowCellValue(e.RowHandle, gv_ScheduleTime.Columns.ColumnByFieldName("Capacity"), ValueConvert.ToInt32(textEdit1.EditValue));
                            }
                        }
                        detail.Choose = !detail.Choose;
                        this.gc_ScheduleTime.RefreshDataSource();
                        break;
                }
            }
        }

        void FormAppointTime_Load(object sender, EventArgs e)
        {
            if (ThreadExcute(BindData))
            {
                this.gc_ScheduleTime.DataSource = _List;
                this.gv_ScheduleTime.BestFitColumns();
                this.gc_ScheduleTime.RefreshDataSource();
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            _AppointTimes.Clear();
            foreach (AppointTime pro in this._List)
            {
                pro.Commoditylist = new AppointTimeDao().GetCommodityList(pro.AppointTimeID);
                if (pro.Choose)
                {
                    _AppointTimes.Add(pro);
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
            this.DialogResult = DialogResult.Cancel;;
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