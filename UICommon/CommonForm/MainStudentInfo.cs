using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DS.Data;
using DS.Model;
using DS.MSClient.UIModule;
using QuickFrame.Common.Converter;

namespace DS.MSClient.UICommon
{
	/// <summary>
	///     学生详情
	/// </summary>
	[ToolboxItem(false)]
    public partial class MainStudentInfo : FormBase
	{
		#region 初始化

        public MainStudentInfo()
		{
			InitializeComponent();
			InitEvent();
		}

		private void InitEvent()
		{
			Load += FormStudentInfo_Load;
            this.gridColumn75.ColumnEdit.Click += ColumnEdit_Click;
			tabcMain.SelectedPageChanged += tabcMain_SelectedPageChanged;
		}



		private void Init()
		{
			SetTextEditValueEmpty(layoutControl1);
		}

		#endregion

		#region 属性

		public Student Student = null;
		public StudentSummary Sum = new StudentSummary();
		public StudentExt Ext = new StudentExt();

		public List<Student> List = null;
		public int SchoolID = 0;
		public int Index = 0; //索引
		private bool _isLoadAccept;
		private bool _isLoadCharge;
		private bool _isLoadAudit;
		private bool _isLoadScore;
        private bool _isLoadTrainHour;
		private bool _isLoadTrain;
        private bool _isLoadPreExam;
        private bool _isLoadFeeAudit;
        private bool _isLoadStudentMark;
        private bool _isLoadDrivePlan;
        private bool _isLoadAccount;

		#endregion

		#region 事件
        //评价按钮点击事件
        void ColumnEdit_Click(object sender, EventArgs e)
        {
            var model = this.gv_DrivePlan.GetFocusedRow() as DrivePlan;
            if (model.SEvaluation)
            {
                MsgBox.ShowWarn("该项已存在评价！");
                return;
            }
            FormEvaluate form = new FormEvaluate();
            form.DrivePlanID = model.DrivePlanID;
            form.ShowDialog();
        }

