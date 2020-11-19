using BullsAndCows;
using Xunit;
using Moq;

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
        public void Should_return_0A0B_when_all_wrong()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            //when
            string answer = game.Guess("5 6 7 8");
            //then
            Assert.Equal("0A0B", answer);
        }

        [Theory]
        [InlineData("4 3 2 1", "4321")]
        [InlineData("4 3 1 2", "4312")]
        public void Should_return_4A0B_when_all_right(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("4A0B", answer);
        }

        [Theory]
        [InlineData("4 3 2 1", "1234")]
        [InlineData("4 3 1 2", "1234")]
        [InlineData("2 3 4 1", "1234")]
        public void Should_return_0A4B_when_all_digits_are_right(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("0A4B", answer);
        }

        //public class TestSecretGenerator : SecretGenerator
        //{
        //    public override string GenerateSecret()
        //    {
        //        return "1234";
        //    }
        //}
    }
}
