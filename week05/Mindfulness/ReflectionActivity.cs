using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private readonly List<string> _prompts = new()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _questions = new()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base(
            name: "Reflection",
            description: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        { }

        public override ActivityResult Run()
        {
            Start();

            var rnd = new Random();
            string prompt = _prompts[rnd.Next(_prompts.Count)];

            Console.WriteLine("Consider the following prompt:\n");
            Console.WriteLine($"--- {prompt} ---\n");
            Console.WriteLine("When you have something in mind, press ENTER to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.WriteLine("You may begin in:");
            Countdown(5);

            // Shuffle questions; avoid repeats until all are asked once
            List<string> queue = _questions.OrderBy(_ => rnd.Next()).ToList();
            int asked = 0;

            var sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < DurationSeconds)
            {
                if (queue.Count == 0)
                {
                    queue = _questions.OrderBy(_ => rnd.Next()).ToList();
                }

                string q = queue[0];
                queue.RemoveAt(0);
                asked++;

                Console.Write($"> {q} ");
                Spinner(8); // pause with spinner for contemplation
                Console.WriteLine();
            }

            End();
            return ActivityResult.Basic(Name, DurationSeconds, new Dictionary<string, object>
            {
                ["questionsShown"] = asked,
                ["prompt"] = prompt
            });
        }
    }
}
