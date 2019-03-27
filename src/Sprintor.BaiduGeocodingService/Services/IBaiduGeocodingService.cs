using Sprintor.BaiduGeocodingService.Primitives;
using System.Threading.Tasks;

namespace Sprintor.BaiduGeocodingService
{

    public interface IBaiduGeocodingService
    {

        /// <summary>
        /// 坐标转换地址
        /// </summary>
        /// <param name="location">坐标</param>
        /// <returns></returns>
        Geocoding LocationOrAddress(Location location);

        /// <summary>
        /// 坐标转换地址
        /// </summary>
        /// <param name="location">坐标</param>
        /// <returns></returns>
        Task<Geocoding> LocationOrAddressAsync(Location location);

        /// <summary>
        /// 地址转换坐标
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        Location AddressOrLocation(string address);

        /// <summary>
        /// 地址转换坐标
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        Task<Location> AddressOrLocationAsync(string address);

    }

}