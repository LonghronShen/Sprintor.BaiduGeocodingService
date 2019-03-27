using Newtonsoft.Json;

namespace Sprintor.BaiduGeocodingService.Primitives
{

    public class Geocoding
    {

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; } = new Result();

    }

}