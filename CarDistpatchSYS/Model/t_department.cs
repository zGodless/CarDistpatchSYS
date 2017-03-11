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
    /// 作用：实体模型类:Department
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：t_department	/// </summary>
	[Serializable]
	public class Department : ModelBase
	{
		#region 基本模型
		/// <summary>
		/// DepartmentID
		/// </summary>	
		public int DepartmentID { get; set; }

		/// <summary>
		/// DepartmentCode
		/// </summary>	
		public string DepartmentCode { get; set; }

		/// <summary>
		/// DepartmentName
		/// </summary>	
		public string DepartmentName { get; set; }

		/// <summary>
		/// ParentID
		/// </summary>	
		public int? ParentID { get; set; }

		/// <summary>
		/// InChargeID
		/// </summary>	
		public int? InChargeID { get; set; }

		/// <summary>
		/// EmployeeCount
		/// </summary>	
		public int? EmployeeCount { get; set; }

		/// <summary>
		/// Note
		/// </summary>	
		public string Note { get; set; }

		/// <summary>
		/// OperateID
		/// </summary>	
		public int? OperateID { get; set; }

		/// <summary>
		/// OperateTime
		/// </summary>	
		public DateTime? OperateTime { get; set; }

		#endregion 基本模型

		#region 扩展模型

        public string ParentName { get; set; }
        public string InChargeName { get; set; }
		
		#endregion 扩展模型
	}
}