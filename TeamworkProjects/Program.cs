using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Marathon
{
    class Program
    {
        class Team
        {
            public string TeamName { get; set; }
            public List<string> Members { get; set; }
            public string CreatorName { get; set; }
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var listOfTeams = new List<Team>();
            for (int i = 0; i < num; i++)
            {
                string[] info = Console.ReadLine().Split('-');
                string creatorName = info[0];
                string team = info[1];

                if (listOfTeams.Any(x => x.TeamName == team))
                {
                    Console.WriteLine($"Team {team} was already created!");
                }
                else if (listOfTeams.Any(x => x.CreatorName == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
                else
                {
                    var newTeam = new Team()
                    {
                        CreatorName = creatorName,
                        TeamName = team,
                        Members = new List<string>()

                    };
                    listOfTeams.Add(newTeam);
                    Console.WriteLine($"Team {team} has been created by {creatorName}!");
                }
            }
            string input = Console.ReadLine();
            while (input != "end of assignment")
            {
                string[] info = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                string memberName = info[0];
                string teamToJoin = info[1];
                if (!listOfTeams.Any(x => x.TeamName == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (listOfTeams.Any(x => x.Members.Any(z => z == memberName)) || listOfTeams.Any(c => c.CreatorName == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
                }
                else
                {
                    int index = listOfTeams.FindIndex(x => x.TeamName == teamToJoin);
                    listOfTeams[index].Members.Add(memberName);
                }
                input = Console.ReadLine();
            }
            foreach (var team in listOfTeams.Where(x => x.Members.Count > 0).OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.CreatorName}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in listOfTeams.Where(x => x.Members.Count == 0).OrderBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }
    }
}
