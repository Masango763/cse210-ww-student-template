using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Entry point demonstrating polymorphic list execution and reporting.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        try
        {
            activities.Add(new Running("03 Nov 2022", 30, 3.0, "miles"));
            activities.Add(new Cycling("04 Nov 2022", 45, 15.0, "miles"));
            activities.Add(new Swimming("05 Nov 2022", 25, 20, "miles"));
            activities.Add(new Running("06 Nov 2022", 40, 6.2, "km")); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during initialization: {ex.Message}");
        }

        Console.WriteLine("================================================================");
        Console.WriteLine("               ADVANCED FITNESS TRACKER REPORT                  ");
        Console.WriteLine("================================================================");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("----------------------------------------------------------------");
        
        int totalWorkouts = activities.Count;
        int totalMinutes = activities.Sum(a => a.GetLengthMinutes());
        
        Console.WriteLine($"[Dashboard Analytics]");
        Console.WriteLine($" Total Workouts Logged : {totalWorkouts}");
        Console.WriteLine($" Total Active Time     : {totalMinutes} minutes");
        Console.WriteLine("================================================================");
    }
}
