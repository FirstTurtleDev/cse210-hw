using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Mindfulness
{
    public static class SessionLogger
    {
        private const string FileName = "mindfulness_log.json";

        public static void Append(ActivityResult result)
        {
            List<ActivityResult> list = LoadAll();
            list.Add(result);
            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }

        public static List<ActivityResult> LoadAll()
        {
            if (!File.Exists(FileName))
            {
                return new List<ActivityResult>();
            }

            try
            {
                string json = File.ReadAllText(FileName);
                List<ActivityResult>? list = JsonSerializer.Deserialize<List<ActivityResult>>(json);
                return list ?? new List<ActivityResult>();
            }
            catch
            {
                return new List<ActivityResult>();
            }
        }
    }
}
