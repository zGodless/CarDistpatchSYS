using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DS.Model.Base
{
    /// <summary>
    /// 作用：该类是所有业务实体的基类。
    /// 作者：Noly Oh
    /// 日期：2015-04-02
    /// </summary>
    [Serializable]
    public abstract class ModelBase : IBase
    {
        public string ID { get; set; }
        private bool _isLock = false;
        private OperateStatus _opStatus = OperateStatus.Normal;
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
        /// (基类)对象的状态
        /// </summary>
		[DisplayName("操作状态"),
        Category("行为"),
        Description("操作状态")]
		public OperateStatus OperateStatus
        {
            get
            {
				return _opStatus;
            }
            set
            {
				_opStatus = value;
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
        public ModelBase Copy()
        {
            var memoryStream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            return (ModelBase)formatter.Deserialize(memoryStream);
        }
    }
}
