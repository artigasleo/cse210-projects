using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            manager.ShowScore();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(manager);
                    break;

                case "2":
                    Console.WriteLine("Your goals:");
                    Console.WriteLine();
                    manager.ListGoals();
                    Console.WriteLine();
                    Pause();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g., goals.txt): ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    Pause();
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g., goals.txt): ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    Pause();
                    break;

                case "5":
                    manager.RecordEvent();
                    Pause();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    private static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine();

        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (typeChoice == "1")
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (typeChoice == "2")
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }
        else
        {
            Console.WriteLine("Invalid type selection.");
            Pause();
            return;
        }

        manager.AddGoal(newGoal);
        Console.WriteLine("Goal created successfully!");
        Pause();
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}
