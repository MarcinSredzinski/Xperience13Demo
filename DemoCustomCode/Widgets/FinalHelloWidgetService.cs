using CMS.Core;
using DemoCustomCode.Abstractions.Providers;
using DemoCustomCode.Abstractions.Services;
using DemoDomainObjects.Models.Widgets.Properties;
using DemoDomainObjects.Models.Widgets.ViewModels;
using System.Text;

namespace DemoCustomCode.Widgets;

public class FinalHelloWidgetService : IFinalHelloWidgetService
{
    private const string CustomTableClassName = "demo.CityName";
    private const string CustomTableColumnName = "CityName";
    private readonly ITableDataProvider _tableDataProvider;
    private readonly IWeatherstackClientService _weatherstackClientService;
    private readonly IEventLogService _eventLogService;

    public FinalHelloWidgetService(ITableDataProvider tableDataProvider, IWeatherstackClientService weatherstackClientService, IEventLogService eventLogService)
    {
        _tableDataProvider = tableDataProvider;
        _weatherstackClientService = weatherstackClientService;
        _eventLogService = eventLogService;
    }

    public async Task<FinalHelloWidgetViewModel> GetWidget(FinalHelloWidgetProperties properties)
    {
        var cities = _tableDataProvider.GetValuesFromColumn<CMS.CustomTables.Types.Demo.CityNameItem>(CustomTableClassName,
                        CustomTableColumnName, c => c.CityName);
        var viewModel = new FinalHelloWidgetViewModel();
        viewModel.HelloText = properties.WelcomeText + " And some more text";
        viewModel.WeatherInfo = await GenerateWeatherInfo(cities);
        _eventLogService.LogWarning("FinalHelloWidgetService", "WidgetGeneration", "Widget generated properly");
        return viewModel;
    }

    protected virtual async Task<string> GenerateWeatherInfo(IEnumerable<string>? cities)
    {
        if (cities == null || !cities.Any())
            return "";

        StringBuilder weatherData = new StringBuilder();
        foreach (var city in cities)
        {
            var weather = await _weatherstackClientService.GetCurrentWeatherForCity(city);
            weatherData.AppendLine($"Temperature for: {city} is {weather?.Current?.Temperature} <br/>");
        }
        return weatherData.ToString();
    }
}