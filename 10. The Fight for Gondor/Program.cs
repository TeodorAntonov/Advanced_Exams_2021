using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesNumb = int.Parse(Console.ReadLine());
            int[] AragornDefence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> Aragorn = new Stack<int>(AragornDefence.Reverse());
            Stack<int> Orcs = new Stack<int>();

            for (int i = 1; i <= wavesNumb; i++)
            {
                if (!Aragorn.Any())
                {
                    break;
                }
                int[] OrcAttacks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                Orcs = new Stack<int>(OrcAttacks);

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    Aragorn.Push(newPlate);
                }

                while (Orcs.Any() && Aragorn.Any())
                {
                    var warriorsAttack = Orcs.Peek();
                    var plates = Aragorn.Peek();

                    if (warriorsAttack > plates)
                    {
                        Aragorn.Pop();
                        var newHpOrc = Orcs.Pop() - plates;

                        if (newHpOrc > 0)
                        {
                            Orcs.Push(newHpOrc);
                        }

                    }
                    else if (plates > warriorsAttack)
                    {
                        Orcs.Pop();
                        var newHPPlate = Aragorn.Pop() - warriorsAttack;

                        if (newHPPlate > 0)
                        {
                            Aragorn.Push(newHPPlate);
                        }
                    }
                    else if (plates == warriorsAttack)
                    {
                        Orcs.Pop();
                        Aragorn.Pop();
                    }
                }              
            }

            if (Aragorn.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", Aragorn));
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine("Orcs left: " + string.Join(", ", Orcs));
            }
        }
    }
}
