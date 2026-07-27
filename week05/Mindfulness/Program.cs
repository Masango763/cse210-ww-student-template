using System;
using System.Threading;
/*
 * EXCEEDING REQUIREMENTS DOCUMENTATION:
 * To exceed the core requirements of the Mindfulness Program, this solution implements:
 * 1. Session Analytics/Activity Log: Tracks how many times each activity was completed 
 *    during the current application runtime and displays a summary log when quitting.
 * 2. Non-Repeating Randomization: Implements tracking lists within the Reflecting and Listing 
 *    activities to ensure prompts and questions do not repeat until all options have been shown once.
 */

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Session Summary Log:");
                Console.WriteLine($" - Breathing Activities Completed: {breathingCount}");
                Console.WriteLine($" - Reflecting Activities Completed: {reflectingCount}");
                Console.WriteLine($" - Listing Activities Completed: {listingCount}");
                Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please select 1 through 4.");
                Thread.Sleep(1500);
            }
        }
    }
}
