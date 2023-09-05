using System;

namespace ShmoogleCounter
{
    class Program
    {

        static void AddCountOfParameterToType(string word, ref int size, ref string[] str)
        {
            if (word.EndsWith(";") || word.EndsWith(")"))
            {
                str[size] = word.Substring(0, word.Length - 1);
            }
            else
            {
                str[size] = word;
            }
            size++;
        }

        static void PrintArray(string[] array, string name)
        {
            if (array.Length == 0)
            {
                Console.WriteLine($"{name}: None");
            }
            else
            {
                Console.WriteLine($"{name}: [{string.Join(", ", array)}]");
            }
        }

        static void Main(string[] avgs)
        {
            string input;
            const int size = 251;
            string[] doubles = new string[size];
            int doublesSize = 0;
            string[] ints = new string[size];
            int intsSize = 0;
            bool isEndOfProgram = false;

            while (!isEndOfProgram)
            {
                input = Console.ReadLine();
                string[] words = input.Split();

                if (words[0] == "//END_OF_CODE")
                {
                    isEndOfProgram = true;
                    break;
                }

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == "double" || words[i].Contains("(double"))
                    {
                        AddCountOfParameterToType(words[i+1], ref doublesSize, ref doubles);
                    }
                    else if (words[i] == "int" || words[i].Contains("(int"))
                    {
                        AddCountOfParameterToType(words[i+1], ref intsSize, ref ints);
                    }
                }
            }

            PrintArray(ints, "Ints");
            PrintArray(doubles, "Doubles: ");
        }
    }
}

