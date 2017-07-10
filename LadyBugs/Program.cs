using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldsize = int.Parse(Console.ReadLine());
            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).Where(a => a >= 0 && a < fieldsize).ToList();

            int[] field = new int[fieldsize];
            foreach (var index in indexes)
            {
                field[index] = 1;
            }

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] info = input.Split(' ');
                int currentIndex = int.Parse(info[0]);
                string direction = info[1];
                int len = int.Parse(info[2]);

                if (currentIndex < 0 || currentIndex >= fieldsize)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else if (field[currentIndex] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    field[currentIndex] = 0;
                    var newIndex = currentIndex;
                    while (true)
                    {
                        if (direction == "right")
                        {
                            newIndex += len;
                        }
                        else
                        {
                            newIndex -= len;
                        }
                        if (newIndex < 0 || newIndex >= fieldsize)
                        {
                            break;
                        }
                        if (field[newIndex] == 1)
                        {
                            continue;
                        }
                        else
                        {
                            field[newIndex] = 1;
                            break;
                        }

                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
