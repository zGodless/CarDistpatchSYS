﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using DS.Model.Base;

namespace CarDistpatchSYS
{
	/// <summary>
	/// 模块：实体模型
    /// 作用：实体模型类:CarOutRegistration
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：t_car_out_registration	/// </summary>
	[Serializable]
	public class CarOutRegistration : ModelBase
	{
		#region 基本模型
		/// <summary>
		/// RegistraID
		/// </summary>	
		public int RegistraID { get; set; }

		/// <summary>
		/// DispatchID
		/// </summary>	
		public int? DispatchID { get; set; }

		/// <summary>
		/// CarID
		/// </summary>	
		public int? CarID { get; set; }

		/// <summary>
		/// RegistraDate
		/// </summary>	
		public DateTime? RegistraDate { get; set; }

		/// <summary>
		/// EmployeeID
		/// </summary>	
		public int? EmployeeID { get; set; }

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

        public string EmployeeName { get; set; }

        public string OperatorName { get; set; }
        public string CarNo { get; set; }

		
		#endregion 扩展模型
	}
}