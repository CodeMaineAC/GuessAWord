using System;
using static System.Console;

namespace GuessAWord
{
    class Program
    {
        static void Main()
        {
            //Array of possible word to guess
            string[] words = {"apricot", "elephant", "tigress",
         "fortunate", "impossible", "historical",
         "colorful", "science"};
            //Gets a random word from the array
            Random RandomClass = new Random();
            int randomNumber;
            randomNumber = RandomClass.Next(0, words.Length);
            string selectedWord = words[randomNumber];

            //variable initization 
            string guessedWord = "";
            string originalWord = selectedWord;
            string guess;
            char letter;
            int pos;
            char tempChar;
            int foundCount = 0;
            bool letterInWord;

            //Places down aterix that represent the length of thhe hidden word
            for (int a = 0; a < selectedWord.Length; ++a)
                guessedWord += "*";


            while (foundCount < selectedWord.Length)
            {
                //User input for the character
                WriteLine("Word: {0}", guessedWord);
                Write("Guess a letter >> ");
                guess = ReadLine();
                letter = Convert.ToChar(guess.Substring(0, 1));


                //Check to see if guessed letter is in the word
                letterInWord = false;
                for (pos = 0; pos < selectedWord.Length; ++pos)
                {
                    tempChar = Convert.ToChar(selectedWord.Substring(pos, 1)); //Getting a charater from the word to compare against
                    if (tempChar == letter) //compare user guess to letter in word
                    {
                        //If letter is in the word reveal where the letter is in the word
                        guessedWord = guessedWord.Substring(0, pos) + letter + guessedWord.Substring(pos + 1, (guessedWord.Length - 1 - pos));
                        selectedWord = selectedWord.Substring(0, pos) + '?' + selectedWord.Substring(pos + 1, (guessedWord.Length - 1 - pos));
                        ++foundCount;
                        letterInWord = true;
                    }

                }

                //Prompt user is the letter was in the word or not
                if (letterInWord)
                    WriteLine("Yes! {0} is in the word", letter);
                else
                    WriteLine("Sorry. {0} is not in the word", letter);
            }
            WriteLine("Good job! Word was {0}", originalWord);
        }
    }
}
