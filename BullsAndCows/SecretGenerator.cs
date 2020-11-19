using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            var result = new StringBuilder();
            List<int> secretList = new List<int>();
            string secret = string.Empty;
            for (int index = 0; index < 4; index++)
            {
                var seed = new Random(Guid.NewGuid().GetHashCode());
                result.Append(seed.Next(0, 9));
            }

            return result.ToString();
        }
    }
}