using Sprintor.BaiduGeocodingService.Primitives;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sprintor.BaiduGeocodingService
{

    public class BaiduGeocodingService
        : IBaiduGeocodingService
    {

        public const string LocationUrl = @"http://api.map.baidu.com/geocoder/v2/?ak={0}&callback=renderReverse&location={1}&output=json&pois=1&callback=";
        public const string AddressUrl = @"http://api.map.baidu.com/geocoder/v2/?ak={0}&address={1}&output=json&callback=";

        protected internal string AccessKey { get; }

        public BaiduGeocodingService(string accessKey)
        {
            this.AccessKey = accessKey;
        }

        public Location AddressOrLocation(string address)
        {
            var gd = HttpUtils.HttpGet<Geocoding>(string.Format(AddressUrl, this.AccessKey, address));
            if (gd.Status == 302)
            {
                throw new Exception("Insufficient quota for the API.");
            }
            return gd.Result.Location;
        }

        public Geocoding LocationOrAddress(Location location)
        {
            var gd = HttpUtils.HttpGet<Geocoding>(string.Format(LocationUrl, this.AccessKey, location.ToString()));
            if (gd.Status == 302)
            {
                throw new Exception("Insufficient quota for the API.");
            }
            return gd;
        }

        public async Task<Geocoding> LocationOrAddressAsync(Location location)
        {
            var gd = await HttpUtils.HttpGetAsync<Geocoding>(string.Format(LocationUrl, this.AccessKey, location.ToString()));
            if (gd.Status == 302)
            {
                throw new Exception("Insufficient quota for the API.");
            }
            return gd;
        }

        public async Task<Location> AddressOrLocationAsync(string address)
        {
            var gd = await HttpUtils.HttpGetAsync<Geocoding>(string.Format(AddressUrl, this.AccessKey, address));
            if (gd.Status == 302)
            {
                throw new Exception("Insufficient quota for the API.");
            }
            return gd.Result.Location;
        }

    }

}