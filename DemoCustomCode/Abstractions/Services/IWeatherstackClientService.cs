using DemoDomainObjects.Models.WeatherStack;

namespace DemoCustomCode.Abstractions.Services;

public interface IWeatherstackClientService
{
    public Task<WeatherForecast?> GetCurrentWeatherForCity(string cityName);
}
