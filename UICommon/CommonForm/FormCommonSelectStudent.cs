using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using DS.Data;
using DS.Model;
using DS.MSClient.UICommon;
using QuickFrame.Common.Converter;
using QuickFrame.UI.Common.Search;

namespace DS.MSClient
{
	public partial class FormCommonSelectStudent : FormDlgBase
	{
		#region 初始化

		public FormCommonSelectStudent()
		{
			InitializeComponent();
			InitEvent();
		}

		private void InitEvent()
		{
			gcStudent.LoadGridLayout(bmMain, "通用对话框/选择学生", AdvancedSearch, SortOrderSearch, GetPageSize,
				GetTotalRecordCount);

			Load += FormStudentForAuditApply_Load;
			FormClosing += FormCommonSelectStudent_FormClosing;
			KeyUp += FormStudentForAuditApply_KeyUp;

			btnSelAdd.Click += btnSelAdd_Click;
			btnSelRemove.Click += btnSelRemove_Click;
			btnSelClear.Click += btnSelClear_Click;

			btnSwitchAdvSearch.Click += btnSwitchAdvSearch_Click;
			btnCheckAll.Click += btnCheckAll_Click;
			btnReset.Click += btnReset_Click;
			btnSearch.Click += btnSearch_Click;
			btnAdd.Click += btnAdd_Click;
			btnOK.Click += btnOK_Click;
			btnCancel.Click += btnCancel_Click;

			pagingControlStudent.PagingEvent += pagingControlStudent_PagingEvent;
			gvStudent.RowClick += gvStudent_RowClick;
			gvStudent.CalcRowHeight += gvStudent_CalcRowHeight;
			gvSel.RowClick += gvSel_RowClick;
			gvSel.CustomDrawRowIndicator += gridView_CustomDrawRowIndicator;
            Btn_StudentInfo.Click += Btn_StudentInfo_Click;

            cLookExamPlace1.EditValueChanged += cLookExamPlace1_EditValueChanged;
		}


		#endregion

		#region 属性

		private List<Student> _list = new List<Student>();
		private string _sql = "";
		private QueryProcedurePara _para;
	    public string SendFormName;
        public bool _zoneIsArrange; //校区是否分配
        public int schoolZoneID; //校区
        public bool groupIsDist; //分组是否分配
        public string trainProperty; //培训性质

	    private int curExamPlaceID;

		private List<Student> ShowList
		{
			get { return _list.FindAll(m => !m.IsSelected); }
		}

		/// <summary>
		///     总行数
		/// </summary>
		private int _allCount;

		/// <summary>
		///     当前页
		/// </summary>
		public int CurPage = 1;

		/// <summary>
		///     分页数
		/// </summary>
		public int PageSize = 100;

		/// <summary>
		///     刷新事件委托
		/// </summary>
		/// <param name="list"></param>
		public delegate void DisplayUpdate(List<Student> list);

		/// <summary>
		///     刷新事件
		/// </summary>
		public event DisplayUpdate ShowUpdate;

		/// <summary>
		///     显示类型
		/// </summary>
		public string DisPlayType = "all";

		/// <summary>
		///     是否显示选择框
		/// </summary>
		public bool SelectOnDialog = false;

		/// <summary>
		///     过滤的ID列表，以“,”分隔
		/// </summary>
		public string IDList = "";

		/// <summary>
		///     初始报名地点
		/// </summary>
		public int? ApplyID;

		/// <summary>
		///     初始报名驾校
		/// </summary>
        public int? SchoolID;

        /// <summary>
        ///     初始校区
        /// </summary>
        public int? SchoolZoneID;

		/// <summary>
		///     学员状态
		/// </summary>
		public string StudentState = "";

		/// <summary>
		///     扩展查询SQL
		/// </summary>
		public string ExtSql = "";

		/// <summary>
		///     已选择列表
		/// </summary>
		public List<Student> ChooseList = new List<Student>();

	    public string ControlMemberFileName = "";

		#endregion

        #region 事件
        void cLookExamPlace1_EditValueChanged(object sender, EventArgs e)
        {
            if (cLookExamPlace1.EditValue != null)
            {
                curExamPlaceID = ValueConvert.ToInt32(cLookExamPlace1.EditValue);
            }
            else
            {
                curExamPlaceID = 0;
            }
        }

