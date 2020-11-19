using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private const int AllowableGuessLength = 4;
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return this.Compare(this.secret, guessWithoutSpace);
        }

        public string Compare(string secret, string guess)
        {
            var xList = secret.Where((secret, index) => guess[index] == secret).ToList();
            var yList = secret.Where(secret => guess.Contains(secret)).ToList();
            var xOverlapY = xList.Where(x => yList.Contains(x)).Count();

            return $"{xList.Count()}A{yList.Count() - xOverlapY}B";
        }

        public bool IsValidGuess(string guess)
        {
            var regex = new Regex(@"^([0-9]\s){3}[0-9]$");
            if (regex.Match(guess).Success)
            {
                var guessArrayWithSpaceRemoved = guess.Split(" ");
                return guessArrayWithSpaceRemoved.Length == AllowableGuessLength && guessArrayWithSpaceRemoved.Distinct<string>().Count() == AllowableGuessLength;
            }

            return false;
        }
    }
}