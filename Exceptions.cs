using System;
using System.IO;

public class Program
{
    static double GetSquareRoot(double number)
    {
        if (number > 0)
        {
            return Math.Sqrt(number);
        }

        throw new InvalidOperationException();
    }

    static int[] CheckArray(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                throw new InvalidOperationException();
            }
        }

        return array;
    }

    static bool IsValidNumber(int number)
    {
        if (number >= 0 && number <= 100)
        {
            return true;
        }

        throw new ArgumentOutOfRangeException();
    }

    public static void Main(string[] args)
    {

        //TASK 1
        double number;

        if (double.TryParse(Console.ReadLine(), out number))
        {
            double result;

            try
            {
                result = GetSquareRoot(number);
                Console.WriteLine(result);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid number");
            }

            Console.WriteLine("Good bye");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        //TASK 2
        int[] array = new int[10];

        for (int i = 0; i < 10; i++)
        {
            int number = int.Parse(Console.ReadLine());
            try
            {
                if (IsValidNumber(number))
                {
                    array[i] = number;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid input.");
            }
        }

        try
        {
            array = CheckArray(array);

            Console.Write("1 < ");

            foreach (int number in array)
            {
                Console.Write($"{number} < ");
            }

            Console.Write("100");
        }
        catch(InvalidOperationException)
        {
            Console.WriteLine("Exception");
        }
    }
}
