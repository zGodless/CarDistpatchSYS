using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using QuickFrame.UI.Touch.Resources;

namespace QuickFrame.UI.Touch
{
	public class QfTouchWindow : Window
	{
		public QfTouchWindow()
		{
			Resources.MergedDictionaries.Add(new ResourceDictionary());
			Style = (Style)FindResource("QfTouchWindowStyle");
		}
	}
}
