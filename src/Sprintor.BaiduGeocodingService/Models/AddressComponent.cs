using Newtonsoft.Json;

namespace Sprintor.BaiduGeocodingService.Primitives
{

    public class AddressComponent
    {

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 省名
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市名
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区县名
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 街道名
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 街道门牌号
        /// </summary>
        [JsonProperty("Street_number")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// 行政区划代码
        /// </summary>
        [JsonProperty("Adcode")]
        public string AdCode { get; set; }

        /// <summary>
        /// 国家代码
        /// </summary>
        [JsonProperty("Country_code")]
        public string CountryCode { get; set; }

    }

}
