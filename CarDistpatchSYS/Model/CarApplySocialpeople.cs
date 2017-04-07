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
    /// 作用：实体模型类:CarApplySocialpeople
    /// 作者：zyl
    /// 代码生成日期：2017-04-08
    /// 最后修改人：zyl
    /// 最后修改日期：2017-04-08
    /// 说明：	/// </summary>
    [Serializable]
    public class CarApplySocialpeople : ModelBase
    {
        #region 基本模型
        /// <summary>
        /// SocialPeopleID
        /// </summary>	
        public int SocialPeopleID { get; set; }

        /// <summary>
        /// ApplyID
        /// </summary>	
        public int? ApplyID { get; set; }

        /// <summary>
        /// Name
        /// </summary>	
        public string Name { get; set; }

        /// <summary>
        /// IdentityNo
        /// </summary>	
        public string IdentityNo { get; set; }

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

        #endregion 扩展模型
    }
}