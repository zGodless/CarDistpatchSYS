using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DS.Model;
using DS.MSClient.UICommon;
using QuickFrame.Common.Converter;

namespace DS.MSClient
{
	public partial class CommonSearchByStudent : FormDlgBase
	{

		#region 初始化

		public CommonSearchByStudent()
		{
			InitializeComponent();
			InitEvent();
		}

		private void InitEvent()
		{
			Load += FormStudentForAuditApply_Load;
			btnReset.Click += btnReset_Click;
			btnOK.Click += btnOK_Click;
			btnCancel.Click += btnCancel_Click;
		}

		#endregion

		#region 属性
        public string ControlMemberFileName = "";
		/// <summary>
		/// 传入条件
		/// </summary>
		public Student Condition { get; set; }

		public string ExtSql { get; private set; }

		#endregion

		#region 事件

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
//             if (Condition.FormName == "MainChargeRegistration" || Condition.FormName == "MainStudentFollow")
// 		    {
// 		        GetStudentSearchFilter(ExtSql);
// 		    }
// 		    else
// 		    {
//                 GetSearchFilter(ExtSql);
//             }
            GetSearchFilter(ExtSql);
			Condition = new Student
			{
				StudentName = ValueConvert.ToString(txt_studentName.EditValue),
				StudentCode = ValueConvert.ToString(txt_StudentCode.EditValue),
				ApplyPlaceID = ValueConvert.ToNullableInt32(cl_ApplyPlace.EditValue),
				SchoolID = ValueConvert.ToNullableInt32(cl_School.EditValue),
				IdentityNo = ValueConvert.ToString(txt_IdentityNo.EditValue),
				TrainPlaceID = ValueConvert.ToNullableInt32(cl_TrainPlace.EditValue),
				BeginTime = ValueConvert.ToNullableDateTime(date_applyStartDate.EditValue),
				EndTime = ValueConvert.ToNullableDateTime(date_applyEndDate.EditValue),
				ApplyWayID = ValueConvert.ToNullableInt32(cl_ApplyWay.EditValue),
				FromState = ValueConvert.ToNullableInt32(cl_StudentStateBegin.EditValue),
				ToState = ValueConvert.ToNullableInt32(cl_StudentStateEnd.EditValue),
				ApplyLicense = ValueConvert.ToString(cmb_ApplyLicense.EditValue),
				GroupID = ValueConvert.ToInt32(cl_Group.EditValue),
				CoachID = ValueConvert.ToInt32(cl_Employee.EditValue),
				BeginLatelyExamTime = ValueConvert.ToNullableDateTime(date_LatelyExamTimeStar.EditValue),
				EndLatelyExamTime = ValueConvert.ToNullableDateTime(date_LatelyExamTimeEnd.EditValue),
				ExamIsArrange = cmb_ExamIsArrange.SelectedIndex,
				Cellphone = ValueConvert.ToString(txt_Cellphone.EditValue),
				TrainProperty = ValueConvert.ToString(cmb_TrainProperty.EditValue),
                BeginClassArrangeTime = ValueConvert.ToNullableDateTime(this.date_ClassArrangeTimeStar.EditValue),
                EndClassArrangeTime = ValueConvert.ToNullableDateTime(this.date_ClassArrangeTimeEnd.EditValue),
				ConIsLocal = cboIsLocal.SelectedIndex,
                IsCoach = cmb_Coach.SelectedIndex,
                PromiseDateType = cboPromiseDate.Text,
                MarkBegin = ValueConvert.ToNullableDateTime(date_MarkBegin.EditValue),
                MarkEnd = ValueConvert.ToNullableDateTime(date_MarkEnd.EditValue),
                TrainBegin = ValueConvert.ToNullableDateTime(date_TrainBegin.EditValue),
                TrainEnd = ValueConvert.ToNullableDateTime(date_TrainEnd.EditValue)
			};
            if (ControlMemberFileName != "")
            {
                ControlMemoryHelper.SaveControl(ControlMemberFileName, lcMain);
            }
			DialogResult = DialogResult.OK;
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			txt_studentName.EditValue = null;
			txt_StudentCode.EditValue = null;
			txt_IdentityNo.EditValue = null;
			txt_Cellphone.EditValue = null;
			date_applyStartDate.EditValue = null;
			cl_StudentStateBegin.EditValue = null;
			cl_ApplyWay.EditValue = null;
			cl_ApplyPlace.EditValue = null;

			cl_School.EditValue = null;
			date_applyEndDate.EditValue = null;
			cl_StudentStateEnd.EditValue = 74;
			cl_Employee.EditValue = null;
			cmb_StudentType.EditValue = null;
			cmb_TrainProperty.EditValue = null;
			cmb_Examstate.EditValue = null;
			cmb_ExamIsArrange.EditValue = null;

			cl_SchoolState1.EditValue = null;
			cl_SchoolState2.EditValue = null;
			cl_SchoolState3.EditValue = null;
			cl_TrainPlace.EditValue = null;
			cboIsLocal.EditValue = null;
			cl_From.EditValue = null;
			cmb_Coach.EditValue = null;
			cmb_IsWeipei.EditValue = null;

			cmb_IsOweFee.EditValue = null;
			cmb_IsLock.EditValue = null;
			cmb_IsFreeze.EditValue = null;
			cmb_IsExpire.EditValue = null;
			cmb_InfoIsFull.EditValue = null;
			cmb_ApplyLicense.EditValue = null;
			cmb_License.EditValue = null;
			cmb_LifeAreaName.EditValue = null;

			txt_TicketNumber.EditValue = null; //准考证号
			txt_ClassArrangeNumber.EditValue = null; //报班编号
			date_ClassArrangeTimeStar.EditValue = null; //报班时间从
			date_ClassArrangeTimeEnd.EditValue = null; //报班时间到
		    dateSubject1PreExamTimeEnd.EditValue = null;
		    date_Subject1PreExamTime.EditValue = null;
            cmb_Subject1PreExamPass.EditValue = null;
            cmb_Subject4PreExamPass.EditValue = null;

			date_LatelyExamTimeStar.EditValue = null;
			date_LatelyExamTimeEnd.EditValue = null;
			date_Subject1ExamPassTimeStar.EditValue = null;
			date_Subject1ExamPassTimeEnd.EditValue = null;
			date_Subject3ExamPassTimeStar.EditValue = null;
			date_Subject3ExamPassTimeEnd.EditValue = null;
			txt_Subject1MakeUpNumberStar.EditValue = -1;
			txt_Subject1MakeUpNumberEnd.EditValue = -1;
			txt_Subject3MakeUpNumberStar.EditValue = -1;
			txt_Subject3MakeUpNumberEnd.EditValue = -1;

			txt_ExamTime.EditValue = null;
			cmb_SubjectStayState.EditValue = null;
			date_Subject2ExamPassTimeStar.EditValue = null;
			date_Subject2ExamPassTimeEnd.EditValue = null;
			date_Subject4ExamPassTimeStar.EditValue = null;
			date_Subject4ExamPassTimeEnd.EditValue = null;
			txt_Subject2MakeUpNumberStar.EditValue = -1;
			txt_Subject2MakeUpNumberEnd.EditValue = -1;
			txt_Subject4MakeUpNumberStar.EditValue = -1;
			txt_Subject4MakeUpNumberEnd.EditValue = -1;

			cl_CourseName.EditValue = null;
			cl_TakePlace.EditValue = null;
			cl_TrainDate.EditValue = null;
			cmb_TrainProgress.EditValue = null;

			//其他查询
			cmb_Sex.EditValue = null;
			txt_ReceivableTrainFeeStar.EditValue = null;
			date_QuitSchoolTimeStar.EditValue = null;
			cl_AgeRange.EditValue = null;
			txt_ReceivableTrainFeeEnd.EditValue = null;
			date_QuitSchoolTimeEnd.EditValue = null;
			cmb_QuitSchoolKind.EditValue = null;
			txt_ReceivedTrainFeeStar.EditValue = null;
			txt_TemporaryName.EditValue = null;
			cmb_GuanXiHu.EditValue = null;
			txt_ReceivedTrainFeeEnd.EditValue = null;
			txt_MedicalTabe.EditValue = null;
            cboDrivePlanCount.EditValue = null;
            cboWeChat.EditValue = null;
            cboPromiseDate.EditValue = null;

            date_MarkBegin.EditValue = null;
            date_MarkEnd.EditValue = null;
            date_TrainBegin.EditValue = null;
            date_TrainEnd.EditValue = null;
		}

