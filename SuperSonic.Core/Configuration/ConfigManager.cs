using System;
using System.Configuration;

namespace SuperSonic.Core.Configuration
{
    public class ConfigManager : IConfigManager
    {
        #region << IConfigManager Members >>

        public T GetAppSetting<T>(string appSettingKey)
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[appSettingKey], typeof (T));
        }

        #endregion
    }
}