		void tabcMain_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
		{
			if (e.Page == tabAccept && !_isLoadAccept)
			{
				var list = new StudentAcceptDao().GetList_ID(Student.StudentID);
				gc_Accept.DataSource = list;
				gc_Accept.RefreshDataSource();
				_isLoadAccept = true;
			}
			else if (e.Page == tabAudit && !_isLoadAudit)
			{
				var list = new AuditItemDao().GetListByStuID(Student.StudentID);
				gc_Audit.DataSource = list;
				gc_Audit.RefreshDataSource();
				_isLoadAudit = true;
			}
			else if (e.Page == tabCharge && !_isLoadCharge)
			{
				var list = new StudentChargeDao().GetByStudentList(Student.StudentID);
				gc_Charge.DataSource = list;
				gc_Charge.RefreshDataSource();

				var itemList = new StudentChargeItemDao().GetListByStudentID(Student.StudentID);
				gc_Charge_item.DataSource = itemList;
				gc_Charge_item.RefreshDataSource();
				_isLoadCharge = true;
			}
			else if (e.Page == tabScore && !_isLoadScore)
			{
				var list = new StudentScoreDao().GetListByStuID(Student.StudentID);
				gc_Score.DataSource = list;
				gc_Score.RefreshDataSource();
				_isLoadScore = true;
			}
            else if (e.Page == tabTrainHour && !_isLoadTrainHour)
            {
                var _list = new StudentSummaryDao().GetModel(Student.StudentID);
                if (_list == null) return;
                textEdit1.Text = string.IsNullOrEmpty(ValueConvert.ToString(_list.Subject1ExamPassTime)) ? "" : ValueConvert.ToDateTime(_list.Subject1ExamPassTime).ToString("yyyy-MM-dd");
                textEdit2.Text = string.IsNullOrEmpty(ValueConvert.ToString(_list.Subject2ExamPassTime)) ? "" : ValueConvert.ToDateTime(_list.Subject2ExamPassTime).ToString("yyyy-MM-dd");
                textEdit3.Text = string.IsNullOrEmpty(ValueConvert.ToString(_list.Subject3ExamPassTime)) ? "" : ValueConvert.ToDateTime(_list.Subject3ExamPassTime).ToString("yyyy-MM-dd");
                textEdit4.Text = string.IsNullOrEmpty(ValueConvert.ToString(_list.Subject4ExamPassTime)) ? "" : ValueConvert.ToDateTime(_list.Subject4ExamPassTime).ToString("yyyy-MM-dd");

                var list = new StudentProgressSumDao().GetListByStudentID(Student.StudentID);
                gc_TrainHour.DataSource = list;
                gc_TrainHour.RefreshDataSource();
                _isLoadTrainHour = true;
            }
			else if (e.Page == tabTrain && !_isLoadTrain)
			{
				var list = new StudentDistDao().GetList(Student.StudentID);
				gcStudentDist.DataSource = list;
				gcStudentDist.RefreshDataSource();
				_isLoadTrain = true;

                var _list = new StudentTrainDao().GetListByStudentID(Student.StudentID);
                gc_Train.DataSource = _list;
                gc_Train.RefreshDataSource();
			}
            else if (e.Page == TabPreExam && !_isLoadPreExam)
            {
                var list = new StudentPreExamDao().GetListByStudentID(Student.StudentID);
                gc_PreExam.DataSource = list;
                gc_PreExam.RefreshDataSource();
                _isLoadPreExam = true;
            }
            else if (e.Page == TabFeeAudit && !_isLoadFeeAudit)
            {
                var list = new StudentFeeauditProjectDao().GetListByStudentID(Student.StudentID);
                gc_FeeAudit.DataSource = list;
                gc_FeeAudit.RefreshDataSource();
                _isLoadFeeAudit = true;
            }
            else if (e.Page == TabStudentMark && !_isLoadStudentMark)
            {
                var list = new StudentMarkDao().GetList(Student.StudentID);
                gc_StudentMark.DataSource = list;
                gc_StudentMark.RefreshDataSource();
                _isLoadStudentMark = true;
            }
            else if (e.Page == TabDrivePlan && !_isLoadDrivePlan)
            {
                var list = new DrivePlanDao().GetListStudentId(Student.StudentID);
                gc_DrivePlan.DataSource = list;
                gc_DrivePlan.RefreshDataSource();
                _isLoadDrivePlan = true;
            }
            else if (e.Page == TabAccount && !_isLoadAccount)
            {
                Account model = new AccountDao().GetModel_StudentID(Student.StudentID);
                if (model != null)
                {
                    text_AccountCode.Text = model.AccountCode;
                    text_Amount.Text = model.Amount.ToString();
                    text_CashAmount.Text = model.CashAmount.ToString();
                    text_FreezeCashAmount.Text = model.FreezeCashAmount.ToString();
                    text_FreezeUncashAmount.Text = model.FreezeUncashAmount.ToString();
                    text_UncashAmount.Text = model.UncashAmount.ToString();
                    text_OperateID.Text = model.OperateID.ToString();
                    text_OperateTime.Text = model.OperateTime.ToString();
                    text_Note.Text = model.Note;
                    text_Status.Text = model.Status == 1 ? "可提现" : "不可提现";

                    var account_seq = new AccountSeqDao().GetListByStudentID(Student.StudentID);
                    gc_AccountSeq.DataSource = account_seq;
                    gc_AccountSeq.RefreshDataSource();

                    var account_freeze_seq = new AccountFreezeSeqDao().GetListByStudentID(Student.StudentID);
                    gc_AccountFreezeSeq.DataSource = account_freeze_seq;
                    gc_AccountFreezeSeq.RefreshDataSource();

                    _isLoadAccount = true;
                }
            }
		}

		private void FormStudentInfo_Load(object sender, EventArgs e)
		{
			tabcMain.SelectedTabPageIndex = 0;
            Student = new StudentDAO().GetModel(Student.StudentID);
			Sum = new StudentSummaryDao().GetModel(Student.StudentID);
			Ext = new StudentExtDao().GetModel(Student.StudentID);
			BindLoadStudent();
			if (Ext != null)
				BindLoadExt();
			if (Sum != null)
			{
				BindLoadExam();
				BindLoadSummary();
				BindLoadOther();
			    BindLoadInterval();
			}
			Init();
		}

		#endregion

		#region 方法

