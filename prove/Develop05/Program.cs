using System; 
using System.Collections.Generic; 
using System.IO;
using System.Threading; 
//Aaron James 

// Enum to represent goal status wanted to try and used something from the youtbechannel bro code 
// This is an ENUMERATION, providing a set of named constants for the goal status
// https://www.youtube.com/watch?v=3p0OJErAbEI&list=PLZPZq0r_RZOPNy28FDBys3GVP2LiaIyP_&index=48 basics of enums 
// https://www.youtube.com/watch?v=T1fRCFcEzgo refresher on spinner animation 
//https://www.youtube.com/watch?v=KKzSQ6r93dY built in struct , this is for date time function used to help keep track of progress 

enum GoalStatus
{
    NotCompleted,
    Completed
}

// Base class for Goals
// Inheritance: This class will be inherited by specific goal types like DailyGoal
abstract class Goal
{
    // Encapsulation: fields are private and accessed via public properties
    private string name;             
    private int points;              
    private GoalStatus status;       // using the enum
    private DateTime lastCompleted;  

    // Properties (read-only) to allow safe access to private fields
    public string Name => name;
    public int Points => points;
    public GoalStatus Status => status;// Re look over all the changes made 

    // Constructor of  goal
    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
        this.status = GoalStatus.NotCompleted;
        this.lastCompleted = DateTime.MinValue; // date
    }

    // Polymorphism: this method is virtual and can be overridden in derived classes
    public virtual int RecordEvent()
    {
        if (IsCompletedToday()) // check to see if goal was already completed today
        {
            Console.WriteLine($"You already completed '{name}' today. YOU CAN ONLY COMPLETE ONCE A DAY");
            return 0; // This will or should award zero points if the goal was already completed today and show message 
        }
        else
        {
            ShowSpinner("Ipdating goal progress"); 
            status = GoalStatus.Completed; 
            lastCompleted = DateTime.Today; 
            Console.WriteLine($"Completed '{name}'. (+{points} points)");
            return points; 
        }
    }

    
    public bool IsCompletedToday()
    {
        return lastCompleted == DateTime.Today;
    }

    // This should reset the goal if a new day started if the program does reset progress could be a problem here  
    // last test july 1st 
    // tested again july 2nd and it works 
    public void ResetIfNewDay()
    {
        if (lastCompleted != DateTime.Today)
        {
            status = GoalStatus.NotCompleted;
        }
    }

    // apply polymorphism aspect heres aswell 
    public virtual void Display()
    {
        string check = status == GoalStatus.Completed ? "[Completed]" : "[ ]"; //completed
        Console.WriteLine($"{check} {name}");
    }

    // spinner 
    protected void ShowSpinner(string message)
    {
        Console.Write($"{message} ");
        for (int i = 0; i < 10; i++) // turning the spinner
        {
            Console.Write("|\b"); Thread.Sleep(50);
            Console.Write("/\b"); Thread.Sleep(50);
            Console.Write("-\b"); Thread.Sleep(50);
            Console.Write("\\\b"); Thread.Sleep(50);
        }
        Console.WriteLine("Done!");
    }
}

// daily goals 
// "DailyGoal"  should  inherits from "Goal"
class DailyGoal : Goal
{
    
    public DailyGoal(string name, int points) : base(name, points) { }
    
}

 // this class will manage the goals 
class GoalManager
{
    private List<DailyGoal> dailyGoals = new List<DailyGoal>(); // stores 
    private int totalScore;       // track score
    private int streakCount;      // track streak
    private DateTime lastActiveDate; 

   
    public GoalManager()
    {
        dailyGoals.Add(new DailyGoal("100 Sit Ups", 25)); 
        dailyGoals.Add(new DailyGoal("100 Push Ups", 25));
        dailyGoals.Add(new DailyGoal("1 Mile Walk,Run,or bike", 25));
        totalScore = 0;
        streakCount = 0;
        lastActiveDate = DateTime.Today;
    }

    // Check if a new day has started and reset goals if needed
    public void CheckForNewDay()
    {
        if (DateTime.Today != lastActiveDate)
        {
            Console.WriteLine("\n new day, Whos gonna carry the boats");
            foreach (var goal in dailyGoals)
            {
                goal.ResetIfNewDay(); 
            }

            // Check goals of previous day 
            bool allCompleteYesterday = true;
            foreach (var goal in dailyGoals)
            {
                if (!goal.IsCompletedToday())
                {
                    allCompleteYesterday = false;
                    break;
                }
            }

            if (allCompleteYesterday)
            {
                streakCount++; 
                if (streakCount == 7)
                {
                    Console.WriteLine(" I week bonus has ben achived (+700 points)");
                    totalScore += 700;
                    streakCount = 0; // Reset  
                }
                else
                {
                    Console.WriteLine($"You're on a {streakCount}-day streak!");
                }
            }
            else
            {
                streakCount = 0; // this will reset streak if not all completed HAD ISSUES WITH THIS ONE 
            }

            lastActiveDate = DateTime.Today; 
        }
    }

