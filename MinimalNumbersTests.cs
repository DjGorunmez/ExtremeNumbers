using ExtremeNumbers;

namespace UnitTests
{
    public class MinimalNumbersTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test12()
        {
            decimal value = ExtremeNumbers.ExtremeNumbers.ToDecimal(new ExtremeNumbersResult("0,100k.000m"));
            decimal compare = Convert.ToDecimal("0,100000");

            Assert.IsTrue(value == compare);
        }

        [Test]
        public void Test1()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100");
            
            Assert.IsTrue(result.Value == "0,100k");
        }

        [Test]
        public void Test2()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100000");

            Assert.IsTrue(result.Value == "0,100k.000m");
        }

        [Test]
        public void Test10()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("123,100000");

            Assert.IsTrue(result.Value == "123,100k.000m");
        }

        [Test]
        public void Test3()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100000000");

            Assert.IsTrue(result.Value == "0,100k.000m.000M");
        }

        [Test]
        public void Test4()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100000000000");

            Assert.IsTrue(result.Value == "0,100k.000m.000M.000T");
        }

        [Test]
        public void Test5()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100000000000000");

            Assert.IsTrue(result.Value == "0,100k.000m.000M.000T.000B");
        }

        [Test]
        public void Test6()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100000000000000000");

            Assert.IsTrue(result.Value == "0,100k.000m.000M.000T.000B.000o");
        }

        [Test]
        public void Test7()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100000000000000000000");

            Assert.IsTrue(result.Value == "0,100k.000m.000M.000T.000B.000o.000N");
        }

        [Test]
        public void Test8()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100000000000000000000000");

            Assert.IsTrue(result.Value == "0,100k.000m.000M.000T.000B.000o.000N.000E");
        }

        [Test]
        public void Test9()
        {
            MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("0,100000000000000000000000000");

            Assert.IsTrue(result.Value == "0,100k.000m.000M.000T.000B.000o.000N.000E.000S");
        }
    }
}