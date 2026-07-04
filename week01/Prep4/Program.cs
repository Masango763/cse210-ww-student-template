using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create a List to store integers
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;

        // 2. Loop to collect numbers until the user enters 0
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string response = Console.ReadLine() ?? "0";
            userNumber = int.TryParse(response, out int result) ? result : 0;
            
            // Only add the number to our list if it's not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // 3. Perform calculations if the user entered any numbers
        if (numbers.Count > 0)
        {
            // Calculate Sum
            int sum = numbers.Sum();
            
            // Calculate Average (cast to double for decimal accuracy)
            double average = numbers.Average();
            
            // Find Max
            int max = numbers.Max();

            // 4. Display the results
            Console.WriteLine($"\nThe sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
        }
        else
        {
            Console.WriteLine("\nNo numbers were entered.");
        }
    }
}