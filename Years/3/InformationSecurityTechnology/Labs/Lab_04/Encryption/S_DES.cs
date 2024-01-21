using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Encryption
{
    public static class S_DES
    {
        public static string Encrypt(BitArray key, string text)
        {
            if (key.Count != 10)
            {
                throw new Exception("key.Count != 10");
            }

            byte[] textBytes = Encoding.Unicode.GetBytes(text);
            BuildSubKeys((BitArray)key.Clone(), out var subKey1, out var subKey2);

            var encryptedTextBytes = new List<byte>();
            foreach (var textByte in textBytes)
            {
                var bits = new BitArray(new byte[] { textByte });
                bits = IP(bits);
                bits = FK(bits, subKey1);
                bits = SW(bits);
                bits = FK(bits, subKey2);
                bits = IPInverse(bits);
                encryptedTextBytes.Add(BitArrayToByte(bits));
            }

            return Encoding.Unicode.GetString(encryptedTextBytes.ToArray());
        }

        public static string Decrypt(BitArray key, string text)
        {
            if (key.Count != 10)
            {
                throw new Exception("key.Count != 10");
            }

            byte[] textBytes = Encoding.Unicode.GetBytes(text);
            BuildSubKeys((BitArray)key.Clone(), out var subKey1, out var subKey2);

            var decryptedTextBytes = new List<byte>();
            foreach (var textByte in textBytes)
            {
                var bits = new BitArray(new byte[] { textByte });
                bits = IP(bits);
                bits = FK(bits, subKey2);
                bits = SW(bits);
                bits = FK(bits, subKey1);
                bits = IPInverse(bits);
                decryptedTextBytes.Add(BitArrayToByte(bits));
            }

            return Encoding.Unicode.GetString(decryptedTextBytes.ToArray());
        }

        private static byte BitArrayToByte(BitArray value8)
        {
            byte b = 0;
            if (value8[0]) b += 1;
            if (value8[1]) b += 2;
            if (value8[2]) b += 4;
            if (value8[3]) b += 8;
            if (value8[4]) b += 16;
            if (value8[5]) b += 32;
            if (value8[6]) b += 64;
            if (value8[7]) b += 128;
            return b;
        }

        private static void BuildSubKeys(BitArray key, out BitArray subKey1, out BitArray subKey2)
        {
            key = P10(key);
            key = CyclicShiftToLeftBy1(key);
            subKey1 = P8(key);
            key = CyclicShiftToLeftBy1(CyclicShiftToLeftBy1(key));
            subKey2 = P8(key);
        }

        private static BitArray P10(BitArray value10)
        {
            return new BitArray(new bool[]{
                value10[2], value10[4], value10[1], value10[6], value10[3], value10[9], value10[0], value10[8], value10[7], value10[5]
            });
        }

        private static BitArray P8(BitArray value10)
        {
            return new BitArray(new bool[]{
                value10[5], value10[2], value10[6], value10[3], value10[7], value10[4], value10[9], value10[8]
            });
        }

        private static BitArray CyclicShiftToLeftBy1(BitArray value)
        {
            var ret = new BitArray(value.Count);
            ret[0] = value[value.Count - 1];
            for (int i = 1; i < value.Count; i++)
            {
                ret[i] = value[i - 1];
            }
            return ret;
        }

        private static BitArray IP(BitArray value8)
        {
            return new BitArray(new bool[]{
                value8[1], value8[5], value8[2], value8[0], value8[3], value8[7], value8[4], value8[6]
            });
        }

        private static BitArray IPInverse(BitArray value8)
        {
            return new BitArray(new bool[]{
                value8[3], value8[0], value8[2], value8[4], value8[6], value8[1], value8[7], value8[5]
            });
        }

        private static BitArray FK(BitArray value8, BitArray subKey)
        {
            var R = new BitArray(new bool[] {
                value8[0], value8[1], value8[2], value8[3]
            });
            var L = new BitArray(new bool[] {
                value8[4], value8[5], value8[6], value8[7]
            });
            BitArray newL = L.Xor(F(R, subKey));
            return new BitArray(new bool[] {
                R[0], R[1], R[2], R[3], newL[0], newL[1], newL[2], newL[3]
            });
        }

        private static BitArray F(BitArray value4, BitArray subKey)
        {
            // Extension with replacing.
            var value8 = new BitArray(new bool[] {
                value4[3], value4[0], value4[1], value4[2], value4[1], value4[2], value4[3], value4[0]
            });
            value8 = value8.Xor(subKey);
            var matrixS0 = new byte[,] {
                { 1, 0, 3, 2 },
                { 3, 2, 1, 0 },
                { 0, 2, 1, 3 },
                { 3, 1, 3, 1 }
            };
            var matrixS1 = new byte[,] {
                { 1, 1, 2, 3 },
                { 2, 0, 1, 3 },
                { 3, 0, 1, 0 },
                { 2, 1, 0, 3 }
            };
            BitArray s0 = S(value8, matrixS0);
            BitArray s1 = S(value8, matrixS1);
            return P4(new BitArray(new bool[] {
                s0[0], s0[1], s1[0], s1[1]
            }));
        }

        private static BitArray S(BitArray value4, byte[,] matrix)
        {
            int row = -1;
            if ((value4[0] == false) && (value4[3] == false))
            {
                row = 0;
            }
            else if ((value4[0] == true) && (value4[3] == false))
            {
                row = 1;
            }
            else if ((value4[0] == false) && (value4[3] == true))
            {
                row = 2;
            }
            else if ((value4[0] == true) && (value4[3] == true))
            {
                row = 3;
            }
            int col = -1;
            if ((value4[1] == false) && (value4[2] == false))
            {
                col = 0;
            }
            else if ((value4[1] == true) && (value4[2] == false))
            {
                col = 1;
            }
            else if ((value4[1] == false) && (value4[2] == true))
            {
                col = 2;
            }
            else if ((value4[1] == true) && (value4[2] == true))
            {
                col = 3;
            }            
            switch (matrix[row, col])
            {
                case 0:
                    {
                        return new BitArray(new bool[] { false, false });
                    }
                case 1:
                    {
                        return new BitArray(new bool[] { true, false });
                    }
                case 2:
                    {
                        return new BitArray(new bool[] { false, true });
                    }
                case 3:
                    {
                        return new BitArray(new bool[] { true, true });
                    }
            }
            return null;
        }

        private static BitArray P4(BitArray value4)
        {
            return new BitArray(new bool[] {
                value4[1], value4[3], value4[2], value4[0]
            });
        }

        private static BitArray SW(BitArray value8)
        {
            return new BitArray(new bool[] {
                value8[4], value8[5], value8[6], value8[7], value8[0], value8[1], value8[2], value8[3]
            });
        }
    }
}