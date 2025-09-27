using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private readonly List<Entry> _entries = new();

    
    public void AddEntry(Entry e) => _entries.Add(e);

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
            return;
        }

        foreach (var e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using var writer = new StreamWriter(filename);
        foreach (var e in _entries)
        {
            writer.WriteLine(e.ToStorageLine());
        }
        Console.WriteLine($"Journal saved to \"{filename}\".\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();

        foreach (var line in File.ReadAllLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var e = Entry.FromStorageLine(line);
            if (e != null) _entries.Add(e);
        }

        Console.WriteLine($"Journal loaded from \"{filename}\" with {_entries.Count} entries.\n");
    }

    // EXCEED REQUIREMENTS: simple keyword search
    public void Search(string keyword)
    {
        keyword = keyword?.Trim() ?? "";
        if (keyword == "")
        {
            Console.WriteLine("Please type a non-empty keyword.\n");
            return;
        }

        int count = 0;
        foreach (var e in _entries)
        {
            if ((e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                (e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            {
                e.Display();
                count++;
            }
        }
        Console.WriteLine(count == 0
            ? "No entries matched your search.\n"
            : $"Found {count} matching entr{(count == 1 ? "y" : "ies")}.\n");
    }
}