		private void FormStudentForAuditApply_Load(object sender, EventArgs e)
		{
			cLookAgeArange1.BindList();
			cl_AgeRange.BindList();
			cl_ApplyPlace.BindList();
			cl_ApplyWay.BindList();
			cl_CourseName.BindList();
			cl_Employee.BindList();
			cl_From.BindList();
			cl_School.BindList();
			cl_SchoolState1.Bind();
			cl_SchoolState2.Bind();
			cl_SchoolState3.Bind();
			cl_StudentStateBegin.Bind();
			cl_StudentStateEnd.Bind();
			cl_TrainDate.BindList();
			cmb_Examstate.Bind();
			cl_TrainPlace.BindList();
			cl_Group.BindList();
			date_applyStartDate.EditValue = "2006-01-01";
			date_applyEndDate.EditValue = DateTime.Now;
            if (ControlMemberFileName != "")
            {
                ControlMemoryHelper.ReadControl(ControlMemberFileName, lcMain);
            }
			if (Condition != null)
			{
			    if (Condition.FormName == "MainStudentFollow")
                {
                    txt_studentName.EditValue = Condition.StudentName;
                    txt_StudentCode.EditValue = Condition.StudentCode;
                    cl_School.EditValue = Condition.SchoolID;
                    cl_TrainPlace.EditValue = Condition.TrainPlaceID;
                    txt_IdentityNo.EditValue = Condition.IdentityNo;
                    date_applyStartDate.EditValue = Condition.BeginTime;
                    date_applyEndDate.EditValue = Condition.EndTime;
                    cl_StudentStateBegin.EditValue = Condition.FromState;
                    cl_StudentStateEnd.EditValue = Condition.ToState;
                    cmb_TrainProperty.EditValue = Condition.TrainProperty;
                    cl_Group.EditValue = Condition.GroupID;
                    cl_Employee.EditValue = Condition.CoachID;
                    txt_Cellphone.EditValue = Condition.Cellphone;
                    cl_ApplyWay.EditValue = Condition.ApplyWayID;
                    cmb_Coach.SelectedIndex = Condition.IsCoach;
                    date_MarkBegin.EditValue = Condition.MarkBegin;
                    date_MarkEnd.EditValue = Condition.MarkEnd;
                    date_TrainBegin.EditValue = Condition.TrainBegin;
                    date_TrainEnd.EditValue = Condition.TrainEnd;
                }
                else if (Condition.FormName == "MainPreAudit")
                {
                    txt_studentName.EditValue = Condition.StudentName;
                    txt_StudentCode.EditValue = Condition.StudentCode;
                    cl_ApplyPlace.EditValue = Condition.ApplyPlaceID;
                    cl_School.EditValue = Condition.SchoolID;
                    txt_IdentityNo.EditValue = Condition.IdentityNo;
                    cl_TrainPlace.EditValue = Condition.TrainPlaceID;
                    date_applyStartDate.EditValue = Condition.BeginTime;
                    date_applyEndDate.EditValue = Condition.EndTime;
                    cl_ApplyWay.EditValue = Condition.ApplyWayID;
                    cl_Group.EditValue = Condition.GroupID;
                    cmb_Coach.EditValue = Condition.CoachID;
                    txt_Cellphone.EditValue = Condition.Cellphone;
                    cmb_TrainProperty.EditValue = Condition.TrainProperty;
                }
                else if (Condition.FormName == "MainClassAuditDetail")
                {
                    txt_studentName.EditValue = Condition.StudentName;
                    txt_IdentityNo.EditValue = Condition.IdentityNo;
                }
                else if (Condition.FormName == "MainPreClassAuditDetail")
                {
                    txt_studentName.EditValue = Condition.StudentName;
                    txt_IdentityNo.EditValue = Condition.IdentityNo;
                }
                else if (Condition.FormName == "MainDrivePlanDetail")
                {
                    txt_StudentCode.EditValue = Condition.StudentCode;
                    cl_School.EditValue = Condition.SchoolID;
                    cl_Group.EditValue = Condition.GroupID;
                    cl_Employee.EditValue = Condition.CoachID;
                }
                else if (Condition.FormName == "MainStudentScoreQuery")
                {
                    cl_School.EditValue = Condition.SchoolID;
                    cl_Group.EditValue = Condition.GroupID;
                    cl_Employee.EditValue = Condition.CoachID;
                    cl_TrainPlace.EditValue = Condition.TrainPlaceID;
                    cl_ApplyPlace.EditValue = Condition.ApplyPlaceID;
                }
                else if (Condition.FormName == "MainStudentScoreQueryForm")
                {
                    txt_studentName.EditValue = Condition.StudentName;
                    txt_StudentCode.EditValue = Condition.StudentCode;
                    txt_IdentityNo.EditValue = Condition.IdentityNo;
                    txt_Cellphone.EditValue = Condition.Cellphone;
                }
			    else
			    {
                    txt_studentName.EditValue = Condition.StudentName;
                    txt_StudentCode.EditValue = Condition.StudentCode;
                    cl_ApplyPlace.EditValue = Condition.ApplyPlaceID;
                    cl_School.EditValue = Condition.SchoolID;
                    txt_IdentityNo.EditValue = Condition.IdentityNo;
                    cl_TrainPlace.EditValue = Condition.TrainPlaceID;
                    date_applyStartDate.EditValue = Condition.BeginTime;
                    date_applyEndDate.EditValue = Condition.EndTime;
                    cl_ApplyWay.EditValue = Condition.ApplyWayID;
                    cl_StudentStateBegin.EditValue = Condition.FromState;
                    cl_StudentStateEnd.EditValue = Condition.ToState;
                    cboPromiseDate.EditValue = Condition.PromiseDateType;
                    cmb_ApplyLicense.EditValue = Condition.ApplyLicense;
                    cl_Group.EditValue = Condition.GroupID;
                    cl_Employee.EditValue = Condition.CoachID;
                    date_LatelyExamTimeStar.EditValue = Condition.BeginLatelyExamTime;
                    date_LatelyExamTimeEnd.EditValue = Condition.EndLatelyExamTime;
                    if (ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue).Year < 1990)
                    {
                        date_ClassArrangeTimeStar.EditValue = Condition.BeginClassArrangeTime;
                    }
                    if (ValueConvert.ToDateTime(date_ClassArrangeTimeEnd.EditValue).Year < 1990)
                    {
                        this.date_ClassArrangeTimeEnd.EditValue = Condition.EndClassArrangeTime;
                    }
                    cmb_ExamIsArrange.SelectedIndex = Condition.ExamIsArrange;
                    txt_Cellphone.EditValue = Condition.Cellphone;
                    cmb_TrainProperty.EditValue = Condition.TrainProperty;
                    cboIsLocal.SelectedIndex = Condition.ConIsLocal;
			    }
			}
		}

		#endregion

		#region 方法

		private void GetSearchFilter(string sql)
		{
			//快捷查询
			if (txt_studentName.Text != "")
			{
				sql += string.Format(" and a.StudentName like '%{0}%'", txt_studentName.Text);
			}
			if (txt_StudentCode.Text != "")
			{
				sql += string.Format(" and a.StudentCode like '%{0}%'", txt_StudentCode.Text);
			}
			if (txt_IdentityNo.Text != "")
			{
				sql += string.Format(" and a.IdentityNo like '%{0}%'", txt_IdentityNo.Text);
			}
			if (txt_Cellphone.Text != "")
			{
				sql += string.Format(" and a.Cellphone like '%{0}%'", txt_Cellphone.Text);
			}
			if (ValueConvert.ToInt32(cl_ApplyPlace.EditValue) != 0)
			{
				sql += string.Format(" and a.ApplyPlaceID = {0}", ValueConvert.ToInt32(cl_ApplyPlace.EditValue));
			}
			if (ValueConvert.ToInt32(cl_School.EditValue) != 0)
			{
				sql += string.Format(" and a.SchoolID = {0}", ValueConvert.ToInt32(cl_School.EditValue));
			}
			if (ValueConvert.ToInt32(cl_Group.EditValue) != 0)
			{
				sql += string.Format(" and a.GroupID = {0}", ValueConvert.ToInt32(cl_Group.EditValue));
			}
			if (cmb_StudentType.Text != "")
			{
				sql += string.Format(" and a.StudentType like '%{0}%'", cmb_StudentType.Text);
			}
			if (cmb_TrainProperty.Text != "")
			{
				sql += string.Format(" and ifnull(a.TrainProperty,'') = '{0}'", cmb_TrainProperty.Text);
			}
			if (ValueConvert.ToInt32(cmb_Examstate.EditValue) != 0)
			{
				sql += string.Format(" and a.Examstate = {0}", ValueConvert.ToInt32(cmb_Examstate.EditValue));
			}
			if (cmb_ExamIsArrange.SelectedIndex > 0)
			{
				sql += string.Format(" and p.ExamIsArrange = {0}", cmb_ExamIsArrange.SelectedIndex == 1 ? 1 : 0);
			}
			if (ValueConvert.ToInt32(cl_Employee.EditValue) != 0)
			{
				sql += string.Format(" and a.CoachID = {0}", ValueConvert.ToInt32(cl_Employee.EditValue));
			}
			if (ValueConvert.ToInt32(cl_ApplyWay.EditValue) != 0)
			{
                sql += string.Format(" and find_in_set(a.ApplyWayID,f_get_applyway_child_list({0}))", cl_ApplyWay.EditValue);
			}
			if (date_applyStartDate.EditValue != null && date_applyEndDate.EditValue == null)
			{
				sql += string.Format(" and a.ApplyDate >= '{0}'",
					ValueConvert.ToDateTime(date_applyStartDate.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_applyEndDate.EditValue != null && date_applyStartDate.EditValue == null)
			{
				sql += string.Format(" and a.ApplyDate <= '{0}'",
					ValueConvert.ToDateTime(date_applyEndDate.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_applyStartDate.EditValue != null && date_applyEndDate.EditValue != null)
			{
				var date1 = ValueConvert.ToDateTime(date_applyStartDate.EditValue);
				var date2 = ValueConvert.ToDateTime(date_applyEndDate.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("报名时间结束日期不可大于开始日期");
					return;
				}
				sql += string.Format(" and date(a.ApplyDate) between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_applyStartDate.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_applyEndDate.EditValue).ToString("yyyy-MM-dd"));
			}
			if (ValueConvert.ToInt32(cl_StudentStateBegin.EditValue) != 0 &&
				ValueConvert.ToInt32(cl_StudentStateEnd.EditValue) == 0)
			{
				sql += string.Format(" and a.State >= {0}", cl_StudentStateBegin.EditValue);
			}
			else if (ValueConvert.ToInt32(cl_StudentStateEnd.EditValue) != 0 &&
					 ValueConvert.ToInt32(cl_StudentStateBegin.EditValue) == 0)
			{
				sql += string.Format(" and a.State <= {0}", cl_StudentStateEnd.EditValue);
			}
			else if (ValueConvert.ToInt32(cl_StudentStateBegin.EditValue) != 0 &&
					 ValueConvert.ToInt32(cl_StudentStateEnd.EditValue) != 0)
			{
				sql += string.Format(" and a.State >={0} and a.State <={1}", ValueConvert.ToInt32(cl_StudentStateBegin.EditValue),
					ValueConvert.ToInt32(cl_StudentStateEnd.EditValue));
			}
			//常用信息查询
			if (cl_SchoolState1.EditValue != null)
			{
				sql += string.Format(" and p.Period1IsFull = '{0}' ", cl_SchoolState1.EditValue);
			}
			if (cl_SchoolState2.EditValue != null)
			{
				sql += string.Format(" and p.Period2IsFull = '{0}'", cl_SchoolState2.EditValue);
			}
			if (cl_SchoolState3.EditValue != null)
			{
				sql += string.Format(" and p.Period3IsFull = '{0}'", cl_SchoolState3.EditValue);
			}
			if (ValueConvert.ToInt32(cl_TrainPlace.EditValue) != 0)
			{
				sql += string.Format(" and a.TrainPlaceID = {0}", ValueConvert.ToInt32(cl_TrainPlace.EditValue));
			}
			if (cboIsLocal.SelectedIndex > 0)
			{
				sql += string.Format(" and a.Islocal = '{0}' ", cboIsLocal.SelectedIndex == 1 ? 1 : 0);
			}
			if (ValueConvert.ToInt32(cl_From.EditValue) != 0)
			{
                sql += string.Format(" and find_in_set(a.FromID,f_get_from_child_list({0}))", cl_From.EditValue);
			}
			if (cmb_Coach.SelectedIndex > 0) //是否分配教练，未解决
			{
				sql += string.Format(" and p.IsCoach = {0}", cmb_Coach.SelectedIndex == 1? 1:2);
			}
			if (cmb_IsWeipei.SelectedIndex >= 0)
			{
				sql += string.Format(" and a.IsWeipei = {0}", ValueConvert.ToInt32(cmb_IsWeipei.SelectedIndex));
			}
			if (cmb_IsOweFee.SelectedIndex >= 0)
			{
				sql += string.Format(" and p.IsOweFee = {0} ", ValueConvert.ToInt32(cmb_IsOweFee.SelectedIndex));
			}
			if (cmb_InfoIsFull.SelectedIndex >= 0)
			{
				sql += string.Format(" and p.InfoIsFull = {0} ", ValueConvert.ToInt32(cmb_InfoIsFull.SelectedIndex));
			}
			if (txt_TicketNumber.Text != "")
			{
				sql += string.Format(" and p.TicketNumber like '%{0}%'", txt_TicketNumber.Text);
			}
			if (cmb_IsLock.SelectedIndex >= 0)
			{
				sql += string.Format(" and a.IsLock  = {0}", ValueConvert.ToInt32(cmb_IsLock.SelectedIndex));
			}
			if (cmb_ApplyLicense.Text != "")
			{
				sql += string.Format(" and a.ApplyLicense = '{0}' ", cmb_ApplyLicense.Text);
			}
			if (txt_ClassArrangeNumber.Text != "")
			{
				sql += string.Format(" and p.ClassArrangeNumber like '%{0}%'", txt_ClassArrangeNumber.Text);
			}
			if (cmb_IsFreeze.SelectedIndex >= 0)
			{
				sql += string.Format(" and a.IsFreeze  = {0}", ValueConvert.ToInt32(cmb_IsFreeze.SelectedIndex));
			}
			if (cmb_License.SelectedText != "")
			{
				sql += string.Format(" and a.License = '{0}'", cmb_License.SelectedText);
			}
			if (cmb_IsExpire.SelectedIndex >= 0)
			{
			    if (cmb_IsExpire.Text == "是")
			    {
			        sql += " and a.IsExpire  = 1";
			    }
			    else if (cmb_IsExpire.Text == "否")
			    {
                    sql += " and a.IsExpire  = 0";
			    }
			}
			if (ValueConvert.ToInt32(cmb_LifeAreaName.EditValue) != 0)
			{
				sql += string.Format(" and a.LifeAreaID = {0}", ValueConvert.ToInt32(cmb_LifeAreaName.EditValue));
			}
			if (date_ClassArrangeTimeStar.EditValue != null && date_ClassArrangeTimeEnd.EditValue == null)
			{
                sql += string.Format(" and date(p.ClassArrangeTime) >= '{0}'",
					ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_ClassArrangeTimeEnd.EditValue != null && date_ClassArrangeTimeStar.EditValue == null)
			{
                sql += string.Format(" and date(p.ClassArrangeTime) <= '{0}'",
					ValueConvert.ToDateTime(date_ClassArrangeTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_ClassArrangeTimeStar.EditValue != null && date_ClassArrangeTimeEnd.EditValue != null)
			{
				var date1 = ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue);
				var date2 = ValueConvert.ToDateTime(date_ClassArrangeTimeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("报班时间结束日期不可大于开始日期");
					return;
				}
                sql += string.Format(" and date(p.ClassArrangeTime) between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_ClassArrangeTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			//考试信息查询
			if (date_LatelyExamTimeStar.EditValue != null && date_LatelyExamTimeEnd.EditValue == null)
			{
				sql += string.Format(" and p.LatelyExamTime >= '{0}'",
					ValueConvert.ToDateTime(date_LatelyExamTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_LatelyExamTimeEnd.EditValue != null && date_LatelyExamTimeStar.EditValue == null)
			{
				sql += string.Format(" and p.LatelyExamTime <= '{0}'",
					ValueConvert.ToDateTime(date_LatelyExamTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_LatelyExamTimeStar.EditValue != null && date_LatelyExamTimeEnd.EditValue != null)
			{
				var date1 = ValueConvert.ToDateTime(date_LatelyExamTimeStar.EditValue);
				var date2 = ValueConvert.ToDateTime(date_LatelyExamTimeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("报班时间结束日期不可大于开始日期");
					return;
				}
				sql += string.Format(" and p.LatelyExamTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_LatelyExamTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_LatelyExamTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (ValueConvert.ToInt32(txt_ExamTime.EditValue) != 0)
			{
				sql += string.Format(" and p.ExamTime = {0}", txt_ExamTime.EditValue);
			}
			if (cmb_SubjectStayState.SelectedText != "")
			{
				sql += string.Format(" and p.SubjectStayState = '{0}'", cmb_SubjectStayState.SelectedText);
			}
			if (date_Subject1ExamPassTimeStar.EditValue != null && date_Subject1ExamPassTimeEnd.EditValue == null) //科一考过时间
			{
				sql += string.Format(" and p.Subject1ExamPassTime >= '{0}'",
					ValueConvert.ToDateTime(date_Subject1ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject1ExamPassTimeEnd.EditValue != null && date_Subject1ExamPassTimeStar.EditValue == null)
			{
				sql += string.Format(" and p.Subject1ExamPassTime <= '{0}'",
					ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject1ExamPassTimeStar.EditValue != null && date_Subject1ExamPassTimeEnd.EditValue != null)
			{
				var date1 = ValueConvert.ToDateTime(date_Subject1ExamPassTimeStar.EditValue);
				var date2 = ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("科一考过时间结束日期不可大于开始日期");
					return;
				}
				sql += string.Format(" and p.Subject1ExamPassTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_Subject1ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (date_Subject2ExamPassTimeStar.EditValue != null && date_Subject2ExamPassTimeEnd.EditValue == null) //科二考过时间
			{
				sql += string.Format(" and p.Subject2ExamPassTime >= '{0}'",
					ValueConvert.ToDateTime(date_Subject2ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject2ExamPassTimeEnd.EditValue != null && date_Subject2ExamPassTimeStar.EditValue == null)
			{
				sql += string.Format(" and p.Subject2ExamPassTime <= '{0}'",
					ValueConvert.ToDateTime(date_Subject2ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject2ExamPassTimeStar.EditValue != null && date_Subject2ExamPassTimeEnd.EditValue != null)
			{
				var date1 = ValueConvert.ToDateTime(date_Subject2ExamPassTimeStar.EditValue);
				var date2 = ValueConvert.ToDateTime(date_Subject2ExamPassTimeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("科二考过时间结束日期不可大于开始日期");
					return;
				}
				sql += string.Format(" and p.Subject2ExamPassTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_Subject2ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_Subject2ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (date_Subject3ExamPassTimeStar.EditValue != null && date_Subject3ExamPassTimeEnd.EditValue == null) //科三考过时间
			{
				sql += string.Format(" and p.Subject3ExamPassTime >= '{0}'",
					ValueConvert.ToDateTime(date_Subject3ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject3ExamPassTimeEnd.EditValue != null && date_Subject3ExamPassTimeStar.EditValue == null)
			{
				sql += string.Format(" and p.Subject3ExamPassTime <= '{0}'",
					ValueConvert.ToDateTime(date_Subject3ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject3ExamPassTimeStar.EditValue != null && date_Subject3ExamPassTimeEnd.EditValue != null)
			{
				var date1 = ValueConvert.ToDateTime(date_Subject3ExamPassTimeStar.EditValue);
				var date2 = ValueConvert.ToDateTime(date_Subject3ExamPassTimeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("科三考过时间结束日期不可大于开始日期");
					return;
				}
				sql += string.Format(" and p.Subject3ExamPassTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_Subject3ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_Subject3ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (date_Subject4ExamPassTimeStar.EditValue != null && date_Subject4ExamPassTimeEnd.EditValue == null) //科四考过时间
			{
                sql += string.Format(" and date(p.Subject4ExamPassTime) >= '{0}'",
					ValueConvert.ToDateTime(date_Subject4ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject4ExamPassTimeEnd.EditValue != null && date_Subject4ExamPassTimeStar.EditValue == null)
			{
                sql += string.Format(" and date(p.Subject4ExamPassTime) <= '{0}'",
					ValueConvert.ToDateTime(date_Subject4ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject4ExamPassTimeStar.EditValue != null && date_Subject4ExamPassTimeEnd.EditValue != null)
			{
				var date1 = ValueConvert.ToDateTime(date_Subject4ExamPassTimeStar.EditValue);
				var date2 = ValueConvert.ToDateTime(date_Subject4ExamPassTimeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("科四考过时间结束日期不可大于开始日期");
					return;
				}
                sql += string.Format(" and date(p.Subject4ExamPassTime) between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_Subject4ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_Subject4ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (ValueConvert.ToInt32(txt_Subject1MakeUpNumberStar.EditValue) != -1 ||
				ValueConvert.ToInt32(txt_Subject1MakeUpNumberEnd.EditValue) != -1)
			{
				var date1 = Convert.ToInt32(txt_Subject1MakeUpNumberStar.EditValue);
				var date2 = ValueConvert.ToInt32(txt_Subject1MakeUpNumberEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("科一补考次数结束次数不可大于开始次数");
					return;
				}
				sql += string.Format(" and p.Subject1MakeUpNumber between {0} and {1}",
					ValueConvert.ToInt32(txt_Subject1MakeUpNumberStar.EditValue),
					ValueConvert.ToInt32(txt_Subject1MakeUpNumberEnd.EditValue));
			}

			if (ValueConvert.ToInt32(txt_Subject2MakeUpNumberStar.EditValue) != -1 ||
				ValueConvert.ToInt32(txt_Subject2MakeUpNumberEnd.EditValue) != -1)
			{
				var date1 = ValueConvert.ToInt32(txt_Subject2MakeUpNumberStar.EditValue);
				var date2 = ValueConvert.ToInt32(txt_Subject2MakeUpNumberEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("科二补考次数结束次数不可大于开始次数");
					return;
				}
				sql += string.Format(" and p.Subject2MakeUpNumber between {0} and {1}",
					ValueConvert.ToInt32(txt_Subject2MakeUpNumberStar.EditValue),
					ValueConvert.ToInt32(txt_Subject2MakeUpNumberEnd.EditValue));
			}
			if (ValueConvert.ToInt32(txt_Subject3MakeUpNumberStar.EditValue) != -1 ||
				ValueConvert.ToInt32(txt_Subject3MakeUpNumberEnd.EditValue) != -1)
			{
				var date1 = ValueConvert.ToInt32(txt_Subject3MakeUpNumberStar.EditValue);
				var date2 = ValueConvert.ToInt32(txt_Subject3MakeUpNumberEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("科三补考次数结束次数不可大于开始次数");
					return;
				}
				sql += string.Format(" and p.Subject3MakeUpNumber between {0} and {1}",
					Convert.ToInt32(txt_Subject3MakeUpNumberStar.EditValue),
					ValueConvert.ToInt32(txt_Subject3MakeUpNumberEnd.EditValue));
			}
			if (ValueConvert.ToInt32(txt_Subject4MakeUpNumberStar.EditValue) != -1 ||
				ValueConvert.ToInt32(txt_Subject4MakeUpNumberEnd.EditValue) != -1)
			{
				var date1 = ValueConvert.ToInt32(txt_Subject4MakeUpNumberStar.EditValue);
				var date2 = ValueConvert.ToInt32(txt_Subject4MakeUpNumberEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("科四补考次数结束次数不可大于开始次数");
					return;
				}
				sql += string.Format(" and p.Subject4MakeUpNumber between {0} and {1} ",
					ValueConvert.ToInt32(txt_Subject4MakeUpNumberStar.EditValue),
					ValueConvert.ToInt32(txt_Subject4MakeUpNumberEnd.EditValue));
			}
			//培训信息查询
			if (ValueConvert.ToInt32(cl_CourseName.EditValue) != 0)
			{
				sql += string.Format(" and a.CourseID = {0}", ValueConvert.ToInt32(cl_CourseName.EditValue));
			}
			if (ValueConvert.ToInt32(cl_TakePlace.EditValue) != 0)
			{
				sql += string.Format(" and a.TakePlaceID = {0}", ValueConvert.ToInt32(cl_TakePlace.EditValue));
			}
			if (ValueConvert.ToInt32(cl_TrainDate.EditValue) != 0)
			{
				sql += string.Format(" and a.TrainDateID = {0}", ValueConvert.ToInt32(cl_TrainDate.EditValue));
			}
			if (cmb_TrainProgress.SelectedText != "")
			{
				sql += string.Format(" and p.TrainProgress = '{0}' ", cmb_TrainProgress.SelectedText);
			}
			//其他信息
			if (cmb_Sex.SelectedText != "")
			{
				sql += string.Format(" and a.Sex = '{0}'", cmb_Sex.SelectedText);
			}
			if (ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue) > 0) //科三补考次数
			{
				sql += string.Format(" and p.ReceivableTrainFee >= {0}", ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue));
			}
			else if (ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue) > 0 &&
					 ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue) == 0)
			{
				sql += string.Format(" and p.ReceivableTrainFee <= {0}", ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue));
			}
			else if (ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue) > 0 &&
					 ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue) > 0)
			{
				var date1 = ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue);
				var date2 = ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("应收培训费查询结束金额不可大于查询开始金额");
					return;
				}
				sql += string.Format(" and p.ReceivableTrainFee between {0} and {1}",
					ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue),
					ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue));
			}
			if (ValueConvert.ToInt32(cl_AgeRange.EditValue) != 0)
			{
				sql += string.Format(" and a.AgeRangeID = {0}", ValueConvert.ToInt32(cl_AgeRange.EditValue));
			}
			if (cmb_QuitSchoolKind.SelectedText != "")
			{
				sql += string.Format(" and p.QuitSchoolKind = '{0}' ", cmb_QuitSchoolKind.SelectedText);
			}
			if (ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue) > 0) //科三补考次数
			{
				sql += string.Format(" and p.ReceivedTrainFee >= {0}", ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue));
			}
			else if (ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue) > 0 &&
					 ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue) == 0)
			{
				sql += string.Format(" and p.ReceivedTrainFee <= {0}", ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue));
			}
			else if (ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue) >= 0 &&
					 ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue) > 0)
			{
				var date1 = ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue);
				var date2 = ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("已收培训费查询结束金额不可大于查询开始金额");
					return;
				}
				sql += string.Format(" and p.ReceivedTrainFee between {0} and {1}",
					ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue), ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue));
			}
			if (date_QuitSchoolTimeStar.EditValue != null && date_QuitSchoolTimeEnd.EditValue == null)
			{
				sql += string.Format(" and p.QuitSchoolTime >= '{0}'",
					ValueConvert.ToDateTime(date_QuitSchoolTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_QuitSchoolTimeEnd.EditValue != null && date_QuitSchoolTimeStar.EditValue == null)
			{
				sql += string.Format(" and p.QuitSchoolTime <= '{0}'",
					ValueConvert.ToDateTime(date_QuitSchoolTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_QuitSchoolTimeStar.EditValue != null && date_QuitSchoolTimeEnd.EditValue != null)
			{
				var date1 = ValueConvert.ToDateTime(date_QuitSchoolTimeStar.EditValue);
				var date2 = ValueConvert.ToDateTime(date_QuitSchoolTimeEnd.EditValue);
				if (date2 < date1)
				{
					MsgBox.ShowInfo("退学时间结束日期不可大于开始日期");
					return;
				}
				sql += string.Format(" and p.QuitSchoolTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_QuitSchoolTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_QuitSchoolTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (ValueConvert.ToInt32(txt_TemporaryName.EditValue) != 0)
			{
				sql += string.Format(" and a.TemporaryName = {0}", ValueConvert.ToInt32(txt_TemporaryName.EditValue));
			}
			if (cmb_GuanXiHu.SelectedIndex >= 0)
			{
				sql += string.Format(" and a.GuanXiHu = {0}", ValueConvert.ToInt32(cmb_GuanXiHu.SelectedIndex));
			}
			if (ValueConvert.ToInt32(txt_MedicalTabe.EditValue) != 0)
			{
				sql += string.Format(" and a.MedicalTabe = {0}", ValueConvert.ToInt32(txt_MedicalTabe.EditValue));
			}

            if (this.date_Subject1PreExamTime.EditValue != null && this.dateSubject1PreExamTimeEnd.EditValue == null) //科一考过时间
            {
                sql += string.Format(" and date(p.Subject1PreExamTime) >= '{0}'",
                    ValueConvert.ToDateTime(date_Subject1PreExamTime.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (dateSubject1PreExamTimeEnd.EditValue != null && date_Subject1PreExamTime.EditValue == null)
            {
                sql += string.Format(" and date(p.Subject1PreExamTime) <= '{0}'",
                    ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject1PreExamTime.EditValue != null && dateSubject1PreExamTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_Subject1PreExamTime.EditValue);
                var date2 = ValueConvert.ToDateTime(dateSubject1PreExamTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科一考过时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and date(p.Subject1PreExamTime) between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_Subject1PreExamTime.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(dateSubject1PreExamTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            if (cmb_Subject1PreExamPass.Text!="")
            {
                if (cmb_Subject1PreExamPass.Text == "是")
                {
                    sql += " and ifnull(p.Subject1PreExamPass,0)  = 1";
                }
                else
                {
                    sql += " and ifnull(p.Subject1PreExamPass,0)  = 0";
                }
            }

            if (cmb_Subject4PreExamPass.Text != "")
            {
                if (cmb_Subject4PreExamPass.Text == "是")
                {
                    sql += " and ifnull(p.Subject4PreExamPass,0)  = 1";
                }
                else
                {
                    sql += " and ifnull(p.Subject4PreExamPass,0)  = 0";
                }
            }
            if (cboDrivePlanCount.SelectedIndex > 0)
            {
                if (cboDrivePlanCount.Text.Trim() == "是")
                {
                    sql += " and ifnull(a.DrivePlanCount,0) > 0 ";
                }
                else if (cboDrivePlanCount.Text.Trim() == "否")
                {
                    sql += " and ifnull(a.DrivePlanCount,0) = 0 ";
                }
            }
            if (cboWeChat.SelectedIndex > 0)
            {
                if (cboWeChat.Text.Trim() == "是")
                {
                    sql += " and ifnull(a.WechatOpenID,'') != '' ";
                }
                else if (cboWeChat.Text.Trim() == "否")
                {
                    sql += " and ifnull(a.WechatOpenID,'') = '' ";
                }
            }
            if (cboPromiseDate.Text.Trim() != "")
            {
                if (cboPromiseDate.Text.Trim() == "是")
                {
                    sql += " and ifnull(p.PromiseDate,'') != '' ";
                }
                else if (cboPromiseDate.Text.Trim() == "否")
                {
                    sql += " and ifnull(p.PromiseDate,'') = '' ";
                }
            }
            if (this.date_MarkBegin.EditValue != null && this.date_MarkEnd.EditValue == null) //最近标记时间
            {
                sql += string.Format(" and date(p.MarkDate) >= '{0}'",
                    ValueConvert.ToDateTime(date_MarkBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_MarkEnd.EditValue != null && date_MarkBegin.EditValue == null)
            {
                sql += string.Format(" and date(p.MarkDate) <= '{0}'",
                    ValueConvert.ToDateTime(date_MarkEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_MarkBegin.EditValue != null && date_MarkEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_MarkBegin.EditValue);
                var date2 = ValueConvert.ToDateTime(date_MarkEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("结束时间不能大于开始时间！");
                    return;
                }
                sql += string.Format(" and date(p.MarkDate) between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_MarkBegin.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_MarkEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (date_TrainBegin.EditValue != null && date_TrainEnd.EditValue == null)
            {
                sql += string.Format(" and extract(year_month from p.PromiseDate) >= extract(year_month from '{0}')",
                    ValueConvert.ToDateTime(date_TrainBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_TrainEnd.EditValue != null && date_TrainBegin.EditValue == null)
            {
                sql += string.Format(" and extract(year_month from p.PromiseDate) <= extract(year_month from '{0}')",
                    ValueConvert.ToDateTime(date_TrainEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_TrainBegin.EditValue != null && date_TrainEnd.EditValue != null)
            {
                var date1 = Convert.ToDateTime(date_TrainBegin.EditValue);
                var date2 = Convert.ToDateTime(date_TrainEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("训练计划结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and extract(year_month from p.PromiseDate) between extract(year_month from '{0}') and extract(year_month from '{1}')",
                    ValueConvert.ToDateTime(date_TrainBegin.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_TrainEnd.EditValue).ToString("yyyy-MM-dd"));
            }
			ExtSql = sql;
		}


        private void GetStudentSearchFilter(string sql)
        {
            //快捷查询
            if (txt_studentName.Text != "")
            {
                sql += string.Format(" and a.StudentName like '%{0}%'", txt_studentName.Text);
            }
            if (txt_StudentCode.Text != "")
            {
                sql += string.Format(" and a.StudentCode like '%{0}%'", txt_StudentCode.Text);
            }
            if (txt_IdentityNo.Text != "")
            {
                sql += string.Format(" and a.IdentityNo like '%{0}%'", txt_IdentityNo.Text);
            }
            if (txt_Cellphone.Text != "")
            {
                sql += string.Format(" and a.Cellphone like '%{0}%'", txt_Cellphone.Text);
            }
            if (ValueConvert.ToInt32(cl_ApplyPlace.EditValue) != 0)
            {
                sql += string.Format(" and a.ApplyPlaceID = {0}", ValueConvert.ToInt32(cl_ApplyPlace.EditValue));
            }
            if (ValueConvert.ToInt32(cl_School.EditValue) != 0)
            {
                sql += string.Format(" and a.SchoolID = {0}", ValueConvert.ToInt32(cl_School.EditValue));
            }
            if (ValueConvert.ToInt32(cl_Group.EditValue) != 0)
            {
                sql += string.Format(" and a.GroupID = {0}", ValueConvert.ToInt32(cl_Group.EditValue));
            }
            if (cmb_StudentType.Text != "")
            {
                sql += string.Format(" and a.StudentType like '%{0}%'", cmb_StudentType.Text);
            }
            if (cmb_TrainProperty.Text != "")
            {
                sql += string.Format(" and ifnull(a.TrainProperty,'') = '{0}'", cmb_TrainProperty.Text);
            }
            if (ValueConvert.ToInt32(cmb_Examstate.EditValue) != 0)
            {
                sql += string.Format(" and a.Examstate = {0}", ValueConvert.ToInt32(cmb_Examstate.EditValue));
            }
            if (cmb_ExamIsArrange.SelectedIndex > 0)
            {
                sql += string.Format(" and a.ExamIsArrange = {0}", cmb_ExamIsArrange.SelectedIndex == 1 ? 1 : 0);
            }
            if (ValueConvert.ToInt32(cl_Employee.EditValue) != 0)
            {
                sql += string.Format(" and a.CoachID = {0}", ValueConvert.ToInt32(cl_Employee.EditValue));
            }
            if (ValueConvert.ToInt32(cl_ApplyWay.EditValue) != 0)
            {
                sql += string.Format(" and find_in_set(a.ApplyWayID,f_get_applyway_child_list({0}))", cl_ApplyWay.EditValue);
            }
            if (date_applyStartDate.EditValue != null && date_applyEndDate.EditValue == null)
            {
                sql += string.Format(" and a.ApplyDate >= '{0}'",
                    ValueConvert.ToDateTime(date_applyStartDate.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_applyEndDate.EditValue != null && date_applyStartDate.EditValue == null)
            {
                sql += string.Format(" and a.ApplyDate <= '{0}'",
                    ValueConvert.ToDateTime(date_applyEndDate.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_applyStartDate.EditValue != null && date_applyEndDate.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_applyStartDate.EditValue);
                var date2 = ValueConvert.ToDateTime(date_applyEndDate.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("报名时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and date(a.ApplyDate) between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_applyStartDate.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_applyEndDate.EditValue).ToString("yyyy-MM-dd"));
            }
            if (ValueConvert.ToInt32(cl_StudentStateBegin.EditValue) != 0 &&
                ValueConvert.ToInt32(cl_StudentStateEnd.EditValue) == 0)
            {
                sql += string.Format(" and a.State >= {0}", cl_StudentStateBegin.EditValue);
            }
            else if (ValueConvert.ToInt32(cl_StudentStateEnd.EditValue) != 0 &&
                     ValueConvert.ToInt32(cl_StudentStateBegin.EditValue) == 0)
            {
                sql += string.Format(" and a.State <= {0}", cl_StudentStateEnd.EditValue);
            }
            else if (ValueConvert.ToInt32(cl_StudentStateBegin.EditValue) != 0 &&
                     ValueConvert.ToInt32(cl_StudentStateEnd.EditValue) != 0)
            {
                sql += string.Format(" and a.State >={0} and a.State <={1}", ValueConvert.ToInt32(cl_StudentStateBegin.EditValue),
                    ValueConvert.ToInt32(cl_StudentStateEnd.EditValue));
            }
            //常用信息查询
            if (cl_SchoolState1.EditValue != null)
            {
                sql += string.Format(" and a.Period1IsFull = '{0}' ", cl_SchoolState1.EditValue);
            }
            if (cl_SchoolState2.EditValue != null)
            {
                sql += string.Format(" and a.Period2IsFull = '{0}'", cl_SchoolState2.EditValue);
            }
            if (cl_SchoolState3.EditValue != null)
            {
                sql += string.Format(" and a.Period3IsFull = '{0}'", cl_SchoolState3.EditValue);
            }
            if (ValueConvert.ToInt32(cl_TrainPlace.EditValue) != 0)
            {
                sql += string.Format(" and a.TrainPlaceID = {0}", ValueConvert.ToInt32(cl_TrainPlace.EditValue));
            }
            if (cboIsLocal.SelectedIndex > 0)
            {
                sql += string.Format(" and a.Islocal = '{0}' ", cboIsLocal.SelectedIndex == 1 ? 1 : 0);
            }
            if (ValueConvert.ToInt32(cl_From.EditValue) != 0)
            {
                sql += string.Format(" and find_in_set(a.FromID,f_get_from_child_list({0}))", cl_From.EditValue);
            }
            if (cmb_Coach.SelectedIndex > 0) //是否分配教练，未解决
            {
                sql += string.Format(" and a.IsCoach = {0}", cmb_Coach.SelectedIndex == 1 ? 1 : 2);
            }
            if (cmb_IsWeipei.SelectedIndex >= 0)
            {
                sql += string.Format(" and a.IsWeipei = {0}", ValueConvert.ToInt32(cmb_IsWeipei.SelectedIndex));
            }
            if (cmb_IsOweFee.SelectedIndex >= 0)
            {
                sql += string.Format(" and a.IsOweFee = {0} ", ValueConvert.ToInt32(cmb_IsOweFee.SelectedIndex));
            }
            if (cmb_InfoIsFull.SelectedIndex >= 0)
            {
                sql += string.Format(" and a.InfoIsFull = {0} ", ValueConvert.ToInt32(cmb_InfoIsFull.SelectedIndex));
            }
            if (txt_TicketNumber.Text != "")
            {
                sql += string.Format(" and a.TicketNumber like '%{0}%'", txt_TicketNumber.Text);
            }
            if (cmb_IsLock.SelectedIndex >= 0)
            {
                sql += string.Format(" and a.IsLock  = {0}", ValueConvert.ToInt32(cmb_IsLock.SelectedIndex));
            }
            if (cmb_ApplyLicense.Text != "")
            {
                sql += string.Format(" and a.ApplyLicense = '{0}' ", cmb_ApplyLicense.Text);
            }
            if (txt_ClassArrangeNumber.Text != "")
            {
                sql += string.Format(" and a.ClassArrangeNumber like '%{0}%'", txt_ClassArrangeNumber.Text);
            }
            if (cmb_IsFreeze.SelectedIndex >= 0)
            {
                sql += string.Format(" and a.IsFreeze  = {0}", ValueConvert.ToInt32(cmb_IsFreeze.SelectedIndex));
            }
            if (cmb_License.SelectedText != "")
            {
                sql += string.Format(" and a.License = '{0}'", cmb_License.SelectedText);
            }
            if (cmb_IsExpire.SelectedIndex >= 0)
            {
                if (cmb_IsExpire.Text == "是")
                {
                    sql += " and a.IsExpire  = 1";
                }
                else if (cmb_IsExpire.Text == "否")
                {
                    sql += " and a.IsExpire  = 0";
                }
            }
            if (ValueConvert.ToInt32(cmb_LifeAreaName.EditValue) != 0)
            {
                sql += string.Format(" and a.LifeAreaID = {0}", ValueConvert.ToInt32(cmb_LifeAreaName.EditValue));
            }
            if (date_ClassArrangeTimeStar.EditValue != null && date_ClassArrangeTimeEnd.EditValue == null)
            {
                sql += string.Format(" and date(a.ClassArrangeTime) >= '{0}'",
                    ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_ClassArrangeTimeEnd.EditValue != null && date_ClassArrangeTimeStar.EditValue == null)
            {
                sql += string.Format(" and date(a.ClassArrangeTime) <= '{0}'",
                    ValueConvert.ToDateTime(date_ClassArrangeTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_ClassArrangeTimeStar.EditValue != null && date_ClassArrangeTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue);
                var date2 = ValueConvert.ToDateTime(date_ClassArrangeTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("报班时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and date(a.ClassArrangeTime) between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_ClassArrangeTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            //考试信息查询
            if (date_LatelyExamTimeStar.EditValue != null && date_LatelyExamTimeEnd.EditValue == null)
            {
                sql += string.Format(" and a.LatelyExamTime >= '{0}'",
                    ValueConvert.ToDateTime(date_LatelyExamTimeStar.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_LatelyExamTimeEnd.EditValue != null && date_LatelyExamTimeStar.EditValue == null)
            {
                sql += string.Format(" and a.LatelyExamTime <= '{0}'",
                    ValueConvert.ToDateTime(date_LatelyExamTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_LatelyExamTimeStar.EditValue != null && date_LatelyExamTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_LatelyExamTimeStar.EditValue);
                var date2 = ValueConvert.ToDateTime(date_LatelyExamTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("报班时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and a.LatelyExamTime between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_LatelyExamTimeStar.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_LatelyExamTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (ValueConvert.ToInt32(txt_ExamTime.EditValue) != 0)
            {
                sql += string.Format(" and a.ExamTime = {0}", txt_ExamTime.EditValue);
            }
            if (cmb_SubjectStayState.SelectedText != "")
            {
                sql += string.Format(" and a.SubjectStayState = '{0}'", cmb_SubjectStayState.SelectedText);
            }
            if (date_Subject1ExamPassTimeStar.EditValue != null && date_Subject1ExamPassTimeEnd.EditValue == null) //科一考过时间
            {
                sql += string.Format(" and a.Subject1ExamPassTime >= '{0}'",
                    ValueConvert.ToDateTime(date_Subject1ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject1ExamPassTimeEnd.EditValue != null && date_Subject1ExamPassTimeStar.EditValue == null)
            {
                sql += string.Format(" and a.Subject1ExamPassTime <= '{0}'",
                    ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject1ExamPassTimeStar.EditValue != null && date_Subject1ExamPassTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_Subject1ExamPassTimeStar.EditValue);
                var date2 = ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科一考过时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and a.Subject1ExamPassTime between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_Subject1ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (date_Subject2ExamPassTimeStar.EditValue != null && date_Subject2ExamPassTimeEnd.EditValue == null) //科二考过时间
            {
                sql += string.Format(" and a.Subject2ExamPassTime >= '{0}'",
                    ValueConvert.ToDateTime(date_Subject2ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject2ExamPassTimeEnd.EditValue != null && date_Subject2ExamPassTimeStar.EditValue == null)
            {
                sql += string.Format(" and a.Subject2ExamPassTime <= '{0}'",
                    ValueConvert.ToDateTime(date_Subject2ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject2ExamPassTimeStar.EditValue != null && date_Subject2ExamPassTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_Subject2ExamPassTimeStar.EditValue);
                var date2 = ValueConvert.ToDateTime(date_Subject2ExamPassTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科二考过时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and a.Subject2ExamPassTime between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_Subject2ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_Subject2ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (date_Subject3ExamPassTimeStar.EditValue != null && date_Subject3ExamPassTimeEnd.EditValue == null) //科三考过时间
            {
                sql += string.Format(" and a.Subject3ExamPassTime >= '{0}'",
                    ValueConvert.ToDateTime(date_Subject3ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject3ExamPassTimeEnd.EditValue != null && date_Subject3ExamPassTimeStar.EditValue == null)
            {
                sql += string.Format(" and a.Subject3ExamPassTime <= '{0}'",
                    ValueConvert.ToDateTime(date_Subject3ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject3ExamPassTimeStar.EditValue != null && date_Subject3ExamPassTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_Subject3ExamPassTimeStar.EditValue);
                var date2 = ValueConvert.ToDateTime(date_Subject3ExamPassTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科三考过时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and a.Subject3ExamPassTime between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_Subject3ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_Subject3ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (date_Subject4ExamPassTimeStar.EditValue != null && date_Subject4ExamPassTimeEnd.EditValue == null) //科四考过时间
            {
                sql += string.Format(" and date(a.Subject4ExamPassTime) >= '{0}'",
                    ValueConvert.ToDateTime(date_Subject4ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject4ExamPassTimeEnd.EditValue != null && date_Subject4ExamPassTimeStar.EditValue == null)
            {
                sql += string.Format(" and date(a.Subject4ExamPassTime) <= '{0}'",
                    ValueConvert.ToDateTime(date_Subject4ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject4ExamPassTimeStar.EditValue != null && date_Subject4ExamPassTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_Subject4ExamPassTimeStar.EditValue);
                var date2 = ValueConvert.ToDateTime(date_Subject4ExamPassTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科四考过时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and date(a.Subject4ExamPassTime) between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_Subject4ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_Subject4ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (ValueConvert.ToInt32(txt_Subject1MakeUpNumberStar.EditValue) != -1 ||
                ValueConvert.ToInt32(txt_Subject1MakeUpNumberEnd.EditValue) != -1)
            {
                var date1 = Convert.ToInt32(txt_Subject1MakeUpNumberStar.EditValue);
                var date2 = ValueConvert.ToInt32(txt_Subject1MakeUpNumberEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科一补考次数结束次数不可大于开始次数");
                    return;
                }
                sql += string.Format(" and a.Subject1MakeUpNumber between {0} and {1}",
                    ValueConvert.ToInt32(txt_Subject1MakeUpNumberStar.EditValue),
                    ValueConvert.ToInt32(txt_Subject1MakeUpNumberEnd.EditValue));
            }

            if (ValueConvert.ToInt32(txt_Subject2MakeUpNumberStar.EditValue) != -1 ||
                ValueConvert.ToInt32(txt_Subject2MakeUpNumberEnd.EditValue) != -1)
            {
                var date1 = ValueConvert.ToInt32(txt_Subject2MakeUpNumberStar.EditValue);
                var date2 = ValueConvert.ToInt32(txt_Subject2MakeUpNumberEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科二补考次数结束次数不可大于开始次数");
                    return;
                }
                sql += string.Format(" and a.Subject2MakeUpNumber between {0} and {1}",
                    ValueConvert.ToInt32(txt_Subject2MakeUpNumberStar.EditValue),
                    ValueConvert.ToInt32(txt_Subject2MakeUpNumberEnd.EditValue));
            }
            if (ValueConvert.ToInt32(txt_Subject3MakeUpNumberStar.EditValue) != -1 ||
                ValueConvert.ToInt32(txt_Subject3MakeUpNumberEnd.EditValue) != -1)
            {
                var date1 = ValueConvert.ToInt32(txt_Subject3MakeUpNumberStar.EditValue);
                var date2 = ValueConvert.ToInt32(txt_Subject3MakeUpNumberEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科三补考次数结束次数不可大于开始次数");
                    return;
                }
                sql += string.Format(" and a.Subject3MakeUpNumber between {0} and {1}",
                    Convert.ToInt32(txt_Subject3MakeUpNumberStar.EditValue),
                    ValueConvert.ToInt32(txt_Subject3MakeUpNumberEnd.EditValue));
            }
            if (ValueConvert.ToInt32(txt_Subject4MakeUpNumberStar.EditValue) != -1 ||
                ValueConvert.ToInt32(txt_Subject4MakeUpNumberEnd.EditValue) != -1)
            {
                var date1 = ValueConvert.ToInt32(txt_Subject4MakeUpNumberStar.EditValue);
                var date2 = ValueConvert.ToInt32(txt_Subject4MakeUpNumberEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科四补考次数结束次数不可大于开始次数");
                    return;
                }
                sql += string.Format(" and a.Subject4MakeUpNumber between {0} and {1} ",
                    ValueConvert.ToInt32(txt_Subject4MakeUpNumberStar.EditValue),
                    ValueConvert.ToInt32(txt_Subject4MakeUpNumberEnd.EditValue));
            }
            //培训信息查询
            if (ValueConvert.ToInt32(cl_CourseName.EditValue) != 0)
            {
                sql += string.Format(" and a.CourseID = {0}", ValueConvert.ToInt32(cl_CourseName.EditValue));
            }
            if (ValueConvert.ToInt32(cl_TakePlace.EditValue) != 0)
            {
                sql += string.Format(" and a.TakePlaceID = {0}", ValueConvert.ToInt32(cl_TakePlace.EditValue));
            }
            if (ValueConvert.ToInt32(cl_TrainDate.EditValue) != 0)
            {
                sql += string.Format(" and a.TrainDateID = {0}", ValueConvert.ToInt32(cl_TrainDate.EditValue));
            }
            if (cmb_TrainProgress.SelectedText != "")
            {
                sql += string.Format(" and a.TrainProgress = '{0}' ", cmb_TrainProgress.SelectedText);
            }
            //其他信息
            if (cmb_Sex.SelectedText != "")
            {
                sql += string.Format(" and a.Sex = '{0}'", cmb_Sex.SelectedText);
            }
            if (ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue) > 0) //科三补考次数
            {
                sql += string.Format(" and a.ReceivableTrainFee >= {0}", ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue));
            }
            else if (ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue) > 0 &&
                     ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue) == 0)
            {
                sql += string.Format(" and a.ReceivableTrainFee <= {0}", ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue));
            }
            else if (ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue) > 0 &&
                     ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue) > 0)
            {
                var date1 = ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue);
                var date2 = ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("应收培训费查询结束金额不可大于查询开始金额");
                    return;
                }
                sql += string.Format(" and a.ReceivableTrainFee between {0} and {1}",
                    ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue),
                    ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue));
            }
            if (ValueConvert.ToInt32(cl_AgeRange.EditValue) != 0)
            {
                sql += string.Format(" and a.AgeRangeID = {0}", ValueConvert.ToInt32(cl_AgeRange.EditValue));
            }
            if (cmb_QuitSchoolKind.SelectedText != "")
            {
                sql += string.Format(" and a.QuitSchoolKind = '{0}' ", cmb_QuitSchoolKind.SelectedText);
            }
            if (ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue) > 0) //科三补考次数
            {
                sql += string.Format(" and a.ReceivedTrainFee >= {0}", ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue));
            }
            else if (ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue) > 0 &&
                     ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue) == 0)
            {
                sql += string.Format(" and a.ReceivedTrainFee <= {0}", ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue));
            }
            else if (ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue) >= 0 &&
                     ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue) > 0)
            {
                var date1 = ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue);
                var date2 = ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("已收培训费查询结束金额不可大于查询开始金额");
                    return;
                }
                sql += string.Format(" and a.ReceivedTrainFee between {0} and {1}",
                    ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue), ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue));
            }
            if (date_QuitSchoolTimeStar.EditValue != null && date_QuitSchoolTimeEnd.EditValue == null)
            {
                sql += string.Format(" and a.QuitSchoolTime >= '{0}'",
                    ValueConvert.ToDateTime(date_QuitSchoolTimeStar.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_QuitSchoolTimeEnd.EditValue != null && date_QuitSchoolTimeStar.EditValue == null)
            {
                sql += string.Format(" and a.QuitSchoolTime <= '{0}'",
                    ValueConvert.ToDateTime(date_QuitSchoolTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_QuitSchoolTimeStar.EditValue != null && date_QuitSchoolTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_QuitSchoolTimeStar.EditValue);
                var date2 = ValueConvert.ToDateTime(date_QuitSchoolTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("退学时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and a.QuitSchoolTime between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_QuitSchoolTimeStar.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_QuitSchoolTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (ValueConvert.ToInt32(txt_TemporaryName.EditValue) != 0)
            {
                sql += string.Format(" and a.TemporaryName = {0}", ValueConvert.ToInt32(txt_TemporaryName.EditValue));
            }
            if (cmb_GuanXiHu.SelectedIndex >= 0)
            {
                sql += string.Format(" and a.GuanXiHu = {0}", ValueConvert.ToInt32(cmb_GuanXiHu.SelectedIndex));
            }
            if (ValueConvert.ToInt32(txt_MedicalTabe.EditValue) != 0)
            {
                sql += string.Format(" and a.MedicalTabe = {0}", ValueConvert.ToInt32(txt_MedicalTabe.EditValue));
            }

            if (this.date_Subject1PreExamTime.EditValue != null && this.dateSubject1PreExamTimeEnd.EditValue == null) //科一考过时间
            {
                sql += string.Format(" and date(a.Subject1PreExamTime) >= '{0}'",
                    ValueConvert.ToDateTime(date_Subject1PreExamTime.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (dateSubject1PreExamTimeEnd.EditValue != null && date_Subject1PreExamTime.EditValue == null)
            {
                sql += string.Format(" and date(a.Subject1PreExamTime) <= '{0}'",
                    ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_Subject1PreExamTime.EditValue != null && dateSubject1PreExamTimeEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_Subject1PreExamTime.EditValue);
                var date2 = ValueConvert.ToDateTime(dateSubject1PreExamTimeEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("科一考过时间结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and date(a.Subject1PreExamTime) between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_Subject1PreExamTime.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(dateSubject1PreExamTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            if (cmb_Subject1PreExamPass.Text != "")
            {
                if (cmb_Subject1PreExamPass.Text == "是")
                {
                    sql += " and ifnull(p.Subject1PreExamPass,0)  = 1";
                }
                else
                {
                    sql += " and ifnull(p.Subject1PreExamPass,0)  = 0";
                }
            }

            if (cmb_Subject4PreExamPass.Text != "")
            {
                if (cmb_Subject4PreExamPass.Text == "是")
                {
                    sql += " and ifnull(p.Subject4PreExamPass,0)  = 1";
                }
                else
                {
                    sql += " and ifnull(p.Subject4PreExamPass,0)  = 0";
                }
            }
            if (cboDrivePlanCount.SelectedIndex > 0)
            {
                if (cboDrivePlanCount.Text.Trim() == "是")
                {
                    sql += " and ifnull(a.DrivePlanCount,0) > 0 ";
                }
                else if (cboDrivePlanCount.Text.Trim() == "否")
                {
                    sql += " and ifnull(a.DrivePlanCount,0) = 0 ";
                }
            }
            if (cboWeChat.SelectedIndex > 0)
            {
                if (cboWeChat.Text.Trim() == "是")
                {
                    sql += " and ifnull(a.WechatOpenID,'') != '' ";
                }
                else if (cboWeChat.Text.Trim() == "否")
                {
                    sql += " and ifnull(a.WechatOpenID,'') = '' ";
                }
            }
            if (cboPromiseDate.Text.Trim() != "")
            {
                if (cboPromiseDate.Text.Trim() == "是")
                {
                    sql += " and ifnull(p.PromiseDate,'') != '' ";
                }
                else if (cboPromiseDate.Text.Trim() == "否")
                {
                    sql += " and ifnull(p.PromiseDate,'') = '' ";
                }
            }
            if (this.date_MarkBegin.EditValue != null && this.date_MarkEnd.EditValue == null) //最近标记时间
            {
                sql += string.Format(" and date(a.MarkDate) >= '{0}'",
                    ValueConvert.ToDateTime(date_MarkBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_MarkEnd.EditValue != null && date_MarkBegin.EditValue == null)
            {
                sql += string.Format(" and date(a.MarkDate) <= '{0}'",
                    ValueConvert.ToDateTime(date_MarkEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_MarkBegin.EditValue != null && date_MarkEnd.EditValue != null)
            {
                var date1 = ValueConvert.ToDateTime(date_MarkBegin.EditValue);
                var date2 = ValueConvert.ToDateTime(date_MarkEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("结束时间不能大于开始时间！");
                    return;
                }
                sql += string.Format(" and date(a.MarkDate) between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_MarkBegin.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_MarkEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (date_TrainBegin.EditValue != null && date_TrainEnd.EditValue == null)
            {
                sql += string.Format(" and extract(year_month from a.PromiseDate) >= extract(year_month from '{0}')",
                    ValueConvert.ToDateTime(date_TrainBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_TrainEnd.EditValue != null && date_TrainBegin.EditValue == null)
            {
                sql += string.Format(" and extract(year_month from a.PromiseDate) <= extract(year_month from '{0}')",
                    ValueConvert.ToDateTime(date_TrainEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_TrainBegin.EditValue != null && date_TrainEnd.EditValue != null)
            {
                var date1 = Convert.ToDateTime(date_TrainBegin.EditValue);
                var date2 = Convert.ToDateTime(date_TrainEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("训练计划结束日期不可大于开始日期");
                    return;
                }
                sql += string.Format(" and extract(year_month from a.PromiseDate) between extract(year_month from '{0}') and extract(year_month from '{1}')",
                    ValueConvert.ToDateTime(date_TrainBegin.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_TrainEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            ExtSql = sql;
        }

		#endregion
	}
}