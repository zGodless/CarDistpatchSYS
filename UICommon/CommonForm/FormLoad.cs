using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NoHeaderXtraTabControl;
using DevExpress.XtraTreeList;

namespace DS.MSClient.UICommon
{
    /// <summary>
    /// 加载被拉出来的窗体
    /// </summary>
    public partial class FormLoad : FormBlankBase
    {
        #region 初始化
        public FormLoad()
        {
            InitializeComponent();
            this.FormClosed += FormLoad_FormClosed;
        }
        #endregion
        #region 事件

        void FormLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isRemove)
            {
                if (this.Tag != null)
                {
                    var node = Program.ArrHistoryNode.Find(m => m.guid == this.Tag.ToString() && m.Array == 3);
                    Program.ArrHistoryNode.Remove(node);
                    if (Program.HtTreeListHistory.ContainsKey(node.Pid + "列表"))
                    {
                        Program.HtTreeListHistory.Remove(node.Pid + "列表");
                    }
                    //判断是否需要移除父节点
                    var parentnode = Program.ArrHistoryNode.FindAll(m => m.Pid == node.Pid);
                    if (parentnode == null || parentnode.Count() == 0)
                    {
                        var _node = Program.ArrHistoryNode.Find(m => m.Fid == node.Pid);
                        Program.ArrHistoryNode.Remove(_node);
                        this.RefreshHistoryTreeList();
                    }
                }
            }
        }
        #endregion
        public delegate void RefreshHistoryTreeListMethod();
        /// <summary>
        /// 刷新工作列表
        /// </summary>
        public RefreshHistoryTreeListMethod RefreshHistoryTreeList { get; set; }
        public DevExpress.XtraTab.XtraTabControl tabc_Main = null;//主界面工作台 

        #region 拦截最大化等按钮事件

        private int WM_SYSCOMMAND = 0x112;
        private long SC_MAXIMIZE = 0xF030;
        private long SC_MINIMIZE = 0xF020;
        private long SC_CLOSE = 0xF060;
        public bool isRemove = true;
        protected override void WndProc(ref Message m)
        { 
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt64() == SC_MAXIMIZE)//最大化
                {
                    //自定义的tab页面
                    NoHeaderXtraTabControl.MyXtraTabPage page = new MyXtraTabPage();
                    page.Tag = this.Tag;
                    page.Text = this.Text;
                    page.Controls.Add( this.Controls[0]);                   
                    this.tabc_Main.TabPages.Add(page);//最大化后，显示在tab控件内 
                    this.tabc_Main.SelectedTabPage = page;
                    isRemove = false;
                    this.RefreshHistoryTreeList();//刷新工作列表
                    this.Close();

                }
                else if (m.WParam.ToInt64() == SC_MINIMIZE)//最小化
                {
                    if (this.Tag!=null&&!Program.HtMinimizeForm.Contains(this.Tag))
                    {
                        Program.HtMinimizeForm.Add(this.Tag.ToString(), this);//保存最小化窗体
                    }
                }
                else if (m.WParam.ToInt64() == SC_CLOSE)//关闭
                {
                    if (this.Tag != null)//guid
                    {
                        //移除工作列表节点
                        var node = Program.ArrHistoryNode.Find(n => n.guid == this.Tag.ToString() && n.Array == 3);
                        if (node != null)
                        {
                            if (!node.formIsSaved&&MsgBox.ShowYesNo("确定取消编辑，退出吗?") != DialogResult.Yes)
                            {
                                return;
                            }
                            if (node.formRecordID != -1)
                            {
                                FormPageOperation.ClearUserTempData(node.guid, node.formName, node.formRecordID);//清除临时表数据
                            } 
                        }
                    }
                    
                }
            }
            base.WndProc(ref m);
        }  
        #endregion
    }
}
