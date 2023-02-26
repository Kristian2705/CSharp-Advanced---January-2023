using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _5.FootballTeamGenerator
{
    public class Team
    {
        //all validations might not need to throw an exception but just print the proper message in the engine
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        //rating could be double
        public int Rating
        {
            get { return CalculateRating(); }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if(players.Any(x => x.Name == playerName))
            {
                players.Remove(players.Find(x => x.Name == playerName));
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {Name} team.");
            }
        }

        private int CalculateRating()
        {
            int totalRating = 0;
            foreach (var player in players)
            {
                int skillLevel = (int)Math.Round((player.Endurance + player.Sprint + player.Dribble + player.Passing + player.Shooting) / 5.0);
                totalRating += skillLevel;
            }
            return totalRating;
        }

        public override string ToString()
        {
            return $"{name} - {Rating:F0}";
        }
    }
}
