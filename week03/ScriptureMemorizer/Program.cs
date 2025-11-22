using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        Console.WriteLine("Press ENTER to begin or type 'quit' at any time.\n");

        // Scripture library (you may add more Scriptures here)
        var scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, " +
                "that whoever believes in him shall not perish but have eternal life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; " +
                "in all your ways submit to him, and he will make your paths straight."
            ),
            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all this through him who gives me strength."
            )
        };

        // Pick a random scripture from the library
        var rand = new Random();
        Scripture current = scriptures[rand.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(current.GetFormattedText());
            Console.WriteLine();

            if (current.IsCompletelyHidden())
            {
                Console.WriteLine("All words are now hidden. Program finished.");
                break;
            }

            Console.WriteLine("Press ENTER to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            // Hide 3 words per iteration
            int hidden = current.HideRandomWords(3);

            // Safety: if no more words can be hidden, end the program
            if (hidden == 0 && current.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(current.GetFormattedText());
                Console.WriteLine("\nAll words are now hidden. Program finished.");
                break;
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}