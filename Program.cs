using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>()
            {
                new Order() {id = 1, name = "Доставка пиццы", pointA = new Coordinate(62.03227173021987, 129.7534264953307 ), pointB = new Coordinate(62.020863663696126, 129.71074152744447 ), price = 100 },
                new Order() {id = 2, name = "Доставка цветов" ,pointA = new Coordinate(62.03321278799289, 129.71128019991897 ), pointB = new Coordinate(62.03895529315584, 129.74575611489044 ), price = 150 },
                new Order() {id = 3, name = "Доставка канцелярии", pointA = new Coordinate(62.00343978529217, 129.70035395067694), pointB = new Coordinate(61.99852997949722, 129.71286950148976), price = 100 }
            };

            var couriers = new List<Courier>()
            {
                new Courier() {id = 1, name = "Николай", point = new Coordinate(62.04598089416351, 129.7270936066221)},
                new Courier() { id = 2, name = "Егор", point = new Coordinate(62.024516837204075, 129.73929802713442) },
            };

            //Console.WriteLine(Distance.Calculate(orders[0].pointA, orders[0].pointB).Value);

            Console.WriteLine("Заказы:");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("Курьеры:");
            foreach (var courier in couriers)
            {
                Console.WriteLine(courier);
            }

            var assignments = Assigner.AssignOrders(orders, couriers);

            Console.WriteLine("Приоритет:");

            foreach (var assignment in assignments)
            {
                Console.WriteLine($"Заказ №{assignment.Key} подойдет курьеру {assignment.Value}");
            }
            Console.ReadLine();

        }
    }
}
