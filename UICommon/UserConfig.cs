using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DS.MSClient.UICommon
{
    public class UserConfig : ConfigBase
    {
        private ClientAppConfig _appConfig = null;
        private SysMessage _sysMessage = null;



        /// <summary>
        /// 客户端应用程序配置
        /// </summary>
        public ClientAppConfig AppConfig
        {
            get
            {
                return _appConfig;
            }
            set
            {
                _appConfig = value;
            }
        }

        /// <summary>
        /// 系统消息列表
        /// </summary>
        public SysMessage SysMessage
        {
            get
            {
                return _sysMessage;
            }
            set
            {
                _sysMessage = value;
            }
        }


        /// <summary>
        /// 加载应用程序配置文件
        /// </summary>
        /// <param name="Path"></param>
        public void LoadAppConfig(string path)
        {
            if (File.Exists(path))
            {
                AppConfig = new ClientAppConfig();
                AppConfig = (ClientAppConfig)AppConfig.Deserialize(path);
            }
            else
            {
                AppConfig = new ClientAppConfig();
                AppConfig.Serialize(path);
            }
        }

        /// <summary>
        /// 加载应用程序配置文件
        /// </summary>
        /// <param name="Path"></param>
        public void LoadSysMessage(string path)
        {
            if (File.Exists(path))
            {
                SysMessage = new SysMessage();
                SysMessage = (SysMessage)SysMessage.Deserialize(path);
            }
            else
            {
                SysMessage = new SysMessage();
                SysMessage.Serialize(path);
            }
        }


        /// <summary>
        /// 保存应用程序配置文件
        /// </summary>
        /// <param name="Path"></param>
        public void SaveAppConfig(string path)
        {
            if (AppConfig != null)
            {
                AppConfig.Serialize(path);
            }
            else
            {
                AppConfig = new ClientAppConfig();
                AppConfig.Serialize(path);
            }
        }

        /// <summary>
        /// 保存系统消息列表
        /// </summary>
        /// <param name="Path"></param>
        public void SaveSysMessage(string path)
        {
            if (SysMessage != null)
            {
                SysMessage.Serialize(path);
            }
            else
            {
                SysMessage = new SysMessage();
                SysMessage.Serialize(path);
            }
        }
    }
}
