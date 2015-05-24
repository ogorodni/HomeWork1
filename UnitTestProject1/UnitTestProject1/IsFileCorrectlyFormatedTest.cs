using System;
using NUnit.Framework;
using System.IO;

namespace UnitTestProject1
{
    [TestFixture]
    public class IsFileCorrectlyFormatedTest
    {
        String filePath = "D:\\new_file.txt";
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("Text with dot.")]
        [TestCase("Text with dot. The dot should be followed by space.")]
        [TestCase("If text contains comma, the space should go after it.")]
        [TestCase("Exclamation mark!")]
        [TestCase("Super! The exclamation mark is followed by a space.")]
        [TestCase("Question mark?")]
        [TestCase("Should be space after question mark? Sure.")]
        [TestCase("Semicolon;")]
        [TestCase("Semicolon; And space again.")]
        [TestCase(".\n")]
        [TestCase("Paragraph.\n\nParagraph.")]
        public void IsFileCorrectlyFormatedTestPositive(String s)
        {
            File.WriteAllText(filePath, s);
            Assert.AreEqual(IsFileCorrectlyFormated(filePath), true);
        }

        [TestCase("two spaces  ")]
        [TestCase(".oops")]
        [TestCase(",error")]
        [TestCase("!error")]
        [TestCase("?error")]
        [TestCase(";error")]
        [TestCase("Paragraph.\nParagraph.")]
        [TestCase("Paragraph.\n\n\nParagraph.")]
        [TestCase("New string after a comma,\n")]
        [TestCase("New string after an exclamation mark!\n")]
        [TestCase("New string after an question mark!\n")]
        [TestCase("New string after an semicolon;\n")]
        public void IsFileCorrectlyFormatedTestNegative(String s)
        {
            File.WriteAllText(filePath, s);
            Assert.AreEqual(IsFileCorrectlyFormated(filePath), false);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(">")]
        [TestCase(null)]
        [TestCase("C:\\aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasssssssssssssssssssssssssssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbbmmmmmmmmmmjjjjjjjjjjjjjjjjjjjjjjkkkkkkkkkkkkkkkkkkkkkkkkkkllllllll/yytyrytrytrytr/a.txt")]
        [TestCase("C:\\aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasssssssssssssssssssssssssssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbbmmmmmmmmmmjjjjjjjjjjjjjjjjjjjjjjkkkkkkkkkkkkkkkkkkkkkkkkkklllllllljhgygtyyttdrsrtdrdttrdtdrtrtyui.txt")]
        [TestCase("U:\\a.txt")]
        [TestCase("C:\\a.txt")]
        public void IsFileCorrectlyFormatedTestException(String s)
        {
            try
            {
                IsFileCorrectlyFormated(s);
            }
            catch(Exception ex)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        public bool IsFileCorrectlyFormated(String file)
        {
            String readText = File.ReadAllText(file);
            for (int i = 0; i <= readText.Length-2; i++)
            {
                if ((readText[i] == ',' 
                    || readText[i] == '!' || readText[i] == '?' || 
                    readText[i] == ';') && readText[i+1] != ' ')
                {
                    return false;
                }
                if (readText[i] == '.')
                {
                    if (!(readText[i + 1] == ' ' ||
                    (readText[i + 1] == '\n') ||
                    (readText[i + 1] == '\n' &&
                    i == readText.Length - 2)))
                    {
                        return false;
                    }
                    if (i < readText.Length-2)
                    {
                        if (readText[i + 1] == '\n' && readText[i + 2] != '\n')
                        {
                            return false;
                        }
                    }
                    if (i < readText.Length - 3)
                    {
                        if (readText[i + 1] == '\n' && readText[i + 2] == '\n' && readText[i + 3] == '\n')
                        {
                            return false;
                        }
                    }
                }
                if (readText[i] == ' ' && readText[i+1] == ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
