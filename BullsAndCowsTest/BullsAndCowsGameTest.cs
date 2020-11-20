using System.Runtime.InteropServices;
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
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_Return_0A0B_When_All_Digit_And_Position_Wrong()
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess("5 6 7 8");

            //then
            Assert.Equal("0A0B", answer);
        }

        [Theory]
        [InlineData("1 2 3 4", "1234")]
        [InlineData("5 6 7 8", "5678")]
        public void Should_Return_Win_Message_When_All_Digit_And_Position_Right(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("Good job, you win", answer);
        }

        [Theory]
        [InlineData("0 1 2 5", "1234")]
        [InlineData("4 8 3 6", "5678")]
        public void Should_Return_0A2B_When_2_Digit_Right_And_2_Position_Wrong(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("0A2B", answer);
        }

        [Theory]
        [InlineData("4 3 2 1", "1234")]
        [InlineData("4 3 1 2", "1234")]
        public void Should_Return_0A4B_When_All_Digit_Right_And_Position_Wrong(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("0A4B", answer);
        }

        [Theory]
        [InlineData("1 6 2 3", "1234")]
        [InlineData("1 6 4 2", "1234")]
        public void Should_Return_1A2B_When_1_Digit_Right_And_2_Position_Wrong(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("1A2B", answer);
        }

        [Theory]
        [InlineData("1 4 2 3", "1234")]
        [InlineData("1 3 4 2", "1234")]
        public void Should_Return_1A3B_When_1_Digit_Right_And_2_Position_Wrong(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("1A3B", answer);
        }

        [Theory]
        [InlineData("1 4 23", "1234")]
        [InlineData("1 3 4 4", "1234")]
        public void Should_Return_Error_Message_When_Invalid_Input(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("Wrong Input, input again", answer);
        }
    }
}
