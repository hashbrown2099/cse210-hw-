using System;
using System.Runtime.CompilerServices;

class Job
{
    public string jobTitle;
    public string company;
    public int startYear;
    public int endYear;
    public void DisplayJobInfo()
    {
        string end = endYear == 2025 ? "Currently Employed" : endYear.ToString();// allows me to state that im currently emplyed instead of saying 2025
        Console.WriteLine($"{jobTitle}) ({company}) {startYear}-{end}");


    }
}
class Resume
{
    public string name;
    public List<Job> jobs = new List<Job>();

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {name}");
        Console.Write("Jobs:");
        foreach (Job job in jobs)
        {
            job.DisplayJobInfo();
        }
    }
    }
class Program
{
    static void Main(String[] args)
    {
        Job job1 = new Job();
        job1.jobTitle = "Jr.Electrical Engineer";
        job1.company = "INL";
        job1.startYear = 2021;
        job1.endYear = 2023;

        Job job2 = new Job();
        job2.jobTitle = "Lead Electrical Designer";
        job2.company = "Tesla";
        job2.startYear = 2023;
        job2.endYear = 2025;

        // Create the resume
        Resume myResume = new Resume();
        myResume.name = "Aaron James";

        // Add jobs to the resume
        myResume.jobs.Add(job1);
        myResume.jobs.Add(job2);

        // Display the resume
        myResume.DisplayResume();


    }
}    