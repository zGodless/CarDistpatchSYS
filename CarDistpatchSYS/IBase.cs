using System;

namespace CarDistpatchSYS
{
    /// <summary>
    /// 模块号：LE0001
    /// 作用：该接口为整个BusinessEntity命名包中的单系接口。
    /// 作者：phq
    /// 日期：2011-12-21
    /// 说明：
    /// </summary>
    public interface IBase
    {
        /// <summary>
        /// 全局唯一标识
        /// </summary>
        string ID { get; set; }
    }
}
