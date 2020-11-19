using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    public class InputValidator
    {
        public bool IsValidGuess(string guess)
        {
            const int allowableGuessLength = 4;
            var regex = new Regex(@"^([0-9]\s){3}[0-9]$");
            if (regex.Match(guess).Success)
            {
                var guessArrayWithSpaceRemoved = guess.Split(" ");
                return guessArrayWithSpaceRemoved.Length == allowableGuessLength && guessArrayWithSpaceRemoved.Distinct<string>().Count() == allowableGuessLength;
            }

            return false;
        }
    }
}
