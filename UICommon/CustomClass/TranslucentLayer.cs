using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DS.MSClient.Properties;

namespace DS.MSClient.UIControl
{
	/// <summary>
	///     半透明层控件
	///     作者：Noly Oh
	///     日期：2013-12-05
	/// </summary>
	[ToolboxBitmap(typeof(TranslucentLayer))]
	public class TranslucentLayer : Control
	{
		#region 初始化

		public TranslucentLayer()
			: this(125, true)
		{
		}

		public PictureBox PicLoading { get; private set; }

		public TranslucentLayer(int alpha, bool isShowLoadingImage)
		{
			SetStyle(ControlStyles.Opaque
			         | ControlStyles.AllPaintingInWmPaint
			         | ControlStyles.UserPaint
			         | ControlStyles.SupportsTransparentBackColor
			         | ControlStyles.ResizeRedraw, true);
			CreateControl();

			_alpha = alpha;
			if (isShowLoadingImage)
			{
				PicLoading = new PictureBox();
				PicLoading.BackColor = Color.White;
				PicLoading.Image = Resources.Loading;
				PicLoading.Name = "picLoading";
				PicLoading.Size = new Size(48, 48);
				PicLoading.SizeMode = PictureBoxSizeMode.AutoSize;
				PicLoading.Parent = this;
				PicLoading.BackColor = Color.Transparent;
				var location = new Point(Location.X + (Width - PicLoading.Width)/2, Location.Y + (Height - PicLoading.Height)/2);
				//居中
				PicLoading.Location = location;
				PicLoading.Anchor = AnchorStyles.None;
				Controls.Add(PicLoading);
			}
		}

		#endregion

		#region 属性

		private readonly Container _components = new Container();
		private int _alpha = 125; //设置透明度
		private bool _transparentBackground = true; //是否使用透明

		protected override CreateParams CreateParams //v1.10 
		{
			get
			{
				var cp = base.CreateParams;
				cp.ExStyle |= 0x00000020; //0x20;  // 开启 WS_EX_TRANSPARENT,使控件支持透明
				return cp;
			}
		}

		/// <summary>
		///     获取或设置是否使用透明
		/// </summary>
		[Category("TranslucentLayer"), Description("是否使用透明, 默认为True")]
		public bool TransparentBackground
		{
			get { return _transparentBackground; }
			set
			{
				_transparentBackground = value;
				Invalidate();
			}
		}

		/// <summary>
		///     获取或设置透明度
		/// </summary>
		[Category("TranslucentLayer"), Description("透明度")]
		public int Alpha
		{
			get { return _alpha; }
			set
			{
				_alpha = value;
				Invalidate();
			}
		}

		#endregion

		#region 方法

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_components != null)
				{
					_components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///     自定义绘制窗体
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			//var g = new GraphicsCache(e.Graphics);

			//Pen labelBorderPen;
			//SolidBrush labelBackColorBrush;

			//if (_transparentBackground)
			//{
			//	var drawColor = Color.FromArgb(_alpha, BackColor);
			//	labelBorderPen = new Pen(drawColor, 0);
			//	labelBackColorBrush = new SolidBrush(drawColor);
			//}
			//else
			//{
			//	labelBorderPen = new Pen(BackColor, 0);
			//	labelBackColorBrush = new SolidBrush(BackColor);
			//}

			//g.DrawRectangle(labelBorderPen, e.ClipRectangle);
			//g.FillRectangle(labelBackColorBrush, e.ClipRectangle);
		}

		#endregion
	}

	/// <summary>
	///     半透明帮助类
	/// </summary>
	public class TranslucentHelper
	{
		public TranslucentHelper()
		{
			TranslucentLayer = null;
		}

		public TranslucentLayer TranslucentLayer { get; private set; }

		/// <summary>
		///     显示半透明层
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="alpha">透明度</param>
		/// <param name="isShowLoadingImage">是否显示图标</param>
		public void ShowTranslucentLayer(Control control, int alpha, bool isShowLoadingImage)
		{
			try
			{
				if (TranslucentLayer == null)
				{
					TranslucentLayer = new TranslucentLayer(alpha, isShowLoadingImage);
					control.Controls.Add(TranslucentLayer);
					TranslucentLayer.Location = new Point(0, 0);
					TranslucentLayer.Size = control.Size;
					TranslucentLayer.BringToFront();
					control.Resize += (s, ee) =>
					{
						TranslucentLayer.Size = control.Size;
					};
				}
				TranslucentLayer.Enabled = true;
				TranslucentLayer.Visible = true;
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     显示半透明层
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="alpha">透明度</param>
		public void ShowTranslucentLayer(Control control, int alpha)
		{
			ShowTranslucentLayer(control, alpha, false);
		}

		/// <summary>
		///     隐藏半透明层
		/// </summary>
		public void HideTranslucentLayer()
		{
			try
			{
				if (TranslucentLayer != null)
				{
					TranslucentLayer.Visible = false;
					TranslucentLayer.Enabled = false;
				}
			}
			catch
			{
				// ignored
			}
		}

		public void CloseTransLucentLayer()
		{
			HideTranslucentLayer();
			try
			{
				if (!TranslucentLayer.IsDisposed)
					TranslucentLayer.Dispose();
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     生成并显示半透明层
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="alpha">透明度</param>
		/// <param name="isShowLoadingImage">是否显示图标</param>
		/// <returns>返回生成的半透明层控件</returns>
		public static TranslucentHelper GenerateAndShowTranslucentLayer(Control control, int alpha,
			bool isShowLoadingImage = false)
		{
			var transHelper = new TranslucentHelper();
			transHelper.ShowTranslucentLayer(control, alpha, isShowLoadingImage);
			return transHelper;
		}
	}
}