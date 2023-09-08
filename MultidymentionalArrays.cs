using System;

namespace MultidymentionalArrays
{
    class Program
    {
        static int[,] CreateMatrix(int rows, int cols)
        {
            Console.WriteLine("Enter the matrix: ");
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }

        static void DisplayMatrixByColumns(int[,] matrix, int size)
        {
            int currentValue = 1;
            int startRow = 0, endRow = size - 1, startCol = 0;

            while (currentValue <= size * size)
            {
                for (int i = startRow; i <= endRow; i++)
                {
                    matrix[i, startCol] = currentValue++;
                }

                startCol++;
            }
        }

        static void DisplayMatrixByZigzagColumns(int[,] matrix, int size)
        {

            int currentValue = 1;
            int startRow = 0, endRow = size - 1, startCol = 0;

            while (currentValue <= size * size)
            {
                if (startCol % 2 == 0)
                {
                    for (int i = startRow; i <= endRow; i++)
                    {
                        matrix[i, startCol] = currentValue++;
                    }
                }
                else
                {
                    for (int i = endRow; i >= startRow; i--)
                    {
                        matrix[i, startCol] = currentValue++;
                    }
                }

                startCol++;
            }
        }

        static void DisplaySpiralMatrix(int[,] matrix, int size)
        {
            int currentValue = 1;
            int startRow = 0, endRow = size - 1, startCol = 0, endCol = size - 1;

            while (currentValue <= size * size)
            {
                for (int i = startRow; i <= endRow; i++)
                {
                    matrix[i, startCol] = currentValue++;
                }

                startCol++;

                for (int i = startCol; i <= endCol; i++)
                {
                    matrix[endRow, i] = currentValue++;
                }

                endRow--;

                for (int i = endRow; i >= startRow; i--)
                {
                    matrix[i, endCol] = currentValue++;
                }

                endCol--;

                for (int i = endCol; i >= startCol; i--)
                {
                    matrix[startRow, i] = currentValue++;
                }

                startRow++;
            }
        }
       
        static void DisplayMatrix()
        {
            Console.WriteLine("Enter the size of matrix: ");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a character: ");
            char character = char.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            switch (character)
            {
                case 'a':
                    DisplayMatrixByColumns(matrix, size);
                    break;
                case 'b':
                    DisplayMatrixByZigzagColumns(matrix, size);
                    break;
                case 'd':
                    DisplaySpiralMatrix(matrix, size);
                    break;

            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
        
        static void DisplaySumOfElements()
        {
            Console.WriteLine("Enter the size of rows in matrix: ");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the size of columns in matrix: ");
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = CreateMatrix(rows, cols);
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j];
                }
            }

            Console.WriteLine(sum);
        }
        
        static bool IsElementInRow(int[] array, int size, int element)
        {
            int leftSide = 0;
            int rightSide = size - 1;

            while (leftSide < rightSide)
            {
                int midd = (leftSide + rightSide) / 2;

                if (array[midd] == element)
                {
                    return true;
                }

                leftSide = array[midd] < element ? midd + 1 : midd;
            }

            return false;
        }
        
        static bool IsElementInMatrix()
        {
            Console.WriteLine("Enter the size of rows in matrix: ");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the size of columns in matrix: ");
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = CreateMatrix(rows, cols);
            Console.WriteLine("Enter the element that you want to search: ");
            int element = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                int[] arrayOfRow = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    arrayOfRow[j] = matrix[i, j];
                }

                if (IsElementInRow(arrayOfRow, cols, element))
                {
                    return true;
                }
            }

            return false;
        }
        
        // static void Main(string[] args)
        // {
        //     DisplayMatrix();
        // }
    }
}
