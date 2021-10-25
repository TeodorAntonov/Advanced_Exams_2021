using System;
using System.Linq;
using System.Collections.Generic;

namespace _15.Selling__Dec16
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int dollars = 0;

            int Srow = 0;
            int Scol = 0;

            int pillar1row = 0;
            int pillar1col = 0;

            int pillar2row = 0;
            int pillar2col = 0;

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        Srow = row;
                        Scol = col;
                    }
                    if (matrix[row, col] == 'O')
                    {
                        if (count == 0)
                        {
                            pillar1row = row;
                            pillar1col = col;
                            count++;
                        }
                        else
                        {
                            pillar2row = row;
                            pillar2col = col;
                        }
                    }
                }
            }

            while (dollars < 50)
            {
                string command = Console.ReadLine();

                if (command == "up" && IntheMatrix(matrix, Srow - 1, Scol))
                {
                    matrix[Srow, Scol] = '-';

                    if (matrix[Srow - 1, Scol] == 'O')
                    {
                        matrix[Srow - 1, Scol] = '-';
                        Srow = pillar2row;
                        Scol = pillar2col;
                        matrix[Srow, Scol] = 'S';
                    }
                    else if (matrix[Srow - 1, Scol] == 'O')
                    {
                        matrix[Srow - 1, Scol] = '-';
                        Srow = pillar1row;
                        Scol = pillar1col;
                        matrix[Srow, Scol] = 'S';
                    }
                    else
                    {
                        if (char.IsDigit(matrix[Srow - 1, Scol]))
                        {
                            var ch = matrix[Srow - 1, Scol];
                            dollars += ch - 48;
                        }
                        Srow--;
                        matrix[Srow, Scol] = 'S';
                    }
                }
                else if (command == "down" && IntheMatrix(matrix, Srow + 1, Scol))
                {
                    matrix[Srow, Scol] = '-';

                    if (matrix[Srow + 1, Scol] == 'O')
                    {
                        matrix[Srow + 1, Scol] = '-';
                        Srow = pillar2row;
                        Scol = pillar2col;
                        matrix[Srow, Scol] = 'S';
                    }
                    else if (matrix[Srow + 1, Scol] == 'O')
                    {
                        matrix[Srow + 1, Scol] = '-';
                        Srow = pillar1row;
                        Scol = pillar1col;
                        matrix[Srow, Scol] = 'S';
                    }
                    else
                    {

                        if (char.IsDigit(matrix[Srow + 1, Scol]))
                        {
                            var ch = matrix[Srow + 1, Scol];
                            dollars += ch - 48;
                        }
                        Srow++;
                        matrix[Srow, Scol] = 'S';
                    }
                }
                else if (command == "right" && IntheMatrix(matrix, Srow, Scol + 1))
                {
                    matrix[Srow, Scol] = '-';

                    if (matrix[Srow, Scol + 1] == 'O')
                    {
                        matrix[Srow, Scol + 1] = '-';
                        Srow = pillar2row;
                        Scol = pillar2col;
                        matrix[Srow, Scol] = 'S';
                    }
                    else if (matrix[Srow, Scol + 1] == 'O')
                    {
                        matrix[Srow, Scol + 1] = '-';
                        Srow = pillar1row;
                        Scol = pillar1col;
                        matrix[Srow, Scol] = 'S';
                    }
                    else
                    {
                        if (char.IsDigit(matrix[Srow, Scol + 1]))
                        {
                            var ch = matrix[Srow, Scol + 1];
                            dollars += ch - 48;
                        }
                        Scol++;
                        matrix[Srow, Scol] = 'S';
                    }
                }
                else if (command == "left" && IntheMatrix(matrix, Srow, Scol - 1))
                {
                    matrix[Srow, Scol] = '-';

                    if (matrix[Srow, Scol - 1] == 'O')
                    {
                        matrix[Srow, Scol - 1] = '-';
                        Srow = pillar2row;
                        Scol = pillar2col;
                        matrix[Srow, Scol] = 'S';
                    }
                    else if (matrix[Srow, Scol - 1] == 'O')
                    {
                        matrix[Srow, Scol - 1] = '-';
                        Srow = pillar1row;
                        Scol = pillar1col;
                        matrix[Srow, Scol] = 'S';
                    }
                    else
                    {
                        if (char.IsDigit(matrix[Srow, Scol - 1]))
                        {
                            var ch = matrix[Srow, Scol - 1];
                            dollars += ch - 48;
                        }
                        Scol--;
                        matrix[Srow, Scol] = 'S';
                    }
                }
                else
                {
                    matrix[Srow, Scol] = '-';
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
            }

            if (dollars >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine("Money: " + dollars);

            PrintText(matrix);

        }

        private static void PrintText(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool IntheMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}

