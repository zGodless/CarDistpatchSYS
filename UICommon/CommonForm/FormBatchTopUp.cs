using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NoHeaderXtraTabControl;
using DS.MSClient.UICommon;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DS.Model;
using DS.Data;
using QuickFrame.UI.Common.Search;
using DS.MSClient.UIControl;
using QuickFrame;
using QuickFrame.Common.Converter;



namespace DS.MSClient.UICommon
{
    /// <summary>
    /// 批量充值
    /// </summary>
    public partial class FormBatchTopUp : FormBase
    {
        public FormBatchTopUp()
        {
            InitializeComponent();

            this.InitEvent();
        }
        #region  初始化
        private void InitEvent()
        {



            this.Load += MainStudent_Load;

            this.trl_Left.FocusedNodeChanged += trl_Left_FocusedNodeChanged;
            this.gv_Student.RowClick += gv_Student_RowClick;
            //全选
            this.checkEdit_All.CheckedChanged += checkEdit_All_CheckedChanged;

            //button 事件
            this.simpleButton_yes.Click += simpleButton_yes_Click;
            this.simpleButton_no.Click += simpleButton_yes_Click;

        }

        void gv_Student_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_Student.FocusedColumn == Column_choose)
            {
                var detail = this.gv_Student.GetFocusedRow() as Student;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_Student.RefreshDataSource();
                        break;
                }
            }
        }

        #endregion

        #region 属性
        public List<Student> _list = new List<Student>();
        public Student _student = null;
        public string sql = "";
        private QueryProcedurePara _para = null;
        public Group currentNode = new Group();
        //当前页
        public int curPage = 1;
        //分页数
        public int pageSize = 100;
        //总行数
        private int allCount = 0;
        //获取所有部门
        public List<Group> _listAllGroups = new List<Group>();
        public List<School> _listAllSchools = new List<School>();
        public int number = 0;//生成数量
        public Account AccCurrent = new Account();
        #endregion

        #region 事件

        void trl_Left_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                currentNode = (Group)this.trl_Left.GetDataRecordByNode(e.Node);
                if (currentNode != null)
                {

                    this.GetSearchFilter(this.sql);
                    this.BindData(this._para);
                }
            }

        }
        void MainStudent_Load(object sender, EventArgs e)
        {
            try
            {
                if (ThreadExcute(BindNodeData))
                {
                    this.trl_Left.RowHeight = 20;
                    this.trl_Left.Padding = new Padding(4, 4, 2, 2);
                    this.trl_Left.SelectImageList = DS.MSClient.Controls.StaticImageList.Instance.ImageList_global;
                    this.trl_Left.CustomDrawNodeImages += treeList_CustomDrawNodeImages;

                    if (_listAllGroups.Count > 0) _listAllGroups.ForEach(m =>
                    {
                        m.Fid = "School" + m.GroupID;
                        m.Pid = m.SchoolID.ToString();
                        m.GroupName = m.TrainPlaceName + "-" + m.GroupName;
                        m.NodeType = "分队";
                    });

                    var Schoollist = new List<Group>();
                    if (_listAllSchools.Count > 0)
                    {
                        foreach (var data in _listAllSchools)
                        {
                            var item = new Group();
                            item.SchoolID = data.SchoolID;
                            item.GroupName = data.SchoolName;
                            item.Fid = data.SchoolID.ToString();
                            item.NodeType = "驾校";
                            Schoollist.Add(item);
                            var node = new Group();
                            node.SchoolID = data.SchoolID;
                            node.Fid = "Node" + data.SchoolID.ToString();
                            node.Pid = data.SchoolID.ToString();
                            node.GroupName = "未分类";
                            node.NodeType = "未分类";
                            Schoollist.Add(node);
                        }
                        _listAllGroups.AddRange(Schoollist);
                    }
                    this.trl_Left.DataSource = this._listAllGroups;
                    this.trl_Left.KeyFieldName = "Fid";
                    this.trl_Left.ParentFieldName = "Pid";
                    this.trl_Left.ExpandToLevel(0);
                    this.trl_Left.OptionsBehavior.Editable = false;
                    this.trl_Left.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex);
            }
        }

        /// <summary>
        /// treeList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeList_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            e.SelectImageIndex = 20;
        }

        /// <summary>
        /// 按钮搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void GetSearchFilter(string sql)
        {
            _para = new QueryProcedurePara();



            currentNode = (Group)this.trl_Left.GetDataRecordByNode(this.trl_Left.FocusedNode);
            if (currentNode != null)
            {
                if (currentNode.NodeType == "驾校")
                {
                    sql = sql + string.Format("  a.SchoolID={0}", currentNode.SchoolID);
                }
                else
                {
                    if (currentNode.NodeType == "分队")
                    {
                        sql = sql + string.Format("  a.SchoolID={0}", currentNode.SchoolID);
                        sql = sql + string.Format(" and a.GroupID={0}", currentNode.GroupID);
                    }
                    else
                    {
                        sql = sql + string.Format("  a.SchoolID={0}", currentNode.SchoolID);
                        sql = sql + string.Format(" and (a.GroupID is null or a.GroupID=0) ");
                    }
                }
            }

            _para.P_Where = sql;
            _para.P_PageSize = pageSize;
            if (curPage == 0)
            {
                curPage = 1;
            }
            _para.P_PageIndex = curPage;
            string _orderBy = "a.TrainPlaceID";//默认排序字段
            foreach (GridColumn col in this.gv_Student.Columns)
            {
                if (col.FieldName != "Choose" && col.SortOrder != DevExpress.Data.ColumnSortOrder.None)//判断是否有排序，如果有，加上列排序信息
                {
                    string sortOrder = col.SortOrder.ToString() == "Descending" ? "desc" : "asc";//升序、降序
                    _orderBy = "a." + col.FieldName + " " + sortOrder;//注意：此处需要根据字段所属表进行必要的替换对应的字段、表别名等。
                    break;
                }
            }

            _para.P_OrderBy = _orderBy;
        }



        void simpleButton_yes_Click(object sender, EventArgs e)
        {
            var ChooseStudent = _list.FindAll(n => n.Choose == true);
            if (sender == simpleButton_yes)
            {
                bool result = false;
                int itype = 0;
                if (ChooseStudent.Count == 0)
                {
                    MsgBox.ShowInfo("请至少勾选一个学员绑定卡券");
                    return;
                }
                        
                if (this.txt_CashAmount.Text == "")
                {
                    MsgBox.ShowInfo("请输入充值金额");
                    return;
                }
                this.number = Convert.ToInt32(txt_CashAmount.Text);
                if (this.checkEdit_ISUse.Checked)
                {
                    itype = 1;
                }
                else
                {
                    itype = 0;
                }
                int? Amount = ValueConvert.ToNullableInt32(this.txt_CashAmount.Text);
                string StudentIDStr = null;
                string note = "";
                var chooserow = _list.FindAll(m => m.Choose == true);
                if (chooserow.Count == 0) return;
                chooserow.ForEach(item => {
                    bool results = new AccountDao().Exist_StudentID(item.StudentID);
                   
                    if (results == false)
                    {
                        this.AccCurrent.AccountID = new CommonDAO().GetIntUniqueNumber("t_account");
                        this.AccCurrent.StudentID = item.StudentID;
                        this.AccCurrent.AccountCode = "C" + AccCurrent.AccountID;
                        AccCurrent.OperateID = Program.CurrentEmployee.EmployeeID;
                        AccCurrent.OperateTime = DateTime.Now;
                        bool result1 = new AccountDao().Add(AccCurrent);



                    }

                    
            
                });
                StudentIDStr = string.Join(",", chooserow.Select(x=>x.StudentID));
              bool   isResult = new AccountDao().query(StudentIDStr, Amount, itype, note, Program.CurrentEmployee.EmployeeID, DateTime.Now);
              if (isResult)
             {
                 MsgBox.ShowInfo("充值成功！");
                 this.Close();
             }
              else
              {
                  MsgBox.ShowInfo("充值失败！");
              }

            }
            else if (sender == simpleButton_no)
            {
                this.Close();
            }

        }

        void checkEdit_All_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_All.Checked)
            {
                for (int i = 0; i < this.gv_Student.RowCount; i++)
                {
                    this.gv_Student.SetRowCellValue(i, gv_Student.Columns.ColumnByFieldName("Choose"), true);
                }
            }
            else
            {
                for (int i = 0; i < this.gv_Student.RowCount; i++)
                {
                    this.gv_Student.SetRowCellValue(i, gv_Student.Columns.ColumnByFieldName("Choose"), false);
                }
            }
        }
        #endregion

        #region 方法
        private void BindNodeData()
        {
            _listAllGroups = new GroupDao().GetList();
            _listAllSchools = new SchoolDao().GetAllList();
        }

        private void BindData(QueryProcedurePara para)
        {
            allCount = 0;
            bool result = ThreadExcute(() =>
            {
                _list = new StudentDAO().Query(para, out allCount);
            });
            if (result)
            {
                this.gc_Student.DataSource = _list;
                this.gc_Student.RefreshDataSource();
                if (allCount == 0)
                {
                    curPage = 0;
                }
                pagingControl1.RefreshPager(pageSize, allCount, curPage);
            }
        }



        #endregion
    }
}
