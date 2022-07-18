namespace PallindromeTests
{
    public class Tests
    {
        [TestCase("word")]
        public void GivenANonPallindrome(string word)
        {
            Assert.That(Program.IsPallindrome(word), Is.False);
        }

        [TestCase("pop")]
        public void GivenAPallindrome(string word)
        {
            Assert.That(Program.IsPallindrome(word), Is.True);
        }

        [TestCase("u")]
        public void GivenASingleCharacter(string word)
        {
            Assert.That(Program.IsPallindrome(word), Is.True);
        }

        [TestCase("3")]
        public void GivenASingleNumber(string word)
        {
            Assert.That(Program.IsPallindrome(word), Is.True);
        }

        [TestCase("767")]
        public void GivenANumberPallindrome(string word)
        {
            Assert.That(Program.IsPallindrome(word), Is.True);
        }

        



    }
}