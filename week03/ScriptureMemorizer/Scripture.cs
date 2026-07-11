using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] splitWords = text.Split(' ');
            foreach (string wordText in splitWords)
            {
                _words.Add(new Word(wordText));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            int hiddenCount = 0;

            List<int> visibleIndices = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                {
                    visibleIndices.Add(i);
                }
            }

            while (hiddenCount < numberToHide && visibleIndices.Count > 0)
            {
                int randomIndex = random.Next(visibleIndices.Count);
                int targetWordIndex = visibleIndices[randomIndex];

                _words[targetWordIndex].Hide();
                visibleIndices.RemoveAt(randomIndex);
                hiddenCount++;
            }
        }

        public string GetDisplayText()
        {
            List<string> renderedWords = new List<string>();
            foreach (Word word in _words)
            {
                renderedWords.Add(word.GetDisplayText());
            }

            return $"{_reference.GetDisplayText()} - {string.Join(" ", renderedWords)}";
        }

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
}