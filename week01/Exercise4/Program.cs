using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        var numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int n))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            if (n == 0)
            {
                break;
            }

            numbers.Add(n);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered. Goodbye!");
            return;
        }

        int sum = 0;
        int max = numbers[0];
        foreach (int x in numbers)
        {
            if (x > max)
            {
                max = x;
            }
            sum += x;
        }

        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        int? smallestPositive = numbers
            .Where(x => x > 0)
            .OrderBy(x => x)
            .Cast<int?>()
            .FirstOrDefault();

        if (smallestPositive.HasValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive.Value}");
        }
        else
        {
            Console.WriteLine("The smallest positive number is: (none)");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int x in numbers)
        {
            Console.WriteLine(x);
        }
    }
}