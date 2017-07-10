using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            string first = words[0];
            string second = words[1];
            var dict = new Dictionary<char, char>();

            int minLength = Math.Min(first.Length, second.Length);
            bool isExchangable = true;

            for (int i = 0; i < minLength; i++)
            {
                if (!dict.ContainsKey(first[i]))
                {
                    if (!dict.ContainsValue(second[i]))
                    {
                        dict[first[i]] = second[i];
                    }
                    else
                    {
                        isExchangable = false;
                        break;
                    }
                }
                else
                {
                    if (dict[first[i]] != second[i])
                    {
                        isExchangable = false;
                        break;
                    }
                }
            }
        }
    }
} 
