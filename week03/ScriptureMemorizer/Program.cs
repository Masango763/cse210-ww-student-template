using System;
using System.Collections.Generic;

// ===================================================================================
// CREATIVITY AND EXCEEDING REQUIREMENTS:
// 1. Expanded Scripture Library: The program maintains an expanded library of 10 
//    diverse scriptures from different volumes of holy text (both single-verse and 
//    multi-verse ranges). It randomly selects one to load on startup.
// 2. Pure Random Selection (Stretch Challenge): When hiding words, the program 
//    identifies only currently visible words. This prevents double-hitting hidden 
//    words, keeping performance optimal and avoiding infinite loops at the end.
// ===================================================================================

class Program
{
    static void Main(string[] args)
    {
        // 1. Populate our library with an expanded list of 10 scriptures
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
            ),
            // 5. 1 Nephi 3:7 (Book of Mormon - Single Verse)
            new Tuple<Reference, string>(
                new Reference("1 Nephi", 3, 7),
                "I will go and do the things which the Lord hath commanded for I know that the Lord giveth no commandments unto the children of men save he shall prepare a way for them that they may accomplish the thing which he commandeth them"
            ),
            // 6. Alma 37:35 (Book of Mormon - Single Verse)
            new Tuple<Reference, string>(
                new Reference("Alma", 37, 35),
                "O remember my son and learn wisdom in thy youth yea learn in thy youth to keep the commandments of God"
            ),
            // 7. Doctrine and Covenants 6:36 (D&C - Single Verse)
            new Tuple<Reference, string>(
                new Reference("Doctrine and Covenants", 6, 36),
                "Look unto me in every thought doubt not fear not"
            ),
            // 8. Doctrine and Covenants 82:10 (D&C - Single Verse)
            new Tuple<Reference, string>(
                new Reference("Doctrine and Covenants", 82, 10),
                "I the Lord am bound when ye do what I say but when ye do not what I say ye have no promise"
            ),
            // 9. Moses 1:39 (Pearl of Great Price - Single Verse)
            new Tuple<Reference, string>(
                new Reference("Moses", 1, 39),
                "For behold this is my work and my glory to bring to pass the immortality and eternal life of man"
            ),
            // 10. Mosiah 2:17 (Book of Mormon - Single Verse)
            new Tuple<Reference, string>(
                new Reference("Mosiah", 2, 17),
                "And behold I tell you these things that ye may learn wisdom that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God"
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