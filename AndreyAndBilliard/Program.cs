using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrey_And_Billiard
{
    class Program
    {
        class Customer
        {
            public string Name { get; set; }
            public Dictionary<string, int> ShopList { get; set; }
            public double Bill { get; set; }
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dictProductPrice = new Dictionary<string, double>();
            for (int i = 0; i < num; i++)
            {
                string[] info = Console.ReadLine().Split('-');
                string product = info[0];
                double price = double.Parse(info[1]);

                if (!dictProductPrice.ContainsKey(product))
                {
                    dictProductPrice.Add(product, price);
                }
                else
                {
                    dictProductPrice[product] = price;
                }
            }
            string input = Console.ReadLine();
            var listOfCustomers = new List<Customer>();
            while (input != "end of clients")
            {
                var order = input.Split('-', ',');
                string name = order[0];
                string product = order[1];
                int quantity = int.Parse(order[2]);
                if (!dictProductPrice.ContainsKey(product))
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (!listOfCustomers.Any(x => x.Name == name))
                {
                    var customer = new Customer()
                    {
                        Name = name,
                        ShopList = new Dictionary<string, int>()
                        {
                            {
                                product,quantity
                            }
                        },
                        Bill = dictProductPrice[product] * quantity
                    };
                    listOfCustomers.Add(customer);
                }
                else
                {
                    int index = listOfCustomers.FindIndex(x => x.Name == name);
                    if (!listOfCustomers[index].ShopList.ContainsKey(product))
                    {
                        listOfCustomers[index].ShopList.Add(product, quantity);
                    }
                    else
                    {
                        listOfCustomers[index].ShopList[product] += quantity;
                    }
                    listOfCustomers[index].Bill += dictProductPrice[product] * quantity;
                }
                input = Console.ReadLine();
            }
            double totalBill = 0.0;
            foreach (var customer in listOfCustomers.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{customer.Name}");
                foreach (var item in customer.ShopList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:f2}");
                totalBill += customer.Bill;

            }
            Console.WriteLine($"Total bill: {totalBill:f2}");


        }
    }
}
