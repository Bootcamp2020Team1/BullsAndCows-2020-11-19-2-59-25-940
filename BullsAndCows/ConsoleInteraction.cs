using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    internal class ConsoleInteraction
    {
        internal void PrintExitMessage()
        {
            Console.WriteLine("Game Over! Press any key to exit");
        }

        internal void PrintWrongInputMessage()
        {
            Console.WriteLine("Wrong Input, input again");
        }

        internal void PrintAnswer(string answer)
        {
            Console.WriteLine(answer);
        }

        internal string Read()
        {
            return Console.ReadLine();
        }
    }
}
