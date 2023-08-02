using System;

namespace Expression
{
    class Program
    {

        void getMyName()
        {
            string fname, lname, town;
            Console.Write("Enter your first name: ");
            fname = Console.ReadLine();
            Console.Write("Enter your last name: ");
            lname = Console.ReadLine();
            Console.Write("Enter how old are you: ");
            var age = int.Parse(Console.ReadLine());
            Console.Write("Enter where you from: ");
            town = Console.ReadLine();
            Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}.", fname, lname, age, town);
        }

        void doSquare()
        {
            var n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                if((i == 0 )|| (i ==n - 1))
                {
                    for(int j = 0; j < n; j++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    Console.Write("*");
                    for(int k=0; k<n-2; k++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        void convertToBool()
        {
                try
                {
                    string str = "kk";
                    bool b = Convert.ToBoolean(str);
                    Console.WriteLine(b);
                }
                catch (Exception)
                {
                    Console.WriteLine("The number could not be converted to a byte");
                }
        }

        static void Main(string[] args)
        {
            
        }
    }
}