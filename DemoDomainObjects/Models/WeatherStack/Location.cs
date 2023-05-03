using Newtonsoft.Json;

namespace DemoDomainObjects.Models.WeatherStack;

public class Location
{
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? Region { get; set; }
    public string? Lat { get; set; }
    public string? Lon { get; set; }

    [JsonProperty("Timezone_id")]
    public string? TimezoneId { get; set; }
    public string? Localtime { get; set; }

    [JsonProperty("Localtime_epoch")]
    public int LocaltimeEpoch { get; set; }

    [JsonProperty("Utc_offset")]
    public string? UtcOffset { get; set; }
}