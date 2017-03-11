using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DS.MSClient.UICommon;
using DS.MSClient.UIModule;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;

namespace DS.MSClient.UIGeneric
{
    static class MainMenu
    {
        /// <summary>
        /// 静态初始化列表
        /// </summary>
        static MainMenu()
        {
            #region 基础配置(1)===========================================================================
            AddItem(1, "01", "系统配置", "01", 15);
            AddItem(2, "0101", "驾校管理");
            AddItem(3, "010101", "驾校管理", "MainSchool");
            AddItem(3, "010102", "部门管理", "MainDepartment");
            AddItem(3, "010103", "员工管理", "MainEmployee");
            AddItem(3, "010104", "配置管理", "MainOption");
            AddItem(2, "0102", "权限");
            AddItem(3, "010201", "角色管理", "MainRole");
            AddItem(3, "010202", "权限管理", "MainRight");
            AddItem(2, "0103", "基础信息");
            AddItem(3, "010301", "职位管理", "MainDuty");
            AddItem(3, "010302", "商品类型", "MainCommoditytype");
            AddItem(3, "010303", "商品管理", "MainCommodity");
            AddItem(3, "010304", "日历", "MainCalendar");
            AddItem(3, "010305", "基础配置", "MainBasicConfig");
            AddItem(3, "010306", "教练教学评价项", "MainEvaluate");
            AddItem(3, "010307", "单据备注", "MainBillNote");
            #endregion 基础配置(1)

            #region 报名管理(02)===========================================================================
            AddItem(1, "02", "报名管理", 28);
            AddItem(2, "0201", "基础字典");
            AddItem(3, "020101", "报名渠道", "MainApplyWay");
            AddItem(3, "020102", "报名地点", "MainApplyPlace");
            AddItem(3, "020103", "接送地点", "MainTakePlace");
            AddItem(3, "020104", "来自何处", "MainFrom");
            AddItem(3, "020105", "收费类型", "MainChargeType");
            AddItem(3, "020106", "收费项目", "MainChargeItem");
            AddItem(3, "020107", "受理项目", "MainAccept");
            AddItem(3, "020108", "培训方式", "MainService");
            AddItem(3, "020109", "培训课程", "MainCourse");
            AddItem(3, "020110", "空闲时间", "MainTrainDate");
            AddItem(3, "020111", "年龄段", "MainAgerange");
            AddItem(3, "020112", "费用收支用途", "MainChargeUse");
            AddItem(3, "020113", "收费策略", "MainStrategy");
            AddItem(2, "0202", "学员信息");
            AddItem(3, "020201", "学员管理", "MainStudent");
            AddItem(2, "0203", "报名管理");
            AddItem(3, "020301", "学员报名管理", "MainChargeRegistration");
            AddItem(3, "020302", "收费移交管理", "MainChargeTransfer");
            AddItem(3, "020303", "驾校分配", "MainSchoolDist");
            AddItem(3, "020304", "分队分配", "MainGroupDist");
            AddItem(3, "020305", "学员培训计划", "MainStudentFollow");
            AddItem(3, "020306", "校区分配", "MainSchoolZoneDist");
            AddItem(3, "020307", "校区分队分配", "MainSchoolZoneGroupDist");
            AddItem(2, "0204", "招生管理");
            AddItem(3, "020401", "学员招生查询", "MainQueryStudentRecruit");
            AddItem(3, "020402", "活动管理", "MainEventManage");
            AddItem(3, "020403", "所有者管理", "MainOwner");
            AddItem(3, "020404", "报名点招生统计", "MainApplyPlaceStatistic");
            #endregion

            #region 预约管理（03）===========================================================================
            AddItem(1, "03", "预约管理", 28);
            AddItem(2, "0301", "科目设置");
            AddItem(3, "030101", "科目管理", "MainSubject");
            AddItem(3, "030102", "科目项目", "MainSubjectItem");
            AddItem(3, "030103", "预约时段", "MainAppointTime");
            AddItem(3, "030104", "预约大类", "MainAppointClass");
            AddItem(3, "030105", "预约大类关联项目", "MainAppointClassSubjectItem");
            AddItem(3, "030106", "分队预约模板", "MainAppointmentTemplate");
            AddItem(3, "030107", "分队大类车辆", "MainGroupAppointClassCar");
            AddItem(3, "030108", "训练计划", "MainWeekPlan");
            AddItem(3, "030109", "预约查询", "MainAppointArrange");
            AddItem(3, "030110", "车辆查询", "MainAppointCar");
            AddItem(3, "030111", "教练查询", "MainAppointEmployee");
            AddItem(3, "030112", "预约限制学员", "MainAppointLimit");
			AddItem(2, "0302", "新版预约");
			AddItem(3, "030201", "计划模板", "MainPlan");
			AddItem(3, "030202", "标准计划", "MainStdPlan");
			AddItem(3, "030203", "增补计划", "MainSubplan");
			AddItem(3, "030204", "预约安排", "MainSchedule");
            #endregion

            #region 场地管理（04）===========================================================================
            AddItem(1, "04", "场地管理", 28);
            AddItem(2, "0401", "场地设置");
            AddItem(3, "040102", "训练场地", "MainTrainPlace");
            AddItem(3, "040103", "训练场地驾校", "MainPlaceSchool");
            AddItem(3, "040104", "分队管理", "MainGroup");
            AddItem(3, "040105", "分队队员", "MainGroupEmployee");
            AddItem(3, "040106", "校区管理", "MainSchoolZone");

            #endregion

            #region 卡券管理（05）===========================================================================
            AddItem(1, "05", "卡券管理", 28);
            AddItem(2, "0501", "卡券");
            AddItem(3, "050101", "卡券", "MainTicket");
            AddItem(3, "050102", "卡券规则", "MainTicketRule");



            #endregion

            #region 业务统计（06）===========================================================================
            AddItem(1, "06", "业务统计", 28);
            AddItem(2, "0601", "考试分析", 28);
            AddItem(3, "060101", "科二分析", "K2ReportForm");
            AddItem(3, "060102", "科三分析", "K3ReportForm");
            AddItem(3, "060103", "学校月考试统计", "SchoolMonthForm");
            AddItem(3, "060104", "自约统计", "AptExamination");
            AddItem(3, "060105", "分队车辆预约统计", "MainGroupStatistic");
            AddItem(3, "060106", "分队预约统计", "MainStatistic");
            AddItem(3, "060107", "考试统计(旧)", "MainEaxmOld");
            AddItem(3, "060108", "驾考统计", "MainCoachStudentScore");
            AddItem(3, "060109", "考试时间间隔统计", "MainExamIntervalStatistic");
            AddItem(3, "060110", "教练合格率招生统计", "MainApplyWayStudentScore");
            AddItem(3, "060111", "驾考统计(新)", "MainCoachStudentScoreNew");
            AddItem(3, "060112", "自约统计(新)", "MainStudentSelfArrange");
            AddItem(3, "060113", "驾考统计(校区)", "MainCoachStudentScoreZone");
            AddItem(2, "0602", "赴约率分析");
            AddItem(3, "060201", "分队赴约率", "MainGroupRate");
            AddItem(3, "060202", "详情统计查询", "MainPlanDetail");
            AddItem(2, "0603", "考核统计");
            AddItem(3, "060301", "考核统计", "MainCheck");
            AddItem(3, "060302", "分队评分统计", "MainCoachEvaluateStatistic");
            AddItem(2, "0604", "校车查询");
            AddItem(3, "060401", "校车查询", "MainShuttle");
            AddItem(2, "0605", "财务报表", 28);
            AddItem(3, "060501", "学员收费日记账", "MainStudentCharge");
            AddItem(3, "060502", "学员收费月报表", "MainStudentChargeMonth");
            AddItem(3, "060503", "学员欠费警示报表", "MainStudentOweWarn");
            AddItem(3, "060504", "招生统计", "MainAdmissions");
			AddItem(3, "060505", "学校收入月报表", "MainSchoolIncome");
            AddItem(3, "060506", "学校收费月报表(旧)", "MainSchoolCharge");
            AddItem(3, "060507", "学校月欠费报表", "MainSchoolOweMonth");
            AddItem(3, "060508", "学校退学月报表", "MainSchoolQuit");
            AddItem(3, "060509", "车辆费用支出月报表", "MainCarExpend");
            AddItem(3, "060510", "费用收支日报表", "MainFeePayment");
            AddItem(3, "060511", "费用收支流水账月报表", "MainFeePaymentMonth");
            AddItem(3, "060512", "季度收入报表", "MainQuarter");
			AddItem(3, "060513", "学校月收入阶段统计", "MainSchoolIncomePeriod");
			AddItem(3, "060514", "学校收费日报表", "MainSchoolDayCharge");
            AddItem(2, "0606", "数据分析", 28);
            AddItem(3, "060601", "教练报班情况", "MainCoachClassReport");
            AddItem(3, "060602", "学员签章统计情况", "MainStudentPeriod");
            AddItem(3, "060603", "教练学员统计", "MainCoachStudent");
            AddItem(3, "060604", "教练学员统计(旧)", "MainCoachStudentOld");
            AddItem(3, "060605", "报名点统计", "MainApplyPlaceStatistics");
            AddItem(3, "060606", "效率统计", "MainTrainingSchedule");
            AddItem(3, "060607", "考试周转率", "MainExamTransformRate");
            AddItem(3, "060608", "教练效率统计", "MainGroupTrainingSchedule");
            AddItem(3, "060609", "教练周转率统计", "MainGroupExamTransformRate");
            AddItem(3, "060610", "流量统计", "MainTotalStatistics");
            AddItem(3, "060611", "实时库存查询", "MainCurrentStatistics");
            AddItem(3, "060612", "考试学员预约统计", "MainExamAppointStatistic");
            AddItem(3, "060613", "教练学员统计(新)", "MainCoachStudentNew");
            #endregion

            #region 工作流设置管理（07）===========================================================================
            AddItem(1, "07", "工作流设置管理", 28);
            AddItem(2, "0701", "工作流设置");
            AddItem(3, "070101", "工作流设置", "MainProcessNode");
            AddItem(3, "070102", "工作流", "MainProcessDefinition");
            #endregion

            #region 财务管理（08）===========================================================================
            AddItem(1, "08", "财务管理", 28);
            AddItem(2, "0801", "财务审核", 28);
            AddItem(3, "080101", "学员收费接收审核", "MainTransferReceive");
            AddItem(3, "080102", "学员收费流水账", "MainChargeRegister");
            AddItem(2, "0802", "学车退款", 28);
            AddItem(3, "080201", "学车退款", "MainDrivePlanRefundment");
            AddItem(2, "0803", "学员相关费用核定", 28);
            AddItem(3, "080301", "费用核销金额核定", "MainFeeAuditApply");
            AddItem(3, "080302", "费用核销金额复核", "MainFeeAuditApplyCheck");
            AddItem(3, "080303", "费用核销项目设置", "MainFeeAuditProject"); 
            AddItem(2, "0804", "费用支出管理", 28);
            AddItem(3, "080401", "费用支出核销申请", "MainaDayBook");
            AddItem(3, "080402", "费用支出核销复核", "MainaDayBookReview");
            AddItem(3, "080403", "费用支出核销审批", "MainDayBookCheck");
            AddItem(3, "080404", "费用支出核销支付", "MainaDayBookPay");
            AddItem(3, "080405", "费用支出查询", "MainFeeOutQuery");
            AddItem(2, "0805", "学员相关费用核销", 28);
            AddItem(3, "080501", "费用核销申请", "MainFeeAudit");
            AddItem(3, "080502", "费用核销审批", "MainFeeAuditCheck");
            AddItem(3, "080503", "费用核销支付", "MainFeeAuditPay");
            AddItem(3, "080504", "费用核销详情", "MainStudentFeeAudit");
            AddItem(2, "0806", "学员退学管理", 28);
            AddItem(3, "080601", "学员退学申请", "MainStudentQuitSchool");
            AddItem(3, "080602", "退学经理审批", "MainManagerCheck");
            AddItem(3, "080603", "退学总经理审批", "MainGeneralManagerCheck");
            AddItem(3, "080604", "退学财务支付", "MainAccountsPay");
            #endregion

            #region 车辆管理（09）===========================================================================
            AddItem(1, "09", "车辆管理", 28);
            AddItem(2, "0900", "车辆管理", 28);
            AddItem(3, "090001", "车辆管理", "MainCar");
            AddItem(2, "0901", "车辆审核", 28);
            AddItem(3, "090101", "车辆费用核销申请", "MainCarExpensesAudit");
            AddItem(3, "090102", "车辆费用核销审批", "MainCarAuditCheck");
            AddItem(3, "090103", "车辆费用核销支付", "MainCarAuditPay");
            AddItem(2, "0902", "车辆加油", 28);
            AddItem(3, "090201", "加油记录管理", "MainCarOil");
            AddItem(2, "0903", "车辆维修", 28);
            AddItem(3, "090301", "维修项目", "MainCarRepairItem");
            AddItem(3, "090302", "维修记录管理", "MainCarRepairRecord");
            AddItem(2, "0904", "车辆保养", 28);
            AddItem(3, "090401", "保养项目", "MainCarMaintainItem");
            AddItem(3, "090402", "保养记录管理", "MainCarMaintainRecord");
            AddItem(2, "0905", "车辆交接管理", 28);
            AddItem(3, "090501", "车辆交接查询", "MainCarHands");
            AddItem(3, "090502", "车辆配件管理", "MainCarParts");
            AddItem(2, "0906", "车辆统计", 28);
            AddItem(3, "090601", "维修保养统计", "MainCarRepairMaintain");
            #endregion

            #region 考试管理（10）===========================================================================
            AddItem(1, "10", "考试管理", 28);
            AddItem(2, "1001", "考试安排", 28);
            AddItem(3, "100101", "考试安排", "MainStudentArrange");
            AddItem(3, "100102", "考试登记", "MainStudentScore");
            AddItem(3, "100103", "考试欠费查询", "MainExamOwnQuery");

            AddItem(2, "1002", "审核", 28);
            AddItem(3, "100201", "预报班审核", "MainForecastClassAudit");
            AddItem(3, "100202", "报班送审", "MainClassAudit");
            AddItem(3, "100203", "运管审核", "MainPipeAudit");
            AddItem(3, "100204", "其他审核", "MainOtherAudit");
            AddItem(3, "100205", "教练送审", "MainPreAudit");
            #endregion

            #region 明细查询（10）===========================================================================
            AddItem(1, "12", "明细查询", 28);
            AddItem(2, "1201", "明细查询", 28);
            AddItem(3, "120101", "收费明细查询", "MainChargeRegister");
            AddItem(3, "120102", "考试查询", "MainStudentScoreQueryForm");
            AddItem(3, "120103", "学生档案查询", "MainStudentQuery");
            AddItem(3, "120104", "预报班查询", "MainPreClassAuditDetail");
            AddItem(3, "120105", "报班查询", "MainClassAuditDetail");
            AddItem(3, "120106", "预约查询", "MainDrivePlanDetail");
            #endregion
        }

