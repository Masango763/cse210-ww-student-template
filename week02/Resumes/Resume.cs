using System;
using System.Collections.Generic;

public class Resume
{
    // Attributes
    public string _name = "";
    
    // We initialize the list immediately so it's ready to accept jobs
    public List<Job> _jobs = new List<Job>();

    // Constructor
    public Resume()
    {
    }

    // Method to display the full resume profile
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        // Loop through each Job object in our list and trigger its custom display method
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}