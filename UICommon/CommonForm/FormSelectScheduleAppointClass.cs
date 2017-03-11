using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.Model;
using DS.Common;
using DS.Data;
using DS.MSClient;
using QuickFrame.Common.Converter;


namespace DS.MSClient.UICommon
{
    public partial class FormSelectScheduleAppointClass : FormBase
    {
        public FormSelectScheduleAppointClass()
        {
            InitializeComponent();
            this.Init();
        }
        #region 初始化

        void Init()
        {
            Load += FormSelectService_Load;
            this.Btn_Cancel.Click += Btn_Canel_Click;
            this.Btn_OK.Click += Btn_OK_Click;
            this.gv_AppointClass.RowClick += gv_Service_RowClick;
        }

        void gv_Service_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gv_AppointClass.FocusedColumn == gridColumn_Choose)
            {
                var detail = gv_AppointClass.GetFocusedRow() as AppointClass;
                if (detail == null) return;

                switch (e.Clicks)
                {
                    case 1:
                        foreach (var comm in _list)
                        {
                            if (comm.AppointClassID == detail.AppointClassID)
                            {
                                detail.Choose = !detail.Choose;
                            }
                        }
                        gc_AppointClass.RefreshDataSource();
                        break;
                }
            }
        }



        #endregion

        #region 属性

        public string idlist = "";
        public AppointClass currentService = null;
        public List<AppointClass> _list = new List<AppointClass>();
        public List<AppointClass> _chooselist = new List<AppointClass>();
        public String iStudentID = null;
        #endregion

        #region 事件
        void FormSelectService_Load(object sender, EventArgs e)
        {
            currentService = new AppointClass();
            _list = new AppointClassDao().GetByIDList(idlist);
            gc_AppointClass.DataSource = _list;
            gc_AppointClass.RefreshDataSource();
        }
        /// <summary>
        /// 预约大类配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Btn_OK_Click(object sender, EventArgs e)
        {
            _chooselist = _list.FindAll(m => m.Choose == true);
            if (_chooselist.Count == 0) return;
            this.DialogResult = DialogResult.OK;
        }
        void Btn_Canel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
