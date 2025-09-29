using System;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Reference
    {
        public string Book { get; }
        public int Chapter { get; }
        public int StartVerse { get; }
        public int? EndVerse { get; }

        // Single-verse constructor
        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = verse;
            EndVerse = null;
        }

        // Verse-range constructor
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            return EndVerse.HasValue
                ? $"{Book} {Chapter}:{StartVerse}-{EndVerse.Value}"
                : $"{Book} {Chapter}:{StartVerse}";
        }

        // Helper for the optional file-loading exceed feature
        public static bool TryParse(string s, out Reference reference)
        {
            reference = null;
            // Matches: Book Chapter:Verse  OR  Book Chapter:StartVerse-EndVerse
            // e.g., "Proverbs 3:5" or "Proverbs 3:5-6"
            var match = Regex.Match(s, @"^\s*(.+?)\s+(\d+):(\d+)(?:-(\d+))?\s*$");
            if (!match.Success) return false;

            var book = match.Groups[1].Value.Trim();
            if (!int.TryParse(match.Groups[2].Value, out int chapter)) return false;
            if (!int.TryParse(match.Groups[3].Value, out int startVerse)) return false;

            if (match.Groups[4].Success && int.TryParse(match.Groups[4].Value, out int endVerse))
            {
                reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                reference = new Reference(book, chapter, startVerse);
            }

            return true;
        }
    }
}
