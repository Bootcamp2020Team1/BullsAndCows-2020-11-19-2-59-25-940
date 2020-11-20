using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly int allowableGuessLength = 4;
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        private int chanceLeft = 6;
        private int maxChance = 6;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
            CanContinue = true;
        }

        public bool CanContinue { get; private set; }

        public string CorrectAnswer
        {
            get
            {
                return "4A0B";
            }
        }

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return this.Compare(this.secret, guessWithoutSpace);
        }

        public bool IsValidGuess(string guess)
        {
            var regex = new Regex(@"^([0-9]\s){3}[0-9]$");
            if (regex.Match(guess).Success)
            {
                var guessArrayWithSpaceRemoved = guess.Split(" ");
                return guessArrayWithSpaceRemoved.Length == allowableGuessLength && guessArrayWithSpaceRemoved.Distinct<string>().Count() == allowableGuessLength;
            }

            return false;
        }

        public void CheckCorrectAnswer(string answer)
        {
            if (answer == CorrectAnswer)
            {
                CanContinue = false;
            }
        }

        private void DeductOneChance()
        {
            if (chanceLeft == 1)
            {
                CanContinue = false;
            }
            else
            {
                chanceLeft -= 1;
            }
        }

        private string Compare(string secret, string guess)
        {
            DeductOneChance();
            var bullsList = secret.Where((secret, index) => guess[index] == secret).ToList();
            var cowsList = secret.Where(secret => guess.Contains(secret)).ToList();
            var theOverlapOfBullsAndCows = bullsList.Where(x => cowsList.Contains(x)).Count();

            return $"{bullsList.Count()}A{cowsList.Count() - theOverlapOfBullsAndCows}B";
        }
    }
}