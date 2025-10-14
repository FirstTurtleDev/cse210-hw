using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ActivityResult
    {
        public string ActivityName { get; set; } = string.Empty;
        public int DurationSeconds { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, object> Extra { get; set; } = new();

        public static ActivityResult Basic(string name, int durationSeconds, Dictionary<string, object>? extra = null)
        {
            return new ActivityResult
            {
                ActivityName = name,
                DurationSeconds = durationSeconds,
                Timestamp = DateTime.Now,
                Extra = extra ?? new Dictionary<string, object>()
            };
        }
    }
}
