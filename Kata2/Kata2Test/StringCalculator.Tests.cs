using Kata2;

namespace Kata2Test
{
    public class StringCalculatorSpecs
    {
        StringCalculator stringCalculator = new();


        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            var expected = 0;

            var result = stringCalculator.Add("");

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}