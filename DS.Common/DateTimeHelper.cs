using System;
using System.Runtime.InteropServices;

namespace DS.Common
{
    public class DateTimeHelper
    {
        #region 获取该时间所在周的周一和周末1(注：这个周一个周末时间不是准确的0:00,可以是周一中的任意一个时间点，具体由传入的时间决定)
        /// <summary>
        /// 获取本周开始和结束
        /// </summary>
        /// <param name="dataTime">时间</param>
        /// <returns></returns>
        public static DateTime[] getMondayAndSundayOfTheTime_1(DateTime dataTime)
        {
            //周一时间
            DateTime first = dataTime;
            switch (dataTime.DayOfWeek)
            {
                case System.DayOfWeek.Monday:
                    first = dataTime;
                    break;
                case System.DayOfWeek.Tuesday:
                    first = dataTime.AddDays(-1);
                    break;
                case System.DayOfWeek.Wednesday:
                    first = dataTime.AddDays(-2);
                    break;
                case System.DayOfWeek.Thursday:
                    first = dataTime.AddDays(-3);
                    break;
                case System.DayOfWeek.Friday:
                    first = dataTime.AddDays(-4);
                    break;
                case System.DayOfWeek.Saturday:
                    first = dataTime.AddDays(-5);
                    break;
                case System.DayOfWeek.Sunday:
                    first = dataTime.AddDays(-6);
                    break;
            }
            return new DateTime[] { first, first.AddDays(6) };
        }
        #endregion


        #region 获取该时间所在周的周一和周末2
        /// <summary>
        /// 获取本周周一和周日时间
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] getMondayAndSundayOfTheTime_2(DateTime dt)
        {
            //获取改时间是本周的第几天
            int thedayoftheweek = Convert.ToInt32(dt.DayOfWeek.ToString("d"));
            //本周周一
            DateTime startWeek = dt.AddDays(1 - (thedayoftheweek == 0 ? 7 : thedayoftheweek));
            return new DateTime[] { startWeek, startWeek.AddDays(6) };
        }
        #endregion


        #region 获取时间所在当天的开始和结束时间(注：在这里当天的结束时间是在明天的开始的基础上加上-1的Tick值)
        /// <summary>
        /// 获取时间所在当天的开始和结束时间
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] getBeginAndEndTimeOfTheDay(DateTime dt)
        {
            DateTime beginTime = DateTime.Parse(dt.ToString("yyyy-MM-dd"));
            DateTime endTime = DateTime.Parse(dt.ToString("yyyy-MM-dd")).AddDays(1).AddTicks(-1);
            return new DateTime[] { beginTime, endTime };
        }
        #endregion


        #region 获取时间所在月的开始和结束时间
        /// <summary>
        /// 获取时间所在月的开始和结束时间
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] getBeginAndEndTimeOfTheMonth(DateTime dt)
        {
            DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末
            return new DateTime[] { startMonth, endMonth };
        }
        #endregion


        #region 获取时间所在季度的开始和结束时间
        /// <summary>
        /// 获取时间所在季度的开始和结束时间
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] getBeginAndEndTimeOfQuarter(DateTime dt)
        {
            //本季度初
            DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day);
            //本季度末
            DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);
            return new DateTime[] { startQuarter, endQuarter };
        }
        #endregion


        #region 获取本年年初和年末
        /// <summary>
        /// 获取本年年初和年末
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <returns></returns>
        public static DateTime[] getBeginAndEndTimeOfTheYear(DateTime dt)
        {
            DateTime startYear = new DateTime(dt.Year, 1, 1);  //本年年初
            DateTime endYear = new DateTime(dt.Year, 12, 31);  //本年年末
            return new DateTime[] { startYear, endYear };
        }
        #endregion


        #region 获取某一年某一月有多少天
        /// <summary>
        /// 获取某一年某一月有多少天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        public static int getMonthDays(int year, int month)
        {
            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1).Day;
        }
        #endregion


        #region 获取两个时间段的相隔天数
        /// <summary>
        /// 获取两个时间段的相隔天数
        /// </summary>
        /// <param name="begin">开始时间(小)</param>
        /// <param name="end">结束时间(大)</param>
        /// <returns></returns>
        public static int getIntervalDaysOfTwoDateTime(DateTime begin, DateTime end)
        {
            //如果开始时间比结束时间大,交换时间
            if (begin.CompareTo(end) > 0)
            {
                DateTime temp = begin;
                begin = end;
                end = temp;
            }
            int days = 0;
            //计算年的相差天数
            for (int i = begin.Year; i < end.Year; i++)
            {
                days += (DateTime.IsLeapYear(i) == true ? 366 : 365);
            }
            //计算月的相差天数
            days += end.DayOfYear - begin.DayOfYear;


            return days;
        }
        #endregion

		#region 设置系统时间

		[DllImport("Kernel32.dll")]
		public static extern bool SetSystemTime(ref SystemTime sysTime);
		[DllImport("Kernel32.dll")]
		public static extern bool SetLocalTime(ref SystemTime sysTime);
		[DllImport("Kernel32.dll")]
		public static extern void GetSystemTime(ref SystemTime sysTime);
		[DllImport("Kernel32.dll")]
		public static extern void GetLocalTime(ref SystemTime sysTime);
		public struct SystemTime
		{
			public ushort wYear;
			public ushort wMonth;
			public ushort wDayOfWeek;
			public ushort wDay;
			public ushort wHour;
			public ushort wMinute;
			public ushort wSecond;
			public ushort wMiliseconds;
		}
		public static bool SetSysTime(DateTime dateTime)
		{
			var sysTime = new SystemTime();
			sysTime.wYear = Convert.ToUInt16(dateTime.Year);
			sysTime.wMonth = Convert.ToUInt16(dateTime.Month);
			sysTime.wDay = Convert.ToUInt16(dateTime.Day);
			sysTime.wHour = Convert.ToUInt16(dateTime.Hour);
			sysTime.wMinute = Convert.ToUInt16(dateTime.Minute);
			sysTime.wSecond = Convert.ToUInt16(dateTime.Second);
			sysTime.wMiliseconds = Convert.ToUInt16(dateTime.Millisecond);
			sysTime.wDayOfWeek = Convert.ToUInt16(dateTime.DayOfWeek);
			return SetLocalTime(ref sysTime);
		}
		#endregion
    }
}
