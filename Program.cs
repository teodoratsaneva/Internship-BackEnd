using System;

namespace ConditionalStatments
{
    class Program
    {
        static void DisplayExchangeOfTwoNumbers()
        {
            Console.Write("Enter the first number: ");
            int number1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int number2 = int.Parse(Console.ReadLine());

            Console.WriteLine(number2 + " " + number1);
        }

        static void DisplayBonusScore()
        {
            Console.Write("Enter the number: ");
            int number = int.Parse(Console.ReadLine());

            int bonus = 0;

            switch(number)
            {
                case 1:
                case 2:
                case 3:
                    bonus = number * 10;
                    break;
                case 4:
                case 5:
                case 6:
                    bonus = number * 100;
                    break;
                case 7:
                case 8:
                case 9:
                    bonus = number * 1000;
                    break;
                default:
                    Console.WriteLine("Invalid score");
                    return;
            }

            Console.WriteLine(bonus);
        }

        static void DisplaySignOfTheProductOfThreeNumbers()
        {
            Console.Write("Enter the first number: ");
            float number1 = float.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            float number2 = float.Parse(Console.ReadLine());

            Console.Write("Enter the third number: ");
            float number3 = float.Parse(Console.ReadLine());

            float productOfThreeNumbes = number1 * number2 * number3;

            if(productOfThreeNumbes < 0)
            {
                Console.WriteLine('-');
            }
            else if(productOfThreeNumbes > 0)
            {
                Console.WriteLine('+');
            }
            else
            {
                Console.WriteLine('0');
            }
        }

        static void DisplaySortedNumbers()
        {
            Console.Write("Enter the first number: ");
            float number1 = float.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            float number2 = float.Parse(Console.ReadLine());

            Console.Write("Enter the third number: ");
            float number3 = float.Parse(Console.ReadLine());

            if (number1 >= number2 && number1 >= number3)
            {
                if (number2 >= number3)
                    Console.WriteLine($"{number1} {number2} {number3}");
                else
                    Console.WriteLine($"{number1} {number3} {number2}");
            }
            else if (number2 >= number1 && number2 >= number3)
            {
                if (number1 >= number3)
                    Console.WriteLine($"{number2} {number1} {number3}");
                else
                    Console.WriteLine($"{number2} {number3} {number1}");
            }
            else
            {
                if (number1 >= number2)
                    Console.WriteLine($"{number3} {number1} {number2}");
                else
                    Console.WriteLine($"{number3} {number2} {number1}");
            }
        }

        static void DisplayDigitAsWord()
        {
            Console.Write("Enter a digit: ");
            int digit = int.Parse(Console.ReadLine());

                switch (digit)
                {
                    case 0:
                        Console.WriteLine("zero");
                        break;
                    case 1:
                        Console.WriteLine("one");
                        break;
                    case 2:
                        Console.WriteLine("two");
                        break;
                    case 3:
                        Console.WriteLine("three");
                        break;
                    case 4:
                        Console.WriteLine("four");
                        break;
                    case 5:
                        Console.WriteLine("five");
                        break;
                    case 6:
                        Console.WriteLine("six");
                        break;
                    case 7:
                        Console.WriteLine("seven");
                        break;
                    case 8:
                        Console.WriteLine("eight");
                        break;
                    case 9:
                        Console.WriteLine("nine");
                        break;
                    default:
                        Console.WriteLine("not a digit");
                        return;
                }
        }

        static void DisplayIsIntDoubleOrString()
        {
            Console.WriteLine("Enter one of the word integer, real or text");
            string inputType = Console.ReadLine();
            switch (inputType)
            {
                case "integer":
                    Console.Write("Enter integer number: ");
                    int intValue = int.Parse(Console.ReadLine());
                    intValue++;
                    Console.WriteLine(intValue);
                    break;
                case "real":
                    Console.Write("Enter real number: ");
                    double doubleValue = double.Parse(Console.ReadLine());
                    doubleValue += 1.0;
                    Console.WriteLine($"{doubleValue:F2}");
                    break;
                case "text":
                    Console.Write("Enter text: ");
                    string stringValue = Console.ReadLine();
                    Console.WriteLine($"{stringValue}*");
                    break;
            }
        }

        static void Main(string[] args)
        {
            DisplayIsIntDoubleOrString();
        }
    }
}








