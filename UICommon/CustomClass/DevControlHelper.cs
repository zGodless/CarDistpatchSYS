using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.MSClient.UICommon
{
    /// 模块：
    /// 作用：DEV控件辅助类（用于自定义DEV控件相关方法）
    /// 作者：phq
    /// 日期： 
    /// 说明：
    public class DevControlHelper
    {
        /// <summary>
        /// grid勾选记录变更
        /// </summary>
        /// <param name="gridView">当前视图（当前要勾选记录的视图）</param>
        /// <param name="fieldName">勾选项字段名称</param>
        /// <param name="currentStatus">勾选状态</param>
        /// <returns></returns>
        public static void GridCheckBoxCheckedChanged(DevExpress.XtraGrid.Views.Grid.GridView gridView, string fieldName, bool currentStatus)
        {
            if (gridView != null)
            {
                gridView.ClearSorting();//禁止排序
                gridView.PostEditor();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    gridView.SetRowCellValue(i, fieldName, currentStatus);
                }

            }
        }
    }
}
