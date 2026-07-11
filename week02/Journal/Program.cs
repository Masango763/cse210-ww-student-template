using System;

// ===================================================================================
// EXCEEDING THE REQUIREMENTS / CREATIVITY DOCUMENTATION:
// 1. INTEGRATED MOOD TRACKER ENGINE: Prompts the user to log an overall daily mood 
//    rating (1-5 scale) directly during the writing execution sequence.
// 2. DYNAMIC HABIT CONSECUTIVE STREAK TRACKER: Explicitly prompts the user for their 
//    consecutive writing baseline upon writing an entry to reinforce the habit.
// 3. COMBINED METADATA LOGGING: Safely injects the streak days and visual mood stars
//    directly into the stored entry context to preserve file safety.
// ===================================================================================

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                Entry entry = new Entry();

                entry._date = DateTime.Now.ToShortDateString();
                entry._prompt = generator.GetRandomPrompt();

                Console.Write("How many consecutive days have you been writing your journal? ");
                string streak = Console.ReadLine();

                Console.Write("Rate your current mood today (1-5 where 5 is excellent): ");
                string moodInput = Console.ReadLine();
                int moodScore = 5;
                int.TryParse(moodInput, out moodScore);
                string stars = new string('★', Math.Clamp(moodScore, 1, 5));

                Console.WriteLine($"\n{entry._prompt}");
                Console.Write("> ");
                string entryText = Console.ReadLine();

                entry._text = $"[Streak: {streak} Days] [Mood: {stars}]\n> {entryText}";

                journal.AddEntry(entry);
                Console.WriteLine("Entry successfully recorded!");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename: ");
                string fileName = Console.ReadLine();
                journal.SaveToFile(fileName);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename: ");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
