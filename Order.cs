using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Order
    {
        public int id { get; set; }
        public Coordinate pointA { get; set; }
        public Coordinate pointB { get; set; }
        public double price { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"Заказ  №{id} '{name}': из {pointA} в {pointB}, цена: {price}";
        }

    }
}
