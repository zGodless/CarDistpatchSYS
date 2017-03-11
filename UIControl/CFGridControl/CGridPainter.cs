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
    public class CGridPainter : GridPainter
    {
        public CGridPainter(DevExpress.XtraGrid.Views.Grid.GridView view)
            : base(view)
        {

        }


        protected override void DrawColumnPanel(GridViewDrawArgs e)
        {
            (View as CGridView).IsColumnPainting = true;
            base.DrawColumnPanel(e);
            (View as CGridView).IsColumnPainting = false;
        }
    }
}
