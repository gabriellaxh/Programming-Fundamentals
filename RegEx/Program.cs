using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var regex = new Regex(@"(?<=\s)[a-z0-9]+([-.]\w*)*@[a-z]+([-.]\w*)*(\.[a-z]+)");
            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Console.WriteLine(string.Join(" ", match));
            }
        }

    }
}
