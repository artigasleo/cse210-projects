using System;

class Program
{
    private static int _breathingCount = 0;
    private static int _reflectionCount = 0;
    private static int _listingCount = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    _breathingCount++;
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    _reflectionCount++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    _listingCount++;
                    break;

                case "4":
                    running = false;
                    ShowSummary();
                    break;

                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }

    private static void ShowSummary()
    {
        Console.Clear();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
        Console.WriteLine();
        Console.WriteLine("Session Summary:");
        Console.WriteLine($"- Breathing activities:  {_breathingCount}");
        Console.WriteLine($"- Reflection activities: {_reflectionCount}");
        Console.WriteLine($"- Listing activities:    {_listingCount}");
        Console.WriteLine();
        Console.WriteLine("Press Enter to close the program.");
        Console.ReadLine();
    }
}
