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

            //窗体
            pictureClose.Click += pictureClose_Click;
            pictureMin.Click += pictureMin_Click;
            pictureMax.Click += pictureMax_Click;

            //调度
            btnApply.ItemClick += btn_ItemClick;
            banDispath.ItemClick += btn_ItemClick;
            btnAudit.ItemClick += btn_ItemClick;
            btnSend.ItemClick += btn_ItemClick;
            btnReturn.ItemClick += btn_ItemClick;

            //维修
            btnRepair.ItemClick += btn_ItemClick;
            btnRepairItem.ItemClick += btn_ItemClick;

            //统计
            btnReportSend.ItemClick += btn_ItemClick;
            btnReportRepair.ItemClick += btn_ItemClick;


            xtraTabControl2.ControlAdded += xtraTabControl2_ControlAdded;
        }
        public void Init()
        {
            var screenArea = Screen.GetWorkingArea(this);
            MaximumSize = screenArea.Size; //防止遮住任务栏 
            MinimumSize = new Size(500, 400); //最小尺寸
            _normalLocation = new Point((screenArea.Width - Width) / 2, (screenArea.Height - Height) / 2);
            WindowState = FormWindowState.Normal;

            Program.TabcMain = xtraTabControl2;
        }

        #endregion

        #region 属性

        private Point _normalLocation;

        #endregion

        #region 事件
        void FormMain_Load(object sender, EventArgs e)
        {
        }
        void pictureMax_Click(object sender, EventArgs e)
        {
            WindowStateMaximized();
        }

        void pictureMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        void pictureClose_Click(object sender, EventArgs e)
        {
            //退出系统 
            Close();
        }
        void xtraTabControl2_ControlAdded(object sender, ControlEventArgs e)
        {

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
                case "调度审批":
                    {
                        var form = new MainDispathAudit() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("调度审批", form);
                        break;
                    }
                case "派车登记":
                    {
                        var form = new MainCarOutRegistration() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("派车登记", form);
                        break;
                    }
                case "回车管理":
                    {
                        var form = new MainCarriageReturn() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("回车管理", form);
                        break;
                    }
                case "维修项目":
                    {
                        var form = new MainRepairItem() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("维修项目", form);
                        break;
                    }
                case "车辆维修登记":
                    {
                        var form = new MainRepairRecord() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("车辆维修登记", form);
                        break;
                    }
                case "车辆调度统计":
                    {
                        var form = new MainCarReport() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("车辆调度统计", form);
                        break;
                    }
                case "车辆维修统计":
                    {
                        var form = new MainRepairReport() { FormState = CarDistpatchSYS.FormState.New };
                        FormPageOperation.Add_TabPage("车辆维修统计", form);
                        break;
                    }
            }
        }   


        #endregion

        #region 方法
        /// <summary>
        ///     窗体最大化
        /// </summary>
        private void WindowStateMaximized()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                Location = _normalLocation;
            }
            else
            {
                _normalLocation = Location;
                var screenArea = Screen.GetWorkingArea(this);
                MaximumSize = screenArea.Size; //防止遮住任务栏 
                WindowState = FormWindowState.Maximized;
            }
        }
        #endregion


    }
}
