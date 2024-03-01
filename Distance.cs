using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Distance
    {
        private const double EarthRadiusKm = 6371.0;

        public double Value { get; private set; }

        public Distance(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Расстояние не может принять отрицательное значение");
            }

            Value = value;
        }

        public static Distance Calculate(Coordinate coord1, Coordinate coord2)
        {
            var lat1 = Math.PI * coord1.latitude / 180.0;
            var lat2 = Math.PI * coord2.latitude / 180.0;
            var deltaLat = Math.PI * (coord2.latitude - coord1.latitude) / 180.0;
            var deltaLon = Math.PI * (coord2.longitude - coord1.longitude) / 180.0;

            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distanceInKm = EarthRadiusKm * c;
            return new Distance(distanceInKm);
        }
    }
}
