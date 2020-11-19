using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret = string.Empty;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            for (int i = 0; i < 4; i++)
            {
                if (guessWithoutSpace.Where(guessChar => guessChar == guessWithoutSpace[i]).ToList().Count > 1)
                {
                    return "Wrong Input, input again";
                }
            }

            return this.Compare(this.secret, guessWithoutSpace);
        }

        private string Compare(string secret, string guess)
        {
            int x = secret.Where(secretChar => (guess.IndexOf(secretChar) == secret.IndexOf(secretChar))).ToList().Count;
            int y = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count - x;
            return $"{x}A{y}B";
        }
    }
}