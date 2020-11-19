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

        [Fact]
        public void Should_return_4A0B_when_all_right()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            //when
            string answer = game.Guess("1 2 3 4");
            //then
            Assert.Equal("4A0B", answer);
        }

        //[Fact]
        //public void Should_return_0A4B_when_all_digits_are_right()
        //{
        //    //given
        //    var secretGenerator = new TestSecretGenerator();
        //    var game = new BullsAndCowsGame(secretGenerator);
        //    //when
        //    string answer = game.Guess("1 2 3 4");
        //    //then
        //    Assert.Equal("4A0B", answer);
        //}

        public class TestSecretGenerator : SecretGenerator
        {
            public override string GenerateSecret()
            {
                return "1234";
            }
        }
    }
}
