using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DS.MSClient.UIModule;

namespace DS.MSClient.UICommon.CustomClass
{
	static class ControlFontZoomHelper
	{
		/// <summary>
		/// 放大字体（只限GridColumn）
		/// </summary>
		/// <param name="baseFont"></param>
		/// <param name="controls"></param>
		public static void ZoomOutFontSize(Font baseFont, Control.ControlCollection controls)
		{
			foreach (Control control in controls)
			{
				if (control is GridControl)
				{
					var gc = control as GridControl;
					if (gc.Tag != null && gc.Tag.ToString().Contains("nozoom")) continue;
					foreach (BaseView view in gc.ViewCollection)
					{
						if (!(view is GridView)) continue;
						var gv = view as GridView;
						var fontHeight = 0;
						foreach (GridColumn gcl in gv.Columns)
						{
							var fcell = gcl.AppearanceCell.Font;
							if (fcell.Size.Equals(baseFont.Size))
							{
								gcl.AppearanceCell.Font = new Font(fcell.FontFamily, fcell.Size + 1);
							}
							var fhead = gcl.AppearanceHeader.Font;
							if (fhead.Size.Equals(baseFont.Size))
							{
								gcl.AppearanceHeader.Font = new Font(fhead.FontFamily, fhead.Size + 1);
							}
							if (gcl.AppearanceHeader.FontHeight > fontHeight) fontHeight = gcl.AppearanceHeader.FontHeight;
						}
						gv.ColumnPanelRowHeight = fontHeight + 6;
					}
				}
				else if (control.Controls.Count > 0)
				{
					ZoomOutFontSize(baseFont, control.Controls);
				}
			}
		}

		/// <summary>
		/// 放大字体（只限GridColumn）
		/// </summary>
		/// <param name="ctl"></param>
		public static void ZoomOutFontSize(this BaseUserControl ctl)
		{
			ZoomOutFontSize(ctl.Font, ctl.Controls);
		}

		/// <summary>
		/// 放大字体（只限GridColumn）
		/// </summary>
		/// <param name="form"></param>
		public static void ZoomOutFontSize(this XtraForm form)
		{
			ZoomOutFontSize(form.Font, form.Controls);
		}
	}
}
