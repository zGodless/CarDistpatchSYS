using System.Xml.Serialization;

namespace DS.Model
{
    /// <summary>
    /// 操作状态
    /// 作者：Noly
    /// </summary>
    public enum OperateStatus
    {
        [XmlEnum(Name = "Normal")]
        Normal = 0,
        [XmlEnum(Name = "Add")]
		Add = 1,
		[XmlEnum(Name = "New")]
		New = 1,
        [XmlEnum(Name = "Delete")]
        Delete = 3,
        [XmlEnum(Name = "Modify")]
        Modify = 5,
    }

	/// <summary>
	/// 性别
	/// </summary>
    public enum Gender
    {
        [XmlEnum(Name = "Male")]
        男 = 0,
        [XmlEnum(Name = "Female")]
        女 = 1
    }
}
