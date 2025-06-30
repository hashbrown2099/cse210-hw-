using System;                       
using System.Collections.Generic;   
using System.Threading;             
//aaron james 
// the extra work for this assigment is including explanation for the code 

//  ABSTRACT CLASS : serves as the base class for all the mental activitites , 

abstract class Activity
// This is an abstract class. It defines a "template" for all mindfulness activities.
// cannot do: new Activity()).
// It is designed to be inherited by child classes 
// used https://claude.ai/chat/71c72192-698d-4676-9fd5-023a21cb6a0b for debugging and reorganization of the code it also fixed errors with some of my classes 
//https://www.youtube.com/watch?v=is9xPX0GTuk
//https://www.youtube.com/watch?v=06BrbJm7Sho&list=PLZPZq0r_RZOPNy28FDBys3GVP2LiaIyP_&index=37
//https://www.youtube.com/watch?v=EvSyka9vJho&list=PLZPZq0r_RZOPNy28FDBys3GVP2LiaIyP_&index=36
{
    protected int duration;

    public void Start()
    // This is a complete method shared by all child classes.
    // this hdanles the setup
    {
        Console.Clear();                 
        DisplayStartMessage();          
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());  // Ask user for activity time

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);                 // spins the spinner for 3 

        Run();                          

        DisplayEndMessage();            
    }

    protected void DisplayStartMessage()
    // 'protected' means this can be reused in child classes if needed.
    
    {
        Console.WriteLine($"\nStarting {GetType().Name}...");
        Console.WriteLine(GetDescription()); // Get 
    }

    protected void DisplayEndMessage()
    
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);                  //pause
        Console.WriteLine($"You have completed the {GetType().Name} for {duration} seconds.");
        ShowSpinner(3);                  //pause
    }

    protected void ShowSpinner(int seconds)
    // shared animatred pause
    {
        string[] spinner = { "/", "-", "\\", "|" };         // this is where the spinner "animaedtion is built
        DateTime end = DateTime.Now.AddSeconds(seconds);    
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % 4]);     // Show spinner character
            Thread.Sleep(250);                 // Wait 1/4 second
            Console.Write("\b");               // Remove character
            i++;
        }
    }

    protected void Countdown(int seconds)
    // displays the countdiown of doom
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);   // 1 second
        }
        Console.WriteLine();
    }

    public abstract string GetDescription();
    // This is an abstract method.
    // it forces all subclasses to implement their own description.

    public abstract void Run();
   
}





class BreathingActivity : Activity
// Inherits from Activity implement Run and GetDescription.
{
    public override string GetDescription()
    {
               return "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing.";
    }

    public override void Run()
    {
             int cycle = duration / 6;  // One cycle 3sbreathing  in  3s breathing out out 
             for (int i = 0; i < cycle; i++)
        {
            Console.Write("Breathe in... ");
            Countdown(3);          // inhale countdown
            Console.Write("Now breathe out... ");
            Countdown(3);          //  exhale countdown
        }
    }
}





class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you saw the hand of the lord in your life .",
         "What are some miracles you have seen today or this week",
        "How can you help someone spiritually with the gifts given to you .",
        " What is important to you ."
    };

    private List<string> questions = new List<string> // used chatgbt to develope a list of prompts 
    {
        "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
         "How did you get started?",
         "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override string GetDescription()
    {
        return "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void Run()
    {
        Random rand = new Random();
        Console.WriteLine("\n" + prompts[rand.Next(prompts.Count)]);  // Show random prompt
        ShowSpinner(5);                                               // Give time to think

        DateTime endTime = DateTime.Now.AddSeconds(duration);         // Set time limit
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\n" + questions[rand.Next(questions.Count)]); // Show random refxlection
            ShowSpinner(5);                                                  // Wait 
        }
    }
}





class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override string GetDescription()
    {
        return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void Run()
    {
        Random rand = new Random();
        Console.WriteLine("\n" + prompts[rand.Next(prompts.Count)]);   // Show prompt
        Console.WriteLine("You may begin listing in...");
        Countdown(5);                                                  

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(duration);              // Set end time

        while (DateTime.Now < end)
        {
            Console.Write(" > ");                                      // Input prompt
            if (!string.IsNullOrWhiteSpace(Console.ReadLine()))       // Accept non empty input
                items.Add("✓");                                        // Count it
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");       // Show count
    }
}



// added a uniqie spin on the assignment  this will give you a list of sipiration quotes prom president nelson

class SecretActivity : Activity
{
    private List<string> quotes = new List<string>
    {
        "The joy we feel has little to do with the circumstances of our lives and everything to do with the focus of our lives. — Russell M. Nealson",
        "Your mind is precious! It is sacred. Therefore, the education of one's mind is also sacred. — Russell M. Nealson",
        "The Lord loves effort, because effort brings rewards that can't come without it. — Russell M. Nealson",
        "In coming days, it will not be possible to survive spiritually without the guiding, directing, comforting, and constant influence of the Holy Ghost. — Russell M. Nealson",
        "The gospel of Jesus Christ has never been needed more than it is today. — Russell M. Nealson"
    };

    public override string GetDescription()
    {
        return "This Secret Activity shares an inspiring quote from President Russell M. Nealson.";
    }

    public override void Run()
    {
        Random rand = new Random();
        Console.WriteLine("\n Secret quote:\n");
        Console.WriteLine($"\"{quotes[rand.Next(quotes.Count)]}\"");   // Show a random quote
        Console.WriteLine();
        ShowSpinner(duration);                                       
    }
}





class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();                    
            Console.WriteLine(" Find the peace you are looking for :");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Secret Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();  // Get user's menu choice
            Activity activity = null;            // Base class reference

            // Instantiate the  child class based on the input of the person
            switch (choice)
            {
                          case "1": activity = new BreathingActivity(); break;
                  case "2": activity = new ReflectionActivity(); break;
                 case "3": activity = new ListingActivity(); break;
                     case "4": activity = new SecretActivity(); break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                       Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.Start();                   
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}
