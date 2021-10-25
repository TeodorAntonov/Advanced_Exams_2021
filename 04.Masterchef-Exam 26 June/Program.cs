using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Masterchef_Exam_26_June
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);

            int[] theIngredientsValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] theFreshnessValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();

            Queue<int> ingredientsVal = new Queue<int>(theIngredientsValues);
            Queue<int> freshnessVal = new Queue<int>(theFreshnessValues.Reverse());

            //while (ingredientsVal.Count != 0 && freshnessVal.Count != 0)
             while (ingredientsVal.Any() && freshnessVal.Any())
            {
                if (ingredientsVal.Peek() == 0)
                {
                    ingredientsVal.Dequeue();
                    continue;
                }
                var ingredient = ingredientsVal.Dequeue();

                var freshness = freshnessVal.Dequeue();
                var result = ingredient * freshness;
                if (ingredient == 0)
                {
                    continue;
                }
                if (150 == result)
                {
                    dishes["Dipping sauce"]++;
                }
                else if (250 == result)
                {
                    dishes["Green salad"]++;
                }
                else if (300 == result)
                {
                    dishes["Chocolate cake"]++;
                }
                else if (400 == result)
                {
                    dishes["Lobster"]++;
                }
                else
                {
                    var newingredient = ingredient + 5;
                    ingredientsVal.Enqueue(newingredient);
                }
            }


            if (dishes.All(x => x.Value > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");

                if (ingredientsVal.Count > 0)
                {
                    Console.WriteLine("Ingredients left: " + ingredientsVal.Sum());
                }

                foreach (var item in dishes.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");

                if (ingredientsVal.Count > 0)
                {
                    Console.WriteLine("Ingredients left: " + ingredientsVal.Sum());
                }

                foreach (var item in dishes.OrderBy(x => x.Key))
                {
                    if (item.Value > 0)
                    {
                        Console.WriteLine($"# {item.Key} --> {item.Value}");
                    }
                }
            }
        }
    }
}
