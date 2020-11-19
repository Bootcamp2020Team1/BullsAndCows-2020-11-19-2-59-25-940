using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            var secret = new StringBuilder();
            for (int index = 0; index < 4; index++)
            {
                var seed = new Random(Guid.NewGuid().GetHashCode());
                var matches = secret.ToString().Select(x => x == seed.Next(0, 9));
                secret.Append(seed.Next(0, 9));
            }

            return secret.ToString();
        }
    }
}