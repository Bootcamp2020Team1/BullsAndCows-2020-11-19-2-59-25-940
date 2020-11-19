using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_Return_0A0B_When_All_Digit_And_Position_Wrong()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Guess("5678");

            //then
            Assert.Equal("0A0B", answer);
        }

        [Fact]
        public void Should_Return_4A0B_When_All_Digit_And_Position_Right()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Guess("1 2 3 4");

            //then
            Assert.Equal("4A0B", answer);
        }

        [Fact]
        public void Should_Return_0A4B_When_All_Digit_Right_And_Position_Wrong()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Guess("1 2 3 4");

            //then
            Assert.Equal("4A0B", answer);
        }
    }

    public class TestSecretGenerator : SecretGenerator
    {
        public override string GenerateSecret()
        {
            return "1 2 3 4";
        }
    }
}
