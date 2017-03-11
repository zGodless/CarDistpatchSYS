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
    public partial class FormSelectTrainDate : FormBase
    {
        public FormSelectTrainDate()
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
            this.gv_TrainDate.FocusedRowChanged+=gv_Service_FocusedRowChanged;
            this.gv_TrainDate.RowClick += gv_Service_RowClick;
        }

        void gv_Service_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
          if(gv_TrainDate.FocusedColumn==gridColumn_Choose)
          {
              var detail = gv_TrainDate.GetFocusedRow() as Traindate;
              if (detail == null) return;

              switch(e.Clicks)
              {
                  case 1:
                     foreach( var comm in _list)
                     {
                         if(comm.TrainDateID==detail.TrainDateID)
                         {
                             detail.Choose = !detail.Choose;
                         }
                         else
                         {
                             comm.Choose = false;
                         }
                     }
                      gc_TrainDate.RefreshDataSource();
                      break;
              }
          }
        }


        void  FormSelectService_Load(object sender, EventArgs e)
        {
            _list = new TraindateDao().GetList();
            gc_TrainDate.DataSource = null;
            gc_TrainDate.DataSource = _list;
            gc_TrainDate.RefreshDataSource();
        }
       #endregion

        #region 属性
        public Traindate currentService = null;
        public List<Traindate> _list = new List<Traindate>();
        public TraindateCommodity currentStudentCommodity = null;
        public String iTrainDateID = null;
        #endregion

        #region 事件

       /// <summary>
       /// 绑定培训类型
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        void Btn_OK_Click(object sender, EventArgs e)
        {
            var choosRow = _list.FindAll(m => m.TrainDateID == currentService.TrainDateID);
            if(choosRow.Count!=1)
            {
                MsgBox.ShowInfo("请只选择一种服务");
                return;
            }
            else
            {
                BuildTrainDate_Para para = new BuildTrainDate_Para();
                BuildTrainDate_Para outPara = null;//返回输出参数    
                para.vStudentStr = iTrainDateID;
                foreach (var ser in choosRow)
                    para.iTrainDateID = ser.TrainDateID;
                para.iOperateID = Program.CurrentEmployee.EmployeeID;
                bool result = new StudentDAO().BindTrainDate(para, out outPara);
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
            this.currentService = (Traindate)gv_TrainDate.GetFocusedRow();
        }
        #endregion
   
    }
}
