using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name?");    // Ask the user for their first name 
        string first_name = Console.ReadLine();      // Defines the first_name as a string and has the user define it
        Console.Write("what is your last name?");   //  Ask the user for their first name   
        string Last_name = Console.ReadLine();      // Degines Last_name as a string and allows user repsonse to define the cvariable
        Console.WriteLine($"Your name is {Last_name}, {first_name} {Last_name}."); // Prints users first then full name in james bond format

    }   
    }
