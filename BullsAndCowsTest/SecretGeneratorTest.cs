using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_Return_String_With_Length_Of_Four()
        {
            //given
            var secretGenerator = new SecretGenerator();

            //when
            var secret = secretGenerator.GenerateSecret();

            //then
            Assert.Equal(4, secret.Length);
        }
    }
}
