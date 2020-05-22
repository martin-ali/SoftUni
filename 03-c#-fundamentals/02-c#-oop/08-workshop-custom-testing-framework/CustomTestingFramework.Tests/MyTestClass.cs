namespace CustomTestingFramework.Tests
{
    using System;
    using CustomTestingFramework.Asserts;
    using CustomTestingFramework.Attributes;

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void ShouldSumValues()
        {
            var a = 2;
            var b = 3;

            var actualSum = a + b;
            var expectedSum = 5;

            Assert.AreEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void ShouldSumValues2()
        {
            var a = 2;
            var b = 3;

            var actualSum = a + b;
            var expectedSum = 6;

            Assert.AreNotEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void ShouldSumValues3()
        {
            var a = new string[5];

            Assert.Throws<IndexOutOfRangeException>(() => a[12] == "Lalala");
        }
    }
}