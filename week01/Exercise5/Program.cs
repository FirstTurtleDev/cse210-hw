using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        DisplayWelcome();
        int number = PromptUserForNumber();
        string name = PromptUserForName();
        int squaredNumber = SquareNumber(number);
        DisplayResult(name, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static int PromptUserForNumber()
    {
        Console.Write("Please enter a number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }
    static string PromptUserForName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int SquareNumber(int number)
    {
        return number * number;
    }
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"The square of your number is {squaredNumber}, {name}.");
    }
}