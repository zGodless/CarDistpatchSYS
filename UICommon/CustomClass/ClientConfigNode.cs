using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DS.MSClient.UICommon
{
    public class ClientConfigNode : ConfigBase
    {

        /// <summary>
        /// 关键字
        /// </summary>
        [XmlAttribute("Key"),
        DisplayName("关键字"),
        Category("1.一般信息"),
        Description("")]
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [XmlAttribute("Value"),
        DisplayName("值"),
        Category("1.一般信息"),
        Description("")]
        public string Value { get; set; }
    }
}
