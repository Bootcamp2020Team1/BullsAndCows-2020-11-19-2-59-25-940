using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    public class GameRunner
    {
        public void Run()
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var console = new ConsoleInteraction();
            var correctAnswer = "4A0B";

            while (game.CanContinue)
            {
                var guess = console.Read();
                if (!game.IsValidGuess(guess))
                {
                    console.PrintWrongInputMessage();
                    continue;
                }

                var answer = game.Guess(guess);
                console.PrintAnswer(answer);

                if (answer == correctAnswer)
                {
                    break;
                }
            }

            console.PrintExitMessage();
            console.Read();
        }
    }
}