using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradeInput = Console.ReadLine();
        int gradePercentage = int.Parse(gradeInput);
        string letterGrade;
        if (gradePercentage >= 90)
        {
            letterGrade = "A";
            Console.WriteLine($"Your letter grade is {letterGrade}.");
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
            Console.WriteLine($"Your letter grade is {letterGrade}.");
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
            Console.WriteLine($"Your letter grade is {letterGrade}.");
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
            Console.WriteLine($"Your letter grade is {letterGrade}.");
        }
        else
        {
            letterGrade = "F";
            Console.WriteLine($"Your letter grade is {letterGrade}.");
        }

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass the course.");
        }
    }
}