using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public int Score => _score;
    public int Level
    {
        get
        {
            return (_score / 1000) + 1;
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatusString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create a goal first.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        ListGoals();
        Console.Write("Enter the number of the goal: ");
        string input = Console.ReadLine();
        int index;

        if (int.TryParse(input, out index) && index >= 1 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;

            Console.WriteLine($"You earned {pointsEarned} points!");
            Console.WriteLine($"Your total score is now {_score}.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Current score: {_score} points");
        Console.WriteLine($"Current level: {Level}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        int loadedScore;
        if (int.TryParse(lines[0], out loadedScore))
        {
            _score = loadedScore;
        }
        else
        {
            _score = 0;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split('|');
            if (parts.Length == 0) continue;

            string type = parts[0];

            if (type == "SimpleGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                Goal goal = new SimpleGoal(name, desc, points, isComplete);
                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);

                Goal goal = new EternalGoal(name, desc, points);
                _goals.Add(goal);
            }
            else if (type == "ChecklistGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int current = int.Parse(parts[6]);

                Goal goal = new ChecklistGoal(name, desc, points, target, bonus, current);
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}
