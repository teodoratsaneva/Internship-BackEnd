using System;

namespace Loops
{
    class Program2
    {
        static void DisplayNumbersFrom1ToN()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                Console.Write(i + 1);
            }
        }

        static void DisplayNumbersThatIsNotDivisibleTo3And7()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            const int divisor = 3;
            const int divisor2 = 7;

            for (int i = 0; i < number; i++)
            {
                if ((i + 1) % divisor == 0 || (i + 1) % divisor2 == 0)
                {
                    continue;
                }
                else
                {
                    Console.Write((i + 1) + " ");
                }
            }
        }

        static void DisplaySum()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a x: ");
            int x = int.Parse(Console.ReadLine());

            double sum = 1.0;
            double factoriel = 1.0;

            for (int i = 1; i <= number; i++)
            {
                factoriel *= i;
                sum += factoriel / x;
            }

            Console.WriteLine(sum);
        }

        static void DisplayCalculation()
        {
            Console.WriteLine("Enter a number N: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number K: ");
            int number2 = int.Parse(Console.ReadLine());

            float factorielN = 1.0f;
            float factorielK = 1.0f;

            for (int i = 1; i <= number; i++)
            {
                factorielN *= i;
            }

            for (int j = 1; j <= number2; j++)
            {
                factorielK *= j;
            }

            Console.WriteLine(factorielN / factorielK);
        }

        static void DisplayCalculationsOfCombinatorics()
        {
            Console.WriteLine("Enter a number N: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number K: ");
            int number2 = int.Parse(Console.ReadLine());
            int factorielN = 1;
            int factorielK = 1;
            int factorielNMinusK = 1;

            for (int i = 1; i <= number; i++)
            {
                factorielN *= i;

                if (i <= number2)
                {
                    factorielK *= i;
                }

            }

            for (int j = 1; j <= (number - number2); j++)
            {
                factorielNMinusK *= j;
            }

            Console.WriteLine(factorielN / (factorielK * factorielNMinusK));
        }

        static void DisplayCatalanNumbers()
        {
            Console.WriteLine("Enter a number N: ");
            int number = int.Parse(Console.ReadLine());

            long numerator = 1;
            long denumirator = 1;

            for (int i = 1; i <= 2 * number; i++)
            {
                numerator *= i;

                if (i <= number)
                {
                    denumirator *= i;
                }
            }

            for (int j = 1; j <= (number + 1); j++)
            {
                denumirator *= j;
            }

            Console.WriteLine(numerator / denumirator);
        }

        static void DisplayMatrixOfNumbers()
        {
            Console.WriteLine("Enter a number N: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number; j++)
                {
                    Console.Write((j + i - 1) + " ");
                }

                Console.WriteLine();
            }
        }

        static bool AreProductsOfEvenAndOddNumbersEqual()
        {
            Console.WriteLine("Enter a number N: ");
            int counter = int.Parse(Console.ReadLine());

            int productOfOddNumbers = 1;
            int productOfEvenNumbers = 1;

            for (int i = 0; i < counter; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    productOfEvenNumbers *= number;
                }
                else
                {
                    productOfOddNumbers *= number;
                }
            }

            return productOfEvenNumbers == productOfOddNumbers;
        }

        static void ConvetDecimalToBinary()
        {
            Console.Write("Enter a decimal number: ");
            long number = int.Parse(Console.ReadLine());

            long remainder;
            string result = string.Empty;

            while (number > 0)
            {
                remainder = number % 2;
                number /= 2;
                result = remainder.ToString() + result;
            }

            Console.WriteLine(result);
        }

        static void ConversBinaryToDecimal()
        {
            Console.Write("Enter a binary number: ");
            string number = Console.ReadLine();

            double result = 0;
            int power = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int digit = int.Parse(number[i].ToString());
                result += digit * Math.Pow(2, power);
                power++;
            }

            Console.WriteLine(result);
        }

        static void DisplayFactorialZerosCount()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            double factorielN = 1.0;

            for (int i = 1; i <= number; i++)
            {
                factorielN *= i;
            }

            long counter = 0;

            while (factorielN % 10 == 0)
            {
                counter++;
                factorielN /= 10;
            }

            Console.WriteLine(counter);
        }

        static void DisplayGCDOfTwoNumbers()
        {
            Console.WriteLine("Enter a first number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a second number: ");
            int number2 = int.Parse(Console.ReadLine());

            while (number2 != 0)
            {
                int temp = number2;
                number2 = number % number2;
                number = temp;
            }

            Console.WriteLine(number);
        }

        static void DisplaySpiralMatrix()
        {
            Console.Write("Enter a positive integer n: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int currentValue = 1;
            int startRow = 0, endRow = n - 1, startCol = 0, endCol = n - 1;

            while (currentValue <= n * n)
            {
                for (int i = startCol; i <= endCol; i++)
                {
                    matrix[startRow, i] = currentValue++;
                }

                startRow++;

            for (int i = startRow; i <= endRow; i++)
            {
                matrix[i, endCol] = currentValue++;
            }

            endCol--;

            for (int i = endCol; i >= startCol; i--)
            {
                matrix[endRow, i] = currentValue++;
            }

            endRow--;

            for (int i = endRow; i >= startRow; i--)
            {
                matrix[i, startCol] = currentValue++;
            }

            startCol++;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            ConversBinaryToDecimal();
        }
    }
}
