namespace QuickFrame.Common.Exception
{
	/// <summary>
	/// QuickFrame 异常
	/// </summary>
    public class QfException : System.Exception
	{
		public QfException()
			: this("QuickFrame 发生异常") { }

		public QfException(string message)
			: base(message)
		{
		}

		public QfException(string message, System.Exception innerException)
			: base(message, innerException)
		{

		}
    }
}
