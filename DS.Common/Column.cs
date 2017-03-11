namespace DS.Common
{
    public class Column
    {
        public Column()
        {
        }

        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnEditName { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// grid控件字段显示的顺序索引
        /// </summary>
        public int VisibleIndex { get; set; }
        /// <summary>
        /// 字段顺序
        /// </summary>
        public int ColumnIndex { get; set; }
        /// <summary>
        /// 冻结类型：left,right,null
        /// </summary>
        public string FixedStyle { get; set; }
    }
}
