using System;
using System.Linq;
using System.Collections.Generic;

namespace _16.Scheduling_25_Oct_20
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksLines = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] threatsLines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int taskTobeKilled = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksLines);
            Queue<int> threats = new Queue<int>(threatsLines);

            while (true)
            {
                var currTask = tasks.Peek();
                var currThreat = threats.Peek();

                if (currTask == taskTobeKilled)
                {
                    Console.WriteLine($"Thread with value {currThreat} killed task {taskTobeKilled}");
                    break;
                }

                if (currTask > currThreat)
                {
                    threats.Dequeue();
                }
                else if (currTask <= currThreat)
                {
                    threats.Dequeue();
                    tasks.Pop();
                }
            }

            Console.WriteLine(string.Join(" ", threats));
        }
    }
}
