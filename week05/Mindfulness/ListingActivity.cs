using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private readonly List<string> _prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base(
            name: "Listing",
            description: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        public override ActivityResult Run()
        {
            Start();

            var rnd = new Random();
            string prompt = _prompts[rnd.Next(_prompts.Count)];

            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("You may begin in:");
            Countdown(5);

            Console.WriteLine("Start listing items! Press ENTER after each one.");

            var items = new List<string>();
            var cts = new CancellationTokenSource();
            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

            while (DateTime.Now < end)
            {
                int remainingMs = (int)Math.Max(0, (end - DateTime.Now).TotalMilliseconds);
                Console.Write("• ");
                string? line = ReadLineWithTimeoutAsync(remainingMs, cts.Token).GetAwaiter().GetResult();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    items.Add(line.Trim());
                }
                if (DateTime.Now >= end)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} item(s).");
            Console.WriteLine();
            End();

            return ActivityResult.Basic(Name, DurationSeconds, new Dictionary<string, object>
            {
                ["prompt"] = prompt,
                ["itemsCount"] = items.Count,
                ["items"] = items
            });
        }
    }
}
