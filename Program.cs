using System;

namespace Expression
{
    class Program
    {
        static void DisplayMyName()
        {
            string firstName;
            Console.Write("Enter your first name: ");
            firstName = Console.ReadLine();

            string secondName;
            Console.Write("Enter your last name: ");
            secondName = Console.ReadLine();

            Console.Write("Enter how old are you: ");
            int age = int.Parse(Console.ReadLine());

            string town;
            Console.Write("Enter where you from: ");
            town = Console.ReadLine();

            Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}.", firstName, secondName, age, town);
        }

        static void DisplaySquare()
        {
            Console.Write("Enter a number: ");

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                if ((i == 0) || (i == number - 1))
                {
                    for (int j = 0; j < number; j++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    Console.Write("*");

                    for (int k = 0; k < number - 2; k++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        static void DisplayIsOddOrEvenNumber()
        {
            Console.Write("Enter a number: ");

            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(number % 2 == 0 ? "even " + number : "odd " + number);
        }

        static void DisplayMoonGravity()
        {
            Console.Write("Enter a number: ");

            float number = float.Parse(Console.ReadLine());
            const float gravitationalField = 0.17f;

            Console.WriteLine(number * gravitationalField);
        }

        static void DisplayIsNumberDivideBy7And5()
        {
            Console.Write("Enter a number: ");

            int number = int.Parse(Console.ReadLine());

            const int firstDivisor = 7;
            const int secondDivisor = 5;

            Console.WriteLine(number % firstDivisor == 0 || number % secondDivisor == 0 ? "true " + number : "false " + number);
        }

        static void DisplayRectangleArea()
        {
            Console.Write("Enter a width of the rectangle: ");
            float width = float.Parse(Console.ReadLine());

            Console.Write("Enter a height of the rectangle: ");
            float height = float.Parse(Console.ReadLine());

            Console.WriteLine(width * height + " " + (width * 2 + height * 2));
        }

        static void DisplayIsThirdDigitEqualTo7()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int thirdDigit = (number / 100) % 10;
            const int digit = 7;

            Console.WriteLine(thirdDigit == digit ? "True" : ("False " + thirdDigit));
        }

        static int GetSumOfDigits(int number)
        {
            int sum = 0;

            while(number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        static int GetReversedNumber(int number)
        {
            int reversedNumber = 0;

            while(number != 0)
            {
                reversedNumber = (reversedNumber * 10) + (number % 10);
                number /= 10;
            }

            return reversedNumber;
        }

        static int GetChagedNumber(int number)
        {
            int changedNum = number % 10;
            changedNum = (changedNum * 1000) + number / 10;

            return changedNum;
        }

        static int GetExchagedNumber(int number)
        {
            int firstDigit = number / 1000;
            int secondDigit = (number / 100) % 10;
            int thirdDigit = (number / 10) % 10;
            int fourthDigit = number % 10;
            int exchangedNumber = (firstDigit * 1000) + (thirdDigit * 100) + (secondDigit * 10) + fourthDigit;

            return  exchangedNumber;
        }
        
        static void DisplayFourDigits()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int sum = GetSumOfDigits(number);
            int reversedNumber = GetReversedNumber(number);
            int changedNum = GetChagedNumber(number);
            int exchangedNumber = GetExchagedNumber(number);

            Console.WriteLine(sum + " " + reversedNumber + " " + changedNum + " " + exchangedNumber);
        }


        static bool IsPrime()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number <= 1)
            {
                return false;
            }

            int sqrt = (int)Math.Sqrt(number);
            int divisor = 2;
            bool isPrime = true;

            while (divisor <= sqrt)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            divisor++;
            }

            return isPrime;
        }
    
        static void DislpayTrapezoidArea()
        {
            Console.Write("Enter the side a: ");
            float a = float.Parse(Console.ReadLine());

            Console.Write("Enter the side b: ");
            float b = float.Parse(Console.ReadLine());

            Console.Write("Enter the height h: ");
            float h = float.Parse(Console.ReadLine());

            Console.WriteLine(((a + b)* h) / 2);
        }

        static int ConvetDecimalToBinary()
        {      
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int remainder;
            string result = string.Empty;

            while (number > 0)
            {
                remainder = number % 2;
                number /= 2;
                result = remainder.ToString() + result;
            }

            return int.Parse(result);
        }


        static void DisplayThirdBitValue()
        {
            Console.Write("Enter a positive integer: ");
            int number = int.Parse(Console.ReadLine());

            const int shiftsCount = 3;

            if (number < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            int thirdBitValue = (number >> shiftsCount) & 1;

            Console.WriteLine(thirdBitValue);
        }

        static void DisplayNthBitValue()
        {
            Console.Write("Enter a positive integer: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter hpw many shifts: ");
            int shiftsCount = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            int nthBitValue = (number >> shiftsCount) & 1;

            Console.WriteLine(nthBitValue);
        }

        static void Main(string[] args)
        {
            DisplayNthBitValue();
        }
    }
}


