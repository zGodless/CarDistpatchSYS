using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace QuickFrame.Repository
{
    public class QfRepository : RepositoryBase
	{
		public override string GetSql(string dbType, string path)
		{
			try
			{
				if (path.Contains('.'))
				{
					var lastDotPos = path.LastIndexOf('.');
					var type = Type.GetType(string.Format("QuickFrame.Repository.{0}.{1}", dbType, path.Substring(0, lastDotPos)), true);
					var mgrProp = type.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
					var cultureProp = type.GetProperty("Culture", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
					var resMgr = (ResourceManager)mgrProp.GetValue(null, null);
					var culture = (CultureInfo)cultureProp.GetValue(null, null);
					return resMgr.GetString(path.Substring(lastDotPos + 1), culture);
				}
				return Properties.Resources.ResourceManager.GetString(path, Properties.Resources.Culture);
			}
			catch
			{
				return "";
			}
		}
    }
}
