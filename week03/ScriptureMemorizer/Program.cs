// Exceeding requirement: hides only non-hidden words each round.
// Exceeding requirement: supports scripture library with random selection


using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main()
        {
            // Build a small scripture library (you can add/remove here).
            var library = new List<Scripture>
            {
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, " +
                    "that whosoever believeth in him should not perish, but have everlasting life."
                ),
                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                    "In all thy ways acknowledge him, and he shall direct thy paths."
                ),
                new Scripture(
                    new Reference("Moroni", 7, 45),
                    "And charity suffereth long, and is kind, and envieth not, and is not puffed up, " +
                    "seeketh not her own, is not easily provoked, thinketh no evil."
                )
            };

            // Optional “exceed” feature: load more scriptures from a local text file if present.
            TryLoadFromFile("scriptures.txt", library);

            // Pick a random scripture from the library
            var rnd = new Random();
            var scripture = library[rnd.Next(library.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.Render());
                Console.WriteLine();
                Console.Write("Press Enter to hide words, or type \"quit\" to end: ");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // If everything is hidden, show the final state and end.
                if (scripture.AllHidden)
                {
                    Console.Clear();
                    Console.WriteLine(scripture.Render());
                    Console.WriteLine("\nAll words are hidden. Program finished.");
                    break;
                }

                // Hide a few (1–3) words that are still visible.
                scripture.HideRandomWords(rnd, count: rnd.Next(1, 4));

                // After hiding, if we’ve reached fully hidden, next iteration will end.
            }
        }

        private static void TryLoadFromFile(string path, List<Scripture> library)
        {
            try
            {
                if (!File.Exists(path)) return;

                foreach (var line in File.ReadAllLines(path))
                {
                    // Expected format: "Book Chapter:Verse[-EndVerse]|Full text"
                    // Example: "Proverbs 3:5-6|Trust in the Lord with all thine heart; ..."
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split('|');
                    if (parts.Length != 2) continue;

                    var referencePart = parts[0].Trim();
                    var text = parts[1].Trim();
                    if (string.IsNullOrWhiteSpace(referencePart) || string.IsNullOrWhiteSpace(text)) continue;

                    if (Reference.TryParse(referencePart, out var reference))
                    {
                        library.Add(new Scripture(reference!, text));
                    }
                }
            }
            catch
            {

            }
        }
    }
}
