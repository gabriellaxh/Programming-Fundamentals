using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal total = 0.0m;
            decimal totalPrice = 0.0m;
            var list = new List<decimal>();
            for (int i = 0; i < n; i++)
            {
                decimal price = decimal.Parse(Console.ReadLine());

                var date = Console.ReadLine().Split('/');
                int month = int.Parse(date[1]);
                int year = int.Parse(date[2]);
                int days = DateTime.DaysInMonth(year, month);

                long quantity = long.Parse(Console.ReadLine());

                totalPrice = days * quantity * price;
                list.Add(totalPrice);
                total += totalPrice;

            }
            foreach (var price in list)
            {
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }
            Console.WriteLine($"Total: ${total:f2}");

        }
    }
}



