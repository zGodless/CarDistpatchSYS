using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.Model.Token
{
	[Serializable]
	public class QfClientInfo
	{
		private DateTime _openTime;
		private string _clientType;
		private string _clientVersion;
		private string _lanip;
		private string _gatewayIp;
		private string _status;
		private string _userId;
		private string _userName;
		private string _organizationId;
		private string _organizationName;
		private string _info;

		/// <summary>
		/// 启动时间
		/// </summary>
		public DateTime OpenTime
		{
			get { return _openTime; }
			set
			{
				_openTime = value;
				UpdateOpenTime = true;
			}
		}

		/// <summary>
		/// 是否更新启动时间
		/// </summary>
		public bool UpdateOpenTime { get; private set; }

		/// <summary>
		/// 客户端类型
		/// </summary>
		public string ClientType
		{
			get { return _clientType; }
			set
			{
				_clientType = value;
				UpdateClientType = true;
			}
		}

		/// <summary>
		/// 是否更新客户端类型
		/// </summary>
		public bool UpdateClientType { get; private set; }

		/// <summary>
		/// 客户端版本号
		/// </summary>
		public string ClientVersion
		{
			get { return _clientVersion; }
			set
			{
				_clientVersion = value;
				UpdateClientVersion = true;
			}
		}

		/// <summary>
		/// 是否更新客户端版本号
		/// </summary>
		public bool UpdateClientVersion { get; private set; }

		/// <summary>
		/// 客户端局域网IP
		/// </summary>
		public string LANIP
		{
			get { return _lanip; }
			set
			{
				_lanip = value;
				UpdateLANIP = true;
			}
		}

		/// <summary>
		/// 是否更新客户端局域网IP
		/// </summary>
		public bool UpdateLANIP { get; private set; }

		/// <summary>
		/// 客户端网关IP
		/// </summary>
		public string GatewayIP
		{
			get { return _gatewayIp; }
			set
			{
				_gatewayIp = value;
				UpdateGatewayIP = true;
			}
		}

		/// <summary>
		/// 是否更新客户端网关IP
		/// </summary>
		public bool UpdateGatewayIP { get; private set; }

		/// <summary>
		/// 状态
		/// </summary>
		public string Status
		{
			get { return _status; }
			set
			{
				_status = value;
				UpdateStatus = true;
			}
		}

		/// <summary>
		/// 是否更新状态
		/// </summary>
		public bool UpdateStatus { get; private set; }

		/// <summary>
		/// 用户ID
		/// </summary>
		public string UserID
		{
			get { return _userId; }
			set
			{
				_userId = value;
				UpdateUserID = true;
			}
		}

		/// <summary>
		/// 是否更新用户ID
		/// </summary>
		public bool UpdateUserID { get; private set; }

		/// <summary>
		/// 用户名称
		/// </summary>
		public string UserName
		{
			get { return _userName; }
			set
			{
				_userName = value;
				UpdateUserName = true;
			}
		}

		/// <summary>
		/// 是否更新用户名称
		/// </summary>
		public bool UpdateUserName { get; private set; }

		/// <summary>
		/// 机构ID
		/// </summary>
		public string OrganizationID
		{
			get { return _organizationId; }
			set
			{
				_organizationId = value;
				UpdateOrganizationID = true;
			}
		}

		/// <summary>
		/// 是否更新机构ID
		/// </summary>
		public bool UpdateOrganizationID { get; private set; }

		/// <summary>
		/// 机构名称
		/// </summary>
		public string OrganizationName
		{
			get { return _organizationName; }
			set
			{
				_organizationName = value;
				UpdateOrganizationName = true;
			}
		}

		/// <summary>
		/// 是否更新机构名称
		/// </summary>
		public bool UpdateOrganizationName { get; private set; }

		/// <summary>
		/// 信息
		/// </summary>
		public string Info
		{
			get { return _info; }
			set
			{
				_info = value;
				UpdateInfo = true;
			}
		}

		/// <summary>
		/// 是否更新信息
		/// </summary>
		public bool UpdateInfo { get; private set; }
	}
}
