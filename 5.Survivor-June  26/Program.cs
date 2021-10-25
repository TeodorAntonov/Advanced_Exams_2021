using System;

namespace _5.Survivor_June__26
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsOfTheBeach = int.Parse(Console.ReadLine());

            string[][] tableTokens = new string[rowsOfTheBeach][];

            for (int row = 0; row < tableTokens.Length; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                tableTokens[row] = new string[input.Length];

                for (int i = 0; i < input.Length; i++)
                {
                    tableTokens[row][i] = input[i].ToString();
                }
            }

            int myTokens = 0;
            int opponentTokens = 0;

            string commnad = Console.ReadLine();

            while (commnad != "Gong")
            {
                string[] cmd = commnad.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);

                if (action == "Find")
                {
                    if (InsideTheMatrix(tableTokens, row, col) && tableTokens[row][col] == "T")
                    {
                        myTokens++;
                        tableTokens[row][col] = "-";
                    }
                }
                else if (action == "Opponent")
                {
                    string directions = cmd[3];
                    if (InsideTheMatrix(tableTokens, row, col) && tableTokens[row][col] == "T")
                    {
                        opponentTokens++;
                        tableTokens[row][col] = "-";

                        switch (directions)
                        {
                            case "up":

                                for (int i = 0; i <= 3; i++)
                                {
                                    int newRow = row--;
                                    int newCol = col;
                                    if (InsideTheMatrix(tableTokens, newRow, newCol))
                                    {
                                        if (tableTokens[newRow][newCol] == "T")
                                        {
                                            opponentTokens++;
                                            tableTokens[newRow][newCol] = "-";
                                        }
                                    }
                                }
                                break;

                            case "down":
                                for (int i = 0; i <= 3; i++)
                                {
                                    int newRow = row++;
                                    int newCol = col;
                                    if (InsideTheMatrix(tableTokens, newRow, newCol))
                                    {
                                        if (tableTokens[newRow][newCol] == "T")
                                        {
                                            opponentTokens++;
                                            tableTokens[newRow][newCol] = "-";
                                        }
                                    }
                                }

                                break;
                            case "right":
                                for (int i = 0; i <= 3; i++)
                                {
                                    int newRow = row;
                                    int newCol = col++;
                                    if (InsideTheMatrix(tableTokens, newRow, newCol))
                                    {
                                        if (tableTokens[newRow][newCol] == "T")
                                        {
                                            opponentTokens++;
                                            tableTokens[newRow][newCol] = "-";
                                        }
                                    }
                                }
                                break;
                            case "left":
                                for (int i = 0; i <= 3; i++)
                                {
                                    int newRow = row;
                                    int newCol = col--;
                                    if (InsideTheMatrix(tableTokens, newRow, newCol))
                                    {
                                        if (tableTokens[newRow][newCol] == "T")
                                        {
                                            opponentTokens++;
                                            tableTokens[newRow][newCol] = "-";
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                commnad = Console.ReadLine();
            }

            PrintText(tableTokens);

            Console.WriteLine("Collected tokens: "+ myTokens);
            Console.WriteLine("Opponent's tokens: " + opponentTokens);
        }

        private static void PrintText(string[][] tableTokens)
        {
            for (int row = 0; row < tableTokens.Length; row++)
            {
                for (int i = 0; i < tableTokens[row].Length; i++)
                {
                    Console.Write(tableTokens[row][i]+" ");
                }
                Console.WriteLine();
            }
        }

        public static bool InsideTheMatrix(string[][] matrix, int row, int col)
        {
            return row < matrix.Length && row >= 0 && col < matrix[row].Length && col >= 0;
        }
    }
}
