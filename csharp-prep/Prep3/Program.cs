using System;

class Program
{
    static void Main()
    {
        // Yo, we're about to enter the mind of the machine.
        // It picks a number between 1 and 100. Totally random. Wild.
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // 1 to 100 — no cap.

        int guess = -1; // Starting with a bogus guess just to get things rolling.

        Console.WriteLine("Welcome to 'Guess My Number'!");
        Console.WriteLine("I'm thinking of a number between 1 and 100... Try to read the mind of the machine.");

        // This loop? It's like the universe. It just keeps going until you reach enlightenment... or guess the number.
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();

            // This part? Super important. You can’t just type "banana" and expect the machine to understand.
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Bro… that's not even a number. Try again.");
                continue; // Just skip the rest and start over.
            }

            // Now we get deep. Did the guess hit? Or are we still wandering in the dark?
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher, dude. You're not quite there yet.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower, bro. You overshot it.");
            }
            else
            {
                // You did it. You beat the machine. Victory is yours.
                Console.WriteLine("You guessed it! That’s insane! Like mind meld with a computer!");
            }
        }
    }
}

            
        
    
