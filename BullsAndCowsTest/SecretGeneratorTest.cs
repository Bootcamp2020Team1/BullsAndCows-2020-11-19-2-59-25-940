using BullsAndCows;
using System.Linq;
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
            Regex expected = new Regex("^[0-9]{4}$");
            Assert.Matches(expected, secret);
        }

        [Fact]
        public void Should_Return_Unique_Number()
        {
            //given
            var secretGenerator = new SecretGenerator();

            //when
            var secret = secretGenerator.GenerateSecret();

            //then
            Assert.Equal(4, secret.Distinct().Count());
        }
    }
}
