using System;

namespace _9.Super_Mario_14_Aprl_20
{
    class Program // 50/100
    {
        static void Main(string[] args)
        {
            int health = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            string[][] matrix = new string[rows][];

            int MarioRow = 0;
            int MarioCol = 0;

            int PrincessRow = 0;
            int PrincessCol = 0;

            int collumLenght = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                string input = Console.ReadLine();
                collumLenght = input.Length;
                matrix[row] = new string[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col].ToString();

                    if (matrix[row][col] == "M")
                    {
                        MarioRow = row;
                        MarioCol = col;
                    }
                    if (matrix[row][col] == "P")
                    {
                        PrincessRow = row;
                        PrincessCol = col;
                    }
                }
            }


            while (health > 0)
            {
                string[] commmand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = commmand[0];
                int rowBowserRnd = int.Parse(commmand[1]);
                int colBowserRnd = int.Parse(commmand[2]);

                matrix[rowBowserRnd][colBowserRnd] = "B";
                health--;

                if (cmd == "W")
                {
                    if (MarioRow - 1 < 0)
                    {
                        continue;
                    }
                    matrix[MarioRow][MarioCol] = "-";
                    MarioRow--;
                    matrix[MarioRow][MarioCol] = "M";
                    if (matrix[MarioRow][MarioCol] == matrix[PrincessRow][PrincessCol])
                    {
                        matrix[MarioRow][MarioCol] = "-";
                        break;
                    }
                    if (matrix[MarioRow][MarioCol] == matrix[rowBowserRnd][colBowserRnd])
                    {
                        health -= 2;
                        if (health <= 0)
                        {
                            matrix[MarioRow][MarioCol] = "X";

                            break;
                        }
                    }
                    if (matrix[MarioRow][MarioCol] == "B")
                    {
                        health -= 2;
                        if (health <= 0)
                        {
                            matrix[MarioRow][MarioCol] = "X";

                            break;
                        }
                    }
                    if (matrix[MarioRow + 1][MarioCol] == matrix[rowBowserRnd][colBowserRnd])
                    {
                        matrix[rowBowserRnd][colBowserRnd] = "B";
                    }
                }
                //
                if (cmd == "S")
                {
                    if (MarioRow + 1 >= rows)
                    {
                        continue;
                    }
                    matrix[MarioRow][MarioCol] = "-";
                    MarioRow++;
                    matrix[MarioRow][MarioCol] = "M";
                    if (matrix[MarioRow][MarioCol] == matrix[PrincessRow][PrincessCol])
                    {
                        matrix[MarioRow][MarioCol] = "-";
                        break;
                    }
                    if (matrix[MarioRow][MarioCol] == matrix[rowBowserRnd][colBowserRnd])
                    {
                        health -= 2;
                        if (health <= 0)
                        {
                            matrix[MarioRow][MarioCol] = "X";
                          
                            break;
                        }
                    }
                    if (matrix[MarioRow][MarioCol] == "B")
                    {
                        health -= 2;
                        if (health <= 0)
                        {
                            matrix[MarioRow][MarioCol] = "X";

                            break;
                        }
                    }
                    if (matrix[MarioRow -1 ][MarioCol] == matrix[rowBowserRnd][colBowserRnd])
                    {
                        matrix[rowBowserRnd][colBowserRnd] = "B";
                    }
                }
                //
                if (cmd == "A" )
                {
                    if (MarioCol - 1 < 0)
                    {
                        continue;
                    }
                    matrix[MarioRow][MarioCol] = "-";
                    MarioCol--;
                    matrix[MarioRow][MarioCol] = "M";
                    if (matrix[MarioRow][MarioCol] == matrix[PrincessRow][PrincessCol])
                    {
                        matrix[MarioRow][MarioCol] = "-";
                        break;
                    }
                    if (matrix[MarioRow][MarioCol] == matrix[rowBowserRnd][colBowserRnd])
                    {
                        health -= 2;
                        if (health <= 0)
                        {
                            matrix[MarioRow][MarioCol] = "X";
                      
                            break;
                        }
                    }
                    if (matrix[MarioRow][MarioCol] == "B")
                    {
                        health -= 2;
                        if (health <= 0)
                        {
                            matrix[MarioRow][MarioCol] = "X";

                            break;
                        }
                    }
                    if (matrix[MarioRow][MarioCol+1] == matrix[rowBowserRnd][colBowserRnd])
                    {
                        matrix[rowBowserRnd][colBowserRnd] = "B";
                    }
                }
                if (cmd == "D" )
                {
                    if (MarioCol + 1 >= collumLenght)
                    {
                        continue;
                    }
                    matrix[MarioRow][MarioCol] = "-";
                    MarioCol++;
                    matrix[MarioRow][MarioCol] = "M";
                    if (matrix[MarioRow][MarioCol] == matrix[PrincessRow][PrincessCol])
                    {
                        matrix[MarioRow][MarioCol] = "-";
                        break;
                    }
                    if (matrix[MarioRow][MarioCol] == matrix[rowBowserRnd][colBowserRnd])
                    {
                        health -= 2;
                        if (health <= 0)
                        {
                            matrix[MarioRow][MarioCol] = "X";
                       
                            break;
                        }
                    }
                    if (matrix[MarioRow][MarioCol] == "B")
                    {
                        health -= 2;
                        if (health <= 0)
                        {
                            matrix[MarioRow][MarioCol] = "X";

                            break;
                        }
                    }
                    if (matrix[MarioRow][MarioCol -1 ] == matrix[rowBowserRnd][colBowserRnd])
                    {
                        matrix[rowBowserRnd][colBowserRnd] = "B";
                    }
                }
                 //PrintText(matrix);
            }

            if (health > 0)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {health}");
            }
            else
            {
                Console.WriteLine($"Mario died at {MarioRow};{MarioCol}.");
            }
            PrintText(matrix);
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
    }
}
