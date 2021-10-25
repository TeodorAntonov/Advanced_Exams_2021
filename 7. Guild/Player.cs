using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        private string rank = "Trial";
        private string description = "n/a";

        public Player(string name, string @class)
        {
            Name = name;
            Class = @class;
            Rank = rank;
            Description = description;
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get => rank; set => rank = value; }
        public string Description { get => description; set => description = value; }

        public override string ToString()
        {
            return $"Player {Name}: {Class}{Environment.NewLine}Rank: {Rank}{Environment.NewLine}Description: {Description}";
        }
    }
}
