using DS.MSClient.UICommon;
using NoHeaderXtraTabControl;
using System.Windows.Forms;
using System;
using System.Linq;
using DevExpress.Utils.Drawing.Helpers;
using QuickFrame.Common.Converter;

namespace DS.MSClient
{
    static class FormPageOperation
    {
        /// <summary>
        /// 清除用户临时数据
        /// </summary>
        /// <param name="guid">guid</param>
        /// <param name="formName">窗体名称</param>
        /// <param name="formRecordID">窗体当前编辑记录id</param>
        public static void ClearUserTempData(string guid, string formName, int formRecordID)
        {
            try
            {
                if (formRecordID == -1) return;
                Cursor.Current = Cursors.WaitCursor;
                switch (formName)
                {
                    //case "FormEditCommerce"://清除商品信息编辑临时表
                    //    EditCommerce_Para inPara = new EditCommerce_Para();
                    //    EditCommerce_Para outPara = null;//返回输出参数     
                    //    inPara.vFlag = "Clear";//清除临时表
                    //    inPara.iCommerceID = formRecordID;//传入当前的记录ID 
                    //    inPara.iOperateID = Program.currentEmployee.EmployeeID;
                    //    inPara.dOperateTime = Convert.ToDateTime(Program.ht_operateTime[guid]);
                    //    new CommerceDAO().EditCommerce(inPara, out outPara);
                    //    break;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static bool FindExistsForm(string FormName, string Tag)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == FormName &&
                    ValueConvert.ToString(Application.OpenForms[i].Tag) == Tag)
                {
                    Application.OpenForms[i].Activate();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static void FormSetMin()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "FormMain")
                {
                    Application.OpenForms[i].WindowState = FormWindowState.Minimized;
                }
                if(Application.OpenForms[i].Tag!=null)
                {
                    if (
                        ValueConvert.ToString(Application.OpenForms[i].Tag)
                            .Contains("Parent:" + ValueConvert.ToString(Program.TabcMain.SelectedTabPage.Tag)))
                    {
                        Application.OpenForms[i].WindowState = FormWindowState.Normal;
                        Application.OpenForms[i].Activate();
                    }
                }
            }
        }
        public static void FormFindMin(string Tag)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Tag != null)
                {
                    if (
                        ValueConvert.ToString(Application.OpenForms[i].Tag)
                            .Contains("Parent:" + Tag))
                    {
                        Application.OpenForms[i].WindowState = FormWindowState.Normal;
                        Application.OpenForms[i].Close();
                    }
                }
            }
        }
        /// <summary>
        /// 更新（历史）工作列表名称
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="name"></param>
        /// <param name="formIsSaved">窗体是否保存</param>
        /// <param name="formRecordID">窗体当前编辑记录id</param>
        public static void UpdateHistoryNodeName(string guid, string name, bool formIsSaved, int formRecordID)
        {
            foreach (CustomStrNode c in Program.ArrHistoryNode)
            {
                if (c.guid == guid)
                {
                    c.formText = name;
                    c.formIsSaved = formIsSaved;
                    c.formRecordID = formRecordID;//当前编辑的记录id,用于关闭窗体的时候清除临时表
                    break;
                }
            }
            Program.MFormMain.treeHistory.RefreshDataSource();
            Program.MFormMain.tluHistoryTreeList.RefreshDataSource();
        }
        /// <summary>
        /// 添加node节点，记忆工作列表
        /// </summary>
        /// <param name="txt">文本</param>
        /// <param name="title">标题</param>
        /// <param name="formIsSaved">窗体是否保存,有用存储过程编辑的，必须填写</param>
        /// <param name="formRecordID">当前窗体编辑记录的ID，有用存储过程编辑的，必须填写</param>
        public static void AddFormNode(object Tag, string guid, string name, string FormName = "", bool formIsSaved = true, int formRecordID = -1)
        {
            try
            {
                if (name != "新建")
                {
                    var _formnode = Program.ArrHistoryNode.Find(m => m.formName == FormName && m.formText == name);
                    if (_formnode != null)
                    {
                        bool isFound = false;//在tabcontrol页面当中是否找到，如果没有找到再去找被最小化的拉出去的窗体了
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
                        if (!isFound)//如果没有找到再去找被最小化的拉出去的窗体了
                        {
                            if (Program.HtMinimizeForm.Contains(_formnode.guid))
                            {
                                FormLoad form = (FormLoad)Program.HtMinimizeForm[_formnode.guid];
                                form.WindowState = FormWindowState.Normal;
                                form.StartPosition = FormStartPosition.CenterScreen;

                                form.Activate();
                            }
                        }
                    }
                    else
                    {
                        var node = Program.ArrHistoryNode.Find(m => m.guid == Tag.ToString() && m.Array == 3);
                        CustomStrNode _node = (CustomStrNode)node.Copy();
                        _node.Array = 3;
                        _node.formName = FormName;
                        _node.formText = name;
                        _node.Fid = guid;
                        _node.Pid = node.Pid;
                        _node.OpenTime = DateTime.Now;
                        _node.guid = _node.Fid;
                        _node.formIsSaved = formIsSaved;//是否保存过,用于关闭的时候判断提醒
                        _node.formRecordID = formRecordID;//当前编辑的记录id,用于关闭窗体的时候清除临时表
                        Program.ArrHistoryNode.Add(_node);
                        Program.TreeListHistory.DataSource = Program.ArrHistoryNode;
                        Program.TreeListHistory.RefreshDataSource();
                        Program.TreeListHistory.Refresh();
                    }
                }
                else
                {
                    var node = Program.ArrHistoryNode.Find(m => m.guid == Tag.ToString() && m.Array == 3);
                    CustomStrNode _node = (CustomStrNode)node.Copy();
                    _node.Array = 3;
                    _node.formText = name;
                    _node.Fid = guid;
                    _node.formName = FormName;
                    _node.formIsSaved = false;//未保存,//是否保存过,用于关闭的时候判断提醒
                    _node.formRecordID = formRecordID;//当前编辑的记录id,用于关闭窗体的时候清除临时表
                    _node.Pid = node.Pid;
                    _node.OpenTime = DateTime.Now;
                    _node.guid = _node.Fid;

                    Program.ArrHistoryNode.Add(_node);
                    Program.TreeListHistory.DataSource = Program.ArrHistoryNode;
                    Program.TreeListHistory.RefreshDataSource();
                    Program.TreeListHistory.Refresh();
                }
            }
            catch
            {
            }
        } 
        /// <summary>
        /// 关闭窗体移除节点
        /// </summary>
        /// <param name="currentForm">当前窗体</param>
        public static void RemovePage(DS.MSClient.UIModule.BaseUserControl currentForm=null)
        {

            if (currentForm != null &&currentForm.Parent!=null&& currentForm.Parent is Form)//父容器是窗体
            {
                ((Form)currentForm.Parent).Close();
            }
            else//父容器是tabpage
            {
                if (Program.TabcMain.SelectedTabPage != null && Program.TabcMain.SelectedTabPageIndex != 0)
                {
                    int currentSelectIndex = Program.TabcMain.SelectedTabPageIndex;
                    if (Program.TabcMain.SelectedTabPage.Tag != null)
                    {
                        FormFindMin(ValueConvert.ToString(Program.TabcMain.SelectedTabPage.Tag));
                        //移除工作列表节点
                        var node = Program.ArrHistoryNode.Find(m => m.guid == Program.TabcMain.SelectedTabPage.Tag.ToString() && m.Array == 3);
                        if (node != null)
                        {
                            if (!node.isForm && Program.HtTreeListHistory.ContainsKey(node.Pid + "列表"))//如果不是编辑窗口,移除防止重复添加列表的key
                            {
                                Program.HtTreeListHistory.Remove(node.Pid + "列表");
                            }
                            Program.ArrHistoryNode.Remove(node);
                            //判断是否需要移除父节点
                            var parentnode = Program.ArrHistoryNode.FindAll(m => m.Pid == node.Pid);
                            if (parentnode == null || parentnode.Count() == 0)
                            {
                                var _node = Program.ArrHistoryNode.Find(m => m.Fid == node.Pid);
                                Program.ArrHistoryNode.Remove(_node);
                            }
                            Program.TreeListHistory.RefreshDataSource();
                            Program.TreeListHistory.Refresh();
                        }
                    }
                    DevExpress.XtraTab.XtraTabPage selectedTabPage = Program.TabcMain.SelectedTabPage;
                    Program.TabcMain.TabPages.Remove(Program.TabcMain.SelectedTabPage);
                    if (selectedTabPage != null)
                    {
                        foreach (System.Windows.Forms.Control tempCtrl in selectedTabPage.Controls)
                        {
                            if (tempCtrl is DevExpress.XtraGrid.GridControl)//移除grid，触发保存grid布局样式事件(此处去掉，grid样式将不能保存)
                            {
                                selectedTabPage.Controls.Remove(tempCtrl);
                            }
                        }
                        selectedTabPage.Dispose();
                    }
                    if (currentSelectIndex <= Program.TabcMain.TabPages.Count - 1)
                    {
                        Program.TabcMain.SelectedTabPageIndex = currentSelectIndex;
                    }
                    else
                    {
                        Program.TabcMain.SelectedTabPageIndex = currentSelectIndex - 1;
                    }

                } 
            } 
        }
    }
}
