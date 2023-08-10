using System;

namespace Arrays
{
    class Program
    {

        static void swapElements(int first, int second)
        {
            int temp = second;
            second = first;
            first = temp;
        }
        static int[] createArray(int size)
        {
            int[] array = new int[size];
            Console.WriteLine("Enter elements of the array: ");

            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            return array;
        }
        static void DisplayAllocatedArray()
        {
            Console.WriteLine("Enter a number: ");
            int n;

            if (int.TryParse(Console.ReadLine(), out n))
            {
                int[] array = new int[n];
                const int multiplier = 5;

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(i * multiplier);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static bool AreArraysEqual()
        {
            Console.WriteLine("Enter the size of arrays: ");
            int size = int.Parse(Console.ReadLine());
            int[] array = createArray(size);
            int[] array2 = createArray(size);

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
        static void DisplayMaximalSequence()
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = createArray(size);
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
            Console.WriteLine("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = createArray(size);

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
            Console.WriteLine("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of elements you want to sum: ");
            int k = int.Parse(Console.ReadLine());
            int[] array = createArray(size);

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

                swapElements(array[i], array[maxIndex]);
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
            Console.WriteLine("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());
            int[] array = createArray(size);

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

                swapElements(array[i], array[minIndex]);
            }

            Console.WriteLine("Sorted array: ");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        static void DisplayMostFrequentElemenOfArray()
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());
            int[] array = createArray(size);
            int maxCounter = 1;
            int currentCounter = 1;
            int maxElement = 0;

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (array[i] == array[j])
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
        static int DisplayBinarySearchAlgorthm()
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());
            int[] array = createArray(size);
            Console.WriteLine("Enter element that you want to search: ");
            int element = int.Parse(Console.ReadLine());
            int leftSide = 0;
            int rightSide = size - 1;

            while (leftSide < rightSide)
            {
                int midd = (leftSide + rightSide) / 2;

                if (array[midd] == element)
                {
                    return midd;
                }
                else if (array[midd] < element)
                {
                    leftSide = midd + 1;
                }
                else
                {
                    rightSide = midd;
                }
            }

            return -1;
        }
        static void DisplayIndexOfLetters()
        {
            const int lettersCount = 26;

            Console.WriteLine("Enter the word: ");
            string word = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < lettersCount; j++)
                {
                    if (word[i] == 'a' + j)
                    {
                        Console.WriteLine(j);
                    }
                }
            }
        }

        static void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            for (int i = 0; i < n1; i++)
                leftArr[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                rightArr[j] = arr[middle + 1 + j];

            int k = left;
            int l = 0;
            int r = 0;

            while (l < n1 && r < n2)
            {
                if (leftArr[l] <= rightArr[r])
                {
                    arr[k] = leftArr[l];
                    l++;
                }
                else
                {
                    arr[k] = rightArr[r];
                    r++;
                }

                k++;
            }

            while (l < n1)
            {
                arr[k] = leftArr[l];
                l++;
                k++;
            }

            while (r < n2)
            {
                arr[k] = rightArr[r];
                r++;
                k++;
            }
        }
        static void Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                Sort(arr, left, middle);
                Sort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }
        static void DisplayMergeSortAlgorithm()
        {
            Console.WriteLine("Enter the size of the arrays: ");
            int size = int.Parse(Console.ReadLine());
            int[] array = createArray(size);

            Sort(array, 0, size - 1);

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(array[i]);
            }

        }
        static void DisplayBiggestPrimeNumber()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            bool[] isPrime = new bool[number + 1];

            for (int i = 2; i <= number; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i <= number; i++)
            {
                for (int j = i * i; j <= number; j += i)
                {
                    isPrime[j] = false;
                }
            }

            for (int i = number; i >= 2; i--)
            {
                if (isPrime[i])
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        // static void Main(string[] args)
        // {
            
        // }
    }
}
