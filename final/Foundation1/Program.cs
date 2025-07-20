using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();
        Console.Clear();
        Video video1 = new Video("Happy birthday", "jhon madden", 3.25);
        video1.commentSection.newComment("MIKE", "THIS SUCKS");
        video1.commentSection.newComment("MIKE", "THIS SUCKS");
        video1.commentSection.newComment("MIKE", "THIS SUCKS");

        video1.display();
        Console.ReadKey();
        Console.Clear();
        Video video2 = new Video("Happy new years", "aaron james", 15.08);
        video2.commentSection.newComment("MIKE", "THIS SUCKS");
        video2.commentSection.newComment("MIKE", "THIS SUCKS");
        video2.commentSection.newComment("MIKE", "THIS SUCKS");

        video2.display();
        Console.ReadKey();
        Console.Clear();
        
        Video video3 = new Video("happy happy holidays", "JMAN", 25.25);
        video3.commentSection.newComment("MIKE", "THIS SUCKS");
        video3.commentSection.newComment("MIKE", "THIS SUCKS");
        video3.commentSection.newComment("MIKE", "THIS SUCKS");

        video3.display();
        Console.ReadKey();
        Console.Clear();
    }
}


class Video
{
    public string _Tittle;
    public string _author;
    public double _videoLength;
    public string commentSection;
    

    public List<Comment> comment = new List<Comment>();

    public Video(string Tittle, string author, double videoLength)
    {
        _Tittle = Tittle;
        _author = author;
        _videoLength = videoLength;
    }

    public void display()
{
        {

            Console.WriteLine($"{_Tittle}");
            Console.WriteLine($"{_author}");
            Console.WriteLine($"{_videoLength}");
            Console.WriteLine("Comments:");
            commentSection.DisplyComments();
        }
}


    class CommentSection
    {

        public List<Comment> comments = new List<Comment>();
        public void newComment(string name, string text)
        {
            comments.Add(new Comment(name, text));

        }
        public void DisplyComments()
        {
            foreach (Comment viewer in comments)
            {
                Console.WriteLine($"{viewer._name}: {viewer._text}");
            }
        }
        public int CommentsNumber()
        {
            return comments.Count;
        }



    }
    
    

    class Comment
    {
        public string _name;
        public string _text;

        public Comment(string name, string text)
        {
            _name = name;
             _text = text;
        }
        
    }
}