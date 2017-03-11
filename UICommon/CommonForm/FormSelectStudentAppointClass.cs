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
    public partial class FormSelectStudentAppointClass : FormBase
    {
        public FormSelectStudentAppointClass()
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
        public AppointClass currentService = null;
        public StudentAppointClass Data = null;
        public List<StudentAppointClass> DataList = new List<StudentAppointClass>();
        public List<AppointClass> _list = new List<AppointClass>();
        public String iStudentID = null;
        #endregion

        #region 事件
        void FormSelectService_Load(object sender, EventArgs e)
        {
            currentService = new AppointClass();
            if (!new StudentAppointClassDao().Exist(currentService.AppointClassID, iStudentID))
            {
                new StudentAppointClassDao().Insert(iStudentID);
            }
            _list = new AppointClassDao().GetList();
            DataList = new StudentAppointClassDao().GetListByStudentID(iStudentID);
            foreach (StudentAppointClass stuappointclass in DataList)
            {
                CheckRightData(stuappointclass);
            }
            gc_AppointClass.DataSource = _list;
            gc_AppointClass.RefreshDataSource();
        }
        private void CheckRightData(StudentAppointClass roleRight)
        {
            foreach (AppointClass stu in _list)
            {
                if (stu.AppointClassID == roleRight.AppointClassID) { stu.Choose = true; }
            }

        }
        /// <summary>
        /// 预约大类配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Btn_OK_Click(object sender, EventArgs e)
        {
            var chooseRow = _list.FindAll(m => m.Choose == true);
            var chooseCancelRow = _list.FindAll(m => !m.Choose);
            if (chooseRow.Count == 0) return;
            bool result = ThreadExcute(() =>
            {
                new StudentAppointClassDao().UpdateState(chooseRow, chooseCancelRow, iStudentID);
            });
            if (result)
            {
                MsgBox.ShowInfo("配置成功！");
            }
            else
            {
                MsgBox.ShowInfo("配置失败！");
            }
            this.DialogResult = DialogResult.OK;
        }
        void Btn_Canel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
