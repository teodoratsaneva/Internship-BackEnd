using System;

namespace ConsoleInputOutput
{
    class Program2
    {
        static void DisplaySumOf3Numbers()
        {
            Console.Write("Enter the first number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number: ");
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(num1 + num2 + num3);
        }

        static void DisplayCirclePerimeterAndArea()
        {
            Console.Write("Enter the radius ofcircle: ");
            float r = float.Parse(Console.ReadLine());

            const float pi = 3.14f;

            Console.WriteLine(2 * pi * r);
            Console.WriteLine(r * r * pi);
        }

        static void CompareNumber()
        {
            Console.Write("Enter the first number: ");
            int number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int number2 = int.Parse(Console.ReadLine());

            Console.Write(number1 > number2 ? number1 : number2);
        }

        static void DisplayNumbersFrom1ToN()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + 1);
            }
        }

        static void DisplayQuadraticEquation()
        {
            Console.Write("Enter a: ");
            float a = float.Parse(Console.ReadLine());

            Console.Write("Enter b: ");
            float b = float.Parse(Console.ReadLine());

            Console.Write("Enter c: ");
            float c = float.Parse(Console.ReadLine());

            float D = b * b - 4 * a * c;

            if (D > 0)
            {
                Console.WriteLine("x1 = " + (-b + Math.Sqrt(D)) / (2 * a));
                Console.WriteLine("x2 = " + (-b - Math.Sqrt(D)) / (2 * a));
            }
            else if (D == 0)
            {
                Console.WriteLine("x = " + (-b) / (2 * a));
            }
            else
            {
                Console.WriteLine("There is no roots");
            }
        }

        static void DisplaySumOfNNumbers()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());

           float[] nums = new float[n];

            for(int j = 0; j < n; j++)
            {
                nums[j] = float.Parse(Console.ReadLine());
            }

            float sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
            }

            Console.WriteLine(sum);
        }

        static void DisplayFibonacciNumbers()
        {
            Console.Write("Enter the number of Fibonacci numbers to generate: ");
            int number = int.Parse(Console.ReadLine());

            int a = 0, b = 1;

            for (int i = 0; i < number; i++)
            {
                Console.Write(a + ", ");
                int temp = a + b;
                a = b;
                b = temp;
            }
        }

        static void DisplayHowManyNumbersHaveBetweenTwoNumbers()
        {
            Console.WriteLine("Enter first number: ");
            int number1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            int number2 = int.Parse(Console.ReadLine());

            int count = 0;

            for(int i = number1 + 1; i < number2; i++)
            {
                if(i % 5 == 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static void Main(string[] args)
        {
            
        }
    }
}
