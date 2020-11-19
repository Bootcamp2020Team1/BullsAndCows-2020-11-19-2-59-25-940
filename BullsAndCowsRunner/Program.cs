using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            BullsAndCowsGame game = new BullsAndCowsGame(secretGenerator);
            Console.WriteLine("please input 4 different digital, use space to separate each other");
            while (game.CanContinue)
            {
                var input = Console.ReadLine();
                var output = game.Guess(input);
                Console.WriteLine(output);
            }

            Console.WriteLine("Game Over");
        }
    }
}