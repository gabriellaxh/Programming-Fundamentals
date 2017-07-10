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
            int num = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, string>();
            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine().Split(' ').ToList();

                switch (input[0])
                {
                    case "register":
                        Register(input, dict);
                        break;
                    case "unregister":
                        Unregister(input, dict);
                        break;
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

        }

        private static void Unregister(List<string> input, Dictionary<string, string> dict)
        {
            string username = input[1];
            if (dict.ContainsKey(username))
            {
                dict.Remove(username);
                Console.WriteLine($"user {username} unregistered successfully");
            }
            else if (!dict.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
        }

        private static void Register(List<string> input, Dictionary<string, string> dict)
        {
            string username = input[1];
            string plateNum = input[2];

            if (dict.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {dict[username]}");
            }
            else if (!IsPlateValid(plateNum))
            {
                Console.WriteLine($"ERROR: invalid license plate {plateNum}");
            }
            else if (dict.ContainsValue(plateNum))
            {
                Console.WriteLine($"ERROR: license plate {plateNum} is busy");
            }
            else
            {
                dict.Add(username, plateNum);
                Console.WriteLine($"{username} registered {plateNum} successfully");
            }

        }

        private static bool IsPlateValid(string plateNum)
        {
            if (plateNum.Length == 8
                 && plateNum.Take(2).All(char.IsUpper)
                 && plateNum.Skip(2).Take(4).All(char.IsDigit)
                 && plateNum.Skip(6).Take(2).All(char.IsUpper))
            {
                return true;
            }
            return false;
        }
    }
}







