using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void DoActivity()
    {
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);

            if (DateTime.Now >= endTime) break;

            Console.WriteLine("Now breathe out...");
            ShowCountdown(6);

            Console.WriteLine();
        }
    }
}
