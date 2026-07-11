using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        /* 
         * W03 PROJECT CREATIVITY & EXCEEDING REQUIREMENTS:
         * 1. SCRIPTURE LIBRARY: The program references a database pool containing multiple scriptures 
         * (both single and multi-verse variations) and dynamically rolls a random choice on execution startup.
         * 2. SMART WORD SELECTION: The random hiding process tracks previously hidden entries, ensuring that 
         * words are only chosen from remaining visible content. Execution ends cleanly without wasted iterations.
         */

        static void Main(string[] args)
        {
            List<Scripture> scriptureLibrary = new List<Scripture>
            {
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"),
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"),
                new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me"),
                new Scripture(new Reference("Alma", 37, 35), "O remember my son and learn wisdom in thy youth yea learn in thy youth to keep the commandments of God")
            };

            Random random = new Random();
            Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();

                if (currentScripture.IsCompletelyHidden())
                {
                    Console.WriteLine("Fantastic job! You've completely hidden the selection.");
                    break;
                }

                Console.Write("Press enter to hide words, or type 'quit' to exit: ");
                string userInput = Console.ReadLine();

                if (userInput.Trim().ToLower() == "quit")
                {
                    break;
                }

                currentScripture.HideRandomWords(3);
            }
        }
    }
}