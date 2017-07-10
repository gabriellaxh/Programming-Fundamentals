using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Preparation
{
    class Program
    {
        class Event
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<string> Participants { get; set; }

            static void Main(string[] args)
            {
                string input = Console.ReadLine();
                var listOfEvents = new List<Event>();

                while (input != "Time for Code")
                {
                    var info = input.Split(' ');
                    var ID = int.Parse(info[0]);
                    var @event = info[1];

                    if (!@event.StartsWith("#"))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if (listOfEvents.Any(x => x.ID == ID))
                    {
                        if (listOfEvents.Any(x => x.Name == @event))
                        {
                            var index = listOfEvents.FindIndex(x => x.Name == @event);
                            for (int i = 2; i < info.Length; i++)
                            {
                                if (info[i].StartsWith("@"))
                                {
                                    if (!listOfEvents[index].Participants.Contains(info[i]))
                                    {
                                        listOfEvents[index].Participants.Add(info[i]);
                                    }
                                }
                            }
                        }
                        else
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                    }
                    if (!listOfEvents.Any(x => x.ID == ID))
                    {
                        var newEvent = new Event()
                        {
                            ID = ID,
                            Name = @event,
                            Participants = new List<string>()

                        };
                        for (int i = 2; i < info.Length; i++)
                        {
                            if (info[i].StartsWith("@"))
                            {
                                newEvent.Participants.Add(info[i]);
                            }
                        }
                        listOfEvents.Add(newEvent);

                    }

                    input = Console.ReadLine();
                }

                foreach (var @event in listOfEvents.OrderByDescending(x => x.Participants.Count).ThenBy(x => x.Name))
                {
                    @event.Name = @event.Name.Remove(0, 1);
                    Console.WriteLine($"{@event.Name} - {@event.Participants.Count}");
                    foreach (var participant in @event.Participants.OrderBy(x => x))
                    {
                        Console.WriteLine($"{participant}");
                    }
                }

            }
        }
    }
}


