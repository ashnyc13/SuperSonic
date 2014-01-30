using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSonic.Core.Configuration
{
    /// <summary>
    /// Wraps configuration subsystem provided by .NET
    /// </summary>
    public interface IConfigManager
    {
        T GetAppSetting<T>(string appSettingKey);
    }
}
