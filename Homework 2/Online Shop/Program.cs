using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Въведете брой купувачи:" + " " + "Максимален Брой 100");
            int buyers = int.Parse(Console.ReadLine());
            List<int> buyersList = new List<int>();

            for (int i = 1; i <= buyers; i++)
            {
                if (i == 100)
                {
                    Console.WriteLine("Достигнахте максималения капацитет");
                    break;
                }
                buyersList.Add(i);
            }
            Console.WriteLine(" Въведете брой доставчици:" + " " + "Максимален Брой 5");
            List<int> suplyersList = new List<int>();
            int suplyers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= suplyers; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine("Достигнахте максимления капацитет");
                    break;
                }

                suplyersList.Add(i);
            }

            Console.WriteLine(" Въведете брой поръчки:" + " " + "Максимален Брой 20");
            List<int> ordersList = new List<int>();
            int orders = int.Parse(Console.ReadLine());

            for (int i = 1; i <= orders; i++)
            {
                if (i == 20)
                {
                    Console.WriteLine("Достигнахте максималния капацитет");
                    break;
                }

                ordersList.Add(i);
            }

            Store store = new Store(buyersList, suplyersList, ordersList);
            Console.WriteLine("Брой купувачи:" + string.Join(" ", store.Customers.Max()));
            Console.WriteLine("Брой доставчици:" + string.Join(" ", store.Suplyers.Max()));
            Console.WriteLine("Брой поръчките:" + string.Join(" ", store.Orders).Max());
        }
    }
}
