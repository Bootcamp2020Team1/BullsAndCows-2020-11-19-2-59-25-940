using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            //var secretGenerator = new SecretGenerator();
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_0A0B_when_all_digital_and_all_positions_wrong()
        {
            //var secretGenerator = new SecretGenerator();
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            //when
            string answer = game.Guess("1 2 3 4");
            //then
            Assert.Equal("0A0B", answer);
        }

        [Theory]
        [InlineData("5 6 7 8", "5678")]
        [InlineData("1 2 3 4", "1234")]
        public void Should_return_4A0B_when_all_digital_right_and__no_positions(string guess, string secret)
        {
            //var secretGenerator = new SecretGenerator();
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            //var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("4A0B", answer);
        }

        [Fact]
        public void Should_return_0A4B_when_no_digital_right_and__all_positions_wrong()
        {
            //var secretGenerator = new SecretGenerator();
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            //when
            string answer = game.Guess("8 7 6 5");
            //then
            Assert.Equal("0A4B", answer);
        }

        [Theory]
        [InlineData("5 7 8 6", "5678")]
        public void Should_return_1A3B_when_1_digital_right_and__3_positions_wrong(string guess, string secret)
        {
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("1A3B", answer);
        }

        [Theory]
        [InlineData("6 5 4 3", "5678")]
        public void Should_return_0A2B_when_0_digital_right_and__2_positions_wrong(string guess, string secret)
        {
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("0A2B", answer);
        }

        [Theory]
        [InlineData("5 4 3 6", "5678")]
        public void Should_return_1A1B_when_1_digital_right_and__1_positions_wrong(string guess, string secret)
        {
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("1A1B", answer);
        }

        public class TestSecretGenerator : SecretGenerator
        {
            public override string GenerateSecret()
            {
                return "5678";
            }
        }
    }
}
