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

        static int[] GetAllEvensFromArray(int[] array, int size)
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

        static int[] GetAllOddsFromArray(int[] array, int size)
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

        static int[] GetFilteredArray(int[] array, Predicate<int> filter, int size)
        {
            int[] filteredArray = new int[size];
            int j = 0;

            foreach (int num in array)
            {
                if (filter(num))
                {
                    filteredArray[j] = num;
                    j++;
                }
            }

            return filteredArray;
        }

        static int GetExtremumIndex(int[] array, Predicate<int> filter, string[] words)
        {
            int extremumResultId = -1;
            bool isOdd = words.Contains("odd");

            for (int i = 0; i < array.Length; i++)
            {
                bool isCurrentValueValid = (isOdd && array[i] % 2 != 0) || (!isOdd && array[i] % 2 == 0);

                if (isCurrentValueValid && filter(array[i]))
                {
                    if (extremumResultId == -1 || array[i] > array[extremumResultId])
                    {
                        extremumResultId = i;
                    }
                }
            }

            return extremumResultId;
        }
        static void PrintFirstsOrLastsOfArray(int[] array, int count, string command, bool isFirst)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            Predicate<int> filter = isFirst ? (int x) => x % 2 == 0 : (int x) => x % 2 != 0;

            int[] filteredArray = GetFilteredArray(array, filter, array.Length);
            int[] resultArray = isFirst ? filteredArray.Take(count).ToArray() : filteredArray.Reverse().Take(count).Reverse().ToArray();

            Console.WriteLine("[" + string.Join(", ", resultArray) + "]");
        }
        enum Operation
        {
            Exchange,
            First,
            Last,
            Max,
            Min,
            End,
            Invalid
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

                Operation operation;

                if (Enum.TryParse(words[0], true, out operation))
                {
                    switch (operation)
                    {
                        case Operation.Exchange:
                            int index = int.Parse(words[1]);
                            array = GetExchangedArray(array, index);
                            break;
                        case Operation.First:
                            count = int.Parse(words[1]);
                            PrintFirstsOrLastsOfArray(array, count, command, true);
                            break;
                        case Operation.Last:
                            count = int.Parse(words[1]);
                            PrintFirstsOrLastsOfArray(array, count, command, false);
                            break;
                        case Operation.Max:
                            int maxIndex = GetExtremumIndex(array, x => x % 2 == 0, words);
                            Console.WriteLine(maxIndex == -1 ? "No matches" : maxIndex);
                            break;
                        case Operation.Min:
                            int minIndex = GetExtremumIndex(array, x => x % 2 == 0, words);
                            Console.WriteLine(minIndex == -1 ? "No matches" : minIndex);
                            break;
                        case Operation.End:
                            running = false;
                            Console.WriteLine("[" + string.Join(", ", array) + "]");
                            break;
                        case Operation.Invalid:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}