        static List<MainMenuItem> _items = new List<MainMenuItem>();

        /// <summary>
        /// 菜单项列表
        /// </summary>
        public static List<MainMenuItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="level">级别</param>
        /// <param name="order">顺序</param>
        /// <param name="text">文本</param>
        /// <param name="mdiName">MID窗口名称</param>
        /// <param name="imageIndex">项头图像索引</param>
        private static void AddItem(int level, string order, string text, string mdiName, int imageIndex = -1)
        {
            if (_items.Find(m => m.Level == level && m.Order == order) != null)
            {
                MsgBox.ShowError("菜单级别与顺序已存在！");
                return;
            }
            var item = new MainMenuItem
            {
                Level = level,
                Order = order,
                ImageIndex = imageIndex,
                Text = text,
                MdiName = mdiName
            };
            _items.Add(item);
        }
        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="level">级别</param>
        /// <param name="order">顺序</param>
        /// <param name="text">文本</param>
        /// <param name="tag">标签</param>
        /// <param name="imageIndex">项头图像索引</param>
        private static void AddItem(int level, string order, string text, int imageIndex = -1)
        {
            AddItem(level, order, text, "", imageIndex);
        }

        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="level">级别</param>
        /// <param name="order">顺序</param>
        /// <param name="text">文本</param>
        /// <param name="headImage">项头图像</param>
        private static void AddItem(int level, string order, string text)
        {
            AddItem(level, order, text, null);
        }

