using DemoCustomCode.Abstractions.Providers;
using DemoCustomCode.Models.WeatherStack;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;
using System.Net.Http.Json;

namespace DemoCustomCode.WeatherStackService;

public class WeatherstackClientService
{
    private const string SettingsKeyName = "WeatherstackApiKey";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;
    private readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _circuitBreakerPolicy =
          Policy<HttpResponseMessage>
        .Handle<HttpRequestException>()
        .OrTransientHttpError()
        .AdvancedCircuitBreakerAsync(0.5, TimeSpan.FromSeconds(10),
                10, TimeSpan.FromSeconds(15));
    private readonly IMemoryCache _weatherCache = new MemoryCache(new MemoryCacheOptions());


    public WeatherstackClientService(IHttpClientFactory httpClientFactory, ISettingsProvider settingsProvider)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = settingsProvider.GetValue(SettingsKeyName);
    }

    public async Task<WeatherForecast?> GetCurrentWeatherForCity(string cityName)
    {
        var client = _httpClientFactory.CreateClient("weatherClient");

        if (_circuitBreakerPolicy.CircuitState is CircuitState.Open or CircuitState.Isolated)
        {
            return _weatherCache.Get<WeatherForecast>(cityName);
        }

        var response = await _circuitBreakerPolicy.ExecuteAsync(() =>
            client.GetAsync($"current?access_key={_apiKey}&query={cityName}"));
        var weather = await response.Content.ReadFromJsonAsync<WeatherForecast>();

        _weatherCache.Set(cityName, weather);

        return weather;
    }
}