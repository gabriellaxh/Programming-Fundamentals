using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMe
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = Console.ReadLine().Split('@');
            var left = email[0].ToCharArray();
            var right = email[1].ToCharArray();
            int sumleft = 0;
            int sumright = 0;
            for (int i = 0; i < left.Length; i++)
            {
                sumleft += (int)left[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                sumright += (int)right[i];
            }
            int total = sumleft - sumright;

            if (total >= 0) { Console.WriteLine("Call her!"); }
            else { Console.WriteLine("She is not the one."); }

        }
    }
}
