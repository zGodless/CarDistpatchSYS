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
    /// 作用：实体模型类:CarRepairRecord
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：t_car_repair_record	/// </summary>
	[Serializable]
	public class CarRepairRecord : ModelBase
	{
		#region 基本模型
		/// <summary>
		/// CarID
		/// </summary>	
		public int? CarID { get; set; }

		/// <summary>
		/// RepairID
		/// </summary>	
		public int RepairID { get; set; }

		/// <summary>
		/// RepairPlace
		/// </summary>	
		public string RepairPlace { get; set; }

		/// <summary>
		/// RepairDate
		/// </summary>	
		public DateTime? RepairDate { get; set; }

		/// <summary>
		/// ItemStr
		/// </summary>	
		public int? ItemStr { get; set; }

		/// <summary>
		/// RepairKil
		/// </summary>	
		public decimal? RepairKil { get; set; }

		/// <summary>
		/// Result
		/// </summary>	
		public string Result { get; set; }

		/// <summary>
		/// PartsCost
		/// </summary>	
		public decimal? PartsCost { get; set; }

		/// <summary>
		/// CreatID
		/// </summary>	
		public int? CreatID { get; set; }

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
        public string CarNo { get; set; }
        public string OperateName { get; set; }
        public string CreatName { get; set; }
        public string RepairName { get; set; }
		
		#endregion 扩展模型
	}
}