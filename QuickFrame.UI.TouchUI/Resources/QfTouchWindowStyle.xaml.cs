using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace QuickFrame.UI.Touch.Resources
{
	/// <summary>
	/// 关闭行为
	/// </summary>
	public class CloseBehavior : Behavior<Border>
	{
		public static readonly DependencyProperty StoryboardProperty =
		   DependencyProperty.Register("Storyboard", typeof(Storyboard), typeof(CloseBehavior), new PropertyMetadata(default(Storyboard)));

		private Window _window;

		public Storyboard Storyboard
		{
			get { return (Storyboard)GetValue(StoryboardProperty); }
			set { SetValue(StoryboardProperty, value); }
		}

		protected override void OnAttached()
		{
			base.OnAttached();
			_window = (Window) AssociatedObject.TemplatedParent;
			_window.Closing += OnWindowClosing;
		}

		private void OnWindowClosing(object sender, CancelEventArgs e)
		{
			if (Storyboard == null) return;
			e.Cancel = true;
			_window.Closing -= OnWindowClosing;
			if (Storyboard.IsFrozen) Storyboard = Storyboard.Clone();
			Storyboard.Completed += (o, a) => _window.Close();
			Storyboard.Begin(AssociatedObject);
		}
	}

	public partial class QfTouchWindowStyle : ResourceDictionary
	{
		private void TitleBar_OnMouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton != MouseButtonState.Pressed) return;
			var window = (Window)((FrameworkElement)sender).TemplatedParent;
			window.DragMove();
		}

		private void BtnCloseForm_OnClick(object sender, RoutedEventArgs e)
		{
			var window = (Window)((FrameworkElement)sender).TemplatedParent;
			window.Close();
		}
	}
}
