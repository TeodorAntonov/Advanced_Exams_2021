using System;

namespace _02._The_Battle_of_the_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            string[][] matrix = new string[n][];

            int M_rowOfM = 0;
            int M_colOfM = 0;

            int A_row = 0;
            int A_col = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string collums = Console.ReadLine();

                matrix[row] = new string[collums.Length];

                for (int i = 0; i < collums.Length; i++)
                {
                    matrix[row][i] = collums[i].ToString();

                    if (matrix[row][i] == "M")
                    {
                        M_rowOfM = row;
                        M_colOfM = i;
                    }
                    else if (matrix[row][i] == "A")
                    {
                        A_row = row;
                        A_col = i;
                    }
                }
            }

            bool wonTheGame = false;

            while (armor > 0 && !wonTheGame)
            {
                string command = Console.ReadLine();
                string[] cmd = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string direction = cmd[0];

                int spawningOrcRow = int.Parse(cmd[1]);
                int spawningOrcCol = int.Parse(cmd[2]);

                matrix[spawningOrcRow][spawningOrcCol] = "O";
                armor--;

                if (direction == "up")
                {
                    var newArmyRow = A_row - 1;
                    MoveArmy(ref armor, matrix, ref A_row, ref A_col, M_rowOfM, M_colOfM, ref wonTheGame, newArmyRow, A_col);
                }
                else if (direction == "down")
                {
                    var newArmyRow = A_row + 1;
                    MoveArmy(ref armor, matrix, ref A_row, ref A_col, M_rowOfM, M_colOfM, ref wonTheGame, newArmyRow, A_col);
                }
                else if (direction == "left")
                {
                    var newArmyCol = A_col - 1;
                    MoveArmy(ref armor, matrix, ref A_row, ref A_col, M_rowOfM, M_colOfM, ref wonTheGame, A_row, newArmyCol);
                }
                else if (direction == "right")
                {
                    var newArmyCol = A_col + 1;
                    MoveArmy(ref armor, matrix, ref A_row, ref A_col, M_rowOfM, M_colOfM, ref wonTheGame, A_row, newArmyCol);
                }
                PrintText(matrix);
            }

            if (armor > 0 || wonTheGame)
            {
                Console.WriteLine("The army managed to free the Middle World! Armor left: " + armor);
                matrix[A_row][A_col] = "-";
                matrix[M_rowOfM][M_colOfM] = "-";
                PrintText(matrix);
            }
            else
            {
                Console.WriteLine($"The army was defeated at {A_row};{A_col}.");
                matrix[A_row][A_col] = "X";
                PrintText(matrix);
            }
        }

        private static void PrintText(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        public static void MoveArmy(ref int armor, string[][] matrix, ref int A_row, ref int A_col, int mordorRow, int mordorCol, ref bool wonTheGame, int newRowA, int newColA)    
        {
            if (InsideTheMatrix(matrix, newRowA, newColA))
            {
                if (newRowA == mordorRow && newColA == mordorCol)
                {
                    wonTheGame = true;
                }
                else
                {
                    var charNewPos = matrix[newRowA][newColA];
                    if (charNewPos == "O")
                    {
                        armor -= 2;
                    }
                }
                matrix[newRowA][newColA] = "A";
                matrix[A_row][A_col] = "-";
                A_row = newRowA;
                A_col = newColA;
            }
        }
        
        public static bool InsideTheMatrix(string[][] matrix, int row, int col)
        {
            return row < matrix.Length && row >= 0 && col < matrix[row].Length && col >= 0;
        }
    }
}
