﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Courier
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coordinate point { get; set; }
        public override string ToString()
        {
            return $"Курьер №{id} '{name}', местоположение: {point}";
        }
    }
}
