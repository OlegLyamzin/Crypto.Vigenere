using System;
using System.Collections.Generic;
using System.Text;

namespace Crypto
{
    public class Vigenere
    {
        private readonly char[] _alphabet = new char[] {'A', 'B','C','D', 'E',
                                               'F','G','H','I','J',
                                               'K','L','M','N','O',
                                               'P','Q','R','S','T',
                                               'U','V','W','X','Y','Z'};
        private const int _alphabetRange = 26;
        public string Encrypt(string source, string key)
        {
            if(key == "")
            {
                return source.ToUpper();
            }
            source = source.ToUpper();
            key = key.ToUpper();
            int iKey = 0;
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in source)
            {
                int indexSymb = Array.IndexOf(_alphabet, symbol);
                int difference = Array.IndexOf(_alphabet, key[iKey % key.Length]);
                sb.Append(_alphabet[(indexSymb + difference) % _alphabetRange]);
                iKey++;
            }
            return sb.ToString();
        }

        public string Dencrypt(string encrypted, string key)
        {
            if (key == "")
            {
                return encrypted.ToUpper();
            }
            encrypted = encrypted.ToUpper();
            key = key.ToUpper();
            int iKey = 0;
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in encrypted)
            {
                int indexSymb = Array.IndexOf(_alphabet, symbol);
                int difference = Array.IndexOf(_alphabet, key[iKey % key.Length]);
                sb.Append(_alphabet[Math.Abs(indexSymb + _alphabetRange - difference) % _alphabetRange]);
                iKey++;
            }
            return sb.ToString();
        }

        public IEnumerable<string> Encrypt (IEnumerable<string> source, string key)
        {
            foreach(string scr in source)
            {
                yield return Encrypt(scr, key);
            }
        }

        public IEnumerable<string> Dencrypt(IEnumerable<string> encrypted, string key)
        {
            foreach (string scr in encrypted)
            {
                yield return Dencrypt(scr, key);
            }
        }
    }
}
