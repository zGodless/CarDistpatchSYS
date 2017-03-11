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
    /// 作用：实体模型类:CarDispatchApply
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：t_car_dispatch_apply	/// </summary>
	[Serializable]
	public class CarDispatchApply : ModelBase
	{
		#region 基本模型
		/// <summary>
		/// ApplyID
		/// </summary>	
		public int ApplyID { get; set; }

		/// <summary>
		/// DispatchID
		/// </summary>	
		public int? DispatchID { get; set; }

		/// <summary>
		/// EmployeeID
		/// </summary>	
		public int? EmployeeID { get; set; }

		/// <summary>
		/// ApplyDate
		/// </summary>	
		public DateTime? ApplyDate { get; set; }

		/// <summary>
		/// CarID
		/// </summary>	
		public int? CarID { get; set; }

		/// <summary>
		/// DispatchReason
		/// </summary>	
		public string DispatchReason { get; set; }

		/// <summary>
		/// PlaceBackDate
		/// </summary>	
		public DateTime? PlaceBackDate { get; set; }

		/// <summary>
		/// CarBackDate
		/// </summary>	
		public DateTime? CarBackDate { get; set; }

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
		
		#endregion 扩展模型
	}
}