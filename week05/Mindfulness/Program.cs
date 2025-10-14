// Program.cs — W05 Project: Mindfulness Program
// ---------------------------------------------------------
// ⭐ Exceeding Requirements Implemented:
// 1) Added a fourth activity: Body Scan Activity (guided attention through body regions).
// 2) Session log persisted to JSON (mindfulness_log.json). Tracks activity, duration, timestamp, and extra metrics.
// 3) Non-repeating random prompts/questions per session until lists are exhausted.
// 4) Breathing animation uses backspace-driven countdown with a simple ease-out effect.
// 5) Listing activity uses time-boxed input, then reports the total items.
// ---------------------------------------------------------

using System;
using System.Linq;

namespace Mindfulness
{
    public static class Program
    {
        public static void Main()
        {
            Console.Title = "Mindfulness Program - W05";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("--------------------");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflection Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Body Scan Activity (extra)");
                Console.WriteLine("5) View Session Log");
                Console.WriteLine("0) Quit\n");
                Console.Write("Select a choice: ");

                string? choice = Console.ReadLine();
                Activity? activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    "4" => new BodyScanActivity(),
                    _ => null
                };

                if (choice == "0")
                {
                    break;
                }

                if (choice == "5")
                {
                    ShowLog();
                    continue;
                }

                if (activity == null)
                {
                    Console.WriteLine("\nInvalid option. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                ActivityResult result = activity.Run();
                SessionLogger.Append(result);

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }

            Console.WriteLine("Goodbye! Be well.\n");
        }

        private static void ShowLog()
        {
            Console.Clear();
            Console.WriteLine("Session Log");
            Console.WriteLine("-----------\n");

            var entries = SessionLogger.LoadAll();
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries yet. Try an activity first.\n");
            }
            else
            {
                foreach (var e in entries.OrderByDescending(e => e.Timestamp))
                {
                    Console.WriteLine($"{e.Timestamp:g} — {e.ActivityName} for {e.DurationSeconds}s");
                    if (e.Extra != null && e.Extra.Count > 0)
                    {
                        foreach (var kv in e.Extra)
                        {
                            string value = kv.Value switch
                            {
                                null => "null",
                                string s when s.Length > 60 => s.Substring(0, 57) + "...",
                                System.Collections.Generic.IEnumerable<string> list => string.Join(", ", list.Take(5)) + (list.Count() > 5 ? ", ..." : ""),
                                _ => kv.Value.ToString() ?? string.Empty
                            };
                            Console.WriteLine($"  - {kv.Key}: {value}");
                        }
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
