using System;
using System.Linq;
using System.Collections.Generic;

namespace Advanced_Retake_Exam___18_August_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfGuest = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse();

            int[] listOfPlates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> guests = new Stack<int>(listOfGuest);

            Stack<int> plates = new Stack<int>(listOfPlates);

            int wastedFood = 0;

            while (guests.Count != 0 && plates.Count != 0)
            {
                var enteredGuest = guests.Pop();
                var lastPlate = plates.Pop();

                if (lastPlate < enteredGuest)
                {
                    guests.Push(enteredGuest - lastPlate);
                }
                else
                {
                    wastedFood += lastPlate - enteredGuest;
                }
            }

            if (plates.Count != 0)
            {
                Console.Write("Plates: ");
                foreach (var item in plates)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Wasted grams of food: " + wastedFood);
            }
            else
            {
                Console.Write("Guests: ");
                foreach (var item in guests)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Wasted grams of food: " + wastedFood);
            }
        }
    }
}
