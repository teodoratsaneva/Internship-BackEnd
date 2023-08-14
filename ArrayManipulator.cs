using System;

namespace ArrayManipulator
{
    class Program
    {
        static int[] GetExchangedArray(int[] array, int index)
        {

            if (index >= array.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            int[] changedArray = new int[array.Length];

            for (int i = 0; i < array.Length - index - 1; i++)
            {
                changedArray[i] = array[index + i + 1];
            }

            for (int i = array.Length - index - 1; i < array.Length; i++)
            {
                changedArray[i] = array[i - (array.Length - index - 1)];
            }

            return changedArray;
        }
        static int[] GetAllEvens(int[] array, int size)
        {
            int[] arrayResult = new int[size];
            int j = 0;

            foreach (int i in array)
            {
                if (i % 2 == 0)
                {
                    arrayResult[j] = i;
                    j++;
                }
            }

            return arrayResult;
        }
        static int[] GetAllOdds(int[] array, int size)
        {
            int[] arrayResult = new int[size];
            int j = 0;

            foreach (int i in array)
            {
                if (i % 2 != 0)
                {
                    arrayResult[j] = i;
                    j++;
                }
            }

            return arrayResult;
        }
        static int GetMax(int[] array, string[] words)
        {
            int maxResultId = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (words[words.Length - 1] == "odd")
                {
                    if (array[i] % 2 != 0)
                    {
                        maxResultId = i;
                        break;
                    }
                }
                else if (words[words.Length - 1] == "even")
                {
                    if (array[i] % 2 == 0)
                    {
                        maxResultId = i;
                        break;
                    }
                }

            }

            for (int j = maxResultId; j < array.Length; j++)
            {
                if (words[words.Length - 1] == "odd")
                {
                    if (array[j] % 2 != 0)
                    {
                        if (array[maxResultId] < array[j])
                        {
                            maxResultId = j;
                        }
                    }
                }
                else if (words[words.Length - 1] == "even")
                {
                    if (array[j] % 2 == 0)
                    {
                        if (array[maxResultId] < array[j])
                        {
                            maxResultId = j;
                        }
                    }

                }
            }

            return maxResultId;
        }
        static int GetMin(int[] array, string[] words)
        {
            int maxResultId = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (words[words.Length - 1] == "odd")
                {
                    if (array[i] % 2 != 0)
                    {
                        maxResultId = i;
                        break;
                    }
                }
                else if (words[words.Length - 1] == "even")
                {
                    if (array[i] % 2 == 0)
                    {
                        maxResultId = i;
                        break;
                    }
                }

            }

            for (int j = maxResultId; j < array.Length; j++)
            {
                if (words[words.Length - 1] == "odd")
                {
                    if (array[j] % 2 != 0)
                    {
                        if (array[maxResultId] > array[j])
                        {
                            maxResultId = j;
                        }
                    }
                }
                else if (words[words.Length - 1] == "even")
                {
                    if (array[j] % 2 == 0)
                    {
                        if (array[maxResultId] > array[j])
                        {
                            maxResultId = j;
                        }
                    }

                }
            }

            return maxResultId;
        }
        static void GetFirst(int[] array, int count, string[] command)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int[] arrayResult = new int[array.Length];
            if (command[command.Length - 1] == "even")
            {
                arrayResult = GetAllEvens(array, array.Length);
            }
            else if (command[command.Length - 1] == "odd")
            {
                arrayResult = GetAllOdds(array, array.Length);
            }

            Console.WriteLine("[" + string.Join(", ", arrayResult.Take(count)) + "]");
        }
        static void GetLast(int[] array, int count, string[] command)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int[] arrayResult = new int[array.Length];
            if (command[command.Length - 1] == "even")
            {
                arrayResult = GetAllEvens(array, array.Length);
            }
            else if (command[command.Length - 1] == "odd")
            {
                arrayResult = GetAllOdds(array, array.Length);
            }

            Console.WriteLine("[" + string.Join(", ", arrayResult.Reverse().Take(count)) + "]");
        }
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string[] stringArray = numbers.Split();
            int[] array = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                array[i] = int.Parse(stringArray[i]);
            }

            bool running = true;

            while (running)
            {
                string command = Console.ReadLine();
                string[] words = command.Split();
                int count;

                switch (words[0])
                {
                    case "exchange":
                        int index = int.Parse(words[1]);
                        array = GetExchangedArray(array, index);
                        break;
                    case "first":
                        count = int.Parse(words[1]);
                        GetFirst(array, count, words);
                        break;
                    case "last":
                        count = Int32.Parse(words[1]);
                        GetLast(array, count, words);
                        break;
                    case "max":
                        int maxIndex = GetMax(array, words);
                        Console.WriteLine(maxIndex == -1 ? "No matches" : maxIndex);
                        break;
                    case "min":
                        int minIndex = GetMin(array, words);
                        Console.WriteLine(minIndex == -1 ? "No matches" : minIndex);
                        break;
                    case "end":
                        running = false;
                        Console.WriteLine("[" + string.Join(", ", array.Take(array.Length)) + "]");
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}

