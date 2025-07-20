using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
      
        Job job1 = new Job();
        job1.company = "Freddy's";
        job1.jobTitle = "Cook";
        job1.startYear = 2020;
        job1.endYear = 2024;

        
        Job job2 = new Job();
        job2.company = "McD";
        job2.jobTitle = " Manager";
        job2.startYear = 2024;
        job2.endYear = 2029;

        
        Resume resume1 = new Resume();
        resume1.name = "Aaron";

   
        resume1.jobs.Add(job1);
        resume1.jobs.Add(job2);

        
        resume1.Display();
    }
}

public class Job
{
    public string company;
    public string jobTitle;
    public int startYear;
    public int endYear;

    public void Display()
    {
        Console.WriteLine($"{jobTitle} ({company}) {startYear}-{endYear}");
    }
}

public class Resume
{
    public string name;
    public List<Job> jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in jobs)
        {
            job.Display();
        }
    }
}


