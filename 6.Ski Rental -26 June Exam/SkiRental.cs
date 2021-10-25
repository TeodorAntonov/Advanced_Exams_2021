using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> _data = new List<Ski>();

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public List<Ski> Data
        {
            get => _data;
            set => _data = value;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Ski ski)
        {
            if (Capacity > Data.Count)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var returnedItem = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (returnedItem != null)
            {
                Data.Remove(returnedItem);
                return true;
            }
            return false;
        }

        public Ski GetNewestSki()
        {
            return Data.Count > 0 ? Data.OrderByDescending(x => x.Year).First() : null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return Data.Any(x => x.Manufacturer == manufacturer && x.Model == model) ?
                    Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model) : null;
        }

        public int Count
        {
            get
            {
                return _data.Count;
            }
        }

        public string GetStatistics()
        {
            return ToString();
        }

        public override string ToString()
        {
            string a = $"The skis stored in {Name}:";
            string b = Environment.NewLine;
            string c = $"{string.Join($"{Environment.NewLine}", Data)}";
            return a + b + c;
        }
    }
}
