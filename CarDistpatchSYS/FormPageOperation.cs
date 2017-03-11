using System.Windows.Forms;
using System;
using System.Linq;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraTab;
using QuickFrame.Common.Converter;
using NoHeaderXtraTabControl;

namespace CarDistpatchSYS
{
    static class FormPageOperation
    {
        public static void Add_TabPage(string str, BaseUserControl myForm) //将标题添加进tabpage中
        {
            if (!tabControlCheckHave(Program.TabcMain, str))
            {
                MyXtraTabPage page = new MyXtraTabPage();
                myForm.BorderStyle = BorderStyle.None;
                myForm.Parent = Program.TabcMain.SelectedTabPage;
                myForm.Dock = DockStyle.Fill;
                page.Text = str;
                page.Controls.Add(myForm);
                Program.TabcMain.TabPages.Add(page);
                Program.TabcMain.SelectedTabPageIndex = ValueConvert.ToInt32(Program.TabcMain.TabPages.Count - 1);
            }
        }
        public static void RemoveTabPage(BaseUserControl myForm) //移除
        {
            if (myForm.Parent != null && myForm.Parent is Form) //父容器是窗体
            {
                ((Form) myForm.Parent).Close();
            }
            else
            {
                Program.TabcMain.TabPages.Remove(Program.TabcMain.SelectedTabPage);
                Program.TabcMain.SelectedTabPageIndex = Program.TabcMain.TabPages.Count - 1;
            }
        }
        public static bool tabControlCheckHave(DevExpress.XtraTab.XtraTabControl tab, string tabName) //看tabpage中是否已有窗体
        {
            for (int i = 0; i < tab.TabPages.Count; i++)
            {
                if (tab.TabPages[i].Text == tabName)
                {
                    tab.SelectedTabPageIndex = i;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 添加node节点，记忆工作列表
        /// </summary>
        public static void AddFormNode(object Tag, string guid, string name, string FormName = "", bool formIsSaved = true, int formRecordID = -1)
        {
            try
            {
                if (name != "新建")
                {
                    var _formnode = Program.ArrHistoryNode.Find(m => m.formName == FormName && m.formText == name);
                    if (_formnode != null)
                    {
                        bool isFound = false; //在tabcontrol页面当中是否找到，如果没有找到再去找被最小化的拉出去的窗体了
                        foreach (MyXtraTabPage page in Program.TabcMain.TabPages)
                        {
                            if (page.Tag != null)
                            {
                                if (page.Tag.ToString() == _formnode.guid)
                                {
                                    Program.TabcMain.SelectedTabPage = page;
                                    isFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    
                }
            }
            catch
            {
            }
        } 
    }
}
