using System;
using static System.Console;

namespace GuessAWord
{
    class Program
    {
        static void Main()
        {
            WordGuess wordguess = new WordGuess();
            wordguess.GuessWord();
        }
    }
}
