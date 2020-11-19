using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        private int chancesLeft = 6;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue
        {
            get
            {
                return chancesLeft > 0;
            }
        }

        public string Guess(string guess)
        {
            string guessResult;
            bool isValid = new Regex(@"^([0-9]\s){3}[0-9]$").IsMatch(guess) && guess.Replace(" ", string.Empty).Distinct().Count() == 4;
            if (!isValid)
            {
                guessResult = "Wrong Input, input again";
            }
            else
            {
                var guessWithoutSpace = guess.Replace(" ", string.Empty);
                guessResult = Compare(this.secret, guessWithoutSpace);
                chancesLeft--;
            }

            return guessResult;
        }

        private string Compare(string secret, string guess)
        {
            var bulls = secret.Where(secretChar => guess[secret.IndexOf(secretChar)] == secretChar).ToList().Count;
            var cows = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count - bulls;
            if (bulls == 4)
            {
                chancesLeft = 0;
            }

            return $"{bulls}A{cows}B";
        }
    }
}