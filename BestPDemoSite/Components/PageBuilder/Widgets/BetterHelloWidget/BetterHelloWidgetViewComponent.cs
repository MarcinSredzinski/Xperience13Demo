using BestPDemoSite.Components.PageBuilder.Widgets.HelloWidget;
using CMS.Core;
using CMS.CustomTables;
using CMS.DataEngine;
using DemoDomainObjects.Models.WeatherStack;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BestPDemoSite.Components.PageBuilder.Widgets.BetterHelloWidget
{
    public class BetterHelloWidgetViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public BetterHelloWidgetViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("weatherStackHttpClient");
        }
        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<BetterHelloWidgetProperties> properties)
        {
            var cityNames = GetCitiesListFromCustomTable();
            var weatherInfo = await GetWeatherInfoForCountries(cityNames);
            var viewModel = new BetterHelloWidgetViewModel();
            viewModel.HelloText = properties.Properties.WelcomeText + " And some more text";
            viewModel.WeatherInfo = weatherInfo;
            return View("~/Components/PageBuilder/Widgets/BetterHelloWidget/_BetterHelloWidget.cshtml", viewModel);
        }

        private List<string> GetCitiesListFromCustomTable()
        {
            string customTableClassName = "demo.CityName";
            DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(customTableClassName);
            var cityNames = CustomTableItemProvider.GetItems<CMS.CustomTables.Types.Demo.CityNameItem>()
                                                   .Columns("CityName").Select(c => c.CityName).ToList();
            return cityNames;
        }

        private async Task<string> GetWeatherInfoForCountries(List<string> cityNames)
        {
            string temperatureForCities = "";
            foreach (string city in cityNames)
            {
                var baseAddress = SettingsKeyInfoProvider.GetValue("WeatherstackApiBaseUrl");
                var apiKey = SettingsKeyInfoProvider.GetValue("WeatherstackApiKey");
                var response = await _httpClient.GetAsync(($"current?access_key={apiKey}&query={city}"));
                var weather = await response.Content.ReadFromJsonAsync<WeatherForecast>();
                Service.Resolve<IEventLogService>().LogInformation("HelloWidget", "WeatherForecast", "Weather forecast downloaded");
                temperatureForCities += $"Temperature for: {city} is {weather?.Current?.Temperature} <br />";
            }
            return temperatureForCities;
        }
    }
}