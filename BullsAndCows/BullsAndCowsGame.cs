using System;
using System.Collections.Generic;
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

        public string Guess(string guess)
        {
            return this.Compare(this.secret, guess);
        }

        public string Compare(string secret, string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            var xList = secret.Where((secret, index) => guessWithoutSpace[index] == secret).ToList();
            var yList = secret.Where(secret => guessWithoutSpace.Contains(secret)).ToList();
            var xOverlapY = xList.Where(x => yList.Contains(x)).Count();

            return $"{xList.Count()}A{yList.Count() - xOverlapY}B";
        }
    }
}