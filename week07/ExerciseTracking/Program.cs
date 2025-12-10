using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Activity run = new RunningActivity(
            new DateTime(2022, 11, 3),
            30,
            3.0);

        Activity bike = new CyclingActivity(
            new DateTime(2022, 11, 3),
            45,
            12.0);

        Activity swim = new SwimmingActivity(
            new DateTime(2022, 11, 3),
            30,
            40);

        List<Activity> activities = new List<Activity> { run, bike, swim };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}
