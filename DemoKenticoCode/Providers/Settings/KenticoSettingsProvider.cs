using CMS.DataEngine;
using DemoCustomCode.Abstractions.Providers;

namespace DemoKenticoCode.Providers.Settings;

public class KenticoSettingsProvider : ISettingsProvider
{
    public string GetValue(string key)
    {
        return SettingsKeyInfoProvider.GetValue(key);
    }
}