using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class FakeGenerator : SecretGenerator
    {
        public override string GenerateSecret()
        {
            return "1234";
        }
    }

    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new FakeGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_Return_0A0B_Given_5678_With_SecretNumber_1234()
        {
            //given
            var secretGenerator = new FakeGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Guess("5 6 7 8");
            //then
            Assert.Equal("0A0B", answer);
        }

        [Theory]
        [InlineData("1 2 3 4", "1234")]
        [InlineData("5 6 7 8", "5678")]
        public void Should_Return_4A0B_Given_4CorrectNumberAnd4CorrectOrder(string guess, string secret)
        {
            //given
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(secretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("4A0B", answer);
        }

        [Theory]
        [InlineData("4 3 2 1", "1234")]
        [InlineData("8 7 6 5", "5678")]
        public void Should_Return_0A4B_Given_4CorrectNumberAnd0CorrectOrder(string guess, string secret)
        {
            //given
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(secretGenerator.Object);
            //when
            string answer = game.Guess(guess);
            //then
            Assert.Equal("0A4B", answer);
        }

        [Theory]
        [InlineData("1 2 4 3", "1234")]
        [InlineData("5 6 8 7", "5678")]
        public void Should_Return_2A2B_Given_4CorrectNumberAnd2CorrectOrder(string guess, string secret)
        {
            //given
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(secretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("2A2B", answer);
        }

        [Theory]
        [InlineData("1 3 2 5", "1234")]
        [InlineData("5 7 8 1", "5678")]
        public void Should_Return_1A2B_Given_3CorrectNumberAnd1CorrectOrder(string guess, string secret)
        {
            //given
            var secretGenerator = new Mock<SecretGenerator>();
            secretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(secretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("1A2B", answer);
        }

        [Fact]
        public void Should_Return_True_If_Format_Is_Correct()
        {
            //given
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            var actual = game.IsValidGuess("0 1 2 3");

            //then
            Assert.True(actual);
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("1    234")]
        [InlineData("12345")]
        [InlineData("ss13")]
        public void Should_Return_False_If_Guess_Is_In_Wrong_Format(string guess)
        {
            //given
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            var actual = game.IsValidGuess(guess);

            //then
            Assert.False(actual);
        }

        [Fact]
        public void Should_Not_Continue_After_Six_Guess()
        {
            //given
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            for (var i = 0; i <= 5; i++)
            {
                game.Guess("1 2 3 4");
            }

            //then
            Assert.False(game.CanContinue);
        }

        [Fact]
        public void Should_Continue_Before_Six_Guess()
        {
            //given
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            for (var i = 0; i <= 4; i++)
            {
                game.Guess("1 2 3 4");
            }

            //then
            Assert.True(game.CanContinue);
        }
    }
}
