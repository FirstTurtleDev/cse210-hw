using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int input = 1; 
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (input != 0)
        {

            Console.Write("Enter number: ");
            input = Convert.ToInt32(Console.ReadLine());
            numbers.Add(input);
        }
        numbers.Remove(0);
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine("The sum is " + sum);
        Console.WriteLine("The average is " + (double)sum / numbers.Count);
        int largest = 0;

        if (numbers.Count > 0)
        {
            largest = numbers[0];
        }

        if (largest < 0)
        {
            largest = 0;
        }

        Console.WriteLine("The largest number is " + largest);    }
        }