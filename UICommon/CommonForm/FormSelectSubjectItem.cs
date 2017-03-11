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
    public partial class FormSelectSubjectItem : FormDlgBase
    {

        #region 初始化
        public FormSelectSubjectItem()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //加载数据
            this.Load += FormTrainPlace_Load;
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.gv_TrainPlace.RowClick += gv_TrainPlace_RowClick;
        }


        #endregion
        #region 属性

        public List<AppointClass> _List;
        public List<AppointClass> _AppointClassSubjectItemList = new List<AppointClass>(); 

        #endregion

        #region 事件

        void gv_TrainPlace_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_TrainPlace.FocusedColumn == Column_Choose)
            {
                var detail = this.gv_TrainPlace.GetFocusedRow() as AppointClass;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_TrainPlace.RefreshDataSource();
                        break;
                }
            }
        }

        void FormTrainPlace_Load(object sender, EventArgs e)
        {
            if (ThreadExcute(BindData))
            {
                if (_List.Count > 0 && _AppointClassSubjectItemList.Count > 0)
                {
                    _AppointClassSubjectItemList.ForEach(m => _List.Remove(_List.Find(n => n.AppointClassID == m.AppointClassID)));
                }
                this.gc_TrainPlace.DataSource = _List;
                this.gc_TrainPlace.RefreshDataSource();
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            //if (_TrainPlacedeliteList==null)
            //_TrainPlacedeliteList = new List<TrainPlace>();
            _AppointClassSubjectItemList.Clear();
            foreach (AppointClass pro in this._List)
            {
                var groupcaptain = new AppointClass();
                groupcaptain.AppointClassID = pro.AppointClassID;
                groupcaptain.AppointClassName = pro.AppointClassName;
                groupcaptain.Note = pro.Note;

                if (pro.Choose) _AppointClassSubjectItemList.Add(groupcaptain);
            }
            if (_AppointClassSubjectItemList.Count == 0)
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
            _List = new AppointClassDao().GetList();
        }
        #endregion
    }
}