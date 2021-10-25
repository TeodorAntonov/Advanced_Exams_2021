using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> _participants = new List<Car>();

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public List<Car> Participants   
        {
            get 
            {
                return _participants;
            }
            set     
            {
                _participants = value;
            }   
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count
        {
            get
            {
                return _participants.Count;
            }

        }
        //public int Count(List<Car> participants)
        //{
        //    int count = participants.Count;
        //    return count;
        //}

        public void Add(Car car)
        {
            if (Participants.Count < Capacity
                && !Participants.Any(x => x.LicensePlate == car.LicensePlate)
                && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            var returnedItem = Participants.FirstOrDefault(X => X.LicensePlate == licensePlate);

            if (returnedItem != null)
            {
                Participants.Remove(returnedItem);
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (var item in Participants.Where(X => X.LicensePlate == licensePlate))
            {
                return item;
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count == 0)
            {
                return null;
            }
            var result = Participants.OrderByDescending(x => x.HorsePower).First();

            return result;
        }

        public override string ToString()
        {
            string a = $"Race: {Name} - Type: {Type} (Laps: {Laps})";
            string v = $"{Environment.NewLine}";
            string b = $"{string.Join($"{Environment.NewLine}", Participants)}";
            string c = a + v + b;
            return c;
        }
        public string Report()
        {
            return ToString();
        }
    }
}
