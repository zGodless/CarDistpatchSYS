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
{
    public partial class FormServiceName : FormBase

    {
        public FormServiceName()
        {
            InitializeComponent();
               InitEvent();
        }
               #region 初始化

        private void InitEvent()
        {
            //加载数据
            this.Load += FormService_Load;
            this.simpleButton_yes.Click += btnOK_Click;
            this.simpleButton_no.Click += btnCancel_Click;
            this.gv_service.RowClick += gv_service_RowClick;
        }


        #endregion
        #region 属性

        public List<Service> _List;
        public List<Service> _ServicedeliteList = new List<Service>(); 

        #endregion

        #region 事件

        void gv_service_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_service.FocusedColumn == gridColumn_choose)
            {
                var detail = this.gv_service.GetFocusedRow() as Service;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_service.RefreshDataSource();
                        break;
                }
            }
        }

        void FormService_Load(object sender, EventArgs e)
        {
            if (ThreadExcute(BindData))
            {
                if (_List.Count>0 )
                {
                    _ServicedeliteList.ForEach(m => _List.Remove(_List.Find(n => n.ServiceID == m.ServiceID)));
                }
                this.gc_service.DataSource = _List;
                this.gc_service.RefreshDataSource();
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            //if (_ServicedeliteList==null)
            //_ServicedeliteList = new List<Service>();
            _ServicedeliteList.Clear();
            foreach (Service pro in this._List)
            {
                if (pro.Choose) _ServicedeliteList.Add(pro);
            }
            if (_ServicedeliteList.Count == 0)
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
            this.DialogResult=DialogResult.Cancel;
        }
        #endregion


        #region 方法
        private void BindData()
        {
            _List = new ServiceDao().GetList();
        }
        #endregion


 
    }
}
