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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace DS.MSClient.UICommon
{
    /// <summary>
    /// 预约窗体
    /// </summary>
    public partial class FormSelectAppointList : FormBase
    {
        public FormSelectAppointList()
        {
            InitializeComponent();
            this.Init();
        }
        #region 初始化

        void Init()
        {
            Load += FormSelectAppointList_Load;
            //预约大类
            this.simpleButton_Canel.Click += simpleButton_Canel_Click;
            this.simpleButton_Next.Click += simpleButton_Next_Click;
            this.gv_AppointClass.FocusedRowChanged += gv_AppointClass_FocusedRowChanged;
            //教练
            this.simpleButton_Return.Click += simpleButton_Return_Click;
            this.simpleButton_next_coach.Click += simpleButton_next_coach_Click;
            //预约时间段
            this.simpleButton_return2.Click += simpleButton_return2_Click;
            this.simpleButton_sumbit.Click += simpleButton_sumbit_Click;
            this.gv_Appoint.RowClick += gv_Appoint_RowClick;
            this.gv_Appoint.FocusedRowChanged += gv_Appoint_FocusedRowChanged;
            this.gv_Coatch.FocusedRowChanged += gv_Coatch_FocusedRowChanged;
            txt_date.EditValueChanged += txt_date_EditValueChanged;
            
 
            
        }

 

    

        void gv_Appoint_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.CurrentAppoint = gv_Appoint.GetFocusedRow() as Appointment;

         
        }

        void gv_Appoint_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gv_Appoint.FocusedColumn == gridC_Choose)
            {
                
                var detail = gv_Appoint.GetFocusedRow() as Appointment;
                if (detail == null) return;
             
                switch (e.Clicks)
                {

                    case 1:
                        detail.Choose = !detail.Choose;
                        
                        gc_Appoint.RefreshDataSource();
                        break;
                }
            }
      
           
        }


        void FormSelectAppointList_Load(object sender, EventArgs e)
        {
            ClassList = new StudentAppointClassDao().GetList_stuid(iStudentID);//需改动
            /**/
            gc_AppointClass.DataSource = null;
            gc_AppointClass.DataSource = ClassList;
            gc_AppointClass.RefreshDataSource();

        }
        void simpleButton_sumbit_Click(object sender, EventArgs e)
        {
            FormSumbitOrderDetail form = new FormSumbitOrderDetail();
            form.iStudentID = iStudentID;
            form.iEmployeeName = CurrentCoach.EmployeeName;
            form.vSource = vSource;
            //form._currentClass = CurrentClass;
            var ChooseRow = AppointList.FindAll(m => m.Choose == true);
            if (ChooseRow.Count == 0)
            {
                MsgBox.ShowInfo("请至少选择一个预约时段");
                return;
            }
            ChooseRow.ForEach(item =>
                {
                    form._AppointList.Add(item);
                }
                );
            form.vAppointmentIDStr = string.Join(",", form._AppointList.Select(m => m.AppointmentID));
            if (IsVip_Check.Checked)
            {
                form.IsVip = true;
            }
            this.Close();
            form.ShowDialog(this);



        }
        #endregion

        #region 属性
        public StudentAppointClass CurrentClass = null;
        public List<StudentAppointClass> ClassList = new List<StudentAppointClass>();
        public Coach CurrentCoach = new Coach();
        public List<Coach> CoachList = new List<Coach>();
        public Appointment CurrentAppoint = null;
        public List<Appointment> AppointList = new List<Appointment>();
        public int iStudentID = 0;
        public string vSource = null;
        public int State = 0;
        

        #endregion
        #region 事件
        void simpleButton_Next_Click(object sender, EventArgs e)
        {
            this.groupControl_Class.Hide();
            this.groupControl_Coach.Show();

        }

        void simpleButton_Canel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void simpleButton_next_coach_Click(object sender, EventArgs e)
        {
            if (CurrentCoach.EmployeeID == 0)
            {
                MsgBox.ShowInfo("教练不为空");
                return;
            }
            this.groupControl_Coach.Hide();
            this.groupControl_list.Show();
        }

        void simpleButton_Return_Click(object sender, EventArgs e)
        {
            this.groupControl_Coach.Hide();
            this.groupControl_Class.Show();

        }



        void simpleButton_return2_Click(object sender, EventArgs e)
        {
            this.groupControl_list.Hide();
            this.groupControl_Coach.Show();
        }

        void gv_Coatch_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.CurrentCoach = (Coach)gv_Coatch.GetFocusedRow();
   
        }

        void gv_AppointClass_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.CurrentClass = (StudentAppointClass)gv_AppointClass.GetFocusedRow();
            if (CurrentClass != null)
            {
                CoachList = new CoachDao().GetList_ClassID(CurrentClass.AppointClassID,State);
                gc_Coatch.DataSource = null;
                gc_Coatch.DataSource = CoachList;
                gc_Coatch.RefreshDataSource();
                if (txt_date.EditValue != null)
                {


                }
            }

           // gv_AppointClass.FocusedColumn.AppearanceCell.ForeColor = Color.Red;
        }

        void txt_date_EditValueChanged(object sender, EventArgs e)
        {

            DateTime dt = this.txt_date.DateTime;
            int ID = ValueConvert.ToInt32(CurrentCoach.EmployeeID);
            AppointList = new AppointmentDao().GetList_Query(CurrentClass.AppointClassID, ID, dt);
            this.gc_Appoint.DataSource = null;
            gc_Appoint.DataSource = AppointList;

            gc_Appoint.RefreshDataSource();
        }


        #endregion






    }
}
