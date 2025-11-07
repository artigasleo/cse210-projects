using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

         Random rng = new Random();

        while (true)
        {
            int magicNumber = rng.Next(1, 101);
            int guessCount = 0;
            int guess = -1;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid integer.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"You guessed it in {guessCount} guess(es)!");

            Console.Write("Play again? (yes/no): ");
            string again = (Console.ReadLine() ?? "").Trim().ToLower();

            if (!(again == "y" || again == "yes"))
            {
                Console.WriteLine("Thanks for playing. Goodbye!");
                break;
            }
        }
    }
}