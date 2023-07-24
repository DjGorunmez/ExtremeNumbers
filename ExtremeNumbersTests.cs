using ExtremeNumbers;
using System.ComponentModel.DataAnnotations;

namespace UnitTests
{
    public class ExtremeNumbersTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test12()
        {
            decimal value = ExtremeNumbers.ExtremeNumbers.ToDecimal(new ExtremeNumbersResult("10k.000,00"));

            Assert.IsTrue(value == 10000);
        }

        [Test]
        public void Test1()
        { 
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000");

            Assert.IsTrue(result.Value == "1k.000");
        }

        [Test]
        public void Test10()
        {
           Assert.IsTrue("1000".ReadableExtremeNumber() == "1k.000");
        }

        [Test]
        public void Test11()
        {
            Assert.IsTrue("1000,00".ReadableExtremeNumber() == "1k.000,00");
        }

        [Test]
        public void Test2()
        {
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000");

            Assert.IsTrue(result.Value == "1m.000k.000");
        }


        [Test]
        public void Test3()
        {
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000000");

            Assert.IsTrue(result.Value == "1M.000m.000k.000");
        }

        [Test]
        public void Test4()
        {
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000000000");

            Assert.IsTrue(result.Value == "1T.000M.000m.000k.000");
        }

        [Test]
        public void Test5()
        {
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000000000000");

            Assert.IsTrue(result.Value == "1B.000T.000M.000m.000k.000");
        }

        [Test]
        public void Test6()
        {
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000000000000000");

            Assert.IsTrue(result.Value == "1o.000B.000T.000M.000m.000k.000");
        }

        [Test]
        public void Test7()
        {
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000000000000000000");

            Assert.IsTrue(result.Value == "1N.000o.000B.000T.000M.000m.000k.000");
        }

        [Test]
        public void Test8()
        {
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000000000000000000000");

            Assert.IsTrue(result.Value == "1E.000N.000o.000B.000T.000M.000m.000k.000");
        }

        [Test]
        public void Test9()
        {
            ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000000000000000000000000");

            Assert.IsTrue(result.Value == "1S.000E.000N.000o.000B.000T.000M.000m.000k.000");
        }
    }
}