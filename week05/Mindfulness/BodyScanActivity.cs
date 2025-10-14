using System;
using System.Diagnostics;

namespace Mindfulness
{
    public class BodyScanActivity : Activity
    {
        private readonly string[] _regions = new[]
        {
            "scalp and forehead",
            "eyes and jaw",
            "neck and shoulders",
            "arms and hands",
            "chest and upper back",
            "abdomen and lower back",
            "hips and glutes",
            "thighs",
            "knees",
            "calves",
            "ankles and feet"
        };

        public BodyScanActivity() : base(
            name: "Body Scan",
            description: "This activity guides attention through body regions. Notice sensations without judgment and soften any tension.")
        { }

        public override ActivityResult Run()
        {
            Start();

            var sw = Stopwatch.StartNew();
            int index = 0;
            int visited = 0;

            while (sw.Elapsed.TotalSeconds < DurationSeconds)
            {
                string region = _regions[index % _regions.Length];
                Console.WriteLine($"Focus on your {region}. Inhale... Exhale...");
                Spinner(6);
                visited++;
                index++;
            }

            End();
            return ActivityResult.Basic(Name, DurationSeconds, new System.Collections.Generic.Dictionary<string, object>
            {
                ["regionsVisited"] = visited
            });
        }
    }
}
