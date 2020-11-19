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
            return this.Compare(this.secret, guessWithoutSpace);
        }

        private string Compare(string secret, string guess)
        {
            var matches = secret.Select((value, index) => new { Index = index, Value = value })
                    .Where(x => x.Value == guess[x.Index])
                    .Select(x => x.Value);
            var sameNumber = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count;
            var sameNumberPosition = matches.ToList().Count;
            if (secret == guess)
            {
                return "4A0B";
            }

            if (sameNumber == 4 && sameNumberPosition == 0)
            {
                return "0A4B";
            }

            if (sameNumber == 4 && sameNumberPosition == 1)
            {
                return "1A3B";
            }

            if (sameNumber == 2 && sameNumberPosition == 0)
            {
                return "0A2B";
            }

            if (sameNumber == 2 && sameNumberPosition == 1)
            {
                return "1A1B";
            }

            return "0A0B";
        }
    }
}