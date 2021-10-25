using System;

namespace _11.Warships_20.Feb
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] coordinates = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            string[,] matrix = new string[n, n];
            int bombRow = 0;
            int bombCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowsString = Console.ReadLine();
                rowsString = rowsString.Replace(" ", "");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsString[col].ToString();
                    if (matrix[row, col] == "#")
                    {
                        bombRow = row;
                        bombCol = col;
                    }
                }
            }
            int firstCount = 0;
            int secondCount = 0;
            int firstSinkShips = 0;
            int secondSinkShips = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (i % 2 == 0)
                {
                    string[] separetedNums = coordinates[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int rowFirst = int.Parse(separetedNums[0]);
                    int colFirst = int.Parse(separetedNums[1]);
                    if (IsInTheMatrix(matrix, rowFirst, colFirst))
                    {
                        if (matrix[rowFirst, colFirst] == "#")
                        {
                            if (rowFirst + 1 < matrix.GetLength(0))
                            {
                                if (matrix[rowFirst + 1, colFirst] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst + 1, colFirst] = "X";
                                }
                                if (matrix[rowFirst + 1, colFirst] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst + 1, colFirst] = "X";
                                }
                            }
                            if (rowFirst - 1 >= 0)
                            {
                                if (matrix[rowFirst - 1, colFirst] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst - 1, colFirst] = "X";
                                }
                                if (matrix[rowFirst - 1, colFirst] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst - 1, colFirst] = "X";
                                }
                            }
                            if (colFirst + 1 < matrix.GetLength(1))
                            {
                                if (matrix[rowFirst, colFirst + 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst, colFirst + 1] = "X";
                                }
                                if (matrix[rowFirst, colFirst + 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst, colFirst + 1] = "X";
                                }
                            }
                            if (colFirst - 1 >= 0)
                            {
                                if (matrix[rowFirst, colFirst - 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst, colFirst - 1] = "X";
                                }
                                if (matrix[rowFirst, colFirst - 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst, colFirst - 1] = "X";
                                }
                            }
                            if (colFirst - 1 >= 0 && rowFirst - 1 >= 0) // 
                            {
                                if (matrix[rowFirst - 1, colFirst - 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst - 1, colFirst - 1] = "X";
                                }
                                if (matrix[rowFirst - 1, colFirst - 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst - 1, colFirst - 1] = "X";
                                }
                            }
                            if (colFirst + 1 < matrix.GetLength(1) && rowFirst + 1 < matrix.GetLength(0)) // uspredka
                            {
                                if (matrix[rowFirst + 1, colFirst + 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst + 1, colFirst + 1] = "X";
                                }
                                if (matrix[rowFirst + 1, colFirst + 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst + 1, colFirst + 1] = "X";
                                }
                            }
                            if (colFirst - 1 >= 0 && rowFirst + 1 < matrix.GetLength(0)) // uspredka
                            {
                                if (matrix[rowFirst + 1, colFirst - 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst + 1, colFirst - 1] = "X";
                                }
                                if (matrix[rowFirst + 1, colFirst - 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst + 1, colFirst - 1] = "X";
                                }
                            }
                            if (colFirst + 1 < matrix.GetLength(1) && rowFirst - 1 >= 0) // uspredka
                            {
                                if (matrix[rowFirst - 1, colFirst + 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst - 1, colFirst + 1] = "X";
                                }
                                if (matrix[rowFirst - 1, colFirst + 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst - 1, colFirst + 1] = "X";
                                }
                            }
                            matrix[rowFirst, colFirst] = "X";
                        }
                        if (matrix[rowFirst, colFirst] == ">")
                        {
                            secondSinkShips++;
                            matrix[rowFirst, colFirst] = "X";
                        }
                    }
                }
                else if (i % 2 == 1)
                {
                    string[] separetedNums = coordinates[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int rowFirst = int.Parse(separetedNums[0]);
                    int colFirst = int.Parse(separetedNums[1]);
                    if (IsInTheMatrix(matrix, rowFirst, colFirst))
                    {
                        if (matrix[rowFirst, colFirst] == "#")
                        {
                            if (rowFirst + 1 < matrix.GetLength(0))
                            {
                                if (matrix[rowFirst + 1, colFirst] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst + 1, colFirst] = "X";
                                }
                                if (matrix[rowFirst + 1, colFirst] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst + 1, colFirst] = "X";
                                }
                            }
                            if (rowFirst - 1 >= 0)
                            {
                                if (matrix[rowFirst - 1, colFirst] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst - 1, colFirst] = "X";
                                }
                                if (matrix[rowFirst - 1, colFirst] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst - 1, colFirst] = "X";
                                }
                            }
                            if (colFirst + 1 < matrix.GetLength(1))
                            {
                                if (matrix[rowFirst, colFirst + 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst, colFirst + 1] = "X";
                                }
                                if (matrix[rowFirst, colFirst + 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst, colFirst + 1] = "X";
                                }
                            }
                            if (colFirst - 1 >= 0)
                            {
                                if (matrix[rowFirst, colFirst - 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst, colFirst - 1] = "X";
                                }
                                if (matrix[rowFirst, colFirst - 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst, colFirst - 1] = "X";
                                }
                            }
                            if (colFirst - 1 >= 0 && rowFirst - 1 >= 0) // 
                            {
                                if (matrix[rowFirst - 1, colFirst - 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst - 1, colFirst - 1] = "X";
                                }
                                if (matrix[rowFirst - 1, colFirst - 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst - 1, colFirst - 1] = "X";
                                }
                            }
                            if (colFirst + 1 < matrix.GetLength(1) && rowFirst + 1 < matrix.GetLength(0)) // uspredka
                            {
                                if (matrix[rowFirst + 1, colFirst + 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst + 1, colFirst + 1] = "X";
                                }
                                if (matrix[rowFirst + 1, colFirst + 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst + 1, colFirst + 1] = "X";
                                }
                            }
                            if (colFirst - 1 >= 0 && rowFirst + 1 < matrix.GetLength(0)) // uspredka
                            {
                                if (matrix[rowFirst + 1, colFirst - 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst + 1, colFirst - 1] = "X";
                                }
                                if (matrix[rowFirst + 1, colFirst - 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst + 1, colFirst - 1] = "X";
                                }
                            }
                            if (colFirst + 1 < matrix.GetLength(1) && rowFirst - 1 >= 0) // uspredka
                            {
                                if (matrix[rowFirst - 1, colFirst + 1] == "<")
                                {
                                    secondSinkShips++;
                                    matrix[rowFirst - 1, colFirst + 1] = "X";
                                }
                                if (matrix[rowFirst - 1, colFirst + 1] == ">")
                                {
                                    firstSinkShips++;
                                    matrix[rowFirst - 1, colFirst + 1] = "X";
                                }
                            }
                            matrix[rowFirst, colFirst] = "X";
                        }
                        if (matrix[rowFirst, colFirst] == "<")
                        {
                            firstSinkShips++;
                            matrix[rowFirst, colFirst] = "X";
                        }
                    }
                }
                var countFrst = 0;
                var countSecond = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == "<")
                        {
                            countFrst++;
                        }
                        else if (matrix[row, col] == ">")
                        {
                            countSecond++;
                        }
                    }
                }
                if (countFrst == 0 || countSecond == 0)
                {
                    firstCount = countFrst;
                    secondCount = countSecond;
                    break;
                }
            }
            if (firstCount > 0)
            {
                Console.WriteLine($"Player One has won the game! {secondSinkShips + firstSinkShips} ships have been sunk in the battle.");
            }
            else if (secondCount > 0)
            {
                Console.WriteLine($"Player Two has won the game! {secondSinkShips + firstSinkShips} ships have been sunk in the battle.");
            }
            else
            {
                var fstCount = 0;
                var sectCount = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == ">")
                        {
                            fstCount++;
                        }
                        if (matrix[row, col] == "<")
                        {
                            sectCount++;
                        }
                    }
                }
                Console.WriteLine($"It's a draw! Player One has {sectCount} ships left. Player Two has {fstCount} ships left.");
            }
           
        }
        public static bool IsInTheMatrix(string[,] matrix, int row, int col)
        {
            return row >= 0 && matrix.GetLength(0) > col && col >= 0 && matrix.GetLength(1) > col;
        }
    }
}
