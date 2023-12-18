using System;

namespace Game
{
    class Hangman
    {
        static void Main()
        {
            bool Run = true;

            // Counter for the for loop
            int Counter = 0;

            // recieves user input for correct word
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            // The correct word as an array
            char[] wordAnswer = word.ToCharArray();

            // Amount of lives
            Console.Write("How many guesses: ");
            var lifeStr = Console.ReadLine();
            int lifeCount = int.Parse(lifeStr);


            // Generates the board
            char[] Board = new char[word.Length];

            // list to contain already guessed letters
            List<char> Guessed = new List<char>();

            // generates 50 lines of empty space in the console
            var LineCounter = 50;
            while (LineCounter > 0)
            {
                Console.WriteLine("\n");
                LineCounter--;
            }

            Console.Write(Board);

            // actually makes the board
            for (int i = 0; i < word.Length; i++)
            {
                Board[i] = '_';
            }

            // general game loop
            while (Run)
            {

                // checks if game should contine to run
                while (lifeCount >= 1)
                {

                    // checks if all letters have been guessed
                    if (!Board.Contains('_'))
                    {
                    Console.WriteLine($"You Win with {lifeCount} Lives Remaining! The Correct Word was \"{word}\"");
                    Run = false;
                    break;
                    }

                    // Gets input from the user
                    Console.Write("Enter your guess: ");
                    string Guess = Console.ReadLine();

                    // counter to contain index for the for loop
                    Counter = 0;

                    char Letter = Guess[0];

                    // Check if the letter has already been guessed
                    if (Guessed.Contains(Letter))
                    {
                        Console.WriteLine($"You already guessed the letter \'{Letter}\'. Try again.\n");
                        continue;
                    }

                    // adds the letter the user guessed to a list
                    Guessed.Add(Letter);

                    // variable to check a correct guess
                    bool CorrectGuess = false;

                    // checks board for user guess
                    foreach (char i in wordAnswer)
                    {
                        if (Letter == i)
                        {
                            Board[Counter] = Letter;
                            CorrectGuess = true;
                        }
                        Counter++;
                    }

                    // removes life
                    if (!CorrectGuess)
                    {
                        lifeCount -= 1;
                    }

                    Console.WriteLine(Board);
                    Console.WriteLine($"You have {lifeCount} lives remaining!\n");
                }

                // ends game if user runs out of lives
                if (lifeCount == 0)
                {
                    Console.WriteLine($"You Lose! The Word was \"{word}\"\n");
                    break;
                }
            }
        }
    }
}
