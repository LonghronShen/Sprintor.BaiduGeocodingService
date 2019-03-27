using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprintor.BaiduGeocodingService.Primitives
{

    public class Location
    {

        public double Lat { get; set; }

        public double Lng { get; set; }

        public Location()
        {
        }

        public Location(double lat, double lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }

        public override string ToString()
        {
            return $"{this.Lat},{this.Lng}";
        }

    }

}