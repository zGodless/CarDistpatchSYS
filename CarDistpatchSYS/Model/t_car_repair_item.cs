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
    /// 作用：实体模型类:CarRepairItem
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：t_car_repair_item	/// </summary>
	[Serializable]
	public class CarRepairItem : ModelBase
	{
		#region 基本模型
		/// <summary>
		/// ItemID
		/// </summary>	
		public int ItemID { get; set; }

		/// <summary>
		/// RepairName
		/// </summary>	
		public string RepairName { get; set; }

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


	    #endregion 扩展模型
	}
}