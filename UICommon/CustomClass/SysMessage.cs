using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DS.MSClient.UICommon
{
    public class SysMessage : ConfigBase
    {
        private List<SysMessageNode> _NodeList = new List<SysMessageNode>();

        /// <summary>
        /// 系统消息列表
        /// </summary>
        [XmlElement("SysMessageNode"),
        Browsable(false)]
        public List<SysMessageNode> NodeList
        {
            get
            {
                return _NodeList;
            }
            set
            {
                _NodeList = value;
            }
        }

        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns>最大ID</returns>
        public int getMaxID()
        {
            var id = 0;
            for (var i = 0; i < _NodeList.Count; i++)
            {
                if (_NodeList[i].Key > id)
                {
                    id = _NodeList[i].Key;
                }
            }
            return id;
        }

        /// <summary>
        /// 删除过期的数据
        /// </summary>
        public void DeleteOrderMessage()
        {
            for (var i = 0; i < NodeList.Count; i++)
            {
                NodeList.RemoveAt(i);
                i--;
            }
        }

        /// <summary>
        /// 增加一个新的消息记录到消息记录系统中
        /// </summary>
        /// <param name="msg">消息记录对象</param>
    }
}