    // Display all goals and allow the user to mark multiple goals as done
    // This took me to longest to work on  i couldnt quite get it working myself  so it might allow you to gain multiple points if you select 1 each time
    // COME BACK AND TROUBLE SHOOT THIS June July 1
    // decided to run it through claude AI because it cotinued to break my  recording goals https://claude.ai/
    public void DisplayAndRecordGoals()
    {
        Console.WriteLine("\nToday's To-Do List:");
        for (int i = 0; i < dailyGoals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. ");
            dailyGoals[i].Display();
        }
        Console.WriteLine($"\nScore: {totalScore}");
        Console.WriteLine($"Streak: {streakCount}/7");

        Console.WriteLine("\nEnter the numbers of the goals you completed (separated by commas), or press Enter to skip:");
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            string[] choices = input.Split(',');
            int sessionPoints = 0;

            foreach (string choice in choices)
            {
                if (int.TryParse(choice.Trim(), out int num) && num >= 1 && num <= dailyGoals.Count)
                {
                    int earned = dailyGoals[num - 1].RecordEvent();
                    sessionPoints += earned;
                }
                else
                {
                    Console.WriteLine($"Skipping invalid choice: {choice}");
                }
            }

            totalScore += sessionPoints; 
            CheckDailyBonus(); 
        }
    }

    // Check BONUSES
    private void CheckDailyBonus()
    {
        int completedCount = 0;
        foreach (var goal in dailyGoals)
        {
            if (goal.Status == GoalStatus.Completed)
                completedCount++;
        }

        if (completedCount == dailyGoals.Count)
        {
            Console.WriteLine("BONUS: All goals crushed today! (+75 points)");
            totalScore += 75;
        }
        else if (completedCount == 2)
        {
            Console.WriteLine("BONUS: Two goals done! (+50 points)");
            totalScore += 50;
        }
    }

    // save progress
    public void SaveProgress()
    {
        ShowSpinner("Saving progress");
        using (StreamWriter writer = new StreamWriter("progress.txt"))
        {
            writer.WriteLine(totalScore);
            writer.WriteLine(streakCount);
            writer.WriteLine(lastActiveDate);
            foreach (var goal in dailyGoals)
            {
                writer.WriteLine(goal.Status);
            }
        }
        Console.WriteLine("Progress saved!");
    }

    // Load progress 
    public void LoadProgress()
    {
        if (File.Exists("progress.txt"))
        {
            ShowSpinner("Loading progress");
            using (StreamReader reader = new StreamReader("progress.txt"))
            {
                totalScore = int.Parse(reader.ReadLine());
                streakCount = int.Parse(reader.ReadLine());
                lastActiveDate = DateTime.Parse(reader.ReadLine());

                foreach (var goal in dailyGoals)
                {
                    GoalStatus status = (GoalStatus)Enum.Parse(typeof(GoalStatus), reader.ReadLine());
                    if (status == GoalStatus.Completed)
                    {
                        goal.RecordEvent();
                    }
                }
            }
            Console.WriteLine("Progress loaded!");
        }
        else
        {
            Console.WriteLine("No saved progress found.");
        }
    }

    //  spinner animation
    private void ShowSpinner(string message)
    {
        Console.Write($"{message} ");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("|\b"); Thread.Sleep(50);
            Console.Write("/\b"); Thread.Sleep(50);
            Console.Write("-\b"); Thread.Sleep(50);
            Console.Write("\\\b"); Thread.Sleep(50);
        }
        Console.WriteLine("Done!");
    }
}

// Main program class
class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager(); 
        bool running = true;

        while (running)
        {
            manager.CheckForNewDay(); 

            // Display menu
            Console.WriteLine("\n $$$ Eternal Quest: Train to be One Punch Man HERO $$$ ");
            Console.WriteLine("1. Check Goals & Mark Them Done");
            Console.WriteLine("2. Save Progress");
            Console.WriteLine("3. Load Progress");
            Console.WriteLine("4. Quit");
            Console.Write("Pick an option 1-4: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    manager.DisplayAndRecordGoals();
                    break;
                case "2":
                    manager.SaveProgress();
                    break;
                case "3":
                    manager.LoadProgress();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }
        }

        Console.WriteLine("Keep crushing those goals!");
    }
}
// spacing correction and  organization done with claude AI 