using System;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;

namespace DS.MSClient.UICommon
{
    /// <summary>
    /// 作用：该类是所有业务实体的基类。
    /// 作者：Noly Oh
    /// 日期：2015-04-02
    /// </summary>
    [Serializable]
    public abstract class EntityBase : IBase
    {
        public string ID { get; set; }
        private bool _isLock = false;
        private bool _choose = false;

        /// <summary>
        /// (基类)全局唯一标识
        /// </summary>
        /// <summary>
        /// (基类)是否锁定
        /// </summary>
        public bool IsLock
        {
            get
            {
                return _isLock;
            }
            set
            {
                _isLock = value;
            }
        }


        /// <summary>
        /// 是否选中
        /// </summary>
        [XmlIgnore]
        public bool Choose
        {
            get
            {
                return _choose;
            }
            set
            {
                _choose = value;
            }
        }

        /// <summary>
        /// (基类)生成深副本
        /// </summary>
        /// <returns>返回深副本</returns>
        public EntityBase Copy()
        {
            var memoryStream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            return (EntityBase)formatter.Deserialize(memoryStream);
        }
    }
}
