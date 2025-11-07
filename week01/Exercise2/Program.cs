using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("Enter your grade percentage (0–100): ");
        int percent = int.Parse(Console.ReadLine());
        string letter;

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";
        int lastDigit = percent % 10;

        if (letter == "F")
        {
            sign = "";
        }
        else if (letter == "A")
        {
            if (percent < 100 && lastDigit < 3)
            {
                sign = "-";
            }
        }
        else
        {
            if (lastDigit >= 7)       sign = "+";
            else if (lastDigit < 3)   sign = "-";
            else                      sign = "";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep going—you’ll do better next time!");
        }
    }
}