using System;
using System.Collections.Generic;
using System.Threading;

namespace DBarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            List<Thread> studentThreads = new List<Thread>();
            List<Drink> drinks = new List<Drink>();
            Console.WriteLine("Изберете бюджет на студента: ");
            int budget = int.Parse(Console.ReadLine());
            Console.WriteLine("На каква възраст е студента: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Изберете брой напитки");
            int drinkCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < drinkCount; i++)
            {
                Console.WriteLine("Изберете име на напитката: ");
                string name = Console.ReadLine();
                Console.WriteLine("Изберете количество: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Цена: ");
                int price = int.Parse(Console.ReadLine());
                Drink drink = new Drink(name, quantity, price);
                drinks.Add(drink);
            }
            for (int i = 1; i < 100; i++)
            {
                var student = new Student(i.ToString(), bar, drinks, budget,age);
                var thread = new Thread(student.PaintTheTownRed);
                thread.Start();
                studentThreads.Add(thread);
            }

            foreach (var t in studentThreads) t.Join();
            Console.WriteLine();
            Console.WriteLine("The party is over.");
            Console.ReadLine();
        }
    }
}