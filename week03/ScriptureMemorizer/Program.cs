using System;
using System.Collections.Generic;

// ===================================================================================
// CREATIVITY AND EXCEEDING REQUIREMENTS:
// 1. Scripture Library: The program maintains a library of 4 diverse scriptures 
//    (both single-verse and multi-verse ranges) and randomly selects one on startup.
// 2. Pure Random Selection (Stretch Challenge): When hiding words, the program 
//    identifies only currently visible words to prevent duplicate hits.
// ===================================================================================

class Program
{
    static void Main(string[] args)
    {
        // 1. Populate our library with 4 scriptures
        List<Tuple<Reference, string>> scriptureLibrary = new List<Tuple<Reference, string>>
        {
            // 1. Proverbs 3:5-6 (Old Testament - Verse Range)
            new Tuple<Reference, string>(
                new Reference("Proverbs", 3, 5, 6), 
                "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"
            ),
            // 2. John 3:16 (New Testament - Single Verse)
            new Tuple<Reference, string>(
                new Reference("John", 3, 16), 
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
            ),
            // 3. Philippians 4:13 (New Testament - Single Verse)
            new Tuple<Reference, string>(
                new Reference("Philippians", 4, 13), 
                "I can do all things through Christ which strengtheneth me"
            ),
            // 4. Joshua 1:9 (Old Testament - Single Verse)
            new Tuple<Reference, string>(
                new Reference("Joshua", 1, 9), 
                "Have not I commanded thee Be strong and of a good courage be not afraid neither be thou dismayed for the Lord thy God is with thee whithersoever thou goest"
            )
        };

        // 2. Select a random scripture from our list
        Random random = new Random();
        int randomIndex = random.Next(scriptureLibrary.Count);
        var selection = scriptureLibrary[randomIndex];

        Scripture scripture = new Scripture(selection.Item1, selection.Item2);

        // 3. Execution Game Loop
        while (true)
        {
            Console.Clear(); // Keeps the interface perfectly clean
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Check if scripture is completely hidden to end program cleanly
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You've successfully memorized the passage.");
                break;
            }

            Console.WriteLine("Press Enter to continue, or type 'quit' to exit.");
            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            // Hide 3 random words during each cycle
            scripture.HideRandomWords(3);
        }
    }
}