using System;
using System.Collections.Generic;
using System.IO;

// Manager class handling user interaction menus, goal collections, file storage, and score logic.
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    // Initializes empty goals collection and zero score.
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Main execution loop for the menu system.
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();
        }
    }

    // Displays current score alongside the advanced Leveling & Rank Title gamification enhancement.
    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        string title = level switch
        {
            1 => "Novice Pilgrim",
            2 => "Dedicated Seeker",
            3 => "Righteous Apprentice",
            4 => "Steadfast Disciple",
            5 => "Master of Habits",
            _ => "Legendary Eternal Seeker"
        };

        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"[Level {level}] Rank Title: {title}");
    }

    // Lists names only for selection prompts.
    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    // Lists full details including checkboxes and progress.
    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Prompts user inputs to instantiate and append new goals.
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    // Records progress on a selected goal and updates score.
    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            int earnedPoints = goal.RecordEvent();
            _score += earnedPoints;

            Console.WriteLine($"\nCongratulations! You have earned {earnedPoints} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
    }

    // Serializes score and goals to an external file.
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    // Deserializes and loads score and goals from an external file.
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(":");
                string type = parts[0];
                string details = parts[1];
                string[] detailsParts = details.Split(",");

                if (type == "SimpleGoal")
                {
                    string name = detailsParts[0];
                    string description = detailsParts[1];
                    int points = int.Parse(detailsParts[2]);
                    bool isComplete = bool.Parse(detailsParts[3]);
                    _goals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    string name = detailsParts[0];
                    string description = detailsParts[1];
                    int points = int.Parse(detailsParts[2]);
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = detailsParts[0];
                    string description = detailsParts[1];
                    int points = int.Parse(detailsParts[2]);
                    int bonus = int.Parse(detailsParts[3]);
                    int target = int.Parse(detailsParts[4]);
                    int amountCompleted = int.Parse(detailsParts[5]);
                    _goals.Add(new ChecklistGoal(name, description, points, bonus, target, amountCompleted));
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
