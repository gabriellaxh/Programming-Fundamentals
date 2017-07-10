using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteFlip
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToList();
            input.RemoveAll(x => x.Length != 2);
            input.Reverse();

            for (int i = 0; i < input.Count; i++)
            {
                char[] reversed = input[i].ToCharArray();
                Array.Reverse(reversed);
                input[i] = string.Join("", reversed);

                int decimall = Convert.ToInt32(input[i], 16);
                Console.Write($"{(char)(decimall)}");
            }
            Console.WriteLine();
            
        }
    }
}
