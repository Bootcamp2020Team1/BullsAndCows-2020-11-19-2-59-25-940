using BullsAndCows;
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
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_Return_0A0B_Given_1234_With_SecretNumber_1234()
        {
            //given
            var secretGenerator = new FakeGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Answer("1234");
            //then
            Assert.Equal("0A0B", answer);
        }
    }
}
