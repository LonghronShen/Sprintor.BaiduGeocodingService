using Newtonsoft.Json;

namespace Sprintor.BaiduGeocodingService.Primitives
{

    public class Result
    {

        [JsonProperty("addressComponent")]
        public AddressComponent AddressComponent { get; set; } = new AddressComponent();

        [JsonProperty("location")]
        public Location Location { get; set; } = new Location();

    }

}