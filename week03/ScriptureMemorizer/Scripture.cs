using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string fullText)
    {
        _reference = reference;
        _random = new Random();
        _words = new List<Word>();

        // Split text into tokens (preserves punctuation)
        var tokens = fullText.Split(' ');
        foreach (var t in tokens)
        {
            _words.Add(new Word(t));
        }
    }

    public Reference Reference => _reference;

    // Returns true if all words containing letters are hidden
    public bool IsCompletelyHidden()
    {
        return _words.Where(w => w.HasLetters()).All(w => w.IsHidden);
    }

    // Returns formatted scripture (reference + processed text)
    public string GetFormattedText()
    {
        var displayed = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.ToString()}\n{displayed}";
    }

    // Hide <count> random visible words (only words not yet hidden)
    public int HideRandomWords(int count)
    {
        var candidates = _words.Where(w => w.HasLetters() && !w.IsHidden).ToList();

        if (candidates.Count == 0)
            return 0;

        int toHide = Math.Min(count, candidates.Count);

        for (int i = 0; i < toHide; i++)
        {
            int idx = _random.Next(candidates.Count);
            candidates[idx].Hide();
            candidates.RemoveAt(idx);
        }

        return toHide;
    }

    // Helper: count how many words are still visible
    public int CountVisibleWords()
    {
        return _words.Count(w => w.HasLetters() && !w.IsHidden);
    }
}
