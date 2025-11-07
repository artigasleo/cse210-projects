using System;

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var promptGen = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1) Write a new entry");
            Console.WriteLine("2) Display the journal");
            Console.WriteLine("3) Save the journal to a file");
            Console.WriteLine("4) Load the journal from a file");
            Console.WriteLine("5) Quit");
            Console.Write("Select an option: ");
            string choice = (Console.ReadLine() ?? "").Trim();
            Console.WriteLine();

            if (choice == "1")
            {
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("Your response: ");
                string text = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();
                var entry = new Entry(date, prompt, text);
                journal.AddEntry(entry);

                Console.WriteLine("Entry added.\n");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option.\n");
            }
        }
    }
}