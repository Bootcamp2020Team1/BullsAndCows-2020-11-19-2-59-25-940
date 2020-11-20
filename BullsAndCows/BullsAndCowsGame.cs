using System;
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
            CanContinue = true;
            PlayCount = 0;
        }

        public bool CanContinue { get; set; }
        private string ErrorMessage => "Wrong Input, input again";
        private int PlayCount { get; set; }

        public string Guess(string guess)
        {
            if (guess.Equals("show me the answer"))
            {
                Console.WriteLine(secret);
            }

            if (!IsValidInput(guess))
            {
                return ErrorMessage;
            }

            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return Compare(secret, guessWithoutSpace);
        }

        private string Compare(string secret, string guess)
        {
            int x = secret.Where(secretChar => (guess.IndexOf(secretChar) == secret.IndexOf(secretChar))).ToList().Count;
            int y = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count - x;
            if (x == 4)
            {
                CanContinue = false;
                return "Good job, you win";
            }

            PlayCount++;

            if (PlayCount == 6)
            {
                CanContinue = false;
            }

            return $"{x}A{y}B";
        }

        private bool IsValidInput(string input)
        {
            if (input.Length != 7)
            {
                return false;
            }

            char space = ' ';
            if (input.ToCharArray()[1] != space || input.ToCharArray()[3] != space || input.ToCharArray()[5] != space)
            {
                return false;
            }

            var inputWithoutSpace = input.Replace(" ", string.Empty);
            for (int i = 0; i < 4; i++)
            {
                if (inputWithoutSpace.Where(guessChar => guessChar == inputWithoutSpace[i]).ToList().Count > 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}