using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string date, string prompt, string text)
    {
        _date = date;
        _promptText = prompt;
        _entryText = text;
    }

    public void Display()
    {
        Console.WriteLine($"[{_date}]");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry : {_entryText}");
        Console.WriteLine();
    }

    public string ToFileLine()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromFileLine(string line)
    {
        var parts = line.Split('|');
        if (parts.Length < 3) return null;
        return new Entry(parts[0], parts[1], parts[2]);
    }
}
