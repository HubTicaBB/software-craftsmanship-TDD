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

        [Test]
        public void Add_OneNumber_ReturnsItsValue()
        {
            var expected = 1;

            var result = stringCalculator.Add("1");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Add_TwoNumbers_ReturnsTheirSum()
        {
            var expected = 3;

            var result = stringCalculator.Add("1,2");

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}