using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using DS.Model.Base;

namespace CarDistpatchSYS
{
	/// <summary>
	/// 模块：实体模型
    /// 作用：实体模型类:CarDispatch
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：t_car_dispatch	/// </summary>
	[Serializable]
	public class CarDispatch : ModelBase
	{
		#region 基本模型
		/// <summary>
		/// DispatchID
		/// </summary>	
		public int DispatchID { get; set; }

		/// <summary>
		/// EmployeeID
		/// </summary>	
		public int? EmployeeID { get; set; }

		/// <summary>
		/// DispatchReason
		/// </summary>	
		public string DispatchReason { get; set; }

		/// <summary>
		/// CarID
		/// </summary>	
		public int? CarID { get; set; }

		/// <summary>
		/// ApplyDate
		/// </summary>	
		public DateTime? ApplyDate { get; set; }

		/// <summary>
		/// AuditDate
		/// </summary>	
		public DateTime? AuditDate { get; set; }

		/// <summary>
		/// RegistraDate
		/// </summary>	
		public DateTime? RegistraDate { get; set; }

		/// <summary>
		/// PlaceBackDate
		/// </summary>	
		public DateTime? PlaceBackDate { get; set; }

		/// <summary>
		/// ReturnDate
		/// </summary>	
		public DateTime? ReturnDate { get; set; }

		/// <summary>
		/// IntervalDate
		/// </summary>	
		public int? IntervalDate { get; set; }

		/// <summary>
		/// Status
		/// </summary>	
		public int? Status { get; set; }

		/// <summary>
		/// Note
		/// </summary>	
		public string Note { get; set; }

		/// <summary>
		/// OperatorID
		/// </summary>	
		public int? OperatorID { get; set; }

		/// <summary>
		/// OperateTime
		/// </summary>	
		public DateTime? OperateTime { get; set; }

		#endregion 基本模型

		#region 扩展模型

        public string StatusStr
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "申请中";
                    case 1:
                        return "审批通过";
                    case 2:
                        return "审批不通过";
                    case 3:
                        return "使用中";
                    default:
                        return "审批不通过";
                }
            }
        }

        public string EmployeeName { get; set; }
        public string OperatorName { get; set; }
        public string CarNo { get; set; }

		#endregion 扩展模型
	}
}