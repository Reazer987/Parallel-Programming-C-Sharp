using System;
using System.Collections.Generic;
using System.Text;

namespace DBarSimulator
{
    class Drink
    {
        public Drink(string name, int quantity, int price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
      
    }
}
