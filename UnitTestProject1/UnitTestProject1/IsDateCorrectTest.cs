using System;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class IsDateCorrectTest
    {
        [TestCase(12, 11, 1983)]
        [TestCase(1, 11, 1983)]
        [TestCase(31, 1, 2015)]
        [TestCase(28, 2, 2015)]
        [TestCase(29, 2, 2016)] // високосный год
        [TestCase(31, 3, 2015)]
        [TestCase(30, 4, 2015)]
        [TestCase(31, 5, 2015)]
        [TestCase(30, 6, 2015)]
        [TestCase(31, 7, 2015)]
        [TestCase(31, 8, 2015)]
        [TestCase(30, 9, 2015)]
        [TestCase(31, 10, 2015)]
        [TestCase(30, 11, 2015)]
        [TestCase(31, 12, 2015)]
        [TestCase(31, 12, 1)]
        [TestCase(15, 5, 2147483647)]
        public void IsCorrectDateTestPositive(int dd, int mm, int yyyy)
        {
            Date date = new Date(dd, mm, yyyy);
            Assert.AreEqual(true, date.isCorrect());
        }
// день
        [TestCase(0, 11, 1983)]
        [TestCase(32, 1, 2015)]
        [TestCase(29, 2, 2015)]
        [TestCase(30, 2, 2016)] // високосный год
        [TestCase(32, 3, 2015)]
        [TestCase(31, 4, 2015)]
        [TestCase(32, 5, 2015)]
        [TestCase(31, 6, 2015)]
        [TestCase(32, 7, 2015)]
        [TestCase(32, 8, 2015)]
        [TestCase(31, 9, 2015)]
        [TestCase(32, 10, 2015)]
        [TestCase(31, 11, 2015)]
        [TestCase(32, 12, 2015)]
// месяц
        [TestCase(15, 0, 1911)]
        [TestCase(15, 13, 1911)]
// год
        [TestCase(15, 5, 0)]
        public void IsCorrectDateTestNegative(int dd, int mm, int yyyy)
        {
            Date date = new Date(dd, mm, yyyy);
            Assert.AreEqual(false, date.isCorrect());
        }
    }
}
