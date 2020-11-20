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
                chancesLeft--;
                var guessWithoutSpace = guess.Replace(" ", string.Empty);
                guessResult = Compare(this.secret, guessWithoutSpace);
            }

            return guessResult;
        }

        private string Compare(string secret, string guess)
        {
            string answer = string.Empty;
            var bulls = secret.Where(secretChar => guess[secret.IndexOf(secretChar)] == secretChar).ToList().Count;
            var cows = secret.Where(secretChar => guess.Contains(secretChar)).ToList().Count - bulls;
            answer = $"{bulls}A{cows}B";
            if (bulls == 4)
            {
                chancesLeft = 0;
                answer += " Congrats, You Win!";
            }
            else
            {
                if (chancesLeft == 0)
                {
                    answer += $" You lost. Secret is {secret}";
                }
                else
                {
                    answer += $" {chancesLeft} chances left!";
                }
            }

            return answer;
        }
    }
}