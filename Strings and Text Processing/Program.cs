using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings_and_Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            var palindromes = new List<String>();
            foreach (var word in text)
            {
                int counter = 0;
                for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word.Length == 1)
                    {
                        palindromes.Add(word);
                        break;
                    }
                    if (word[i] == word[word.Length - 1 - i])
                    {
                        counter++;
                    }

                    else { break; }
                }
                
                if (counter == word.Length / 2)
                {
                    palindromes.Add(word);
                }
            }
            Console.WriteLine(string.Join(", ", palindromes));
        }
    }
}
