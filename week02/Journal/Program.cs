using System;

// Exceeding Requirements: added a simple "Search by keyword" menu option (6).


class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        bool running = true;
        while (running)
        {
            ShowMenu();
            Console.Write("Select an option: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g., journal.txt): ");
                    var saveName = Console.ReadLine() ?? "journal.txt";
                    journal.SaveToFile(saveName);
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g., journal.txt): ");
                    var loadName = Console.ReadLine() ?? "journal.txt";
                    journal.LoadFromFile(loadName);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                case "6": 
                    Console.Write("Keyword to search: ");
                    var kw = Console.ReadLine() ?? "";
                    Console.WriteLine();
                    journal.Search(kw);
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Journal Menu");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
        Console.WriteLine("6. Search entries (extra)\n");
    }


    static void WriteNewEntry(Journal journal, PromptGenerator prompts)
    {
        var prompt = prompts.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        var response = Console.ReadLine() ?? "";

        var entry = new Entry
        {
            DateText = DateTime.Now.ToString("yyyy-MM-dd"),
            Prompt = prompt,
            Response = response
        };

        journal.AddEntry(entry);
        Console.WriteLine("\nEntry added.\n");
    }
}
