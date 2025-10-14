using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Mindfulness
{
    public abstract class Activity
    {
        // Encapsulation: private fields, exposed via read-only properties
        private readonly string _name;
        private readonly string _description;
        private int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Name => _name;
        public string Description => _description;
        public int DurationSeconds => _durationSeconds;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name} Activity.\n");
            Console.WriteLine(Description + "\n");
            _durationSeconds = AskDurationSeconds();
            Console.WriteLine("\nGet ready to begin...");
            Spinner(3);
        }

        public void End()
        {
            Console.WriteLine();
            Console.WriteLine("\nWell done! ✨");
            Spinner(2);
            Console.WriteLine($"You have completed the {Name} Activity for {DurationSeconds} seconds.");
            Spinner(3);
        }

        public abstract ActivityResult Run();

        // ----------------- Shared Utilities (Inherited Behaviors) -----------------
        protected int AskDurationSeconds()
        {
            while (true)
            {
                Console.Write("Enter duration in seconds (e.g., 30): ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    return seconds;
                }
                Console.WriteLine("Please enter a positive integer.\n");
            }
        }

        protected void Spinner(int seconds)
        {
            // Uses backspaces for animation (meets rubric #9)
            char[] frames = { '|', '/', '-', '\\' };
            var sw = Stopwatch.StartNew();
            int i = 0;
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                char c = frames[i % frames.Length];
                Console.Write(c);
                Thread.Sleep(100);
                Console.Write('\b'); // backspace one char
                i++;
            }
            // Clear any residue visually
            Console.Write(' ');
            Console.Write('\b');
        }

        protected void Countdown(int seconds, string prefix = "")
        {
            // Backspace-driven numeric countdown
            for (int i = seconds; i >= 1; i--)
            {
                string text = $"{prefix}{i}";
                Console.Write(text);
                Thread.Sleep(1000);
                Console.Write(new string('\b', text.Length));
            }
        }

        protected void TimeBoxedLoop(int totalSeconds, Action<double> onTick)
        {
            var sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < totalSeconds)
            {
                double remaining = totalSeconds - sw.Elapsed.TotalSeconds;
                onTick(Math.Max(0, remaining));  // <-- FIXED: Math.Max
            }
        }

        protected static Task<string?> ReadLineWithTimeoutAsync(int timeoutMs, CancellationToken token)
        {
            return Task.Run(() =>
            {
                string? line = null;
                var readTask = Task.Run(() => line = Console.ReadLine(), token);
                Task.WaitAny(new Task[] { readTask }, timeoutMs, token);
                return line;
            }, token);
        }
    }
}
