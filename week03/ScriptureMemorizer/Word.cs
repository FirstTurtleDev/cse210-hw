using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Word
    {
        private readonly string _original;
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            _original = text;
            IsHidden = false;
        }

        // Replace letters with underscores, keep punctuation/spaces intact.
        private static string MaskLetters(string s)
        {
            // Replace alphabetic characters only; keep digits/punctuation as-is
            return Regex.Replace(s, "[A-Za-zÁÉÍÓÚÜÑáéíóúüñ]", "_");
        }

        public void Hide() => IsHidden = true;
        public void Show() => IsHidden = false;

        public string Render()
        {
            return IsHidden ? MaskLetters(_original) : _original;
        }
    }
}
