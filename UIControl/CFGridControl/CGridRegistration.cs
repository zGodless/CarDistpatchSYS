using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid;

namespace DS.MSClient.UIControl
{
	public class CGridViewInfoRegistrator : GridInfoRegistrator {
		public override string ViewName { get { return "CGridView"; } }
		public override BaseView CreateView(GridControl grid) { return new CGridView(grid as GridControl); }
		public override BaseViewInfo CreateViewInfo(BaseView view) { return new CGridViewInfo(view as CGridView); } 
		public override BaseViewHandler CreateHandler(BaseView view) { return new CGridHandler(view as CGridView); }

        ViewPaintStyle GetSkinStyle()
        {
            foreach (ViewPaintStyle style in PaintStyles)
            {
                if (style.Name == "Skin")
                    return style;
            }
            return null;
        }

        protected override void RegisterViewPaintStyles()
        {
            base.RegisterViewPaintStyles();
            PaintStyles.Remove(GetSkinStyle());
            PaintStyles.Add(new CGridSkinPaintStyle());
        }
	}
    
}
