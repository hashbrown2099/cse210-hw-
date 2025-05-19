using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage number leave out the % symbol: "); 
        string gradePercent = Console.ReadLine();
        int percentage;

        // Validate input
        if (!int.TryParse(gradePercent, out percentage) || percentage < 0 || percentage > 100) // included int.TryParse according to google will not crash the program if an invalid input is entered into the program this has an advantage over int.parse
        {
            Console.WriteLine(" Write a NUMBER between 0 and 100");
            return; // Stops the rest of the code from running is theres a input that is not a int 
        }

        string letter = "";
        string sign = "";

        // Else if statements for returning the Letter grade results back to the user
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine Wether or not you got a c-,c,b-
        int lastDigit = percentage % 10; // the %  returns the remainder number devided by 10, that number is then used to determine wether or not you are a base letter grade or an additional - or +

        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && percentage < 97)
        {
            
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        
        Console.WriteLine($"Your grade is: {letter}{sign}"); // prints your letter grade and assotiated sign

       
        if (percentage >= 70)
        {
            Console.WriteLine("Shout out to you. you are the certified Goat!");
        }
        else
        {
            Console.WriteLine("Brother your cooked go see the professor for some mercy and grace");
        }
    }
}
    
