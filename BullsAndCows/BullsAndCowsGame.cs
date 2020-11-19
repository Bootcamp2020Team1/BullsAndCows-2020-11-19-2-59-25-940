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
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Answer(string guess)
        {
            return this.Compare(this.secret, guess);
        }

        public string Compare(string secret, string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            if (secret == guessWithoutSpace)
            {
                return "4A0B";
            }

            if (secret.Where(secret => guessWithoutSpace.Contains(secret)).Count() == 4)
            {
                return "0A4B";
            }

            return "0A0B";
        }
    }
}