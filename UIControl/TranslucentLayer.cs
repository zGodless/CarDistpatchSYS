using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DS.ImportClient
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

		private PictureBox _picLoading;
		public PictureBox PicLoading
		{
			get { return _picLoading; }
		}
		public TranslucentLayer(int alpha, bool isShowLoadingImage)
		{
			SetStyle(ControlStyles.Opaque, true);
			base.CreateControl();

			_alpha = alpha;
			if (isShowLoadingImage)
			{
				_picLoading = new PictureBox();
				_picLoading.BackColor = Color.White;
				_picLoading.Name = "picLoading";
				_picLoading.Size = new Size(48, 48);
				_picLoading.SizeMode = PictureBoxSizeMode.AutoSize;
				_picLoading.Parent = this;
				_picLoading.BackColor = Color.Transparent;
				var location = new Point(Location.X + (Width - _picLoading.Width) / 2, Location.Y + (Height - _picLoading.Height) / 2);
				//居中
				_picLoading.Location = location;
				_picLoading.Anchor = AnchorStyles.None;
				Controls.Add(_picLoading);
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
				CreateParams cp = base.CreateParams;
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
			Pen labelBorderPen;
			SolidBrush labelBackColorBrush;

			if (_transparentBackground)
			{
				var drawColor = Color.FromArgb(_alpha, BackColor);
				labelBorderPen = new Pen(drawColor, 0);
				labelBackColorBrush = new SolidBrush(drawColor);
			}
			else
			{
				labelBorderPen = new Pen(BackColor, 0);
				labelBackColorBrush = new SolidBrush(BackColor);
			}
			base.OnPaint(e);
			float vlblControlWidth = Size.Width;
			float vlblControlHeight = Size.Height;
			e.Graphics.DrawRectangle(labelBorderPen, 0, 0, vlblControlWidth, vlblControlHeight);
			e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, vlblControlWidth, vlblControlHeight);
		}

		#endregion
	}

	/// <summary>
	/// 半透明帮助类
	/// </summary>
	public class TranslucentHelper
	{
		private TranslucentLayer _translucentLayer = null;//半透明蒙板层

		public TranslucentLayer TranslucentLayer
		{
			get { return _translucentLayer; }
		}
		/// <summary>
		/// 显示半透明层
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="alpha">透明度</param>
		/// <param name="isShowLoadingImage">是否显示图标</param>
		public void ShowTranslucentLayer(Control control, int alpha, bool isShowLoadingImage)
		{
			try
			{
				if (this._translucentLayer == null)
				{
					this._translucentLayer = new TranslucentLayer(alpha, isShowLoadingImage);
					control.Controls.Add(this._translucentLayer);
					this._translucentLayer.Location = new Point(0, 0);
					this._translucentLayer.Size = control.Size;
					this._translucentLayer.BringToFront();
				}
				this._translucentLayer.Enabled = true;
				this._translucentLayer.Visible = true;
			}
			catch { }
		}

		/// <summary>
		/// 显示半透明层
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="alpha">透明度</param>
		public void ShowTranslucentLayer(Control control, int alpha)
		{
			ShowTranslucentLayer(control, alpha, false);
		}

		/// <summary>
		/// 隐藏半透明层
		/// </summary>
		public void HideTranslucentLayer()
		{
			try
			{
				if (_translucentLayer != null)
				{
					_translucentLayer.Visible = false;
					_translucentLayer.Enabled = false;
				}
			}
			catch
			{
				
			}
		}

		/// <summary>
		/// 生成并显示半透明层
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="alpha">透明度</param>
		/// <param name="isShowLoadingImage">是否显示图标</param>
		/// <returns>返回生成的半透明层控件</returns>
		public static TranslucentHelper GenerateAndShowTranslucentLayer(Control control, int alpha, bool isShowLoadingImage = false)
		{
			var transHelper = new TranslucentHelper();
			transHelper.ShowTranslucentLayer(control, alpha, isShowLoadingImage);
			return transHelper;
		}
	}
}