using System;

namespace ShmoogleCounter
{
    class Program
    {
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
                        if (words[i + 1].EndsWith(";") || words[i + 1].EndsWith(")"))
                        {
                            doubles[doublesSize] = words[i + 1].Substring(0, words[i + 1].Length - 1);
                        }
                        else
                        {
                            doubles[doublesSize] = words[i + 1];
                        }
                        doublesSize++;
                    }
                    else if (words[i] == "int" || words[i].Contains("(int"))
                    {
                        if (words[i + 1].EndsWith(";") || words[i + 1].EndsWith(")"))
                        {
                            doubles[intsSize] = words[i + 1].Substring(0, words[i + 1].Length - 1);
                        }
                        else
                        {
                            ints[intsSize] = words[i + 1];
                        }
                        intsSize++;
                    }
                }
            }

            if (doublesSize == 0)
            {
                Console.WriteLine("Doubles: None");
            }
            else
            {
                Console.Write("Doubles: ");
                for (int i = 0; i < doublesSize; i++)
                {
                    if (i == doublesSize - 1)
                    {
                        Console.WriteLine(doubles[i]);
                    }
                    else
                    {
                        Console.Write(doubles[i] + ", ");
                    }
                }
            }

            if (intsSize == 0)
            {
                Console.WriteLine("Ints: None");
            }
            else
            {
                Console.Write("Ints: ");
                for (int i = 0; i < intsSize; i++)
                {
                    if (i == intsSize - 1)
                    {
                        Console.WriteLine(ints[i]);
                    }
                    else
                    {
                        Console.Write(ints[i] + ", ");
                    }
                }
            }
        }
    }
}

