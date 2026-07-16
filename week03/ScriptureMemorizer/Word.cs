using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor: All words start as visible
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Encapsulates how the word renders itself
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replaces the word with an exact matching number of underscores
            return new string('_', _text.Length);
        }
        return _text;
    }
}