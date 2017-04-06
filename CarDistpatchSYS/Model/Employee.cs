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
    /// 作用：实体模型类:Employee
    /// 作者：zyl
    /// 代码生成日期：2017-03-12
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-12
    /// 说明：	/// </summary>
    [Serializable]
    public class Employee : ModelBase
    {
        #region 基本模型
        /// <summary>
        /// EmployeeID
        /// </summary>	
        public int EmployeeID { get; set; }

        /// <summary>
        /// EmployeeCode
        /// </summary>	
        public string EmployeeCode { get; set; }

        /// <summary>
        /// EmployeeName
        /// </summary>	
        public string EmployeeName { get; set; }

        /// <summary>
        /// DepartmentID
        /// </summary>	
        public int? DepartmentID { get; set; }

        /// <summary>
        /// DutyID
        /// </summary>	
        public int? DutyID { get; set; }

        /// <summary>
        /// Sex
        /// </summary>	
        public string Sex { get; set; }

        /// <summary>
        /// Birthday
        /// </summary>	
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Address
        /// </summary>	
        public string Address { get; set; }

        /// <summary>
        /// IdentityNo
        /// </summary>	
        public string IdentityNo { get; set; }

        /// <summary>
        /// Degree
        /// </summary>	
        public string Degree { get; set; }

        /// <summary>
        /// Cellphone
        /// </summary>	
        public string Cellphone { get; set; }

        /// <summary>
        /// Email
        /// </summary>	
        public string Email { get; set; }

        /// <summary>
        /// QQ
        /// </summary>	
        public string QQ { get; set; }

        /// <summary>
        /// resume
        /// </summary>	
        public string resume { get; set; }

        /// <summary>
        /// EntryDate
        /// </summary>	
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// DimissionDate
        /// </summary>	
        public DateTime? DimissionDate { get; set; }

        /// <summary>
        /// Status
        /// </summary>	
        public int? Status { get; set; }

        /// <summary>
        /// Password
        /// </summary>	
        public string Password { get; set; }

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

        /// <summary>
        /// DriverLicense
        /// </summary>	
        public string DriverLicense { get; set; }

        /// <summary>
        /// DriverLicenseType
        /// </summary>	
        public string DriverLicenseType { get; set; }

        /// <summary>
        /// FileNumber
        /// </summary>	
        public string FileNumber { get; set; }

        #endregion 基本模型

        #region 扩展模型

        public string StatusStr
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "离职";
                    case 2:
                        return "实习";
                    default:
                        return "在职";
                }
            }
        }
        public string DepartmentName { get; set; }


        #endregion 扩展模型
    }
}