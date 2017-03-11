using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.Common;
using DS.Data;
using DS.Model;
using DS.MSClient;
using DevExpress.XtraGrid;

namespace DS.MSClient.UICommon
{
    //p_build_sale
    /// <summary>
    /// 订单详情
    /// </summary>
    public partial class FormSumbitOrderDetail : FormBase
    {
        public FormSumbitOrderDetail()
        {
            InitializeComponent();
            this.InitEvent();
        }
        #region 初始化
        void InitEvent()
        {

            Load += FormSumbitOrderDetail_Load;
            this.gv_ticket.RowClick += gv_ticket_RowClick;
            this.simpleButton_Sumbit.Click += simpleButton_Sumbit_Click;
        }

        #endregion
        #region 属性
        public List<Appointment> _AppointList = new List<Appointment>();
     
        public List<Commodity> _commoditylist = new List<Commodity>();
        public List<Commodity> Copy_commoditylist = new List<Commodity>();
        public List<Ticket> _ticketlist = new List<Ticket>();

        public AppointClass _currentClass = new AppointClass();
        public Coach _cuurentCoach = new Coach();
        public int iEmployeeID = 0;//学生ID
        public int iStudentID = 0;//学生ID
        public Student _currentStudent = new Student();
        public string iEmployeeName = null;//教练名
        public Coach _currentCoach = new Coach();
        public string vAppointmentIDStr = null;
        public string vSNstr = null;
        public bool IsVip = false;
        public string CommodityIDStr = null;
        public string vSource;
        #endregion
        #region 事件

        void simpleButton_Sumbit_Click(object sender, EventArgs e)
        {
            BuildOrder_Para para = new BuildOrder_Para();
            BuildOrder_Para outPara = null;//返回输出参数     
            var ChooseRow = _ticketlist.FindAll(m => m.Choose == true);
            if (ChooseRow.Count != 0)
                para.vSntr = string.Join(",", ChooseRow.Select(m => m.TicketID));
            int vip = 0;
            if (IsVip)
            {
                para.iisVip = 1;
            }
            else
            {
                para.iisVip = 0;
            }
            if (ck_ischeck.Checked)
            {
                para.iIsShuttle = 1;

            }
            else
            {
                para.iIsShuttle = 0;
            }
            para.vappointmentStr = vAppointmentIDStr;
            para.vSource = vSource;
            para.iEmployeeID = iEmployeeID;

            para.iStudentID = iStudentID;
            bool result = new StudentDAO().BuildOrder(para, out outPara);
            if (result)
            {
                MsgBox.ShowInfo("预约成功");
                this.Close();
            }
            else
            {
                MsgBox.ShowInfo(outPara.vReturnValue);
            }
        }


  
        void gv_ticket_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gv_ticket.FocusedColumn == gridColumn_Choose)
            {
                var detail = gv_ticket.GetFocusedRow() as Ticket;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        gc_ticket.RefreshDataSource();
                        break;
                }
            }
        }

        void FormSumbitOrderDetail_Load(object sender, EventArgs e)
        {
            textEdit1.Text = _currentStudent.StudentName;
            textEdit2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textEdit3.Text = iEmployeeName;
            if (IsVip)
            {
                textEdit4.Text = "一对一";
            }
            else
            {
                textEdit4.Text = "一对多";
            }
            if (_AppointList != null)
            {
                gc_appointtime.DataSource = null;
                gc_appointtime.DataSource = _AppointList;
                gc_appointtime.RefreshDataSource();
            }
            this._commoditylist = new CommodityDao().Query_sale(iStudentID, vAppointmentIDStr, IsVip);

            Commodity comm = new Commodity();
            comm.CommodityName = "保证金(1)";
            comm.Price = 30;

            if (_commoditylist != null)
            {
                List<Commodity> commdity = new List<Commodity>();

                this.Copy_commoditylist = new CommodityDao().GetList();
                commdity.Add(comm);


                int count = 0;
                foreach (Commodity Comm in Copy_commoditylist)
                {


                    count = 0;
                    Commodity dity = new Commodity();
                    foreach (Commodity Com in _commoditylist)
                    {
                        if (Comm.CommodityID == Com.CommodityID)
                        {

                            count++;

                        }

                    }

                    if (count != 0)
                    {
                        dity.CommodityID = Comm.CommodityID;
                        dity.CommodityName = Comm.CommodityName + "(" + count + ")";
                        dity.Price = Comm.Price;

                        commdity.Add(dity);
                    }




                }

                this.gc_commodity.DataSource = null;
                gc_commodity.DataSource = commdity;
                gc_commodity.RefreshDataSource();
            }
            CommodityIDStr = string.Join(",", _commoditylist.Select(m => m.CommodityID));
            this._ticketlist = new TicketDao().GetList_ID(iStudentID, CommodityIDStr);
            if (_ticketlist != null)
            {
                this.gc_ticket.DataSource = null;
                gc_ticket.DataSource = _ticketlist;
                gc_ticket.RefreshDataSource();
            }
        }
        #endregion
        #region 方法
        #endregion

    }
}
