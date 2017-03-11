using System;
using System.Windows.Forms;
using DS.MSClient.Properties;
using DS.MSClient.UICommon;

namespace DS.MSClient.UIControl
{
	public partial class PagingControl : UserControl
	{
		public delegate void ExportEventHandler(bool singlePage); //单页，所有
		public delegate void PagingEventHandler(int curPage, int pageSize);

		//总条数
		private int _allCount;
		//当前页
		private int _curPage = 1;
		//页行数
		private int _pageSize = 100;

		public PagingControl()
		{
			InitializeComponent();
			InitEvent();
			Init();
		}

		public event PagingEventHandler PagingEvent;
		//public event ExportEventHandler ExportEvent;

		private void InitEvent()
		{
			textEditToPage.KeyPress += textEditToPage_KeyPress;
			comboBoxEditPageSize.SelectedIndexChanged += comboBoxEditPageSize_SelectedIndexChanged;
			Btn_Next.Click += Btn_Next_Click;
			Btn_End.Click += Btn_End_Click;
			Btn_Prev.Click += Btn_Prev_Click;
			Btn_First.Click += Btn_First_Click;
			Btn_toPage.Click += Btn_ToPage_Click;
		}

		private void Init()
		{
			Btn_First.Image = Resources.firstPage;
			Btn_Next.Image = Resources.nextPage;
			Btn_Prev.Image = Resources.prevPage;
			Btn_End.Image = Resources.lastPage;
			Btn_toPage.Image = Resources.go;
		}

		public void RefreshPager(int pageSize = 1, int allCount = 0, int curPage = 1)
		{
			_allCount = allCount;
			_pageSize = pageSize;
			_curPage = curPage;
			//页码信息, 共{0}条记录,共{1}页
			lbl_pageInfo.Text = string.Format("共{0}条记录,共{1}页", allCount, GetPageCount());
			textEditToPage.Text = curPage == 0 ? "1" : curPage.ToString();
			comboBoxEditPageSize.Text = pageSize.ToString();

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
			if (PagingEvent != null)
			{
				if (_curPage < GetPageCount())
				{
					_curPage += 1;
					PagingEvent(_curPage, _pageSize);
				}
			}
		}

		private void Btn_End_Click(object sender, EventArgs e)
		{
			if (_curPage == 0) return;
			if (PagingEvent != null)
			{
				var totalPageCount = GetPageCount();
				if (_curPage < totalPageCount)
				{
					_curPage = GetPageCount();
					PagingEvent(_curPage, _pageSize);
				}
			}
		}

		private void Btn_Prev_Click(object sender, EventArgs e)
		{
			if (PagingEvent != null)
			{
				if (_curPage > 1)
				{
					_curPage -= 1;
					PagingEvent(_curPage, _pageSize);
				}
			}
		}

		private void Btn_First_Click(object sender, EventArgs e)
		{
			if (_curPage == 0) return;
			if (PagingEvent != null)
			{
				if (_curPage != 1)
				{
					_curPage = 1;
					PagingEvent(_curPage, _pageSize);
				}
			}
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
				if (PagingEvent != null)
				{
					if ((selPage >= 1) && (selPage <= GetPageCount()))
						_curPage = selPage;
					PagingEvent(_curPage, _pageSize);
				}
			}
			catch
			{
				// ignored
			}
		}

		private void comboBoxEditPageSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				var pageSize = Convert.ToInt32(comboBoxEditPageSize.Text);
				if ((pageSize > 0))
				{
					_pageSize = pageSize;
					if (PagingEvent != null) PagingEvent(_curPage, pageSize);
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     回车
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textEditToPage_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				Btn_ToPage_Click(Btn_toPage, e);
			}
		}
	}
}