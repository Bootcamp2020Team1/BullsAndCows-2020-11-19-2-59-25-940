using BullsAndCows;
using System.Text.RegularExpressions;
using Xunit;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_Return_Number_With_Length_Of_Four()
        {
            //given
            var secretGenerator = new SecretGenerator();

            //when
            var secret = secretGenerator.GenerateSecret();

            //then
            Regex expected = new Regex("^[0-9]+$");
            Assert.Matches(expected, secret);
        }
    }
}
