using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheRace
{
    public class Race
    {
        private List<Racer> collection = new List<Racer>();
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Racer> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
            }
        }


        public void Add(Racer Racer)
        {
            if (Collection.Count < Capacity)
            {
                Collection.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            var returnedItem = Collection.FirstOrDefault(x => x.Name == name);

            if (Collection.Contains(returnedItem))
            {
                Collection.Remove(returnedItem);
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            var oldestRacer = Collection.OrderByDescending(x => x.Age).First();
            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            var returnedItem = Collection.FirstOrDefault(x => x.Name == name);
            return returnedItem;
        }

        public Racer GetFastestRacer()
        {
            var returnedItem = Collection.OrderByDescending(x => x.Car.Speed).First();
            return returnedItem;
        }

        public int Count
        {
            get
            {
                return Collection.Count;
            }
        }

        public string Report()
        {
            return ToString();
        }

        public override string ToString()
        {
            return $"Racers participating at {Name}{Environment.NewLine}{string.Join(Environment.NewLine, Collection)}";
        }
    }
}
