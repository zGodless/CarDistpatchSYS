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

namespace DS.MSClient.UICommon.CommonForm
{
    public partial class FromPlanDetail : FormBase
    {
        public FromPlanDetail()
        {
            InitializeComponent();
            InitEvent();
        }

        #region 属性

        public DrivePlan _drive = new DrivePlan();
        public List<DrivePlan> _tappointment = new List<DrivePlan>();
        public List<DrivePlan> _fappointment = new List<DrivePlan>();
        public List<DrivePlan> _rate = new List<DrivePlan>();
        public List<DrivePlan> _list = new List<DrivePlan>();
        public string CurrentSchool = null;
        public string CurrentGroup = null;
        public DateTime dateTime1;
        public DateTime dateTime2;
        public int _groupid;
        private Group _group = new Group();
        private List<DrivePlan> _student = new List<DrivePlan>();
        #endregion

        #region 初始化
        void InitEvent()
        {
            Load += FromPlanDetail_Load;
        }

        #endregion

        #region 事件
        void FromPlanDetail_Load(object sender, EventArgs e)
        {
            BindData();
            SetTextEditState(false, this.layoutControl1);
        }

        #endregion

        #region 方法
        /// <summary>
        ///  遍历Layout改变里面控件状态
        /// </summary>
        /// <param name="readOnly"></param>
        /// <param name="layoutControl"></param>
        private void SetTextEditState(bool readOnly, DevExpress.XtraLayout.LayoutControl layoutControl)
        {
            foreach (Control c in layoutControl.Controls)
            {
                if (c is DevExpress.XtraEditors.TextEdit)
                {
                    var textEdit = c as DevExpress.XtraEditors.TextEdit;
                    textEdit.Properties.ReadOnly = readOnly;
                    textEdit.BackColor = Color.White;
                }
                else if (c is DevExpress.XtraEditors.MemoEdit)
                {
                    var memoEdit = c as DevExpress.XtraEditors.MemoEdit;
                    memoEdit.Properties.ReadOnly = readOnly;
                    memoEdit.BackColor = Color.White;
                }

            }
            txt_School.Properties.ReadOnly = true;
            txt_Group.Properties.ReadOnly = true;
            date_BeginTime.Properties.ReadOnly = true;
            date_EndTime.Properties.ReadOnly = true;
            txt_Subject.Properties.ReadOnly = true;
            txt_CarCount2.Properties.ReadOnly = true;
            txt_CarCount.Properties.ReadOnly = true;
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            _group = new GroupDao().GetModel_ID(_groupid);
            this.txt_School.EditValue = CurrentSchool;
            this.txt_Group.EditValue = CurrentGroup;
            this.date_BeginTime.EditValue = dateTime1.ToString();
            this.date_EndTime.EditValue = dateTime2.ToString();
            this.txt_Subject.EditValue = _group.GroupSubjecttext;
            this.txt_CarCount.EditValue = _group.CarCount;
            this.txt_CarCount2.EditValue = _group.CarCount2;
        }
        #endregion
    }
}