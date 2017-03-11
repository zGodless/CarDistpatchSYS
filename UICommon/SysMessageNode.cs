using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DS.MSClient.UICommon
{
    public class SysMessageNode : ConfigBase
    {

        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime ValidDate { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public string NoticePeople { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime NoticeTime { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        [XmlAttribute("Key"),
        DisplayName("关键字"),
        Category("1.一般信息"),
        Description("")]
        public int Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [XmlAttribute("Content"),
        DisplayName("值"),
        Category("1.一般信息"),
        Description("")]
        public string Content { get; set; }
    }
}
