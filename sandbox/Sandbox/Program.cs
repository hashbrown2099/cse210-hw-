using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

class Car
{
    string make;
    string model;
    int year;

    void Display()
    {
        Console.WriteLine($"{make} {model} {year}");
    }
    
}
class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Hello world");
    
   }
}
