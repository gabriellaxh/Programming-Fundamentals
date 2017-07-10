using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            var demons = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var demon in demons.OrderBy(x => x))
            {
                var health = GetHealth(demon);
                var damage = GetDamage(demon);
                Console.WriteLine($"{demon} - {health} health, {damage:f2} damage");
            }
        }

        private static object GetDamage(string demon)
        {
            var pattern = new Regex(@"[+|-]*[\d]+([.]*[\d+]*)+");
            var matches = pattern.Matches(demon);
            double damage = 0;

            foreach (var num in matches)
            {
                var damagecount = double.Parse(num.ToString());
                damage += damagecount;
            }

            foreach (var symbol in demon.Where(s => s == '*' || s == '/'))
            {
                if (symbol == '*')
                {
                    damage *= 2;
                }
                if (symbol == '/')
                {
                    damage /= 2;
                }
            }
            return damage;
        }

        private static object GetHealth(string demon)
        {
            var pattern = new Regex(@"[^.\d-,*+\/]");
            var matches = pattern.Matches(demon);
            double health = 0;
            foreach (Match match in matches)
            {
                var healthcount = (int)char.Parse(match.Value);
                health += healthcount;
            }
            return health;
        }
    }
}
