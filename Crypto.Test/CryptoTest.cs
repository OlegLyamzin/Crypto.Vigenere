using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace Crypto.Test
{
    public class Tests
    {

        [TestCase("ATTACKATDAWN", "LEMON", "LXFOPVEFRNHR")]
        [TestCase("YOUARESOBEAUTIFUL", "PASSWORD", "NOMSNSJRQESMPWWXA")]
        [TestCase("HELLO", "WORLD", "DSCWR")]
        [TestCase("HELLO", "", "HELLO")]
        public void Encrypt(string source, string key, string expected)
        {
            var crypto = new Vigenere();
            string actual = crypto.Encrypt(source, key);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("LXFOPVEFRNHR", "LEMON", "ATTACKATDAWN")]
        [TestCase("NOMSNSJRQESMPWWXA", "PASSWORD", "YOUARESOBEAUTIFUL")]
        [TestCase("DSCWR", "WORLD", "HELLO")]
        [TestCase("HELLO", "", "HELLO")]
        public void Decrypt(string source, string key, string expected)
        {
            var crypto = new Vigenere();
            string actual = crypto.Dencrypt(source, key);

            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(typeof(EncryptMocks))]
        public void EncryptEnumerable(string[] sources, string key, string[] expected)
        {
            var crypto = new Vigenere();
            string[] actual = crypto.Encrypt(sources, key).ToArray();

            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(typeof(DencryptMocks))]
        public void DencryptEnumerable(string[] sources, string key, string[] expected)
        {
            var crypto = new Vigenere();
            string[] actual = crypto.Dencrypt(sources, key).ToArray();

            Assert.AreEqual(expected, actual);
        }

        public class EncryptMocks : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { 
                    new string[] { "ATTACKATDAWN", "YOUARESOBEAUTIFUL" },
                    "PASSWORD",
                    new string[] { "PTLSYYRWSAOF", "NOMSNSJRQESMPWWXA" } };
                yield return new object[] {
                    new string[] { "HELLO", "OLEG" }, 
                    "lemon", 
                    new string[] { "SIXZB", "ZPQU" } };
            }
        }

        public class DencryptMocks : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {
                    new string[] { "PTLSYYRWSAOF", "NOMSNSJRQESMPWWXA" }, 
                    "PASSWORD", 
                    new string[] { "ATTACKATDAWN", "YOUARESOBEAUTIFUL" } };
                yield return new object[] { 
                    new string[] { "SIXZB", "ZPQU" }, 
                    "LEMON", 
                    new string[] { "HELLO", "OLEG" } };
            }
        }
    }
}