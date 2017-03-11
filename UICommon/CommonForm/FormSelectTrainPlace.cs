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
    public partial class FormSelectTrainPlace : FormDlgBase
    {

        #region 初始化
        public FormSelectTrainPlace()
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

        public List<TrainPlace> _List;
        public List<TrainPlace> _TrainPlacedeliteList = new List<TrainPlace>(); 

        #endregion

        #region 事件

        void gv_TrainPlace_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_TrainPlace.FocusedColumn == Column_Choose)
            {
                var detail = this.gv_TrainPlace.GetFocusedRow() as TrainPlace;
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
                if (_List.Count>0 && _TrainPlacedeliteList.Count>0)
                {
                        _TrainPlacedeliteList.ForEach(m=>_List.Remove(_List.Find(n=>n.TrainPlaceID==m.TrainPlaceID)));
                }
                this.gc_TrainPlace.DataSource = _List;
                this.gc_TrainPlace.RefreshDataSource();
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            //if (_TrainPlacedeliteList==null)
            //_TrainPlacedeliteList = new List<TrainPlace>();
            _TrainPlacedeliteList.Clear();
            foreach (TrainPlace pro in this._List)
            {
                var groupcaptain = new TrainPlace();
                groupcaptain.TrainPlaceID = pro.TrainPlaceID;
                groupcaptain.TrainPlaceName = pro.TrainPlaceName;
                groupcaptain.Address = pro.Address;

                if (pro.Choose) _TrainPlacedeliteList.Add(groupcaptain);
            }
            if (_TrainPlacedeliteList.Count == 0)
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
            _List = new TrainPlaceDAO().GetList();
        }
        #endregion
    }
}