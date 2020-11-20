using System;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            Random ran = new Random();
            string secret = ran.Next(0, 10).ToString();
            ConstructNumber();
            ConstructNumber();
            ConstructNumber();

            void ConstructNumber()
            {
                string nextNumber = ran.Next(0, 10).ToString();
                while (secret.Contains(nextNumber))
                {
                    nextNumber = ran.Next(0, 10).ToString();
                }

                secret += nextNumber;
            }

            return secret;
        }
    }
}