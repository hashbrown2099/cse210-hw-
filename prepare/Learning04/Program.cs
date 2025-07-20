using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        Console.ReadKey();
        Console.Clear();

        // Test the MathAssignment
        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.ReadKey();
        Console.Clear();

        WritingAssignment writingAssignment = new WritingAssignment("MaryWaters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
        Console.ReadKey();
        Console.Clear();
    }
    

}



public class Assignment
{
    public string _studentName;
    public string _topic;


    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
    public string GetSummary()
    {
        return $"{_studentName} -  {_topic}";
    }
    public string GetStudentName()
    {
        return _studentName;
    }
}


public class MathAssignment : Assignment
{
    public string _textbookSection;
    public string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"{_textbookSection} {_problems}";
    }


}
public class WritingAssignment : Assignment
{
    public string _tittle;

    public WritingAssignment(string studentName, string topic, string tittle) : base(studentName, topic)
    {
        _tittle = tittle;
    }
    public string GetWritingInformation()
    {
        return $"{_tittle} by {GetStudentName()}";
    }
    
    
}