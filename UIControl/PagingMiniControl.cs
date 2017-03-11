using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DS.MSClient.Properties;
using DS.MSClient.UICommon;

namespace DS.MSClient.UIControl
{
	public partial class PagingMiniControl : UserControl
	{
		public delegate void ExportEventHandler(bool singlePage); //单页，所有

		public delegate void PagingEventHandler(int curPage, int pageSize);

		//总条数
		private int _allCount;
		//当前页
		private int _curPage = 1;
		//页行数
		private int _pageSize = 10;

		public PagingMiniControl()
		{
			InitializeComponent();
			InitEvent();
			Init();
		}

		public event PagingEventHandler PagingEvent;
		public event ExportEventHandler ExportEvent;

		private void InitEvent()
		{
			textEditToPage.KeyPress += textEditToPage_KeyPress;

			Btn_Next.Click += Btn_Next_Click;
			Btn_End.Click += Btn_End_Click;
			Btn_Prev.Click += Btn_Prev_Click;
			Btn_First.Click += Btn_First_Click;
			Btn_toPage.Click += Btn_ToPage_Click;
			btn_page10.Click += btn_page10_Click;
			btn_page20.Click += btn_page10_Click;
			btn_page30.Click += btn_page10_Click;
		}

		private void Init()
		{
			Btn_First.Image = Resources.firstPageMini;
			Btn_Next.Image = Resources.nextPageMini;
			Btn_Prev.Image = Resources.prevPageMini;
			Btn_End.Image = Resources.lastPageMin;
			Btn_toPage.Image = Resources.go;
			btn_page10.Image = Resources._10;
			btn_page20.Image = Resources._20;
			btn_page30.Image = Resources._30;
		}

		public void RefreshPager(int pageSize = 10, int allCount = 0, int curPage = 1)
		{
			_allCount = allCount;
			if (pageSize == 30)
			{
				btn_page10.Enabled = true;
				btn_page20.Enabled = true;
				btn_page30.Enabled = false;
				_pageSize = pageSize;
			}
			else if (pageSize == 20)
			{
				btn_page10.Enabled = true;
				btn_page20.Enabled = false;
				btn_page30.Enabled = true;
				_pageSize = pageSize;
			}
			else
			{
				btn_page10.Enabled = false;
				btn_page20.Enabled = true;
				btn_page30.Enabled = true;
				_pageSize = 10;
			}

			_curPage = curPage;
			//页码信息, 共{0}条记录,共{1}页
			lbl_pageInfo.Text = string.Format("共{0}条记录,共{1}页", allCount, GetPageCount());
			if (curPage == 0)
			{
				textEditToPage.Text = "1";
			}
			else
			{
				textEditToPage.Text = curPage.ToString();
			}
			//comboBoxEditPageSize.Text = pageSize.ToString();

			if (curPage == 0)
			{
				if (GetPageCount() > 0)
				{
					curPage = 1;
					if (PagingEvent != null) PagingEvent(curPage, pageSize);
				}
			}
			if (curPage > GetPageCount())
			{
				curPage = GetPageCount();
				if (PagingEvent != null) PagingEvent(curPage, pageSize);
			}
		}

		//获取总记录数
		public int GetAllCount()
		{
			return _allCount;
		}

		//获得当前页编号，从1开始
		public int GetCurPage()
		{
			return _curPage;
		}

		//获得总页数
		public int GetPageCount()
		{
			var count = 0;
			if (_allCount%_pageSize == 0)
			{
				count = _allCount/_pageSize;
			}
			else
				count = _allCount/_pageSize + 1;
			return count;
		}

		private void Btn_Next_Click(object sender, EventArgs e)
		{
			if (PagingEvent == null) return;
			if (_curPage >= GetPageCount()) return;
			_curPage += 1;
			PagingEvent(_curPage, _pageSize);
		}

		private void Btn_End_Click(object sender, EventArgs e)
		{
			if (_curPage == 0) return;
			if (PagingEvent == null) return;
			var totalPageCount = GetPageCount();
			if (_curPage >= totalPageCount) return;
			_curPage = GetPageCount();
			PagingEvent(_curPage, _pageSize);
		}

		private void Btn_Prev_Click(object sender, EventArgs e)
		{
			if (PagingEvent == null) return;
			if (_curPage <= 1) return;
			_curPage -= 1;
			PagingEvent(_curPage, _pageSize);
		}

		private void Btn_First_Click(object sender, EventArgs e)
		{
			if (_curPage == 0) return;
			if (PagingEvent == null) return;
			if (_curPage == 1) return;
			_curPage = 1;
			PagingEvent(_curPage, _pageSize);
		}

		private void Btn_ToPage_Click(object sender, EventArgs e)
		{
			try
			{
				if (_curPage == 0) return;
				var selPage = Convert.ToInt32(textEditToPage.Text);
				if (_curPage == selPage) return;
				if (selPage <= 0)
				{
					MsgBox.ShowWarn("禁止输入小于1数据");
					return;
				}
				if (PagingEvent == null) return;
				if ((selPage >= 1) && (selPage <= GetPageCount()))
					_curPage = selPage;
				PagingEvent(_curPage, _pageSize);
			}
			catch
			{
				// ignored
			}
		}

		private void btn_page10_Click(object sender, EventArgs e)
		{
			btn_page10.Enabled = true;
			btn_page20.Enabled = true;
			btn_page30.Enabled = true;
			var button = sender as SimpleButton;
			var pageSize = Convert.ToInt32(button.Text.Trim());
			button.Enabled = false;
			if (pageSize <= 0 || PagingEvent == null) return;
			_pageSize = pageSize;
			PagingEvent(_curPage, pageSize);
		}

		/// <summary>
		///     回车
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textEditToPage_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					Btn_ToPage_Click(Btn_toPage, e);
				}
			}
			catch
			{
				// ignored
			}
		}


		protected virtual void OnExportEvents(bool singlepage)
		{
			var handler = ExportEvent;
			if (handler != null) handler(singlepage);
		}
	}
}