using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenorship
{
    class Program
    {
        static void Main(string[] args)
        {
            string censor = Console.ReadLine();
            string text = Console.ReadLine();
            if (text.Contains(censor))
            {
                text = text.Replace(censor, new string('*', censor.Length));
            }
            Console.WriteLine(text);
         
        }
    }
}
