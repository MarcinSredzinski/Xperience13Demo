using DemoDomainObjects.Models.WeatherStack;

namespace DemoDomainObjects.Models.WeatherStack;

public class WeatherForecast
{
    public Request? Request { get; set; }
    public Location? Location { get; set; }
    public Current? Current { get; set; }
}