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
        public void Should_terminate_game_after_6_guesses()
        {
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            for (int i = 0; i < 5; i++)
            {
                game.Guess("5 2 3 4");
            }

            Assert.True(game.CanContinue);

            game.Guess("5 2 3 4");
            Assert.False(game.CanContinue);
        }

        [Fact]
        public void Should_return_0A0B_when_all_wrong()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            //when
            string answerWithMessage = game.Guess("5 6 7 8");
            //then
            Assert.Equal("0A0B", answerWithMessage.Split(" ")[0]);
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
            string answerWithMessage = game.Guess(guess);
            //then
            Assert.Equal("4A0B", answerWithMessage.Split(" ")[0]);
            Assert.False(game.CanContinue);
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
            string answerWithMessage = game.Guess(guess);
            //then
            Assert.Equal("0A4B", answerWithMessage.Split(" ")[0]);
        }

        [Theory]
        [InlineData("1 3 2 5", "1234")]
        [InlineData("2 1 3 5", "1234")]
        [InlineData("2 3 9 4", "1234")]
        public void Should_return_1A2B_for_certain_partially_right_cases(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answerWithMessage = game.Guess(guess);
            //then
            Assert.Equal("1A2B", answerWithMessage.Split(" ")[0]);
        }

        [Theory]
        [InlineData("1 ")]
        [InlineData("1 3 5")]
        [InlineData("2 2 9 4")]
        [InlineData("2 c 9 4")]
        [InlineData("asdf")]
        [InlineData("2194")]
        public void Should_return_error_message_for_invalid_guess(string guess)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("Wrong Input, input again", answer);
        }

        public class TestSecretGenerator : SecretGenerator
        {
            public override string GenerateSecret()
            {
                return "1234";
            }
        }
    }
}
