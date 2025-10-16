using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private readonly List<Goal> _goals = new();
    private int _score = 0;

    // --- Small "Exceeds" Feature: Levels ---
    // Level 1 starts at 0 points; every 1000 points you level up.
    public int Level => (_score / 1000) + 1;

    public void ShowScore()
    {
        Console.WriteLine($"\nScore: {_score}  |  Level: {Level}\n");
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateNewGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";
        Console.Write("Points: ");
        int points = int.TryParse(Console.ReadLine(), out int p) ? p : 0;

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Simple goal created.");
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Eternal goal created.");
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.TryParse(Console.ReadLine(), out int t) ? t : 1;
                Console.Write("What is the bonus for completing it that many times? ");
                int bonus = int.TryParse(Console.ReadLine(), out int b) ? b : 0;
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Checklist goal created.");
                break;

            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record yet.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoals();
        Console.Write("Enter number: ");
        if (!int.TryParse(Console.ReadLine(), out int idx))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        idx -= 1;
        if (idx < 0 || idx >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int beforeLevel = Level;
        int earned = _goals[idx].RecordEvent();
        _score += earned;

        Console.WriteLine(earned > 0
            ? $"Congratulations! You earned {earned} points!"
            : "No points awarded.");

        if (Level > beforeLevel)
        {
            Console.WriteLine($"✨ Level Up! You reached Level {Level}!");
        }
    }

    public void SaveGoals(string filePath)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(_score);
        foreach (var goal in _goals)
        {
            sw.WriteLine(goal.GetStringRepresentation());
        }
        Console.WriteLine($"Saved to {filePath}");
    }

    public void LoadGoals(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length == 0) return;

        _score = int.TryParse(lines[0], out int s) ? s : 0;

        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split('|');
            if (parts.Length < 4) continue;

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.TryParse(parts[3], out int p) ? p : 0;

            switch (type)
            {
                case "Simple":
                    bool done = parts.Length > 4 && bool.TryParse(parts[4], out bool d) ? d : false;
                    _goals.Add(new SimpleGoal(name, description, points, done));
                    break;

                case "Eternal":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;

                case "Checklist":
                    // Type|Name|Description|Points|Target|Bonus|Current
                    int target = parts.Length > 4 && int.TryParse(parts[4], out int t) ? t : 1;
                    int bonus = parts.Length > 5 && int.TryParse(parts[5], out int b) ? b : 0;
                    int current = parts.Length > 6 && int.TryParse(parts[6], out int c) ? c : 0;
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus, current));
                    break;
            }
        }

        Console.WriteLine($"Loaded from {filePath}");
    }
}
