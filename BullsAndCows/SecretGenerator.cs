using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        private static readonly List<int> StaticDigitList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public virtual string GenerateSecret()
        {
            List<int> digitList = StaticDigitList;
            var random = new Random();
            string secret = string.Empty;
            for (var i = 0; i < 4; i++)
            {
                int index = random.Next(0, digitList.Count + 1);
                secret += digitList[index].ToString();
                digitList.RemoveAt(index);
            }

            return secret;
        }
    }
}