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
            Console.Write("Enter a number: ");

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if ((i == 0) || (i == n - 1))
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    Console.Write("*");
                    for (int k = 0; k < n - 2; k++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void OddOrEvenNumber()
        {
            Console.Write("Enter a number: ");

            var num = int.Parse(Console.ReadLine());

            if (num % 2 == 0)
                Console.WriteLine("even {0}", num);
            else
                Console.WriteLine("odd {0}", num);
        }

        static void MoonGravity()
        {
            Console.Write("Enter a number: ");

            var num = float.Parse(Console.ReadLine());

            Console.WriteLine(num * 0.17f);
        }

        static void DivideBy7And5()
        {
            Console.Write("Enter a number: ");

            var num = int.Parse(Console.ReadLine());

            if(num % 7 == 0 || num % 5 == 0)
                Console.WriteLine("true {0}", num);
            else
                Console.WriteLine("false {0}", num);
        }

        static void Rectangles()
        {
            Console.Write("Enter a width of the rectangle: ");
            var width = float.Parse(Console.ReadLine());

            Console.Write("Enter a height of the rectangle: ");
            var height = float.Parse(Console.ReadLine());

            Console.WriteLine(width*height + " " + (width*2 + height*2));
        }

        static void ThirdDigitCheck()
        {
            Console.Write("Enter a number: ");
            var num = int.Parse(Console.ReadLine());

            int thirdDigit = (num / 100) % 10;

            if (thirdDigit == 7)
                Console.WriteLine("true");
            else
                Console.WriteLine("false " + thirdDigit);
        }
        
        static void FourDigits()
        {
            Console.Write("Enter a number: ");
            var num = int.Parse(Console.ReadLine());

            int sum = 0;
            int numCopy = num;
            while(numCopy != 0)
            {
                sum += numCopy % 10;
                numCopy /= 10;
            }
            int reversedNumber = 0;
            int numCopy2 = num;
            while(numCopy2 != 0)
            {
                reversedNumber = (reversedNumber * 10) + (numCopy2 % 10);
                numCopy2 /= 10;
            }
            int numCopy3 = num;
            int changedNum = numCopy3 % 10;
            changedNum = (changedNum * 1000) + numCopy3 / 10;

            int firstDigit = num / 1000;
            int secondDigit = (num / 100) % 10;
            int thirdDigit = (num / 10) % 10;
            int fourthDigit = num % 10;
            int exchangedNumber = (firstDigit * 1000) + (thirdDigit * 100) + (secondDigit * 10) + fourthDigit;

            Console.WriteLine(sum + " " + reversedNumber + " " + changedNum + " " + exchangedNumber);
        }


        static bool IsPrime()
        {
            Console.Write("Enter a number: ");
            var num = int.Parse(Console.ReadLine());

            if (num <= 1)
            {
                return false;
            }

            int sqrt = (int)Math.Sqrt(num);
            for (int i = 2; i <= sqrt; i++)
            {
                if (num % i == 0)
                    return false;
            }

             return true;
        }
    
        static void FindTrapezoidArea()
        {
            Console.Write("Enter the side a: ");
            var a = float.Parse(Console.ReadLine());

            Console.Write("Enter the side b: ");
            var b = float.Parse(Console.ReadLine());
            
            Console.Write("Enter the height h: ");
            var h = float.Parse(Console.ReadLine());

            Console.WriteLine(((a + b)* h) / 2);
        }

        static int ConvetDecimalToBinary(int num)
        {      
            int remainder;
            string result = string.Empty;
            while (num > 0)
            {
                remainder = num % 2;
                num /= 2;
                result = remainder.ToString() + result;
            }
            return int.Parse(result);
        }

        static void GetThirdBitValue()
        {
            Console.Write("Enter a positive integer: ");
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            int thirdBitValue = (num >> 3) & 1;

            Console.WriteLine(thirdBitValue);
        }

        static void GetNthBitValue()
        {
            Console.Write("Enter a positive integer: ");
            int num = int.Parse(Console.ReadLine());

            Console.Write("Enter N: ");
            int N = int.Parse(Console.ReadLine());

            if (num < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            int nthBitValue = (num >> N) & 1;

            Console.WriteLine(nthBitValue);
        }

        static void Main(string[] args)
        {
            
        }
    }
}


