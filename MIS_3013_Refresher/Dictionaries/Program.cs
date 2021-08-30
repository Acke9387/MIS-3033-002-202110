using System;
using System.Collections.Generic;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> fruits = new Dictionary<string, double>();
            fruits.Add("Apples", 0.99);
            fruits.Add("Oranges", 0.50);
            fruits.Add("Bananas", 0.50);
            fruits.Add("Grapes", 2.99);
            fruits.Add("Blueberries", 1.99);

            Console.WriteLine("What fruit do you want a price of? >>");
            string fruit = Console.ReadLine();

            if (fruits.ContainsKey(fruit) == true)
            {
                Console.WriteLine($"{fruit}'s cost {fruits[fruit]}");
            }
            else
            {
                Console.WriteLine($"Sorry, we do not carry {fruit}'s.");
            }


        }
    }
}
