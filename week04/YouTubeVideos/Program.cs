using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // Tracks one comment (name + text)
    public class Comment
    {
        private readonly string _author;
        private readonly string _text;

        public Comment(string author, string text)
        {
            _author = author;
            _text = text;
        }

        public string Format() => $"{_author}: {_text}";
    }

    // Tracks a video (title, author, length seconds) + its comments
    public class Video
    {
        private readonly string _title;
        private readonly string _author;
        private readonly int _lengthSeconds;
        private readonly List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int lengthSeconds)
        {
            _title = title;
            _author = author;
            _lengthSeconds = lengthSeconds;
        }

        public void AddComment(Comment c) => _comments.Add(c);
        public int GetCommentCount() => _comments.Count;
        public IEnumerable<Comment> GetComments() => _comments;

        private static string FormatLength(int seconds)
        {
            int m = seconds / 60;
            int s = seconds % 60;
            return $"{m:D2}:{s:D2}";
        }

        public void Print()
        {
            Console.WriteLine($"Title:  {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {FormatLength(_lengthSeconds)}");
            Console.WriteLine($"Comments: {GetCommentCount()}");
            foreach (var c in _comments)
                Console.WriteLine($"  - {c.Format()}");
            Console.WriteLine(new string('-', 40));
        }
    }

    class Program
    {
        static void Main()
        {
            var videos = new List<Video>();

            var v1 = new Video("Intro to C#", "CodeCamp", 315);
            v1.AddComment(new Comment("Ana", "Great pacing—thanks!"));
            v1.AddComment(new Comment("Luis", "Clear explanation of classes."));
            v1.AddComment(new Comment("Mara", "Examples were helpful."));
            videos.Add(v1);

            var v2 = new Video("Unity Basics", "GameDevLab", 642);
            v2.AddComment(new Comment("Teo", "Loved the demo scene."));
            v2.AddComment(new Comment("Rafa", "Could you cover physics next?"));
            v2.AddComment(new Comment("Karla", "Subscribed!"));
            videos.Add(v2);

            var v3 = new Video("SQL Joins Explained", "DataNerd", 498);
            v3.AddComment(new Comment("Diego", "Left vs inner finally clicked."));
            v3.AddComment(new Comment("Sara", "Diagram was 🔥"));
            v3.AddComment(new Comment("Noah", "Please do indexes next."));
            videos.Add(v3);

            // Optional 4th video
            var v4 = new Video("Design Patterns Overview", "DevPatterns", 780);
            v4.AddComment(new Comment("Ivy", "Observer pattern FTW."));
            v4.AddComment(new Comment("Sam", "More examples please."));
            v4.AddComment(new Comment("Jen", "Nice summary."));
            videos.Add(v4);

            // Display
            foreach (var v in videos) v.Print();

     
        }
    }
}
