using System;
using System.Collections.Generic; // lit and strings 
class PromptGenerator // This class will be where the prompt is held, using 
{
    private List<string> prompts = new List<string>
    {
        "What are some miracles that happened in your day today",
        "Did you see and opprotunuitys to serve others",
        "How have you see the hand of God in your life today",
        "What were some tender mercies you notice ",
        "Did you get a chace to pray or meditate, write about this exprience",
    };
    private Random random = new Random(); // Will generate random index
    public string GetRandomPrompt()// when naming method it cannot have space or gives error  
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class Entry
{
    public string date;
    public string prompt;
    public string response;
    public void Display()
    {
        Console.Write($"Date: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine($"Response: {response}");
        Console.WriteLine();
    }

    public string FormatForFile()
    {
        return $"{date}|{prompt}|{response}";
    }

    public static Entry ParseFromFile(string line)
    {
        string[] parts = line.Split('|');
        return new Entry
        {
            date = parts[0],
            prompt = parts[1],
            response = parts[2]
        };
    }
}// aaron james 

// This class keeps track of the whole journal
class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename)) //https://byui-cse.github.io/cse210-course-2023/unit02/develop.html
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.FormatForFile());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                _entries.Add(Entry.ParseFromFile(line));
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
    //aaron james 

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal(); // this is the journal
        PromptGenerator promptGenerator = new PromptGenerator();// this will handle all of the questions
        bool running = true;

        // this where i started creating the menu including  options  the prompt and getting resposnse will go below as well 
        while (running)
        {
            // menus options will get displayed to the user 
            Console.WriteLine("\nJournal MENU:");
            Console.WriteLine("Create a new entry");
            Console.WriteLine("View Your journal entry");
            Console.WriteLine("Save Your Journal Entry");
            Console.WriteLine("Load past Journal");
            Console.Write("Exist");
            Console.Write(" Respond with a option by choosing a number 1 through 5");
            string choice = Console.ReadLine();

            // Come back to this part later 
            //https://www.youtube.com/watch?v=sWfe80Fj9Pg   I use this program to help understand the assignment a little better
            // https://www.youtube.com/@BroCodez  I use this youtube channel video to review some of the c# fundamentals 
            // Handle the menu option
            switch (choice)
            {
                case "1":
                    // Get a prompt and let the user write their response
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}"); // $ looks for response from user to define prompt 
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    // Create a new journal entry
                    Entry newEntry = new Entry
                    {
                        date = DateTime.Now.ToString("yyyy-MM-dd"), // current date  date used https://byui-cse.github.io/cse210-course-2023/unit02/develop.html
                        prompt = prompt,
                        response = response
                    };

                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    // Show all the journal entries
                    Console.WriteLine("\nYour Journal:");
                    journal.Display();
                    break;

                case "3":
                    // Ask for a filename and save everything
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    // Ask for a file to load and load it
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.");
                    break;

                case "5":
                    // Exit the loop/program
                    running = false;
                    Console.WriteLine("Journal Closed");
                    break;

                default:
                    Console.WriteLine("Please enter a number from 1 to 5");
                    break;
            }


        }


    }
}