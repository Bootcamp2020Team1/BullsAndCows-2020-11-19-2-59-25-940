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
            string answer = game.Guess("5 6 7 8");

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

        [Theory]
        [InlineData("4 3 2 1")]
        [InlineData("4 3 1 2")]
        public void Should_Return_0A4B_When_All_Digit_Right_And_Position_Wrong(string guess)
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("0A4B", answer);
        }
    }

    public class TestSecretGenerator : SecretGenerator
    {
        public override string GenerateSecret()
        {
            return "1234";
        }
    }
}
