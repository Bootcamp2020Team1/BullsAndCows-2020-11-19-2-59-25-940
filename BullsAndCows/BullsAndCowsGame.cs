using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return Compare(this.secret, guessWithoutSpace);
        }

        private string Compare(string secret, string guess)
        {
            var bulls = secret.Where(secretChar => guess[secret.IndexOf(secretChar)] == secretChar).ToList().Count;
            var cows = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count - bulls;

            return $"{bulls}A{cows}B";
        }
    }
}