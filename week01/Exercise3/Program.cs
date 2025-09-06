using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int number = random.Next(1, 11);
        int magicNumberGuess;
        do
        {
            Console.Write("What is the magic number? ");
            string magicInput = Console.ReadLine();
            magicNumberGuess = int.Parse(magicInput);
            if (magicNumberGuess < number)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumberGuess > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (magicNumberGuess != number);
    }
}