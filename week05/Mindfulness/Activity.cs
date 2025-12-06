using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        ShowStartingMessage();
        DoActivity();
        ShowEndingMessage();
    }

    protected abstract void DoActivity();

    private void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number of seconds: ");
            input = Console.ReadLine();
        }

        Console.WriteLine();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3);
        Console.Clear();
    }

    private void ShowEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] sequence = { "|", "/", "-", "\\" };
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(sequence[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % sequence.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
