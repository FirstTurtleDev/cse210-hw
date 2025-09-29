using System;

namespace YouTubeVideos
{
    public class Comment
    {
        private readonly string _author;
        private readonly string _text;

        public Comment(string author, string text)
        {
            _author = author;
            _text = text;
        }

        public string Format()
        {
            return $"{_author}: {_text}";
        }
    }
}
