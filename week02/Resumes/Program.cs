using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create instance for the first job
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // 2. Create instance for the second job
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // 3. Create the main Resume container instance
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        // 4. Add both distinct job instances into the resume's list
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // 5. Run the Display method to cleanly unpack and print everything
        myResume.Display();
    }
}