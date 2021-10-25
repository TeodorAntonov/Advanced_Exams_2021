using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster = new List<Player>();
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = roster;
        }

        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (Capacity > Roster.Count)
            {
                Roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            var returnedPLayer = Roster.FirstOrDefault(x => x.Name == name);

            if (Roster.Contains(returnedPLayer))
            {
                Roster.Remove(returnedPLayer);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            var returnedPLayer = Roster.FirstOrDefault(x => x.Name == name);

            if (returnedPLayer.Rank != "Member")
            {
                returnedPLayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var returnedPLayer = Roster.FirstOrDefault(x => x.Name == name);

            if (returnedPLayer.Rank != "Trial")
            {
                returnedPLayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> kicked = new List<Player>();

            foreach (var player in Roster.Where(x => x.Class == @class))
            {
                kicked.Add(player);
            }

            Roster.RemoveAll(x => x.Class == @class);

            Player[] kckedPlayer = kicked.ToArray();

            return kckedPlayer;
        }

        public int Count
        {
            get
            {
                return Roster.Count;
            }
        }

        public string Report()
        {
            return ToString();
        }
        public override string ToString()
        {
            return $"Players in the guild: {Name}{Environment.NewLine}{string.Join(Environment.NewLine, Roster)}";
        }
    }
}
