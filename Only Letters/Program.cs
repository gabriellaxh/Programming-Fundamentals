using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Only_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            bool h;
            var text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    for (int j = i + 1; j < text.Length; j++)
                    {
                        if (char.IsLetter(text[j]))
                        {
                            text = text.Replace(text[i], text[j]);
                            break;
                        }
                    }
                }

            }

            Console.WriteLine(text);
        }
    }
}
