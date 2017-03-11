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
    public class CGridSkinPaintStyle : GridSkinPaintStyle
    {

        public CGridSkinPaintStyle()
        {

        }
        public override BaseViewPainter CreatePainter(BaseView view)
        {
            return new CGridPainter(view as GridView);
        }
    }
}
