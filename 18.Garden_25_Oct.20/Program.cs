using System;
using System.Linq;
using System.Collections.Generic;

namespace _18.Garden_25_Oct._20
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int r = size[0];
            int c = size[1];

            int[,] matrix = new int[r, c];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int flower1 = int.Parse(cmd[0]);
                int flower2 = int.Parse(cmd[1]);

                if (InTheMatrix(matrix, flower1, flower2))
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, flower2] += 1;
                        if (matrix[row, flower2] == matrix[flower1, row])
                        {
                            matrix[flower1, row] -= 1;
                        }
                        matrix[flower1, row] += 1;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                command = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool InTheMatrix(int[,] matrix, int row, int col)   
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
