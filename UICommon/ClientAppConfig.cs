using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DS.MSClient.UICommon
{
    public class ClientAppConfig : ConfigBase
    {
        private List<ClientConfigNode> _NodeList = new List<ClientConfigNode>();
        private List<ClientConfigNode> _UsedUserControls = new List<ClientConfigNode>();
        private List<ClientConfigNode> _UsedUserName = new List<ClientConfigNode>();

        /// <summary>
        /// 配置文件列表
        /// </summary>
        [XmlElement("AppConfigNode"),
        Browsable(false)]
        public List<ClientConfigNode> NodeList
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
        /// 曾经使用过的组件列表
        /// </summary>
        [XmlElement("UsedUserControl"),
        Browsable(false)]
        public List<ClientConfigNode> UsedUserControls
        {
            get
            {
                return _UsedUserControls;
            }
            set
            {
                _UsedUserControls = value;
            }
        }



        /// <summary>
        /// 曾经使用过的用户名
        /// </summary>
        [XmlElement("UsedUserName"),
        Browsable(false)]
        public List<ClientConfigNode> UsedUserNames
        {
            get
            {
                return _UsedUserName;
            }
            set
            {
                _UsedUserName = value;
            }
        }



        /// <summary>
        /// 获取配置文件的值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="attribute">属性名</param>
        /// <returns></returns>
        public string GetKeyValue(string key)
        {
            for (var i = 0; i < NodeList.Count; i++)
            {
                if (NodeList[i].Key == key)
                {
                    return NodeList[i].Value;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 设置配置文件的值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="attribute">属性名</param>
        /// <returns></returns>
        public void SetKeyValue(string key, string Value)
        {
            var exit = false;
            for (var i = 0; i < NodeList.Count; i++)
            {
                if (NodeList[i].Key == key)
                {
                    NodeList[i].Value = Value;
                    exit = true;
                    break;
                }
            }
            if (!exit)
            {
                var node = new ClientConfigNode();
                node.Key = key;
                node.Value = Value;
                NodeList.Add(node);
            }
        }
        /// <summary>
        /// 增加曾经用过的用户控件节点
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="attribute">属性名</param>
        /// <returns></returns>
        public void AddUsedUserControls(string tag, string caption)
        {
            for (var i = 0; i < UsedUserControls.Count; i++)
            {
                if (UsedUserControls[i].Key == tag)
                {
                    UsedUserControls.RemoveAt(i);
                    break;
                }
            }
            var node = new ClientConfigNode();
            node.Key = tag;
            node.Value = caption;
            UsedUserControls.Add(node);
            if (UsedUserControls.Count > 12)
            {
                UsedUserControls.RemoveAt(0);
            }
        }

        /// <summary>
        /// 增加使用过的用户名
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public void AddUsedUserName(string userName)
        {
            for (var i = 0; i < UsedUserNames.Count; i++)
            {
                if (UsedUserNames[i].Value == userName)
                {
                    UsedUserNames.RemoveAt(i);
                    break;
                }
            }
            var node = new ClientConfigNode();
            node.Key = "UserName";
            node.Value = userName;
            UsedUserNames.Add(node);
            if (UsedUserNames.Count > 6)
            {
                UsedUserNames.RemoveAt(0);
            }
        }

        /// <summary>
        /// 删除所有使用过的用户
        /// </summary>
        public void DeleteAllUser()
        {
            UsedUserNames.Clear();
        }
    }
}
