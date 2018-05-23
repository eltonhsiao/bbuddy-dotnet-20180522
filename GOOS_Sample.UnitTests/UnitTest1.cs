using System;
using System.Globalization;
using NUnit.Framework;

namespace GOOS_Sample.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        public DateTime now;

        [SetUp]
        public void SetUp()
        {
            now = DateTime.MaxValue;
        }

        [Test]
        public void Format_Now_Time()
        {
            var actual = getNowString(now);
            var expected = "9999/12/31 11:59:59.999";

            Assert.AreEqual(expected, actual);
        }

        private string getNowString(DateTime date)
        {
            return date.ToString("yyyy/MM/dd hh:mm:ss.fff");
        }
    }
}