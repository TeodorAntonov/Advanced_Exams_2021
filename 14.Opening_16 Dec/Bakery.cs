using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data = new List<Employee>();

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Employee> Data { get => data; set => data = value; }

        public void Add(Employee employee)
        {
            if (Capacity > data.Count)
            {
                Data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            var returendItem = Data.FirstOrDefault(x => x.Name == name);

            if (Data.Contains(returendItem))
            {
                Data.Remove(returendItem);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            var returendItem = Data.OrderByDescending(x => x.Age).First();
            return returendItem;
        }

        public Employee GetEmployee(string name)
        {
            var returendItem = Data.FirstOrDefault(x => x.Name == name);
            return returendItem;
        }

        public int Count
        {
            get
            {
                return Data.Count;
            }
        }

        public string Report()
        {
            return ToString();
        }
        public override string ToString()
        {
            return $"Employees working at Bakery {Name}{Environment.NewLine}{string.Join(Environment.NewLine, Data)}";
        }
    }
}