		/// <summary>
		///     学生信息
		/// </summary>
		private void BindLoadStudent()
		{
			txt_Address.Text = Student.Address;
			txt_AgeRangeID.Text = Student.AgeRange;
			txt_ApplyDate.Text = ValueConvert.ToString(Student.ApplyDate);
			txt_ApplyLicense.Text = Student.ApplyLicense;
			txt_ApplyPlaceID.Text = Student.ApplyPlaceName;
			txt_ApplyType.Text = Student.ApplyType;
			txt_ApplyWayID.Text = Student.ApplyWayName;
			txt_Birthday.Text = ValueConvert.ToString(Student.Birthday);
			txt_Cellphone.Text = Student.Cellphone;
			txt_CourseID.Text = Student.CourseName;
			txt_FromID.Text = Student.FromName;
			txt_IdentityAddress.Text = Student.IdentityAddress;
			txt_IdentityNo.Text = Student.IdentityNo;
			txt_IdentityType.Text = Student.IdentityType;
			txt_IsExpire.Text = Judge(Student.IsExpire);
			txt_IsFreeze.Text = Judge(Student.IsFreeze);
			txt_Islocal.Text = Judge(Student.Islocal);
			txt_IsLock.Text = Judge(Student.IsLock);
			txt_License.Text = Student.License;
			txt_LifeAreaID.Text = ValueConvert.ToString(Student.LifeAreaID);
			txt_MailAddress.Text = Student.MailAddress;
			txt_MedicalDate.Text = ValueConvert.ToString(Student.MedicalDate);
			txt_MedicalTabe.Text = Student.MedicalTabe;
			txt_Note.Text = Student.Note;
			txt_Postcode.Text = Student.Postcode;
			txt_School.Text = Student.SchoolName;
			txt_Sex.Text = Student.Sex;
			txt_StudentCode.Text = Student.StudentCode;
			txt_StudentName.Text = Student.StudentName;
			txt_TakePlaceID.Text = Student.TakePlaceName;
			txt_TakePlaceName.Text = Student.TakePlaceName;
			txt_TemporaryCode.Text = Student.TemporaryCode;
			txt_TemporaryDate.Text = ValueConvert.ToString(Student.TemporaryDate);
			txt_TemporaryName.Text = Student.TemporaryName;
			txt_TrainDateID.Text = Student.TrainDateName;
			txt_StudentType.Text = Student.StudentType;
			txt_TrainPlaceID.Text = Student.TrainPlaceName;
			txt_TrainProperty.Text = Student.TrainProperty;
			txtGroup.Text = Student.GroupName;
			txtCoach.Text = Student.CoachName;
            txt_TemporaryAddress.Text = Student.TemporaryAddress;
		    textStudentNo.Text = Student.StudentNo;
			var url = Student.PhotoUrl ?? "";
			if (!url.Contains("photo"))
		    {
				url = url.Insert(0, "photo");
            }
			var imgurl = Path.Combine(Application.StartupPath, "Temp", "StudentInfo", url);
			var path1 = Path.GetDirectoryName(imgurl);
		    if (File.Exists(imgurl))
            {
                System.IO.File.Delete(imgurl);
		    }
			var web = new WebClient();
			if (path1 != null && !Directory.Exists(path1))
			{
				Directory.CreateDirectory(path1);
			}
			DownImage(Program.FilesWebServiceUrl + "/" + url.Replace(@"\", "/"), imgurl, web);
           
			try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(imgurl);
                System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
                img.Dispose();              
                pictureEdit1.Image = bmp;				               
			}
			catch
			{
				// ignored
			}
            
		}

		public void DownImage(string url, string path, WebClient web)
		{
			try
			{
				web.DownloadFile(url, path);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     其他信息
		/// </summary>
		private void BindLoadOther()
		{
			txt_ReceivableTrainFee.Text = ValueConvert.ToString(Sum.ReceivableTrainFee);
			txt_ReceivedTrainFee.Text = ValueConvert.ToString(Sum.ReceivedTrainFee);
			txt_OweFeeMoney.Text = ValueConvert.ToString(Sum.ReceivableTrainFee - Sum.ReceivedTrainFee);
			txt_ReceivableMoney.Text = ValueConvert.ToString(Sum.ReceivableMoney);
            txt_allReceivedTrainFee.Text = ValueConvert.ToString(Sum.ReceivableMoney - Sum.OweFeeMoney);
			txt_allOweFeeMoney.Text = ValueConvert.ToString(Sum.OweFeeMoney);
			txt_IsOweFee.Text = Judge(Sum.IsOweFee);
			txt_StateName.Text = Student.statustext;
		}

		private void BindLoadSummary()
		{
			txt_IsWeipei.Text = Judge(Student.IsWeipei);
			txt_SyncDM.Text = Judge(Sum.SyncDM);
            txt_SyncTM.Text = Judge(Sum.SyncTM);
            switch (Sum.TrainProgress)
            {
                case "Period1": txt_TrainProgress.Text = "阶段一"; break;
                case "Period2": txt_TrainProgress.Text = "阶段二"; break;
                case "Period3": txt_TrainProgress.Text = "阶段三"; break;
                default: txt_TrainProgress.Text = "其它"; break;
            }
            date_FirstDist.EditValue = ValueConvert.ToNullableDateTime(Sum.FirstDistDate);
            date_Apply.EditValue = ValueConvert.ToNullableDateTime(Student.ApplyDate);
			txt_CoachName.Text = Student.CoachName;
			txt_LastTrainTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.LastTrainTime))?"": ValueConvert.ToDateTime(Sum.LastTrainTime).ToString("yyyy-MM-dd");
			txt_LicenseCode.Text = Student.LicenseCode;
			txt_TotalActionHour.Text = ValueConvert.ToString(Sum.TotalActionHour);
			txt_Period1IsFull.Text = Sum.txt_Period1IsFull;
			txt_Period2IsFull.Text = Sum.txt_Period2IsFull;
			txt_Period3IsFull.Text = Sum.txt_Period3IsFull;
		}

		/// <summary>
		///     考试信息
		/// </summary>
		private void BindLoadExam()
		{
            txt_Examstate.Text = ValueConvert.ToString(Student.examstatetext);
            txt_ExamTime.Text = ValueConvert.ToString(Sum.ExamTime);
            txt_ClassArrangeTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.ClassArrangeTime)) ? "" : ValueConvert.ToDateTime(Sum.ClassArrangeTime).ToString("yyyy-MM-dd");
            txt_ClassArrangeNumber.Text = ValueConvert.ToString(Sum.ClassArrangeNumber);
			txt_InfoIsFull.Text = ValueConvert.ToString(Sum.InfoIsFull)=="yes"?"是": "否";
            txt_LatelyExamTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.LatelyExamTime)) ? "" : ValueConvert.ToDateTime(Sum.LatelyExamTime).ToString("yyyy-MM-dd");
			txt_State.Text = ValueConvert.ToString(Student.statustext);
            txt_Subject1ExamPassTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject1ExamPassTime)) ? "":ValueConvert.ToDateTime(Sum.Subject1ExamPassTime).ToString("yyyy-MM-dd") ;
            txt_Subject1ExamReserveTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject1ExamReserveTime)) ? "":ValueConvert.ToDateTime(Sum.Subject1ExamReserveTime).ToString("yyyy-MM-dd");
			txt_Subject1MakeUpNumber.Text = ValueConvert.ToString(Sum.Subject1MakeUpNumber);
			txt_Subject1PreExamScore.Text = ValueConvert.ToString(Sum.Subject1PreExamScore);
            txt_Subject1PreExamTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject1PreExamTime)) ?"": ValueConvert.ToDateTime(Sum.Subject1PreExamTime).ToString("yyyy-MM-dd");
			txt_Subject2MakeUpNumber.Text = ValueConvert.ToString(Sum.Subject2MakeUpNumber);
            txt_Subject2ExamPassTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject2ExamPassTime)) ? "":ValueConvert.ToDateTime(Sum.Subject2ExamPassTime).ToString("yyyy-MM-dd");
            txt_Subject2ExamReserveTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject2ExamReserveTime)) ?"": ValueConvert.ToDateTime(Sum.Subject2ExamReserveTime).ToString("yyyy-MM-dd");
            txt_Subject3ExamPassTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject3ExamPassTime)) ? "": ValueConvert.ToDateTime(Sum.Subject3ExamPassTime).ToString("yyyy-MM-dd");
            txt_Subject3ExamReserveTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject3ExamReserveTime)) ?"": ValueConvert.ToDateTime(Sum.Subject3ExamReserveTime).ToString("yyyy-MM-dd");
			txt_Subject3MakeUpNumber.Text = ValueConvert.ToString(Sum.Subject3MakeUpNumber);
            txt_Subject4ExamPassTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject4ExamPassTime)) ? "":ValueConvert.ToDateTime(Sum.Subject4ExamPassTime).ToString("yyyy-MM-dd");
            txt_Subject4ExamReserveTime.Text = string.IsNullOrEmpty(ValueConvert.ToString(Sum.Subject4ExamReserveTime)) ? "":ValueConvert.ToDateTime(Sum.Subject4ExamReserveTime).ToString("yyyy-MM-dd");
			txt_Subject4MakeUpNumber.Text = ValueConvert.ToString(Sum.Subject4MakeUpNumber);
			txt_TicketNumber.Text = ValueConvert.ToString(Sum.TicketNumber);
		}

        /// <summary>
        ///     间隔信息
        /// </summary>
        private void BindLoadInterval()
        {
            if (Sum.FirstDistDate != null)
            {
                text_ApplyDist.EditValue = Math.Abs(ValueConvert.ToInt32(((TimeSpan)(Sum.FirstDistDate - Student.ApplyDate)).Days));
            }
            if (Sum.ClassArrangeTime != null)
            {
                text_ApplyArrange.EditValue = Math.Abs(ValueConvert.ToInt32(((TimeSpan)(Sum.ClassArrangeTime - Student.ApplyDate)).Days));
            }
            if (Sum.Subject1ExamPassTime != null)
            {
                text_ApplyK1.EditValue = Math.Abs(ValueConvert.ToInt32(((TimeSpan)(Sum.Subject1ExamPassTime - Student.ApplyDate)).Days));
            }
            if (Sum.Subject2ExamPassTime != null)
            {
                text_ApplyK2.EditValue = Math.Abs(ValueConvert.ToInt32(((TimeSpan)(Sum.Subject2ExamPassTime - Student.ApplyDate)).Days));
            }
            if (Sum.Subject3ExamPassTime != null)
            {
                text_ApplyK3.EditValue = Math.Abs(ValueConvert.ToInt32(((TimeSpan)(Sum.Subject3ExamPassTime - Student.ApplyDate)).Days));
            }
            if (Sum.Subject4ExamPassTime != null)
            {
                text_ApplyK4.EditValue = Math.Abs(ValueConvert.ToInt32(((TimeSpan)(Sum.Subject4ExamPassTime - Student.ApplyDate)).Days));
            }
        }

		/// <summary>
		///     体检信息
		/// </summary>
		private void BindLoadExt()
		{
			txt_ColorVision.Text = ValueConvert.ToString(Ext.ColorVision);
			txt_Hospital.Text = ValueConvert.ToString(Ext.Hospital);
			txt_LeftAudition.Text = ValueConvert.ToString(Ext.LeftAudition);
			txt_LeftCorrection.Text = ValueConvert.ToString(Ext.LeftCorrection);
			txt_LeftLowerLimb.Text = ValueConvert.ToString(Ext.LeftLowerLimb);
			txt_LeftUpperLimb.Text = ValueConvert.ToString(Ext.LeftUpperLimb);
			txt_LeftVision.Text = ValueConvert.ToString(Ext.LeftVision);
			txt_MedicalTime.Text = ValueConvert.ToString(Ext.MedicalTime);
			txt_RightAudition.Text = ValueConvert.ToString(Ext.RightAudition);
			txt_RightCorrection.Text = ValueConvert.ToString(Ext.RightCorrection);
			txt_RightLowerLimb.Text = ValueConvert.ToString(Ext.RightLowerLimb);
			txt_RightUpperLimb.Text = ValueConvert.ToString(Ext.RightUpperLimb);
			txt_RightVision.Text = ValueConvert.ToString(Ext.RightVision);
			txt_Stature.Text = ValueConvert.ToString(Ext.Stature);
			txt_Truncus.Text = ValueConvert.ToString(Ext.Truncus);
		}

		/// <summary>
		///     返回“是”和  “否”
		/// </summary>
		/// <param name="bol"></param>
		/// <returns></returns>
		public string Judge(bool bol)
		{
			return bol ? "是" : "否";
		}

		/// <summary>
		///     设置输入文本值为空(只读)
		/// </summary>
		private void SetTextEditValueEmpty(LayoutControl layoutControl)
		{
			foreach (Control c in layoutControl.Controls)
			{
				if (!(c is TextEdit)) continue;
				var textEdit = c as TextEdit;
				textEdit.Properties.ReadOnly = true;
				textEdit.BackColor = Color.White;
			}
		}

		#endregion
	}
}