using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static string FormatLength(int seconds)
        {
            int minutes = seconds / 60;
            int secs = seconds % 60;
            return $"{minutes:D2}:{secs:D2}";
        }

        static void Main()
        {
            List<Video> videos = new List<Video>();

            Video v1 = new Video("Intro to C#", "CodeCamp", 315);
            v1.AddComment(new Comment("Ana", "Great pacing—thanks!"));
            v1.AddComment(new Comment("Luis", "Clear explanation of classes."));
            v1.AddComment(new Comment("Mara", "Examples were helpful."));
            videos.Add(v1);

            Video v2 = new Video("Unity Basics", "GameDevLab", 642);
            v2.AddComment(new Comment("Teo", "Loved the demo scene."));
            v2.AddComment(new Comment("Rafa", "Could you cover physics next?"));
            v2.AddComment(new Comment("Karla", "Subscribed!"));
            videos.Add(v2);

            Video v3 = new Video("SQL Joins Explained", "DataNerd", 498);
            v3.AddComment(new Comment("Diego", "Left vs inner finally clicked."));
            v3.AddComment(new Comment("Sara", "Diagram was super helpful."));
            v3.AddComment(new Comment("Noah", "Please do indexes next."));
            videos.Add(v3);

            // Optional 4th to be extra safe
            Video v4 = new Video("Design Patterns Overview", "DevPatterns", 780);
            v4.AddComment(new Comment("Ivy", "Observer pattern FTW."));
            v4.AddComment(new Comment("Sam", "More examples please."));
            v4.AddComment(new Comment("Jen", "Nice summary."));
            videos.Add(v4);

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title:   {video.GetTitle()}");
                Console.WriteLine($"Author:  {video.GetAuthor()}");
                Console.WriteLine($"Length:  {FormatLength(video.GetLengthSeconds())}");
                Console.WriteLine($"Comments: {video.GetCommentCount()}");

                foreach (Comment c in video.GetComments())
                {
                    Console.WriteLine($"  - {c.Format()}");
                }

                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
