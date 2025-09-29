using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        public Reference Reference { get; }

        private readonly List<Word> _words;

        public Scripture(Reference reference, string fullText)
        {
            Reference = reference;
            // Split by spaces to preserve punctuation within tokens.
            _words = fullText
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(tok => new Word(tok))
                .ToList();
        }

        public bool AllHidden => _words.All(w => w.IsHidden);

        public string Render()
        {
            var text = string.Join(' ', _words.Select(w => w.Render()));
            return $"{Reference}\n{text}";
        }

        public void HideRandomWords(Random rnd, int count = 2)
        {
            var visibleIndexes = _words
                .Select((w, i) => (w, i))
                .Where(t => !t.w.IsHidden)
                .Select(t => t.i)
                .ToList();

            if (visibleIndexes.Count == 0) return;

            // Limit count to remaining visible words
            count = Math.Min(count, visibleIndexes.Count);

            // Shuffle visible indexes and take 'count'
            for (int i = visibleIndexes.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (visibleIndexes[i], visibleIndexes[j]) = (visibleIndexes[j], visibleIndexes[i]);
            }

            foreach (int idx in visibleIndexes.Take(count))
            {
                _words[idx].Hide();
            }
        }

        // Optional helper if you ever need to reset for testing:
        public void RevealAll()
        {
            foreach (var w in _words) w.Show();
        }
    }
}
