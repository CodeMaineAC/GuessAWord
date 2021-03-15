using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace GuessAWord
{
    class WordGuess
    {
        //Array of possible word to guess
        string[] words = {"apricot", "elephant", "tigress",
         "fortunate", "impossible", "historical",
         "colorful", "science"};

        //Array of allowed charcters
        char[] letters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
         'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        //Gets a random word from the array
        Random RandomClass = new Random();
        int randomNumber;
        string selectedWord;

        //variable initization 
        string guessedWord = "";
        string originalWord;
        string guess;
        char letter;
        int pos;
        char tempChar;
        int foundCount = 0;
        bool letterInWord;
        bool isLetter;
        public WordGuess()
        {
            randomNumber = RandomClass.Next(0, words.Length);
            selectedWord = words[randomNumber];
            originalWord = selectedWord;
            InitializeGuessedWord();
        }

        private void InitializeGuessedWord()
        {
            for (int a = 0; a < selectedWord.Length; ++a)
                guessedWord += "*";
        }

        private void GetGuessedLetter()
        {
            WriteLine("Word: {0}", guessedWord);
            Write("Guess a letter >> ");
            guess = ReadLine().ToLower();
            letter = Convert.ToChar(guess.Substring(0, 1));
        }

        private void CheckIsAllowedChar()
        {
            int x;
            isLetter = false;

            for(x = 0; x < letters.Length; ++x)
            {
                if(letter == letters[x])
                {
                    isLetter = true;
                    break;
                }
            }

            if (!isLetter) throw (new NonLetterException(letter));
        }

        private void CheckLetter()
        {
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
        }

        public void GuessWord()
        {
            while (foundCount < selectedWord.Length)
            {
                try
                {
                    //User input for the character
                    GetGuessedLetter();

                    //Check if letter is an allowed character
                    CheckIsAllowedChar();

                    //Check to see if guessed letter is in the word
                    CheckLetter();
                    //Prompt user is the letter was in the word or not
                    if (letterInWord)
                        WriteLine("Yes! {0} is in the word", letter);
                    else
                        WriteLine("Sorry. {0} is not in the word", letter);
                }
                catch(NonLetterException e)
                {
                    WriteLine(e.Message);
                }
               

                
            }
            WriteLine("Good job! Word was {0}", originalWord);
        }
    }
    
}
