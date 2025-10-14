using System;
using System.Diagnostics;
using System.Threading;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            name: "Breathing",
            description: "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        public override ActivityResult Run()
        {
            Start();

            int total = DurationSeconds;
            int inhaleSeconds = 4;
            int exhaleSeconds = 6;
            int cycles = 0;

            var sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < total)
            {
                Console.Write("Breathe in... ");
                EasingCountdown(inhaleSeconds);
                Console.WriteLine();

                Console.Write("Breathe out... ");
                EasingCountdown(exhaleSeconds);
                Console.WriteLine();

                cycles++;
            }

            End();
            return ActivityResult.Basic(Name, DurationSeconds, new System.Collections.Generic.Dictionary<string, object>
            {
                ["cycles"] = cycles,
                ["inhaleSeconds"] = inhaleSeconds,
                ["exhaleSeconds"] = exhaleSeconds
            });
        }

        private void EasingCountdown(int seconds)
        {
            // Simple ease-out pacing: slightly longer waits near the end of the count
            for (int s = seconds; s >= 1; s--)
            {
                string text = s.ToString();
                Console.Write(text);
                int baseMs = 1000;
                int extra = (int)(250 * (1.0 - (double)s / seconds));
                Thread.Sleep(baseMs + extra);
                Console.Write(new string('\b', text.Length));
            }
        }
    }
}
