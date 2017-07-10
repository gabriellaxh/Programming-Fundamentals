using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            var tickets = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var pattern = new Regex(@"[@]{6,10}|[#]{6,10}|[$]{6,10}|[\^]{6,10}");
            var jackpotPattern = new Regex(@"[@]{10}|[#]{10}|[$]{10}|[\^]{10}");
            foreach (var ticket in tickets)
            {
                int count = ticket.Count();
                var leftPart = ticket.Substring(0, count / 2);
                var rightPart = ticket.Substring(count / 2);

                if (ticket.Count() != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                
                else if (jackpotPattern.IsMatch(leftPart) && jackpotPattern.IsMatch(rightPart))
                {
                    if(leftPart == rightPart)
                    {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{ticket[1]} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    if (pattern.IsMatch(leftPart) && pattern.IsMatch(rightPart))
                    {
                        var firstMatch = pattern.Match(leftPart).ToString();
                        var secondMatch = pattern.Match(rightPart).ToString();
                        
                        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(firstMatch.Length,secondMatch.Length)}{firstMatch[1]}");
                        
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }

                }
            }

        }
    }
}
