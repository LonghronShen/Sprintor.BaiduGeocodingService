using Sprintor.BaiduGeocodingService.Primitives;
using System;
using System.Linq;
using Xunit;

namespace Sprintor.BaiduGeocodingService.Tests
{

    public class BaiduGeocodingServiceTests
    {

        private readonly string _accessKey;

        private readonly IBaiduGeocodingService _baiduGeocodingService;

        public BaiduGeocodingServiceTests()
        {
            this._accessKey = Environment.GetEnvironmentVariable("ACCESSKEY");
            this._baiduGeocodingService = new BaiduGeocodingService(_accessKey);
        }

        [Theory]
        [InlineData(39.9109245472996, 116.413383697123, "北京市")]
        public void LocationOrAddressTest(double lat, double lng, string place)
        {
            var result = this._baiduGeocodingService.LocationOrAddress(new Location(lat, lng));
            Assert.Equal(place, result.Result.AddressComponent.City);
        }

        [Theory]
        [InlineData("北京市北京市", 39.9109245472996, 116.413383697123)]
        public void AddressOrLocationTest(string place, double lat, double lng)
        {
            var result = this._baiduGeocodingService.AddressOrLocation(place);
            Assert.Equal(lat, result.Lat, 5);
            Assert.Equal(lng, result.Lng, 5);
        }

    }

}