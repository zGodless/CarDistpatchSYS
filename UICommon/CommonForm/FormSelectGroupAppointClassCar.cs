using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet;
using DS.Data;
using DS.Model;

namespace DS.MSClient.UICommon.CommonForm
{
    public partial class FormSelectGroupAppointClassCar : FormDlgBase
    {

        #region 初始化
        public FormSelectGroupAppointClassCar()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //加载数据
            this.Load += FormGroupAppointClassCar_Load;
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.gv_GroupAppointClassCar.RowClick += gv_GroupAppointClassCar_RowClick;
            this.Btn_Search.Click += Btn_Search_Click;
        }

        #endregion
        #region 属性

        public List<GroupAppointClassCar> _List = new List<GroupAppointClassCar>();
        public List<GroupAppointClassCar> _DelList = new List<GroupAppointClassCar>();
        public List<GroupAppointClassCar> _itemlist = null;
        public int _TrainPlaceID = 0;
        public List<GroupAppointClassCar> _GroupAppointClassCar = new List<GroupAppointClassCar>(); 

        #endregion

        #region 事件
        void Btn_Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_Car.Text))
            {
                _itemlist = _List.FindAll(m => m.CarNo.Contains(text_Car.Text.Trim()) || (!string.IsNullOrEmpty(m.GroupCarCode) && m.GroupCarCode.Contains(text_Car.Text.Trim())));
                this.gc_GroupAppointClassCar.DataSource = _itemlist;
                this.gc_GroupAppointClassCar.RefreshDataSource();
            }
            else
            {
                this.gc_GroupAppointClassCar.DataSource = _List;
                this.gc_GroupAppointClassCar.RefreshDataSource();
            }
        }

        void gv_GroupAppointClassCar_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_GroupAppointClassCar.FocusedColumn == Column_Choose)
            {
                var detail = this.gv_GroupAppointClassCar.GetFocusedRow() as GroupAppointClassCar;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_GroupAppointClassCar.RefreshDataSource();
                        break;
                }
            }
        }

        void FormGroupAppointClassCar_Load(object sender, EventArgs e)
        {
            if (ThreadExcute(BindData))
            {
                if (_List.Count > 0 && _GroupAppointClassCar.Count > 0)
                {
                    foreach (var data in _GroupAppointClassCar)
                    {
                        _List.Find(m => m.CarID == data.CarID).Choose = true;
                    }
                }
                if (_DelList.Count > 0 && _List.Count > 0)
                {
                    foreach (var data in _DelList)
                    {
                        _List.Remove(_List.Find(m => m.CarID == data.CarID));
                    }
                }
                this.gc_GroupAppointClassCar.DataSource = _List;
                this.gc_GroupAppointClassCar.RefreshDataSource();
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            _GroupAppointClassCar.Clear();
            foreach (GroupAppointClassCar pro in this._List)
            {
                if (pro.Choose) _GroupAppointClassCar.Add(pro);
            }
            if (_GroupAppointClassCar.Count == 0)
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
            _List = new GroupAppointClassCarDao().GetListByGroup(_TrainPlaceID);
        }
        #endregion
    }
}