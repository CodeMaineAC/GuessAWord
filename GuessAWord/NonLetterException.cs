using System;
using System.Collections.Generic;
using System.Text;

namespace GuessAWord
{
    class NonLetterException : Exception
    {
        public NonLetterException(char c) : base("Not a letter : " + c)
        {

        }
    }
}
