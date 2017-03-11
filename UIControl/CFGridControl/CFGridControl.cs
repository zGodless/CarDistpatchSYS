using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DS.MSClient.UIControl
{
    /// <summary>
    /// 带自定义字段GridControl控件
    /// 1、增加加载、保存grid样式方法
    /// 2、携带自定义字段列，用于扩展
    /// </summary>
    [System.ComponentModel.DesignerCategory("")]
    [ToolboxItem(true)]
    public class CFGridControl : CGridControl
    {
        
		protected override BaseView CreateDefaultView() {
             
            return CreateView("CGridView");
		}
		protected override void RegisterAvailableViewsCore(InfoCollection collection) {
			base.RegisterAvailableViewsCore(collection);
			collection.Add(new CGridViewInfoRegistrator());
        } 
    }
}
