using System;

public class Entry
{
    public string DateText { get; set; } = "";
    public string Prompt { get; set; } = "";
    public string Response { get; set; } = "";


    public void Display()
    {
        Console.WriteLine($"Date: {DateText}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine(new string('-', 40));
    }


    private const string Sep = "~|~";

    public string ToStorageLine()
    {
     
        string safeDate = DateText.Replace(Sep, " ");
        string safePrompt = Prompt.Replace(Sep, " ");
        string safeResponse = Response.Replace(Sep, " ");
        return $"{safeDate}{Sep}{safePrompt}{Sep}{safeResponse}";
    }

    public static Entry FromStorageLine(string line)
    {
        var parts = line.Split(Sep);
        if (parts.Length < 3) return null!;
        return new Entry
        {
            DateText = parts[0],
            Prompt = parts[1],
            Response = parts[2]
        };
    }
}
