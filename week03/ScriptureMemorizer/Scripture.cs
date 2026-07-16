using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Splitting the text by spaces directly inside the constructor
        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    // STRETCH CHALLENGE: Targets only words that are currently visible
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        
        // Find positions of words that are still visible
        List<int> visibleIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndices.Add(i);
            }
        }

        // Adjust requested count if there are fewer visible words left
        int actualToHide = Math.Min(numberToHide, visibleIndices.Count);

        for (int i = 0; i < actualToHide; i++)
        {
            int randomIndex = random.Next(visibleIndices.Count);
            int wordToHideIndex = visibleIndices[randomIndex];

            _words[wordToHideIndex].Hide();
            visibleIndices.RemoveAt(randomIndex); // Protect against duplicate hiding in this execution cycle
        }
    }

    // Merges the reference and the formatted list of words
    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        string formattedText = string.Join(" ", displayWords);
        return $"{_reference.GetDisplayText()} - {formattedText}";
    }

    // Returns true when every word in the scripture is hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}