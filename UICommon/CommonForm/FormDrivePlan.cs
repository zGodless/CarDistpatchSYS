using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DS.Data;
using DS.Model;

namespace DS.MSClient.UICommon
{
    /// <summary>
    /// 预约记录
    /// </summary>
    public partial class FormDrivePlan : FormBase
    {
        public FormDrivePlan()
        {
            InitializeComponent();
            InitEvent();
        }
        #region 初始化
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            this.rbtn_Cancel.Click += rbtn_Cancel_Click;
            this.gv_DrivePlan.FocusedRowChanged += gv_DrivePlan_FocusedRowChanged;
            this.gv_DrivePlan.MouseUp += gv_DrivePlan_MouseUp;
        }

        void gv_DrivePlan_MouseUp(object sender, MouseEventArgs e)
        {
            if (gv_DrivePlan.FocusedColumn == gridColumn_Code)
            {

                bool result = new DrivePlanDao().BuildDriveCode(_current.DrivePlanID);
                if (result)
                {
                    MsgBox.ShowInfo("学车码生成成功！");
                    _listDriveplay = new DrivePlanDao().GetListStudentId(_studentid);
                    gc_DrivePlan.DataSource = null;
                    gc_DrivePlan.DataSource = _listDriveplay;
                    gc_DrivePlan.RefreshDataSource();
                }
            }
        }

        void gv_DrivePlan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _current = (DrivePlan)this.gv_DrivePlan.GetFocusedRow();
        }
        #endregion
        #region 属性

        public List<DrivePlan> _listDriveplay = new List<DrivePlan>();
        public DrivePlan _current = null;
        public Student _student;
        public int iDrivePlanID = 0;
        public int iType = 0;
        public int _studentid = 0;
        #endregion
        #region 事件
        void rbtn_Cancel_Click(object sender, EventArgs e)
        {
            if (_current.DrivePlanID != 0)
            {
                FormStudentOrSchool form = new FormStudentOrSchool();
                if (form.ShowDialog(this) == DialogResult.Yes)
                {
					if (form.IsStudent.Checked) //学员取消预约
                    {
                        CancelSale3_Para para = new CancelSale3_Para();
                        CancelSale3_Para outPara = null;//返回输出参数    
                        para.iDrivePlanID = _current.DrivePlanID;
                        para.iType = 3;

                        bool result = new StudentDAO().CancelSaleStudent(para, out outPara);
                        if (result)
                        {
                            MsgBox.ShowInfo(outPara.vReturnValue);
                        }
                        else
                        {
                            MsgBox.ShowInfo(outPara.vReturnValue);
                        }
                    }
					else if (form.IsCoach.Checked)  //教练取消预约
                    {
                        CancelSale_Para para = new CancelSale_Para();
                        CancelSale_Para outPara = null;//返回输出参数    
                        para.iDrivePlanID = _current.DrivePlanID;
                        para.iType = 2;

                        bool result = new StudentDAO().CancelSale(para, out outPara);
                        if (result)
                        {
                            MsgBox.ShowInfo(outPara.vReturnValue);
                        }
                        else
                        {
                            MsgBox.ShowInfo(outPara.vReturnValue);
                        }
                    }
                    _listDriveplay = new DrivePlanDao().GetListStudentId(_studentid);
                    gc_DrivePlan.DataSource = null;
                    gc_DrivePlan.DataSource = _listDriveplay;
                    gc_DrivePlan.RefreshDataSource();
                }
                else
                {
                    return;
                }
            }
        }
        #endregion
        #region 方法

        public FormDrivePlan OpenSaleDetail(int studentid)
        {
            this._studentid = studentid;
            _listDriveplay = new DrivePlanDao().GetListStudentId(studentid);
            if (_listDriveplay.Count <= 0)
            {
                MsgBox.ShowInfo("该学生没有预约记录！");
            }
            else
            {
                this.gc_DrivePlan.DataSource = _listDriveplay;
                this.Show();
            }
            return this;
        }

        #endregion


    }
}
