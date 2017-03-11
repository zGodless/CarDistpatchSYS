using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace DS.MSClient.UICommon
{
	internal class UIRight
	{
		#region 获取权限

		/// <summary>
		///     根据rightID判断是否有权限
		/// </summary>
		/// <param name="rightID"></param>
		/// <returns></returns>
		public static bool CheckRightByID(string rightID)
		{
            return Program._employeeroleRight.Exists(m => m.Status && m.RightID == rightID);
		}

		#endregion

		#region 文本框是否可见权限

		/// <summary>
		///     设置文本框是否可见权限
		/// </summary>
		/// <param name="text">文本框</param>
		/// <param name="rightID">权限ID</param>
		public static void CheckTextRight(TextEdit text, string rightID)
		{
			text.Visible = CheckRightByID(rightID);
		}

		/// <summary>
		///     检查菜单操作权限[按钮]
		/// </summary>
		/// <param name="textItems"></param>
		/// <param name="rightIDs"></param>
		public static void CheckTextRightRange(TextEdit[] textItems, string[] rightIDs)
		{
			if (textItems.Length != rightIDs.Length) return;
			for (var i = 0; i < textItems.Length; i++)
			{
				if (!textItems[i].Visible) continue;
				CheckTextRight(textItems[i], rightIDs[i]);
			}
		}

		/// <summary>
		///     检查菜单操作权限[按钮]
		/// </summary>
		/// <param name="textItems"></param>
		/// <param name="rightID"></param>
		public static void CheckTextRightRange(TextEdit[] textItems, string rightID)
		{
			foreach (TextEdit t in textItems)
			{
				if (t.Properties.ReadOnly) continue;
				CheckTextRight(t, rightID);
			}
		}

		#endregion

		#region 文本框是否可编辑权限

		/// <summary>
		///     设置文本框是否只读权限
		/// </summary>
		/// <param name="text">文本框</param>
		/// <param name="rightID">权限ID</param>
		public static void CheckTextReadOnlyRight(TextEdit text, string rightID)
		{
			text.Properties.ReadOnly = !CheckRightByID(rightID);
		}

		/// <summary>
		///     检查菜单操作权限[按钮]
		/// </summary>
		/// <param name="textItems"></param>
		/// <param name="rightIDs"></param>
		public static void CheckTextReadOnlyRightRange(TextEdit[] textItems, string[] rightIDs)
		{
			if (textItems.Length != rightIDs.Length) return;
			for (var i = 0; i < textItems.Length; i++)
			{
				if (textItems[i].Properties.ReadOnly) continue;
				CheckTextReadOnlyRight(textItems[i], rightIDs[i]);
			}
		}

		/// <summary>
		///     检查菜单操作权限[按钮]
		/// </summary>
		/// <param name="textItems"></param>
		/// <param name="rightID"></param>
		public static void CheckTextReadOnlyRightRange(TextEdit[] textItems, string rightID)
		{
			foreach (TextEdit t in textItems)
			{
				if (t.Properties.ReadOnly) continue;
				CheckTextReadOnlyRight(t, rightID);
			}
		}

		#endregion

		#region 标签是否可见权限

		/// <summary>
		///     设置Label是否可见权限
		/// </summary>
		/// <param name="label">标签</param>
		/// <param name="rightID">权限ID</param>
		public static void CheckLableRight(LabelControl label, string rightID)
		{
			label.Visible = CheckRightByID(rightID);
		}

		/// <summary>
		///     检查菜单操作权限[按钮]
		/// </summary>
		/// <param name="labelItems"></param>
		/// <param name="rightIDs"></param>
		public static void CheckLableRightRange(LabelControl[] labelItems, string[] rightIDs)
		{
			if (labelItems.Length != rightIDs.Length) return;
			for (var i = 0; i < labelItems.Length; i++)
			{
				if (!labelItems[i].Visible) continue;
				CheckLableRight(labelItems[i], rightIDs[i]);
			}
		}

		#endregion

		#region 菜单(项)/按钮是否可见权限

		/// <summary>
		///     检查菜单操作权限[按钮]
		/// </summary>
		/// <param name="barButtonItem">按钮</param>
		/// <param name="rightID">权限ID</param>
		public static void CheckMenuOperateRight(BarButtonItem barButtonItem, string rightID)
		{
			barButtonItem.Visibility = CheckRightByID(rightID) ? BarItemVisibility.Always : BarItemVisibility.Never;
		}

		/// <summary>
		///     检查菜单操作权限[菜单项]
		/// </summary>
		/// <param name="barSubItem"></param>
		/// <param name="rightID"></param>
		public static void CheckMenuOperateRight(BarSubItem barSubItem, string rightID)
		{
			barSubItem.Visibility = CheckRightByID(rightID) ? BarItemVisibility.Always : BarItemVisibility.Never;
		}

		/// <summary>
		///     检查菜单操作权限[普通按钮]
		/// </summary>
		/// <param name="simpleButton"></param>
		/// <param name="rightID"></param>
		public static void CheckMenuOperateRight(SimpleButton simpleButton, string rightID)
		{
			simpleButton.Enabled = CheckRightByID(rightID);
		}

		/// <summary>
		///     检查菜单操作权限[Layout按钮]
		/// </summary>
		/// <param name="layoutControlitem"></param>
		/// <param name="rightID"></param>
		public static void CheckMenuOperateRight(LayoutControlItem layoutControlitem, string rightID)
		{
			layoutControlitem.Visibility = CheckRightByID(rightID) ? LayoutVisibility.Always : LayoutVisibility.Never;
		}

		/// <summary>
		///     检查菜单操作权限[按钮]
		/// </summary>
		/// <param name="barButtonItems"></param>
		/// <param name="rightIDs"></param>
		public static void CheckMenuOperateRightRange(BarButtonItem[] barButtonItems, string[] rightIDs)
		{
			if (barButtonItems.Length != rightIDs.Length) return;
			for (var i = 0; i < barButtonItems.Length; i++)
			{
				if (barButtonItems[i].Visibility == BarItemVisibility.Never) continue;
				CheckMenuOperateRight(barButtonItems[i], rightIDs[i]);
			}
		}

		/// <summary>
		///     检查菜单操作权限[按钮]字典
		/// </summary>
		/// <param name="barButtonItems"></param>
		/// <param name="rightIDs"></param>
		public static void CheckMenuOperateRightRangeDict(BarButtonItem[] barButtonItems, string[] rightIDs)
		{
			if (barButtonItems.Length != rightIDs.Length) return;
			for (var i = 0; i < barButtonItems.Length; i++)
			{
				CheckMenuOperateRight(barButtonItems[i], rightIDs[i]);
			}
		}

		#endregion
	}
}