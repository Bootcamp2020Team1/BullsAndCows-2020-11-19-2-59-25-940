using BullsAndCows;
using Xunit;
using System.Linq;
using Moq;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame_with_real_generator()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_create_proper_random_secret()
        {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();
            Assert.Equal(4, secret.Length);
            Assert.Equal(4, secret.Distinct().Count());
        }
    }
}
