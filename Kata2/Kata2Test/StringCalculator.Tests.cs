using Kata2;

namespace Kata2Test
{
    public class StringCalculatorSpecs
    {
        private StringCalculator stringCalculator;

        [SetUp]
        public void SetUp()
        {
            stringCalculator = new StringCalculator();
        }


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

        [Test]
        public void Add_UnknownAmountOfNumbers_ReturnsTheirSum()
        {
            var expected = 15;

            var result = stringCalculator.Add("1,2,3,4,5");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Add_WithNewLineSeparator_ReturnsSum()
        {
            var expected = 6;

            var result = stringCalculator.Add("1\n2, 3");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Add_WithCustomSeparator_ReturnsSum()
        {
            var expected = 3;

            var result = stringCalculator.Add("//;\n1;2");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Add_NegativeNumber_Throws()
        {
            var exception = Assert.Throws<Exception>(() => stringCalculator.Add("-1"));
            Assert.That(exception.Message, Is.EqualTo("Negatives not allowed: -1"));
        }


        [Test]
        public void Add_MultipleNegativeNumbers_Throws()
        {
            var exception = Assert.Throws<Exception>(() => stringCalculator.Add("-1,-2"));
            Assert.That(exception.Message, Is.EqualTo("Negatives not allowed: -1, -2"));
        }

        [Test]
        public void GetCalledCount_CalledOnce_ReturnsOne()
        {
            var expected = 1;

            stringCalculator.Add("1");
            var result = stringCalculator.GetCalledCount();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetCalledCount_CalledMultipleTimes_ReturnsCount()
        {
            var expected = 3;

            stringCalculator.Add("1");
            stringCalculator.Add("1,2");
            stringCalculator.Add("1,2,3");

            var result = stringCalculator.GetCalledCount();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}