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
            int initialhealth = int.Parse(Console.ReadLine());


            var viruslist = new List<string>();
            int timetodefeat = 0;
            int maxhealth = initialhealth;

            while (true)
            {
                string virus = Console.ReadLine();

                if (virus == "end")
                {
                    Console.WriteLine($"Final Health: {initialhealth}");
                    return;
                }
                else
                {

                    int virusstrength = virus.Sum(x => x) / 3;

                    if (!viruslist.Contains(virus))
                    {
                        viruslist.Add(virus);
                        timetodefeat = virusstrength * virus.Length;
                    }
                    else
                    {
                        timetodefeat = (virusstrength * virus.Length) / 3;
                    }
                    Console.WriteLine($"Virus {virus}: {virusstrength} => {timetodefeat} seconds");


                    if (initialhealth - timetodefeat > 0)
                    {
                        int minutes = timetodefeat / 60;
                        int seconds = timetodefeat % 60;

                        Console.WriteLine($"{virus} defeated in {minutes}m {seconds}s.");
                        initialhealth -= timetodefeat;
                        Console.WriteLine($"Remaining health: {initialhealth}");

                        if (initialhealth + (int)(initialhealth * 0.2) > maxhealth)
                        {
                            initialhealth = maxhealth;
                        }
                        else
                        {
                            initialhealth += (int)(initialhealth * 0.2);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Immune System Defeated.");
                        return;
                    }
                }
            }
        }



    }
}



