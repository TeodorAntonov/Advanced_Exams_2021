using System;
using System.Linq;
using System.Collections.Generic;

namespace _8.Warm_Winter_14_April_20
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sets = new List<int>();
            int[] hats = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] scarfs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> hatsCol = new Stack<int>(hats);
            Queue<int> scarfsCol = new Queue<int>(scarfs);

            while (hatsCol.Any() && scarfsCol.Any())
            {
                var hat = hatsCol.Peek();
                var scarf = scarfsCol.Peek();

                if (hat > scarf)
                {
                    var newSet = hat + scarf;
                    sets.Add(newSet);

                    hatsCol.Pop();
                    scarfsCol.Dequeue();
                }
                if (scarf > hat)
                {
                    hatsCol.Pop();
                    continue;
                }
                if (scarf == hat)
                {
                    scarfsCol.Dequeue();
                    hatsCol.Pop();
                    var increasedHat = hat + 1;
                    hatsCol.Push(increasedHat);
                }
            }

            var mostExpensiveSet = sets.OrderByDescending(x => x).First();

            Console.WriteLine("The most expensive set is: " + mostExpensiveSet);

            foreach (var item in sets)
            {
                Console.Write(item + " ");
            }
        }
    }
}
