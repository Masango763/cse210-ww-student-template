using System;

class Program
{
    static void Main(string[] args)
    {
        // Call the functions and store their return values
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    // 1. Function to display a simple welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // 2. Function to ask for and return the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine() ?? "User";
        return name;
    }

    // 3. Function to ask for and return the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string response = Console.ReadLine() ?? "0";
        int number = int.TryParse(response, out int result) ? result : 0;
        return number;
    }

    // 4. Function to accept an integer, square it, and return the result
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // 5. Function to accept the name and squared number, then display them
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}