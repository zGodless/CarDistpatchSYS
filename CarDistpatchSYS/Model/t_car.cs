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
    /// 作用：实体模型类:Car
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：t_car	/// </summary>
	[Serializable]
	public class Car : ModelBase
	{
		#region 基本模型
		/// <summary>
		/// CarID
		/// </summary>	
		public int CarID { get; set; }

		/// <summary>
		/// CarModel
		/// </summary>	
		public string CarModel { get; set; }

		/// <summary>
		/// CarNo
		/// </summary>	
		public string CarNo { get; set; }

		/// <summary>
		/// DepartmentID
		/// </summary>	
		public int? DepartmentID { get; set; }

		/// <summary>
		/// Status
		/// </summary>	
		public int? Status { get; set; }

		/// <summary>
		/// ServiceTime
		/// </summary>	
		public DateTime? ServiceTime { get; set; }

		/// <summary>
		/// BuyTime
		/// </summary>	
		public DateTime? BuyTime { get; set; }

		/// <summary>
		/// LicenseCode
		/// </summary>	
		public string LicenseCode { get; set; }

		/// <summary>
		/// LicenseExpireDate
		/// </summary>	
		public DateTime? LicenseExpireDate { get; set; }

		/// <summary>
		/// EmployeeID
		/// </summary>	
		public int? EmployeeID { get; set; }

		/// <summary>
		/// Brand
		/// </summary>	
		public string Brand { get; set; }

		/// <summary>
		/// OwnerID
		/// </summary>	
		public int? OwnerID { get; set; }

		/// <summary>
		/// FuelType
		/// </summary>	
		public string FuelType { get; set; }

		/// <summary>
		/// EngineNumber
		/// </summary>	
		public string EngineNumber { get; set; }

		/// <summary>
		/// ChassisNumber
		/// </summary>	
		public string ChassisNumber { get; set; }

		/// <summary>
		/// YearCheckExpDate
		/// </summary>	
		public DateTime? YearCheckExpDate { get; set; }

		/// <summary>
		/// CurrentKil
		/// </summary>	
		public decimal? CurrentKil { get; set; }

		/// <summary>
		/// RepairExpenses
		/// </summary>	
		public decimal? RepairExpenses { get; set; }

		/// <summary>
		/// MaintenanceExp
		/// </summary>	
		public decimal? MaintenanceExp { get; set; }

		/// <summary>
		/// OilExpenses
		/// </summary>	
		public decimal? OilExpenses { get; set; }

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
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }

	    public string StatusStr
	    {
	        get
	        {
	            switch (Status)
	            {
                    case 1:
	                    return "在用";
                    case 2:
	                    return "维修中";
                    case 3:
	                    return "借出";
                    case null:
	                    return null;
                    default:
	                    return "报废";
	            }
	        }
	    }
        public string OwnerName { get; set; }

	    #endregion 扩展模型
	}
}