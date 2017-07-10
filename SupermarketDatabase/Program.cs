using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var fulldict = new Dictionary<string, Dictionary<double, int>>();
            var quantdict = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "stocked")
            {
                var splitted = input.Split(' ').ToList();
                string product = splitted[0];
                double price = double.Parse(splitted[1]);
                int quantity = int.Parse(splitted[2]);

                if (!fulldict.ContainsKey(product))
                {
                    fulldict[product] = new Dictionary<double, int>();
                    fulldict[product].Add(price, quantity);

                    quantdict[product] = quantity;
                }
                else
                {
                    quantity += quantdict[product];
                    quantdict[product] = quantity;

                    fulldict[product].Clear();
                    fulldict[product].Add(price, quantity);
                }
                input = Console.ReadLine();
            }

            double grandtotal = 0.0;
            foreach (var f in fulldict)
            {
                foreach (var q in f.Value)
                {
                    double sum = q.Key * q.Value;
                    grandtotal += sum;

                    Console.WriteLine($"{f.Key}: ${q.Key:f2} * {q.Value} = ${sum:f2}");

                }

            }
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${grandtotal:f2}");

        }



    }
}







