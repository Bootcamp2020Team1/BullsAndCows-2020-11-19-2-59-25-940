using System;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            Random seed = new Random();
            string secret = seed.Next(0, 10).ToString();
            int secretLength = 4;
            for (int i = 1; i < secretLength; i++)
            {
                ConstructNumber();
            }

            void ConstructNumber()
            {
                string nextNumber = seed.Next(0, 10).ToString();
                while (secret.Contains(nextNumber))
                {
                    nextNumber = seed.Next(0, 10).ToString();
                }

                secret += nextNumber;
            }

            return secret;
        }
    }
}