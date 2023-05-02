using BestPDemoSite.Components.PageBuilder.Widgets.HelloWidget;
using BestPDemoSite.WeatherStack;
using CMS.DataEngine;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BestPDemoSite.Components.PageBuilder.Widgets.BetterHelloWidget
{
    public class BetterHelloWidgetViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<BetterHelloWidgetProperties> properties)
        {
            var viewModel = new BetterHelloWidgetViewModel();
            viewModel.HelloText = properties.Properties.WelcomeText + " Mordeczki";
            return View("~/Components/PageBuilder/Widgets/BetterHelloWidget/_BetterHelloWidget.cshtml", viewModel);
        }

        private async Task<string> GetWeatherInfoForCountries(List<string> cityNames)
        {
            string temperatureForCities = "";
            foreach (string city in cityNames)
            {
                var httpClient = new HttpClient();
                var baseAddress = SettingsKeyInfoProvider.GetValue("WeatherstackApiBaseUrl");
                var apiKey = SettingsKeyInfoProvider.GetValue("WeatherstackApiKey");
                httpClient.BaseAddress = new Uri(baseAddress);
                var response = await httpClient.GetAsync(($"current?access_key={apiKey}&query={city}"));
                var weather = await response.Content.ReadFromJsonAsync<WeatherForecast>();

                temperatureForCities += $"Temperature for: {city} is {weather?.Current?.Temperature} <br />";
            }
            return temperatureForCities;
        }
    }
}