        void Btn_StudentInfo_Click(object sender, EventArgs e)
        {
            var model = gvStudent.GetFocusedRow() as Student;
            if (!FormPageOperation.FindExistsForm("MainStudentInfo", ValueConvert.ToString(model.StudentID)))
            {
                MainStudentInfo form = new MainStudentInfo();
                form.Student = model;
                form.Tag = model.StudentID;
                form.Show();
            }
        }
		private void FormStudentForAuditApply_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control || e.Alt || e.KeyCode != Keys.F5) return;
			btnSearch.PerformClick();
		}

		private void gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
		{
			if (e.Info.IsRowIndicator && e.RowHandle >= 0)
			{
				e.Info.DisplayText = (e.RowHandle + 1).ToString();
			}
		}


		private void btnCheckAll_Click(object sender, EventArgs e)
		{
			if (ShowList != null)
			{
				ShowList.ForEach(m => m.Choose = true);
				gcStudent.RefreshDataSource();
			}
		}

		private void btnSwitchAdvSearch_Click(object sender, EventArgs e)
		{
			SwitchAdvSearch();
		}

		private void gvStudent_RowClick(object sender, RowClickEventArgs e)
		{
			var detail = gvStudent.GetFocusedRow() as Student;
			if (detail == null) return;
			switch (e.Clicks)
			{
				case 1:
					if (gvStudent.FocusedColumn == null || gvStudent.FocusedColumn.FieldName != "Choose") return;
					detail.Choose = !detail.Choose;
					gcStudent.RefreshDataSource();
					break;
				case 2:
					if (!SelectOnDialog) return;
                    int index_top = gvStudent.TopRowIndex;
					detail.Choose = false;
					detail.IsSelected = true;
			        detail.ExamPlaceID = curExamPlaceID;
			        detail.ExamPlaceName = cLookExamPlace1.Text;
					ChooseList.Add(detail);
					gcStudent.DataSource = ShowList;
					gcStudent.RefreshDataSource();
					gcSel.RefreshDataSource();
                    gvStudent.TopRowIndex = index_top;
					gvSel.FocusedRowHandle = gvSel.GetRowHandle(ChooseList.Count - 1);
					break;
			}
		}

		void gvStudent_CalcRowHeight(object sender, RowHeightEventArgs e)
		{
			var row = gvStudent.GetRow(e.RowHandle) as Student;
			if (row == null) return;
			if (string.IsNullOrEmpty(row.ChargeText) && string.IsNullOrEmpty(row.DefinitionText)) return;
			e.RowHeight -= 18;
		}

		void gvSel_RowClick(object sender, RowClickEventArgs e)
		{
			var detail = gvSel.GetFocusedRow() as Student;
			if (detail == null) return;
			switch (e.Clicks)
			{
				case 1:
					if (gvSel.FocusedColumn == null || gvSel.FocusedColumn.FieldName != "Choose") return;
					detail.Choose = !detail.Choose;
					gcSel.RefreshDataSource();
					break;
				case 2:
					detail.Choose = false;
					detail.IsSelected = false;
					ChooseList.Remove(detail);
					gcStudent.DataSource = ShowList;
					gcStudent.RefreshDataSource();
					gcSel.RefreshDataSource();
					break;
			}
		}

		/// <summary>
		///     绑定分页事件
		/// </summary>
		/// <param name="curPage"></param>
		/// <param name="pageSize"></param>
		private void pagingControlStudent_PagingEvent(int curPage, int pageSize)
		{
			Cursor.Current = Cursors.WaitCursor;
			CurPage = curPage;
			PageSize = pageSize;
			GetSearchFilter(_sql);
			BindData();
			Cursor.Current = Cursors.Default;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!SelectOnDialog || !ChooseList.Any())
            {
//                 if (SendFormName == "FormEditStudentArrange" && cLookExamPlace1.EditValue == null)
//                 {
//                     MsgBox.ShowWarn("请选择考试地点");
//                     return;
//                 }
				ChooseList.Clear();
				foreach (var item in ShowList)
				{
					if (item.Choose)
					{
					    if (SendFormName == "FormEditStudentArrange")
					    {
                            item.ExamPlaceID = curExamPlaceID;
                            item.ExamPlaceName = ValueConvert.ToString(cLookExamPlace1.Text);
					    }
						ChooseList.Add(item);
					}
				}
			}
			if (!ChooseList.Any())
			{
				MsgBox.ShowWarn("您没有选择任何学员");
				return;
			}
			SchoolID = ValueConvert.ToInt32(cl_School.EditValue);
            if (ControlMemberFileName != "")
            {
                ControlMemoryHelper.SaveControl(ControlMemberFileName, lcMain);
            }
			DialogResult = DialogResult.OK;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			ChooseList.Clear();
			foreach (var item in _list)
			{
				if (item.Choose)
				{
					ChooseList.Add(item);
				}
			}
			if (ChooseList.Count == 0)
			{
				MsgBox.ShowWarn("请选择数据进行添加");
				return;
			}
			if (ShowUpdate != null)
			{
				ShowUpdate(ChooseList);
				ChooseList.ForEach(m => _list.RemoveAll(n => m.StudentID == n.StudentID));
				IDList += "," + string.Join(",", ChooseList.Select(m => m.StudentID).ToArray());
				gcStudent.RefreshDataSource();
			}
		}

		void btnSelAdd_Click(object sender, EventArgs e)
		{
			var chList = ShowList.FindAll(m => m.Choose);
			if (!chList.Any())
			{
				MsgBox.ShowWarn("请选择数据进行添加");
				return;
			}
// 			if (SendFormName == "FormEditStudentArrange" && cLookExamPlace1.EditValue == null)
//             {
//                 MsgBox.ShowWarn("请选择考试地点");
//                 return;
// 		    }
			foreach (var item in chList)
			{
				if (!item.Choose) continue;
				item.Choose = false;
				item.IsSelected = true;
                item.ExamPlaceID = curExamPlaceID;
			    item.ExamPlaceName = cLookExamPlace1.Text;
				ChooseList.Add(item);
			}
			gcStudent.DataSource = ShowList;
			gcStudent.RefreshDataSource();
			gcSel.RefreshDataSource();
			if (!ChooseList.Any()) return;
			gvSel.FocusedRowHandle = gvSel.GetRowHandle(ChooseList.Count - 1);
		}

		void btnSelRemove_Click(object sender, EventArgs e)
		{
			var chList = ChooseList.FindAll(m => m.Choose);
			if (!chList.Any())
			{
				MsgBox.ShowWarn("请选择数据进行移除");
				return;
			}
			foreach (var item in chList)
			{
				if (!item.Choose) continue;
				item.Choose = false;
				item.IsSelected = false;
				ChooseList.Remove(item);
			}
			gcStudent.DataSource = ShowList;
			gcStudent.RefreshDataSource();
			gcSel.RefreshDataSource();
		}

		void btnSelClear_Click(object sender, EventArgs e)
		{
			if (!ChooseList.Any()) return;
			foreach (var item in ChooseList)
			{
				item.Choose = false;
				item.IsSelected = false;
			}
			ChooseList.Clear();
			gcStudent.DataSource = ShowList;
			gcStudent.RefreshDataSource();
			gcSel.RefreshDataSource();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
            _sql = " 1 = 1 ";
			GetSearchFilter(_sql);
			BindData();
			SwitchAdvSearch(false);
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
		    cLookExamPlace1.EditValue = null;
			txt_studentName.EditValue = null;
			txt_StudentCode.EditValue = null;
			txt_IdentityNo.EditValue = null;
			txt_Cellphone.EditValue = null;
			date_applyStartDate.EditValue = null;
			cl_StudentStateBegin.EditValue = 10;
			cl_ApplyWay.EditValue = null;
			cl_ApplyPlace.EditValue = ApplyID;

			cl_School.EditValue = SchoolID;
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
			cmb_Islocal.EditValue = null;
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
		}

		private void FormStudentForAuditApply_Load(object sender, EventArgs e)
		{
		    cob_ZoneIsArr.SelectedIndex = 0;
		    cob_IsGroup.SelectedIndex = 0;
            if (SendFormName == "FormEditSchoolZoneDist")       //校区分配
            {
                cob_ZoneIsArr.SelectedIndex = 2;
                cob_IsGroup.SelectedIndex = 2;
                cmb_TrainProperty.SelectedIndex = 1;
                date_applyStartDate.EditValue = DateTime.Now.AddDays(-3);
            }
            if (SendFormName == "FormEditStudentArrange")
            {
                BindExamPlaceDate();
            }
		    else
		    {
                layoutControlItem92.HideToCustomization();      //隐藏考试地点选项
		    }
		    if (DisPlayType == "Audit")
			{
				gridColumn12.Visible = false;
				gridColumn13.Visible = false;
				gridColumn14.Visible = false;
				gridColumn15.Visible = false;
			}
			if (DisPlayType == "Dist")
			{
				gridColumn11.Visible = false;
				gridColumn12.Visible = false;
				gridColumn13.Visible = false;
				gridColumn14.Visible = false;
				gridColumn15.Visible = false;
				gridColumn16.Visible = false;
				gridColumn17.Visible = false;
				cl_ApplyPlace.Enabled = true;
			}
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
			date_applyEndDate.EditValue = DateTime.Now;
			if (DisPlayType == "ForecastClassAudit" || DisPlayType == "ClassAudit")
			{
			}
			else
			{
				if (StudentState.Trim() == "")
				{
					cl_StudentStateBegin.SelectedText = "资料受理";
					cl_StudentStateEnd.SelectedText = "科四培训";
				}
				else
				{
					cl_StudentStateBegin.SelectedText = StudentState;
					cl_StudentStateEnd.SelectedText = StudentState;
				}
				LoadData();
			}

			if (SelectOnDialog)
			{
				splSel.Visibility = LayoutVisibility.Always; 
				lcgSel.Visibility = LayoutVisibility.Always;
				lciBtnAdd.Visibility = LayoutVisibility.Never;
			}
			else
			{
				splSel.Visibility = LayoutVisibility.Never;
				lcgSel.Visibility = LayoutVisibility.Never;
				lciBtnAdd.Visibility = LayoutVisibility.Always;
			}

			gcSel.DataSource = ChooseList;
			gcSel.RefreshDataSource();
		    if (ControlMemberFileName != "")
		    {
		        ControlMemoryHelper.ReadControl(ControlMemberFileName,lcMain);
		    }
		}

		void FormCommonSelectStudent_FormClosing(object sender, FormClosingEventArgs e)
		{
			gcStudent.SaveStyle();
		}

		#endregion

		#region 方法

	    private void BindExamPlaceDate()
	    {
	        cLookExamPlace1.BindList();
            
            // Create an unbound column.
            GridColumn unbColumn = gvSel.Columns.AddField("ExamPlaceName");
            unbColumn.VisibleIndex = gvSel.Columns.Count + 2;
	        unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.String;
	        unbColumn.Caption = "考试地点";
	        unbColumn.FieldName = "ExamPlaceName";
            unbColumn.OptionsColumn.AllowEdit = false;
            unbColumn.OptionsColumn.ReadOnly = true;
            unbColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            unbColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
	        unbColumn.Width = 90;
	    }

		private void SwitchAdvSearch(bool? show = null)
		{
			if (show == null)
			{
				if (lcgGernal.Visibility == LayoutVisibility.Always)
				{
					lcgGernal.Visibility = LayoutVisibility.Never;
					lcgExam.Visibility = LayoutVisibility.Never;
					lcgTrain.Visibility = LayoutVisibility.Never;
					lcgOther.Visibility = LayoutVisibility.Never;
				}
				else
				{
					lcgGernal.Visibility = LayoutVisibility.Always;
					lcgExam.Visibility = LayoutVisibility.Always;
					lcgTrain.Visibility = LayoutVisibility.Always;
					lcgOther.Visibility = LayoutVisibility.Always;
				}
			}
			else
			{
				if (show == true)
				{
					lcgGernal.Visibility = LayoutVisibility.Always;
					lcgExam.Visibility = LayoutVisibility.Always;
					lcgTrain.Visibility = LayoutVisibility.Always;
					lcgOther.Visibility = LayoutVisibility.Always;
				}
				if (show == false)
				{
					lcgGernal.Visibility = LayoutVisibility.Never;
					lcgExam.Visibility = LayoutVisibility.Never;
					lcgTrain.Visibility = LayoutVisibility.Never;
					lcgOther.Visibility = LayoutVisibility.Never;
				}
			}
		}

		private void GetSearchFilter(string sql)
		{
			_para = new QueryProcedurePara();
            //快捷查询
		    if (schoolZoneID != 0)
            {
                sql += " and ifnull(a.SchoolZoneID, 0) = " + schoolZoneID;
		    }
            if (cob_IsGroup.SelectedIndex == 1)
            {
                sql += " and ifnull(a.GroupID, 0) <> 0 ";
            }
            else if (cob_IsGroup.SelectedIndex == 2)
            {
                sql += " and ifnull(a.GroupID, 0) = 0 ";
            }
            if (cob_ZoneIsArr.SelectedIndex == 1)
		    {
                sql += " and ifnull(a.SchoolZoneID, 0) <> 0 ";
		    }
            else if (cob_ZoneIsArr.SelectedIndex == 2)
            {
                sql += " and ifnull(a.SchoolZoneID, 0) = 0 ";
            }
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
				sql += string.Format(" and b.ExamIsArrange = {0}", cmb_ExamIsArrange.SelectedIndex == 1 ? 1 : 0);
			}
			if (ValueConvert.ToInt32(cl_Employee.EditValue) != 0)
			{
				sql += string.Format(" and a.CoachID = {0}", ValueConvert.ToInt32(cl_Employee.EditValue));
			}
			if (ValueConvert.ToInt32(cl_ApplyWay.EditValue) != 0)
			{
                sql += string.Format(" and find_in_set(a.ApplyWayID,f_get_applyway_child_list({0}))", this.cl_ApplyWay.EditValue);
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
				sql += string.Format(" and b.Period1IsFull = '{0}' ", cl_SchoolState1.EditValue);
			}
			if (cl_SchoolState2.EditValue != null)
			{
				sql += string.Format(" and b.Period1IsFull = '{0}'", cl_SchoolState2.EditValue);
			}
			if (cl_SchoolState3.EditValue != null)
			{
				sql += string.Format(" and b.Period1IsFull = '{0}'", cl_SchoolState3.EditValue);
			}
			if (ValueConvert.ToInt32(cl_TrainPlace.EditValue) != 0)
			{
				sql += string.Format(" and a.TrainPlaceID = {0}", ValueConvert.ToInt32(cl_TrainPlace.EditValue));
			}
			if (cmb_Islocal.SelectedIndex >= 0)
			{
				sql += string.Format(" and a.Islocal = '{0}' ", ValueConvert.ToInt32(cmb_Islocal.SelectedIndex));
			}
			if (ValueConvert.ToInt32(cl_From.EditValue) != 0)
			{
                sql += string.Format(" and find_in_set(a.FromID,f_get_from_child_list({0}))", cl_From.EditValue);
			}
			if (cmb_Coach.SelectedIndex >= 0) //是否分配教练，未解决
			{
			    if (cmb_Coach.Text == "已分配")
			    {
                    sql += string.Format(" and ifnull(b.IsCoach,0) = {0}", 1);
			    }
			    else
			    {
                    sql += string.Format(" and ifnull(b.IsCoach,0) = {0}", 2);
			    }
			}
			if (cmb_IsWeipei.SelectedIndex >= 0)
			{
				sql += string.Format(" and a.IsWeipei = {0}", ValueConvert.ToInt32(cmb_IsWeipei.SelectedIndex));
			}
			if (cmb_IsOweFee.SelectedIndex >= 0)
			{
				sql += string.Format(" and b.IsOweFee = {0} ", ValueConvert.ToInt32(cmb_IsOweFee.SelectedIndex));
			}
			if (cmb_InfoIsFull.SelectedIndex >= 0)
			{
				sql += string.Format(" and b.InfoIsFull = {0} ", ValueConvert.ToInt32(cmb_InfoIsFull.SelectedIndex));
			}
			if (txt_TicketNumber.Text != "")
			{
				sql += string.Format(" and b.TicketNumber like '%{0}%'", txt_TicketNumber.Text);
			}
			if (cmb_IsLock.SelectedIndex >= 0)
			{
				sql += string.Format(" and a.IsLock  = {0}", ValueConvert.ToInt32(cmb_IsLock.SelectedIndex));
			}
			if (cmb_ApplyLicense.Text != "")
			{
				sql += string.Format(" and a.ApplyLicense = '{0}' ", cmb_ApplyLicense.SelectedText);
			}
			if (txt_ClassArrangeNumber.Text != "")
			{
				sql += string.Format(" and b.ClassArrangeNumber like '%{0}%'", txt_ClassArrangeNumber.Text);
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
				sql += string.Format(" and b.LifeAreaID = {0}", ValueConvert.ToInt32(cmb_LifeAreaName.EditValue));
			}
			if (date_ClassArrangeTimeStar.EditValue != null && date_ClassArrangeTimeEnd.EditValue == null)
			{
				sql += string.Format(" and b.ClassArrangeTime >= '{0}'",
					ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_ClassArrangeTimeEnd.EditValue != null && date_ClassArrangeTimeStar.EditValue == null)
			{
				sql += string.Format(" and b.ClassArrangeTime <= '{0}'",
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
				sql += string.Format(" and b.ClassArrangeTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_ClassArrangeTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_ClassArrangeTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			//考试信息查询
			if (date_LatelyExamTimeStar.EditValue != null && date_LatelyExamTimeEnd.EditValue == null)
			{
				sql += string.Format(" and b.LatelyExamTime >= '{0}'",
					ValueConvert.ToDateTime(date_LatelyExamTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_LatelyExamTimeEnd.EditValue != null && date_LatelyExamTimeStar.EditValue == null)
			{
				sql += string.Format(" and b.LatelyExamTime <= '{0}'",
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
				sql += string.Format(" and b.LatelyExamTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_LatelyExamTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_LatelyExamTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
            if (ValueConvert.ToInt32(txt_ExamTime.EditValue) != 0)
			{
				sql += string.Format(" and b.ExamTime = {0}", txt_ExamTime.EditValue);
			}
			if (cmb_SubjectStayState.SelectedText != "")
			{
				sql += string.Format(" and b.SubjectStayState = '{0}'", cmb_SubjectStayState.SelectedText);
			}
			if (date_Subject1ExamPassTimeStar.EditValue != null && date_Subject1ExamPassTimeEnd.EditValue == null) //科一考过时间
			{
				sql += string.Format(" and b.Subject1ExamPassTime >= '{0}'",
					ValueConvert.ToDateTime(date_Subject1ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject1ExamPassTimeEnd.EditValue != null && date_Subject1ExamPassTimeStar.EditValue == null)
			{
				sql += string.Format(" and b.Subject1ExamPassTime <= '{0}'",
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
				sql += string.Format(" and b.Subject1ExamPassTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_Subject1ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_Subject1ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (date_Subject2ExamPassTimeStar.EditValue != null && date_Subject2ExamPassTimeEnd.EditValue == null) //科二考过时间
			{
				sql += string.Format(" and b.Subject2ExamPassTime >= '{0}'",
					ValueConvert.ToDateTime(date_Subject2ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject2ExamPassTimeEnd.EditValue != null && date_Subject2ExamPassTimeStar.EditValue == null)
			{
				sql += string.Format(" and b.Subject2ExamPassTime <= '{0}'",
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
				sql += string.Format(" and b.Subject2ExamPassTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_Subject2ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_Subject2ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (date_Subject3ExamPassTimeStar.EditValue != null && date_Subject3ExamPassTimeEnd.EditValue == null) //科三考过时间
			{
				sql += string.Format(" and b.Subject3ExamPassTime >= '{0}'",
					ValueConvert.ToDateTime(date_Subject3ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject3ExamPassTimeEnd.EditValue != null && date_Subject3ExamPassTimeStar.EditValue == null)
			{
				sql += string.Format(" and b.Subject3ExamPassTime <= '{0}'",
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
				sql += string.Format(" and b.Subject3ExamPassTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_Subject3ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_Subject3ExamPassTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (date_Subject4ExamPassTimeStar.EditValue != null && date_Subject4ExamPassTimeEnd.EditValue == null) //科四考过时间
			{
				sql += string.Format(" and b.Subject4ExamPassTime >= '{0}'",
					ValueConvert.ToDateTime(date_Subject4ExamPassTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_Subject4ExamPassTimeEnd.EditValue != null && date_Subject4ExamPassTimeStar.EditValue == null)
			{
				sql += string.Format(" and b.Subject4ExamPassTime <= '{0}'",
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
				sql += string.Format(" and b.Subject4ExamPassTime between '{0}' and '{1}'",
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
				sql += string.Format(" and b.Subject1MakeUpNumber between {0} and {1}",
                    ValueConvert.ToInt32(txt_Subject1MakeUpNumberStar.EditValue), ValueConvert.ToInt32(txt_Subject1MakeUpNumberEnd.EditValue));
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
				sql += string.Format(" and b.Subject2MakeUpNumber between {0} and {1}",
                    ValueConvert.ToInt32(txt_Subject2MakeUpNumberStar.EditValue), ValueConvert.ToInt32(txt_Subject2MakeUpNumberEnd.EditValue));
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
				sql += string.Format(" and b.Subject3MakeUpNumber between {0} and {1}",
                    Convert.ToInt32(txt_Subject3MakeUpNumberStar.EditValue), ValueConvert.ToInt32(txt_Subject3MakeUpNumberEnd.EditValue));
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
				sql += string.Format(" and b.Subject4MakeUpNumber between {0} and {1} ",
                    ValueConvert.ToInt32(txt_Subject4MakeUpNumberStar.EditValue), ValueConvert.ToInt32(txt_Subject4MakeUpNumberEnd.EditValue));
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
				sql += string.Format(" and b.TrainProgress = '{0}' ", cmb_TrainProgress.SelectedText);
			}
			//其他信息
			if (cmb_Sex.SelectedText != "")
			{
				sql += string.Format(" and a.Sex = '{0}'", cmb_Sex.SelectedText);
			}
			if (ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue) > 0) //科三补考次数
			{
				sql += string.Format(" and b.ReceivableTrainFee >= {0}", ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue));
			}
			else if (ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue) > 0 &&
			         ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue) == 0)
			{
				sql += string.Format(" and b.ReceivableTrainFee <= {0}", ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue));
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
				sql += string.Format(" and b.ReceivableTrainFee between {0} and {1}",
                    ValueConvert.ToInt32(txt_ReceivableTrainFeeStar.EditValue), ValueConvert.ToInt32(txt_ReceivableTrainFeeEnd.EditValue));
			}
			if (ValueConvert.ToInt32(cl_AgeRange.EditValue) != 0)
			{
				sql += string.Format(" and a.AgeRangeID = {0}", ValueConvert.ToInt32(cl_AgeRange.EditValue));
			}
			if (cmb_QuitSchoolKind.SelectedText != "")
			{
				sql += string.Format(" and b.QuitSchoolKind = '{0}' ", cmb_QuitSchoolKind.SelectedText);
			}
			if (ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue) > 0) //科三补考次数
			{
				sql += string.Format(" and b.ReceivedTrainFee >= {0}", ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue));
			}
			else if (ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue) > 0 &&
			         ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue) == 0)
			{
				sql += string.Format(" and b.ReceivedTrainFee <= {0}", ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue));
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
				sql += string.Format(" and b.ReceivedTrainFee between {0} and {1}",
                    ValueConvert.ToInt32(txt_ReceivedTrainFeeStar.EditValue), ValueConvert.ToInt32(txt_ReceivedTrainFeeEnd.EditValue));
			}
			if (date_QuitSchoolTimeStar.EditValue != null && date_QuitSchoolTimeEnd.EditValue == null)
			{
				sql += string.Format(" and b.QuitSchoolTime >= '{0}'",
					ValueConvert.ToDateTime(date_QuitSchoolTimeStar.EditValue).ToString("yyyy-MM-dd"));
			}
			else if (date_QuitSchoolTimeEnd.EditValue != null && date_QuitSchoolTimeStar.EditValue == null)
			{
				sql += string.Format(" and b.QuitSchoolTime <= '{0}'",
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
				sql += string.Format(" and b.QuitSchoolTime between '{0}' and '{1}'",
					ValueConvert.ToDateTime(date_QuitSchoolTimeStar.EditValue).ToString("yyyy-MM-dd"),
					ValueConvert.ToDateTime(date_QuitSchoolTimeEnd.EditValue).ToString("yyyy-MM-dd"));
			}
			if (ValueConvert.ToInt32(txt_TemporaryName.EditValue) != 0)
			{
				sql += string.Format(" and b.TemporaryName = {0}", ValueConvert.ToInt32(txt_TemporaryName.EditValue));
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
                sql += string.Format(" and date(b.Subject1PreExamTime) >= '{0}'",
                    ValueConvert.ToDateTime(date_Subject1PreExamTime.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (dateSubject1PreExamTimeEnd.EditValue != null && date_Subject1PreExamTime.EditValue == null)
            {
                sql += string.Format(" and date(b.Subject1PreExamTime) <= '{0}'",
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
                sql += string.Format(" and date(b.Subject1PreExamTime) between '{0}' and '{1}'",
                    ValueConvert.ToDateTime(date_Subject1PreExamTime.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(dateSubject1PreExamTimeEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            if (cmb_Subject1PreExamPass.Text != "")
            {
                if (cmb_Subject1PreExamPass.Text == "是")
                {
                    sql += " and ifnull(b.Subject1PreExamPass,0)  = 1";
                }
                else
                {
                    sql += " and ifnull(b.Subject1PreExamPass,0)  = 0";
                }
            }

            if (cmb_Subject4PreExamPass.Text != "")
            {
                if (cmb_Subject4PreExamPass.Text == "是")
                {
                    sql += " and ifnull(b.Subject4PreExamPass,0)  = 1";
                }
                else
                {
                    sql += " and ifnull(b.Subject4PreExamPass,0)  = 0";
                }
            }
            if (date_PromiseBegin.EditValue != null && date_PromiseEnd.EditValue == null)
            {
                sql += string.Format(" and extract(year_month from b.PromiseDate) >= extract(year_month from '{0}')",
                    ValueConvert.ToDateTime(date_PromiseBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_PromiseEnd.EditValue != null && date_PromiseBegin.EditValue == null)
            {
                sql += string.Format(" and extract(year_month from b.PromiseDate) <= extract(year_month from '{0}')",
                    ValueConvert.ToDateTime(date_PromiseEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            else if (date_PromiseBegin.EditValue != null && date_PromiseEnd.EditValue != null)
            {
                var date1 = Convert.ToDateTime(date_PromiseBegin.EditValue);
                var date2 = Convert.ToDateTime(date_PromiseEnd.EditValue);
                if (date2 < date1)
                {
                    MsgBox.ShowInfo("训练计划结束月份不可大于开始月份");
                    return;
                }
                sql += string.Format(" and extract(year_month from b.PromiseDate) between extract(year_month from '{0}') and extract(year_month from '{1}')",
                    ValueConvert.ToDateTime(date_PromiseBegin.EditValue).ToString("yyyy-MM-dd"),
                    ValueConvert.ToDateTime(date_PromiseEnd.EditValue).ToString("yyyy-MM-dd"));
            }
			sql += ExtSql;
			sql += string.Format(" and not find_in_set(a.StudentID,'{0}') ", IDList);
		    if (!sql.Contains("a.IsExpire"))
		    {
                sql += " and a.IsExpire  = 0";
		    }
			_para.P_Where = sql;
			_para.P_PageSize = PageSize;
			if (CurPage == 0)
			{
				CurPage = 1;
			}
			_para.P_PageIndex = CurPage;
			var orderBy = " ApplyDate desc"; //默认排序字段
			foreach (GridColumn col in gvStudent.Columns)
			{
				var field = col.FieldName;
                if (field == "ChargeText" || field == "DefinitionText")
                {
                    continue;
                }
				if (field != "Choose" && col.SortOrder != ColumnSortOrder.None) //判断是否有排序，如果有，加上列排序信息
				{
					var sortOrder = col.SortOrder.ToString() == "Descending" ? "desc" : "asc"; //升序、降序
					switch (field)
					{
						case "StudentCode":
							field = "convert(StudentCode,int)";
							break;
						case "statustext":
							field = "State";
							break;
						case "examstatetext":
							field = "ExamState";
							break;
                        case "StudentName":
                            field = " convert(StudentName USING gbk) COLLATE gbk_chinese_ci ";
                            break;
					}
					orderBy = field + " " + sortOrder; //注意：此处需要根据字段所属表进行必要的替换对应的字段、表别名等。
					break;
				}
			}

			_para.P_OrderBy = orderBy;
		}

		private void LoadData()
		{
			cl_ApplyPlace.EditValue = ApplyID;
			cl_School.EditValue = SchoolID;
		}

		/// <summary>
		///     字段排序查询
		/// </summary>
		private void SortOrderSearch()
		{
			CurPage = 1; //字段排序，从第一页开始
			GetSearchFilter(_sql);
			BindData();
		}

		/// <summary>
		///     高级查询
		/// </summary>
		private void AdvancedSearch()
		{
			var form = new FormSearchCondition {gv_current = gvStudent};
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				if (form.CondtionList.Count > 0)
				{
					_sql = Manager.GetQueryExpress(form.CondtionList);
					GetSearchFilter(_sql);
					BindData();
				}
			}
		}

		private void BindData()
		{
			_allCount = 0;
			var chargeList = new List<StudentChargeItem>();
			var feeauditList = new List<StudentFeeauditProject>();
			var result = ThreadExcute(() =>
			{
				_list = new FeeauditApplyDao().QueryStudentForAuditApply(_para, out _allCount);
				var stuIdListStr = string.Join(",", _list.Select(m => m.StudentID));
				chargeList = new StudentChargeDao().GetListStudentChargeItem(stuIdListStr);
				feeauditList = new StudentFeeauditProjectDao().GetListStudentFeeBy(stuIdListStr);
			});
			if (!result) return;
			var strB = new StringBuilder();
			foreach (var item in _list)
			{
				var stuChargeList = chargeList.FindAll(m => m.StudentID == item.StudentID);
				if (stuChargeList.Any())
				{
					strB.Clear();
					strB.Append("<font face='宋体' size='2'><table width='100%' border='1' bordercolor='#AAAAFF' bgcolor='#FFFFFF' cellpadding='1' cellspacing='0'>");
					foreach (var model in stuChargeList)
					{
						strB.AppendFormat(
							"<tr><td align='center' width='40%' style='color:{3}'>{0}</td><td align='center' width='30%' style='color:{3}'>{1}</td><td align='center' width='30%' style='color:{3}'>{2}</td></tr>",
							model.ChargeItemName, model.Amount, model.ChargeAmount, model.ChargeAmount < model.Amount ? "red" : "");
					}
					strB.Append("</table></font>");
					item.ChargeText = strB.ToString();
				}

				var stuFeeauditList = feeauditList.FindAll(m => m.StudentID == item.StudentID);
				if (stuFeeauditList.Any())
				{
					strB.Clear();
					strB.Append("<font face='宋体' size='2'><table width='100%' border='1' bordercolor='#AAAAFF' bgcolor='#FFFFFF' cellpadding='1' cellspacing='0'>");
					foreach (var model in stuFeeauditList)
					{
						strB.AppendFormat(
							"<tr><td align='center' width='40%'>{0}</td><td align='center' width='30%'>{1}</td><td align='center' width='30%'>{2}</td></tr>",
							model.DefinitionName, model.MustAuditMoney, model.AlreadyAuditMoney);
					}
					strB.Append("</table></font>");
					item.DefinitionText = strB.ToString();
				}
				if (ChooseList.Exists(m => m.StudentID == item.StudentID))
				{
					item.IsSelected = true;
				}
			}
			gcStudent.DataSource = ShowList;
			gcStudent.RefreshDataSource();
			if (_allCount == 0)
			{
				CurPage = 0;
			}
			pagingControlStudent.RefreshPager(PageSize, _allCount, CurPage);
		}

		private int GetPageSize()
		{
			return PageSize;
		}

		private int GetTotalRecordCount()
		{
			return _allCount;
		}

		#endregion
	}
}