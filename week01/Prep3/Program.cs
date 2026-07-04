using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Generate a random magic number between 1 and 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        // 2. Loop until the user guesses the correct number
        while (guess != magicNumber)
        {
            // Ask the user for their guess safely
            Console.Write("What is your guess? ");
            string answer = Console.ReadLine() ?? "0";
            guess = int.TryParse(answer, out int result) ? result : 0;

            // 3. Provide higher/lower feedback using conditionals inside the loop
            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}