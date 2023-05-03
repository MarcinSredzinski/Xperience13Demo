namespace DemoCustomCode.Abstractions.Providers;

public interface ISettingsProvider
{
    public string GetValue(string key);
}