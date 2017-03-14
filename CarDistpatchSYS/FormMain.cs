using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraTab;
using DS.MSClient;
using NoHeaderXtraTabControl;

namespace CarDistpatchSYS
{
    public partial class FormMain : FormBase
    {
        #region 初始化
        public FormMain()
        {
            InitializeComponent();
            InitEvent();
            Init();
        }

        private void InitEvent()
        {
            Load += FormMain_Load;
            //基础信息
            btncar.ItemClick += btn_ItemClick;
            btnDepartment.ItemClick += btn_ItemClick;
            btnEmployee.ItemClick += btn_ItemClick;
            btnDuty.ItemClick += btn_ItemClick;

            //调度
            btnApply.ItemClick += btn_ItemClick;
            banDispath.ItemClick += btn_ItemClick;
            btnAudit.ItemClick += btn_ItemClick;
            btnSend.ItemClick += btn_ItemClick;
            btnReturn.ItemClick += btn_ItemClick;

            xtraTabControl2.ControlAdded += xtraTabControl2_ControlAdded;
        }


        void xtraTabControl2_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void Init()
        {
            Program.TabcMain = xtraTabControl2;
        }
        
        

        void btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Caption.Trim())
            {
                case "车辆管理":
                    {
                        var form = new MainCar() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("车辆信息", form);
                        break;
                    }
                case "部门管理":
                    {
                        var form = new MainDepartment() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("部门管理", form);
                        break;
                    }
                case "员工管理":
                    {
                        var form = new MainEmployee() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("员工管理", form);
                        break;
                    }
                case "职位":
                    {
                        var form = new MainDuty() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("职位", form);
                        break;
                    }
                case "申请用车":
                    {
                        var form = new MainCarApply() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("申请用车", form);
                        break;
                    }
            }
        }   

        //移除子tab
        void form_TabRemove(BaseUserControl myForm, string formName)
        {
            if (xtraTabControl2.SelectedTabPage.Text == formName)
            {
                int index = xtraTabControl2.SelectedTabPageIndex - 1;
                Program.TabcMain.TabPages.Remove(xtraTabControl2.SelectedTabPage);
                xtraTabControl2.TabPages.Remove(xtraTabControl2.SelectedTabPage);
                xtraTabControl2.SelectedTabPageIndex = index;
            }
        }
        #endregion

        #region 事件
        void FormMain_Load(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
