using System;

namespace Expression
{
    class Program
    {
        static void GetMyName()
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

        static void DoSquare()
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

        static void ConvertToBool()
        {
            try
            {
                string str = "True";
                bool b = Convert.ToBoolean(str);
                Console.WriteLine(b);
            }
            catch (Exception)
            {
                Console.WriteLine("The string could not be converted to a boolean");
            }
        }

        static void StudyHall()
        {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                
        }
        static void Main(string[] args)
        {
            DoSquare();
        }
    }
}
