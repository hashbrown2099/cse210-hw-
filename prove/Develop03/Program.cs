using System; 
using System.Collections.Generic; 

class Program
{
    static void Main(string[] args) 
    {
        // Create a scripture reference for Helaman 5:12
        Reference reference = new Reference("Helaman", 5, 12);

        // Store the full verse text from Helaman 5:12 (Book of Mormon)
        string text = "And now, my sons, remember, remember that it is upon the rock of our Redeemer, " +
                      "who is Christ, the Son of God, that ye must build your foundation; that when the devil " +
                      "shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail " +
                      "and his mighty storm shall beat upon you, it shall have no power over you to drag you down " +
                      "to the gulf of misery and endless wo, because of the rock upon which ye are built, which is " +
                      "a sure foundation, a foundation whereon if men build they cannot fall.";

        // Create a Scripture object that will manage the verse and hiding logic
        Scripture scripture = new Scripture(reference, text);

        // Loop until all words are hidden or the user quits
        while (!scripture.AllWordsHidden())
        {
            Console.Clear(); // Clear the console to refresh the display each time
            scripture.Display(); // Show the scripture with current visibility state

            // Ask the user what to do next
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine(); // Read user's input

            // If user types 'quit', break the loop and end the program
            if (input.ToLower() == "quit")
            {
                break;
            }

            // Otherwise, hide a few random words and repeat
            scripture.HideRandomWords();
        }

        // Final message once all words are hidden or user quit
        Console.WriteLine("\nAll No more words can be hidden, Congratulations");
    }
}

// This class represents the scripture reference  Helaman 5:12
class Reference
{
    private string _book; // The book name, e.g., "Helaman"
    private int _chapter; // The chapter number
    private int _verseStart; // The starting verse (if a range, this is the first verse)
    private int _verseEnd;   // The ending verse (if single verse, same as _verseStart)

    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book; // Store the book name
        _chapter = chapter; // Store the chapter number
        _verseStart = verse; // Store the verse number
        _verseEnd = verse; // Set end verse same as start for single-verse reference
    }

    // Constructor for multiple verses Helaman 5:12
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    // Return the reference as a  string
    public string GetDisplayText()
    {
        if (_verseStart == _verseEnd) // If it's just one verse
        {
            return $"{_book} {_chapter}:{_verseStart}";
        }
        else // If it's a verse range
        {
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
    }
}

// Represents a single word in the scripture and whether it’s hidden or not
class Word
{
    private string _text; // The actual word text, like "Redeemer"
    private bool _isHidden; // Flag to track if the word is hidden

    // Constructor: creates a Word object with given text
    public Word(string text)
    {
        _text = text; // Set the word text
        _isHidden = false; // Words are visible by default
    }

    // Method to hide the word (set flag to true)
    public void Hide()
    {
        _isHidden = true;
    }

    // Return the word's display: either the text or underscores
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }

    // Check whether the word is currently hidden
    public bool IsHidden()
    {
        return _isHidden;
    }
}

// This class manages the full scripture — its reference and list of words
class Scripture
{
    private Reference _reference; // The scripture reference (e.g., Helaman 5:12)
    private List<Word> _words; // The list of Word objects for the verse
    private Random _random = new Random(); // For picking random words to hide

    // Constructor takes a reference and verse text and sets it up
    public Scripture(Reference reference, string text)
    {
        _reference = reference; // Store the reference
        _words = new List<Word>(); // Initialize the word list

        // Split the verse text into words and convert each to a Word object
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word)); // Add each word to the list
        }
    }

    // Display the scripture on the console
    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText()); // Show the reference (e.g., "Helaman 5:12")

        // Loop through each word and display its current state (hidden or not)
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " "); // Print word followed by space
        }

        Console.WriteLine(); // Add new line after the verse
    }

    // Randomly hide a few visible words
    public void HideRandomWords(int numberToHide = 3)
    {
        int hidden = 0; // Counter for how many we've hidden so far

        // Keep hiding until we've hit the target number
        while (hidden < numberToHide)
        {
            int index = _random.Next(_words.Count); // Pick a random index

            // Only hide if the word isn’t already hidden
            if (!_words[index].IsHidden())
            {
                _words[index].Hide(); // Hide the word
                hidden++; // Count it
            }
        }
    }

    // Return true if every word is currently hidden
    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) // If at least one is still visible
            {
                return false; // Not done yet
            }
        }
        return true; // Everything is hidden, we're finished
    }
}
// the program should only leave three words left and not hide all the words. When three words are left it should say All the words are hidden Nicley done 