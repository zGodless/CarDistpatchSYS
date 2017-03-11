using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.Data;
using DS.Model;

namespace DS.MSClient.UICommon
{ 
    /// <summary>
    /// 设置权限
    /// </summary>
    public partial class FormRightSetRole : FormBase
    {
        public FormRightSetRole()
        {
            InitializeComponent();
            this.Init();
            this.InitEvent();
        }
        #region 初始化

        private void Init()
        {

        }

        private void InitEvent()
        {
            this.simpleButton_no.Click += Btn_Cancel_Click;
            this.simpleButton_yes.Click += Btn_Ok_Click;
            this.Load += FormRightSetRole_Load;
            this.trl_Left.CellValueChanging += trl_Left_CellValueChanging;
        }



        #endregion

        #region 属性

        public int RoleId = 0;//角色权限id

        private Right right = null;
        private List<Right> rightList = null;

        private RoleRight roleRight = null;
        private List<RoleRight> roleRightList = null;

        #endregion

        #region  事件
        /// <summary>
        /// 装载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormRightSetRole_Load(object sender, EventArgs e)
        {
            if (RoleId > 0) { Role roles = new RoleDao().GetModel(RoleId); if (roles != null) { lbl_RoleName.Text = "所设角色：" + roles.RoleName; } }
            this.LoadData();
            this.LoadRightData();
        }

        void Btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                /* 清空原有数据 */
                new RoleRightDao().DeleteWithRoleId(RoleId);
                string StrRightID = null;
                /* 新增新的数据 */
                var chooseRow = rightList.FindAll(m => m.Choose == true);
                //foreach (Right rig in rightList)
                //{
                //    if (rig.Choose)
                //    {
                //    }
                //}
              StrRightID=string.Join(",",chooseRow.Select(n=>n.RightID));
             
                RoleRight ri = new RoleRight();
                ri.ModifierID = Program.CurrentEmployee.EmployeeID;
                ri.ModifyTime = DateTime.Now;
                ri.StrRightID = StrRightID;
                ri.RoleID = RoleId;
                if (StrRightID == null) return;
               bool results= new RoleRightDao().AddList(ri);
                if(results)
                MsgBox.ShowInfo("权限设置成功", "提示");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        void trl_Left_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.Name.Equals("treeListColumn1") && e.Node.HasChildren)
            {
                bool value = (bool)e.Value;
                Right tempRight = (Right)this.trl_Left.GetDataRecordByNode(e.Node);

                tempRight.Choose = value;
                bool hasChild = false;
                Right parentRight = null;
                for (int i = 0; i < this.rightList.Count; i++)
                {
                    if (rightList[i].RightID.StartsWith(tempRight.RightID))
                    {
                        rightList[i].Choose = value;
                    }
                    if (rightList[i].RightID == tempRight.ParentID)
                    {
                        parentRight = rightList[i];//记住父亲节点
                    }
                    if (!value)//如果是去勾选的情况，需要判断儿子节点全部取消勾选的情况，这时父亲节点也应去勾选
                    {
                        if (rightList[i].ParentID == tempRight.ParentID && rightList[i].Choose == true)
                        {
                            hasChild = true;//判断同个父亲的节点是否有勾选的情况
                        }
                    }
                }
                if (!value && !hasChild)//如果点击当前节点去勾选，并且所有兄弟都没有勾选，则父亲节点去掉勾选
                {
                    //if(parentRight!=null)
                    // parentRight.State = false;
                }
                else if (value)
                {
                    SetParentNodeState(e.Node);//设置父亲节点选中状态
                }
                this.trl_Left.RefreshDataSource();
            }
        }

        private void RoleClick(Right right, bool checks)
        {
            foreach (Right ri in rightList)
            {
                if (ri.ParentID == right.RightID) { ri.Choose = checks; RoleClick(ri, checks); }
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 设置父亲节点选中状态
        /// </summary>
        /// <param name="tn"></param>
        private void SetParentNodeState(DevExpress.XtraTreeList.Nodes.TreeListNode tn)
        {
            if (tn != null)
            {
                if (tn.ParentNode != null)
                {
                    Right tempRight = (Right)this.trl_Left.GetDataRecordByNode(tn.ParentNode);
                    tempRight.Choose = true;
                    SetParentNodeState(tn.ParentNode);
                }
            }
        }
        private void LoadData()
        {
            try
            {
                trl_Left.BeginUpdate();

                trl_Left.RowHeight = 20;
                trl_Left.Padding = new Padding(3, 4, 2, 2);
                //trl_Left.SelectImageList = Client.Controls.StaticImageList.Instance.ImageList_global;

                rightList = new RightDao().GetList();

                trl_Left.Nodes.Clear();
                trl_Left.DataSource = null;
                trl_Left.DataSource = rightList;
                trl_Left.KeyFieldName = "RightID";
                trl_Left.ParentFieldName = "ParentID";
                trl_Left.OptionsBehavior.Editable = true;
                trl_Left.RefreshDataSource();
                trl_Left.ExpandToLevel(0);
                //trl_Left.ExpandToLevel(0);
                trl_Left.EndUpdate();
            }
            catch { }
        }

        /// <summary>
        /// 装载已经设置的权限值
        /// </summary>
        private void LoadRightData()
        {
            if (RoleId > 0)
            {
                roleRightList = new RoleRightDao().GetList(RoleId);
                foreach (RoleRight right in roleRightList)
                {
                    CheckRightData(right);
                }
                trl_Left.DataSource = null;
                trl_Left.DataSource = rightList;
                trl_Left.ExpandToLevel(0);
                //trl_Left.ExpandAll();
                trl_Left.RefreshDataSource();
            }
        }

        private void CheckRightData(RoleRight roleRight)
        {
            foreach (Right right in rightList)
            {
                if (right.RightID == roleRight.RightID) { right.Choose = true; }
            }

        }

        #endregion

      
    }
}
