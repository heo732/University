using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Encryption
{
    public class CaesarAffinitySystem
    {
        /// <summary>
        /// Key - real letter number,
        /// Value - encrypt letter number
        /// </summary>
        public Dictionary<uint, uint> CodeDictionaryByReal { get; private set; }

        /// <summary>
        /// Key - encrypt letter number,
        /// Value - real letter number
        /// </summary>
        public Dictionary<uint, uint> CodeDictionaryByEncrypt { get; private set; }

        public Dictionary<char, uint> AlphabetByLetter { get; private set; }

        public Dictionary<uint, char> AlphabetByNumber { get; private set; }

        public CaesarAffinitySystem()
        {
            CodeDictionaryByReal = new Dictionary<uint, uint>();
            CodeDictionaryByEncrypt = new Dictionary<uint, uint>();
            AlphabetByLetter = new Dictionary<char, uint>();
            AlphabetByNumber = new Dictionary<uint, char>();
        }

        public void BuildAlphabetFromFile(string filePath)
        {
            AlphabetByLetter = new Dictionary<char, uint>();
            AlphabetByNumber = new Dictionary<uint, char>();
            using (var reader = new StreamReader(filePath))
            {
                foreach (var letter in reader.ReadToEnd().ToArray())
                {
                    if (!AlphabetByLetter.ContainsKey(letter))
                    {
                        AlphabetByLetter.Add(letter, (uint)AlphabetByLetter.Count);
                        AlphabetByNumber.Add((uint)AlphabetByNumber.Count, letter);
                    }
                }
            }
        }

        public void BuildAlphabet(List<char> letters)
        {
            AlphabetByLetter = new Dictionary<char, uint>();
            AlphabetByNumber = new Dictionary<uint, char>();
            foreach (var letter in letters)
            {
                if (!AlphabetByLetter.ContainsKey(letter))
                {
                    AlphabetByLetter.Add(letter, (uint)AlphabetByLetter.Count);
                    AlphabetByNumber.Add((uint)AlphabetByNumber.Count, letter);
                }
            }
        }

        public List<char> GetAlphabet()
        {
            return AlphabetByLetter.Keys.ToList();
        }

        public void SaveAlphabetToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var letter in AlphabetByLetter.Keys.ToList())
                {
                    writer.Write(letter);
                }
            }
        }

        /// <summary>Greatest common divisor.</summary>
        private uint GCD(uint a, uint b)
        {
            if (a == 0 || b == 0)
            {
                return Math.Max(a, b);
            }
            uint greatestDivisor = 0;
            for (uint i = 1; i <= Math.Min(a, b); i++)
            {
                if ((a % i == 0) && (b % i == 0))
                    greatestDivisor = i;
            }
            return greatestDivisor;
        }

        public void BuildCodeDictionary(uint keyA, uint keyB)
        {
            if (AlphabetByLetter == null || AlphabetByLetter.Count == 0)
            {
                throw new Exception("Alphabet need for building code dictionary.");
            }
            else if (GCD(keyA, (uint)AlphabetByLetter.Count) != 1)
            {
                throw new Exception("GCD(keyA, Alphabet.Length) should be equal to 1");
            }
            else if (!(
                (0 < keyA) && (keyA < AlphabetByLetter.Count) &&
                (0 < keyB) && (keyB < AlphabetByLetter.Count)))
            {
                throw new Exception("0 < keyA, keyB < Alphabet.Length");
            }
            else
            {
                CodeDictionaryByReal = new Dictionary<uint, uint>();
                CodeDictionaryByEncrypt = new Dictionary<uint, uint>();
                foreach (var number in AlphabetByLetter.Values.ToList())
                {
                    uint encryptNumber = (keyA * number + keyB) % (uint)AlphabetByLetter.Count;
                    CodeDictionaryByReal.Add(number, encryptNumber);
                    CodeDictionaryByEncrypt.Add(encryptNumber, number);
                }
            }
        }

        public string Encrypt(string input)
        {
            var ret = new StringBuilder();
            foreach (var item in input)
            {
                if (AlphabetByLetter.ContainsKey(item))
                    ret.Append(AlphabetByNumber[CodeDictionaryByReal[AlphabetByLetter[item]]]);
                else
                    ret.Append(item);
            }
            return ret.ToString();
        }

        public char Encrypt(char input)
        {
            if (AlphabetByLetter.ContainsKey(input))
                return AlphabetByNumber[CodeDictionaryByReal[AlphabetByLetter[input]]];
            else
                return input;
        }

        public string Decrypt(string input)
        {
            var ret = new StringBuilder();
            foreach (var item in input)
            {
                if (AlphabetByLetter.ContainsKey(item))
                    ret.Append(AlphabetByNumber[CodeDictionaryByEncrypt[AlphabetByLetter[item]]]);
                else
                    ret.Append(item);
            }
            return ret.ToString();
        }

        public char Decrypt(char input)
        {
            if (AlphabetByLetter.ContainsKey(input))
                return AlphabetByNumber[CodeDictionaryByEncrypt[AlphabetByLetter[input]]];
            else
                return input;
        }
    }
}