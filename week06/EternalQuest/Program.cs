using System;

/// W06 Project: Eternal Quest Program
/// Exceeds note:
/// - Added a simple Level system (Level = Score/1000 + 1) and "Level Up!" message on thresholds.
/// - This keeps the core app simple while adding a small gamification element.

class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();
        string savePath = "goals.txt";

        while (true)
        {
            manager.ShowScore();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine()?.Trim() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    manager.CreateNewGoal();
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    Console.Write($"Enter file name (default '{savePath}'): ");
                    string s = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(s)) savePath = s.Trim();
                    manager.SaveGoals(savePath);
                    break;

                case "4":
                    Console.Write($"Enter file name to load (default '{savePath}'): ");
                    string l = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(l)) savePath = l.Trim();
                    manager.LoadGoals(savePath);
                    break;

                case "5":
                    manager.RecordEvent();
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
