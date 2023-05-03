using Newtonsoft.Json;

namespace DemoCustomCode.Models.WeatherStack;

public class Current
{
    [JsonProperty("observation_time")]
    public string? ObservationTime { get; set; }
    public int Temperature { get; set; }

    [JsonProperty("Weather_code")]
    public int WeatherCode { get; set; }

    [JsonProperty("Weather_icons")]
    public string[]? WeatherIcons { get; set; }

    [JsonProperty("Weather_descriptions")]
    public string[]? WeatherDescriptions { get; set; }

    [JsonProperty("Wind_speed")]
    public int WindSpeed { get; set; }

    [JsonProperty("Wind_degree")]
    public int WindDegree { get; set; }

    [JsonProperty("Wind_dir")]
    public string? WindDir { get; set; }
    public int Pressure { get; set; }
    public float Precip { get; set; }
    public int Humidity { get; set; }
    public int Cloudcover { get; set; }
    public int Feelslike { get; set; }

    [JsonProperty("Uv_index")]
    public int UvIndex { get; set; }
    public int Visibility { get; set; }

    [JsonProperty("is_day")]
    public string? IsDay { get; set; }
}