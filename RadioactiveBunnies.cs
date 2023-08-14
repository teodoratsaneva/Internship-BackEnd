using System;

namespace RadioactiveBunnies
{
    class Program
    {
        static void BunniesMoves(char[][] lair,char[][] newLair, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (lair[i][j] == 'B')
                    {
                        if (i > 0) newLair[i - 1][j] = 'B';
                        if (i < rows - 1) newLair[i + 1][j] = 'B';
                        if (j > 0) newLair[i][j - 1] = 'B';
                        if (j < cols - 1) newLair[i][j + 1] = 'B';
                    }
                }
            }
        }
        static void PrintLair(char[][] lair, int playerRow, int playerCol, string status)
        {
            foreach (var row in lair)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine($"{status}: {playerRow} {playerCol}");
        }
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);
            int playerRow = 0;
            int playerCol = 0;
            char[][] lair = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                lair[i] = Console.ReadLine().ToCharArray();

                if (Array.IndexOf(lair[i], 'P') >= 0)
                {
                    playerRow = i;
                    playerCol = Array.IndexOf(lair[i], 'P');
                }
            }

            string directions = Console.ReadLine();

            foreach (char direction in directions)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;

                switch (direction)
                {
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                }

                char[][] newLair = new char[rows][];

                for (int i = 0; i < rows; i++)
                {
                    newLair[i] = new char[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        newLair[i][j] = lair[i][j];
                    }
                }

                newLair[oldPlayerRow][oldPlayerCol] = '.';

                BunniesMoves(lair, newLair, rows, cols);

                if (playerRow < 0 || playerRow >= rows || playerCol < 0 || playerCol >= cols)
                {
                    PrintLair(newLair, oldPlayerRow, oldPlayerCol, "won");
                    return;
                }
                else if (newLair[playerRow][playerCol] == 'B')
                {
                    PrintLair(newLair, playerRow, playerCol, "dead");
                    return;
                }

                lair = newLair;
            }
        }
    }
}

