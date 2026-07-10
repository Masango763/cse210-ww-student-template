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
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("How many consecutive days have you been writing your journal? ");
                string streak = Console.ReadLine();
                
                Console.Write("Rate your current mood today (1-5 where 5 is excellent): ");
                string moodInput = Console.ReadLine();
                int moodScore = 5;
                int.TryParse(moodInput, out moodScore);
                string stars = new string('★', Math.Clamp(moodScore, 1, 5));

                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {randomPrompt}");
                Console.Write("> ");
                string entryText = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToString("dd/MM/yyyy");
                newEntry._promptText = randomPrompt;
                newEntry._entryText = $"[Streak: {streak} Days] [Mood: {stars}]\n> {entryText}";

                theJournal.AddEntry(newEntry);
                Console.WriteLine("Entry successfully recorded!");
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded successfully.");
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                running = false;
            }
        }
    }
}
