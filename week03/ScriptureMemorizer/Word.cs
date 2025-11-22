using System;
using System.Text;

public class Word
{
    private string _text;    
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    // Original text token
    public string Text => _text;

    // Encapsulated hidden flag
    public bool IsHidden
    {
        get { return _hidden; }
        private set { _hidden = value; }
    }

    // Mark word as hidden
    public void Hide()
    {
        _hidden = true;
    }

    // Returns the displayed version of the word:
    // Letters become underscores; punctuation remains.
    public string GetDisplayText()
    {
        if (!IsHidden)
            return _text;

        var sb = new StringBuilder();
        foreach (char c in _text)
        {
            if (char.IsLetter(c))
                sb.Append('_');
            else
                sb.Append(c); // Keep punctuation or special chars
        }
        return sb.ToString();
    }

    // Returns true if the token has at least one letter
    public bool HasLetters()
    {
        foreach (char c in _text)
        {
            if (char.IsLetter(c)) 
                return true;
        }
        return false;
    }
}
