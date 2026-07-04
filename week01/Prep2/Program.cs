using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Ask the user for their grade percentage safely handling null values
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine() ?? "0";
        
        // Safely parse the string to integer to avoid runtime crashes on empty input
        int percent = int.TryParse(answer, out int result) ? result : 0;

        string letter = "";

        // 2. Determine the letter grade using conditional statements
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // 3. Display the letter grade
        Console.WriteLine($"Your grade is: {letter}");
        
        // 4. Check if the user passed the course (70% or higher is a passing grade)
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep working hard! You can do better next time.");
        }
    }
}