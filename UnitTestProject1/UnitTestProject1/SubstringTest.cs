using System;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class SubstringTest
    {
        [TestCase("ABCD", "BC")]
        [TestCase("ABCD", "AB")]
        [TestCase("ABCD", "ABCD")]
        [TestCase("ABCD", "CD")]
        public void SubstringTestPositive(String s1, String s2)
        {
            Assert.AreEqual(true, Substring(s1, s2));
        }

        [TestCase("ABCD", "cvd")]
        [TestCase("ABCD", "cvdSDFS")]
        public void SubstringTestNegative(String s1, String s2)
        {
            Assert.AreEqual(false, Substring(s1, s2));
        }

        [TestCase("", "sdf")]
        [TestCase("ABCD", "")]
        [TestCase("", "")]
        public void SubstringTestExceprion(String s1, String s2)
        {
            try
            {
                Substring(s1, s2);
            }
            catch (Exception ex)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        public bool Substring(String s1, String s2) 
        {
            Exception ex = new Exception("One of string is empty");
            if (s1.Length == 0 || s1.Length == 0) throw ex;
            for (int i = 0; i <= s1.Length-s2.Length; i++ )
            {
                int j = 0;
                while (s1[i+j] == s2[j])
                {
                    if (j+1 == s2.Length) return true;
                    j++;
                }

            }
                return false;
        }
    }
}
