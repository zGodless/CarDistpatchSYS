using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using DS.Model.Base;

namespace DS.Model
{
    /// <summary>
    /// 模块：实体模型
    /// 作用：实体模型类:Option
    /// 作者：zyl
    /// 代码生成日期：2016-08-09
    /// 最后修改人：zyl
    /// 最后修改日期：2016-08-09
    /// 说明：	/// </summary>
    [Serializable]
    public class Option : ModelBase
    {
        #region 基本模型
        /// <summary>
        /// PK,选项编码
        /// </summary>	
        public string OptionCode { get; set; }

        /// <summary>
        /// 选项名称
        /// </summary>	
        public string OptionName { get; set; }

        /// <summary>
        /// 值类型
        /// </summary>	
        public string ValueType { get; set; }

        /// <summary>
        /// 值
        /// </summary>	
        public string Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>	
        public string Description { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>	
        public int? Modifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>	
        public DateTime? ModifyTime { get; set; }

        #endregion 基本模型

        #region 扩展模型

        #endregion 扩展模型
    }
}