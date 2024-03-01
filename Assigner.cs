using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Assigner
    {
        private static double CalculateTotalDistance(Coordinate courierLocation, Coordinate pointA, Coordinate pointB)
        {
            // Расстояние от курьера до точки A заказа, затем от точки A до точки B, и обратно на место курьера
            double distanceToA = CalculateDistance(courierLocation, pointA);
            double distanceToB = CalculateDistance(pointA, pointB);
            return distanceToA + distanceToB + distanceToA;
        }

        public static Dictionary<int, int> AssignOrders(List<Order> orders, List<Courier> couriers)
        {
            var assignments = new Dictionary<int, int>();

            foreach (var order in orders)
            {
                Coordinate orderLocationA = order.pointA;
                Coordinate orderLocationB = order.pointB;
                double minTotalDistance = double.PositiveInfinity;
                int assignedCourier = -1;

                foreach (var courier in couriers)
                {
                    double totalDistance = CalculateTotalDistance(courier.point, orderLocationA, orderLocationB);

                    if (totalDistance < minTotalDistance)
                    {
                        minTotalDistance = totalDistance;
                        assignedCourier = courier.id;
                    }
                }

                if (assignedCourier != -1)
                {
                    assignments.Add(order.id, assignedCourier);
                }
            }

            return assignments;
        }

        private static double CalculateDistance(Coordinate coord1, Coordinate coord2)
        {
            const double EarthRadiusKm = 6371.0;
            var lat1 = Math.PI * coord1.latitude / 180.0;
            var lat2 = Math.PI * coord2.latitude / 180.0;
            var deltaLat = Math.PI * (coord2.latitude - coord1.latitude) / 180.0;
            var deltaLon = Math.PI * (coord2.longitude - coord1.longitude) / 180.0;

            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }
    }
}
