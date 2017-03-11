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
    public partial class FormSelectService : FormBase
    {
        public FormSelectService()
        {
            InitializeComponent();
            this.Init();
        }
        #region 初始化
       
        void Init()
        {
            Load += FormSelectService_Load;
            this.Btn_Canel.Click += Btn_Canel_Click;
            this.Btn_OK.Click += Btn_OK_Click;
            this.gv_Service.FocusedRowChanged+=gv_Service_FocusedRowChanged;
            this.gv_Service.RowClick += gv_Service_RowClick;
        }

        void gv_Service_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
          if(gv_Service.FocusedColumn==gridColumn_Choose)
          {
              var detail = gv_Service.GetFocusedRow() as Service;
              if (detail == null) return;

              switch(e.Clicks)
              {
                  case 1:
                     foreach( var comm in _list)
                     {
                         if(comm.ServiceID==detail.ServiceID)
                         {
                             detail.Choose = !detail.Choose;
                         }
                         else
                         {
                             comm.Choose = false;
                         }
                     }
                      gc_Service.RefreshDataSource();
                      break;
              }
          }
        }


        void  FormSelectService_Load(object sender, EventArgs e)
        {
            _list = new ServiceDao().GetList();
            gc_Service.DataSource = null;
            gc_Service.DataSource = _list;
            gc_Service.RefreshDataSource();
        }
       #endregion

        #region 属性
        public Service currentService = null;
        public List<Service> _list = new List<Service>();
        public StudentCommodity currentStudentCommodity = null;
        public String  iStudentID=null;
        #endregion

        #region 事件

       /// <summary>
       /// 绑定培训类型
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        void Btn_OK_Click(object sender, EventArgs e)
        {
            var choosRow = _list.FindAll(m => m.ServiceID == currentService.ServiceID);
            if(choosRow.Count!=1)
            {
                MsgBox.ShowInfo("请只选择一种服务");
                return;
            }
            else
            {
                BuildBind_Para para = new BuildBind_Para();
                BuildBind_Para outPara = null;//返回输出参数    
                para.vStudentStr = iStudentID;
                foreach (var ser in choosRow)
                    para.iServiceID = ser.ServiceID;
                para.iOperateID = Program.CurrentEmployee.EmployeeID;
                bool result = new StudentDAO().BuildBind(para, out outPara);
                if (result)
                {
                    MsgBox.ShowInfo(outPara.vReturnValue);
                }
                else
                {
                    MsgBox.ShowInfo(outPara.vReturnValue);
                }
            }

        }
        void Btn_Canel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void gv_Service_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.currentService = (Service)gv_Service.GetFocusedRow();
        }
        #endregion
   
    }
}
