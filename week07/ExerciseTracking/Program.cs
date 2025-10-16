using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // ====== Choose ONE unit system for the whole program ======
        bool useMiles = true; // set false to use kilometers
        string unitDistance = useMiles ? "miles" : "km";
        string unitSpeed    = useMiles ? "mph"   : "kph";
        string unitPace     = useMiles ? "min per mile" : "min per km";

        var activities = new List<Activity>
        {
            // Running: supply distance (mi or km depending on useMiles)
            new Running(new DateTime(2022,11,03), 30, useMiles ? 3.0 : 4.8),

            // Cycling: supply speed (mph or kph)
            new Cycling(new DateTime(2022,11,03), 30, useMiles ? 6.0 : 9.7),

            // Swimming: supply laps; Swimming converts to chosen unit
            new Swimming(new DateTime(2022,11,03), 30, laps: 60, useMiles: useMiles)
        };

        foreach (var a in activities)
        {
            Console.WriteLine(a.GetSummary(unitDistance, unitSpeed, unitPace));
        }
    }
}
