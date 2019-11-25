using NUnit.Framework;
using BingoGen;

namespace BingoGenTests
{
    public class BingoGenTests
    {
        private ShortenerService Shortener = new ShortenerService();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Shortener.GenerateUniqueShortPhrase();
            Assert.Pass();
        }
    }
}