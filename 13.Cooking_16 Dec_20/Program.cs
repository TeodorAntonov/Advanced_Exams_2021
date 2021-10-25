using System;
using System.Linq;
using System.Collections.Generic;

namespace _13.Cooking_16_Dec_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> food = new Dictionary<string, int>();
            food.Add("Bread", 0);
            food.Add("Cake", 0);
            food.Add("Pastry", 0);
            food.Add("Fruit Pie", 0);

            int[] liquidsSeq = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] ingredientsSeq = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> ingredients = new Stack<int>(ingredientsSeq);
            Queue<int> liquids = new Queue<int>(liquidsSeq);

            //Console.WriteLine(ingredients.Peek());
            //Console.WriteLine(liquids.Peek());

            while (ingredients.Any() && liquids.Any())
            {
                var ingredientsFirst = ingredients.Peek();
                var liquidsFirst = liquids.Peek();
                var sum = ingredientsFirst + liquidsFirst;

                if (sum == 25)
                {
                    food["Bread"]++;

                    ingredients.Pop();
                    liquids.Dequeue();
                }
                else if (sum == 50)
                {
                    food["Cake"]++;

                    ingredients.Pop();
                    liquids.Dequeue();
                }
                else if (sum == 75)
                {
                    food["Pastry"]++;

                    ingredients.Pop();
                    liquids.Dequeue();
                }
                else if (sum == 100)
                {
                    food["Fruit Pie"]++;

                    ingredients.Pop();
                    liquids.Dequeue();
                }
                else
                {
                    liquids.Dequeue();
                    var newIngrediaent = ingredients.Pop() + 3;
                    ingredients.Push(newIngrediaent);
                }
            }

            if (food.All(x => x.Value > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var item in food.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
