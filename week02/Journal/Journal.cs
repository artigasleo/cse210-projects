using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        foreach (var e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (var writer = new StreamWriter(file))
        {
            foreach (var e in _entries)
            {
                writer.WriteLine(e.ToFileLine());
            }
        }
        Console.WriteLine($"Journal saved to '{file}'.\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(file);
        foreach (var line in lines)
        {
            var entry = Entry.FromFileLine(line);
            if (entry != null) _entries.Add(entry);
        }
        Console.WriteLine($"Journal loaded from '{file}'.\n");
    }
}