        /// <summary>
        /// 根据顺序获取级别项集合
        /// </summary>
        /// <param name="level">级别</param>
        public static IEnumerable<MainMenuItem> GetLevelItemsByOrder(int level, string order)
        {
            var items = _items.FindAll(m => m.Level == level && m.Order.StartsWith(order));
            items.Sort((m, n) => String.Compare(m.Order, n.Order, StringComparison.Ordinal));
            return items;
        }
        /// <summary>
        /// 根据顺序获取级别项集合
        /// </summary>
        /// <param name="level">级别</param>
        public static IEnumerable<MainMenuItem> GetLevelItemsByOrder(int level)
        {
            var items = _items.FindAll(m => m.Level == level);
            items.Sort((m, n) => String.Compare(m.Order, n.Order, StringComparison.Ordinal));
            return items;
        }
        /// <summary>
        /// 根据级别和顺序获取主菜单项
        /// </summary>
        /// <param name="level">级别</param>
        /// <param name="order">顺序</param>
        /// <returns></returns>
        public static MainMenuItem GetItem(int level, string order)
        {
            return _items.Find(m => m.Level == level && m.Order.StartsWith(order));
        }
    }
    class MainMenuItem
    {
        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public string Order { get; set; }
        /// <summary>
        /// 项头图像索引
        /// </summary>
        public int ImageIndex { get; set; }
        /// <summary>
        /// 导航组
        /// </summary>
        public NavBarGroup NavGroup { get; set; }
        /// <summary>
        /// 项头图像
        /// </summary>
        public Image HeadImage { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// MDI窗口名称
        /// </summary>
        public string MdiName { get; set; }
        /// <summary>
        /// 导航项
        /// </summary>
        public NavBarItem NavItem { get; set; }
        /// <summary>
        /// 导航项链接
        /// </summary>
        public NavBarItemLink NavItemLink { get; set; }
    }
}
