using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            var secret = string.Empty;
            while (secret.Length < 4)
            {
                var previous = new Random().Next(0, 9);
                var random = new Random().Next(0, previous);
                secret += random;
            }

            return secret;
        }
    }
}