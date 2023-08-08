using System;

namespace Arrays
{
    class Program
    {
        static void DisplayAllocatedArray()
        {
            Console.WriteLine("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            const int multiplier = 5;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i * multiplier);
            }
        }

        static bool IsArraysAreEqual()
        {
            Console.WriteLine("Enter the size of arrays: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            Console.WriteLine("Enter elements of the first array: ");

            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int[] array2 = new int[size];
            Console.WriteLine("Enter elements of the second array: ");
            
            for (int i = 0; i < size; i++)
            {
                array2[i] = int.Parse(Console.ReadLine());
            }

            bool isEqual = true;
            
            for (int i = 0; i < size; i++)
            {

                if (array[i] != array2[i])
                {
                    isEqual = false;
                    break;
                }
            }

            return isEqual;
        }

        // static void DisplayComparingCharArrays()
        // {
        //     Console.WriteLine("Enter first char array: ");
        //     string firstAsAString = Console.ReadLine();
        //     char[] firstArray = firstAsAString.ToCharArray();
        //     int firstArrayLength = firstArray.Length;

        //     Console.WriteLine("Enter second char array: ");
        //     string secondAsAString = Console.ReadLine();
        //     char[] seconArray = secondAsAString.ToCharArray();
        //     int secondArrayLength = secondArray.Length;

        //     Console.Write(secondArrayLenght);

            


        // }

        static void DisplayMaximalSequence()
        {
            Console.WriteLine("Enter the size of the arrays: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            Console.WriteLine("Enter elements of the array: ");

            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int longestCounter = 1;
            int currentCounter = 1;

            for (int i = 0; i < size - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    currentCounter++;

                    if (currentCounter > longestCounter)
                    {
                        longestCounter = currentCounter;
                    }
                }
                else
                {
                    currentCounter = 1;
                }
            }

            Console.WriteLine("Longest sequence " + longestCounter);
        }

        static void DisplayMaximalIncreasingSequence()
        {
            Console.WriteLine("Enter the size of the arrays: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            Console.WriteLine("Enter elements of the array: ");

            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int longestCounter = 1;
            int currentCounter = 1;

            for (int i = 0; i < size - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    currentCounter++;

                    if (currentCounter > longestCounter)
                    {
                        longestCounter = currentCounter;
                    }
                }
                else
                {
                    currentCounter = 1;
                }
            }

            Console.WriteLine("Longest sequence " + longestCounter);
        }

        static void DisplayMaximalKSum()
        {
            Console.WriteLine("Enter the size of the arrays: ");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of elements you want to sum: ");
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            Console.WriteLine("Enter elements of the array: ");

            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < size - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < size; j++)
                {

                    if (array[j] > array[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int temp = array[maxIndex];
                array[maxIndex] = array[i];
                array[i] = temp;
            }

            int sum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += array[i];
            }

            Console.WriteLine("Sum: " + sum);
        }

        static void DisplaySelectionSort()
        {
            Console.WriteLine("Enter the size of the arrays: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            Console.WriteLine("Enter elements of the array: ");

            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < size - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < size; j++)
                {

                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }

            Console.WriteLine("Sorted array: ");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static void DisplayMostFrequentElemenOfArray()
        {
            Console.WriteLine("Enter the size of the arrays: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            Console.WriteLine("Enter elements of the array: ");

            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            
            int maxCounter = 1;
            int currentCounter = 1;
            int maxElement = 0;

            for (int i = 0; i < size - 1; i++)
            {

                for (int j = i + 1; j < size; j++)
                {

                    if(array[i] == array[j])
                    {
                        currentCounter++;
                    }
                }

                if (currentCounter > maxCounter)
                {
                    maxCounter = currentCounter;
                    maxElement = array[i];
                }

                currentCounter = 1;

            }

            Console.WriteLine($"{maxElement} ({maxCounter} times)");
        }

        // static void DisplayElementsWichAreSumOfGivenNumber()
        // {
        //     Console.WriteLine("Enter the size of the arrays: ");
        //     int size = int.Parse(Console.ReadLine());

        //     Consle.WriteLine("Enter the number: ");
        //     int number = int.Parse(Console.ReadLIne());

        //     int[] array = new int[size];
        //     Console.WriteLine("Enter elements of the array: ");

        //     for (int i = 0; i < size; i++)
        //     {
        //         array[i] = int.Parse(Console.ReadLine());
        //     }

        //     for (int i = 0; i < size - 1; i++)
        //     {
        //         number -= array[i];

        //         for (int j = 0; j < size; j++)
        //         {
        //             number -= array[j];
        //         }

        //         if (number == 0)
        //         {
        //             Console.WriteLine()
        //         }
        //     }
        // }


        static void DinplayIndexOfLetters()
        {
            
        }

        static void Main(string[] args)
        {
            DisplayMostFrequentElemenOfArray();
        }
    }
}




