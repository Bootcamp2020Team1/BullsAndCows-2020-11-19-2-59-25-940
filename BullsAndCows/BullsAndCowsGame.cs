using System;

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
            if (secret == guess)
            {
                return "4A0B";
            }

            return "0A0B";
        }
    }
}