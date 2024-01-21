using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public static class DiffieHellmanKeyExchange
    {
        public static void ExchangeKey(StringBuilder A, StringBuilder B)
        {
            var random = new Random();
            List<int> primeNumbers = GetPrimeNumbers(20, 2);
            int p = primeNumbers[random.Next(primeNumbers.Count)];
            List<int> aValues = (from t in Range(1000000, 2)
                                 where (t % p != 0) && (((int)Math.Pow(t, p - 1) - 1) % p == 0)
                                 select t).ToList();
            int a = aValues[random.Next(aValues.Count)];
            int x = random.Next(10000, int.MaxValue - 1);
            int X = (int)Math.Pow(a, x) % p;
            int y = random.Next(10000, int.MaxValue - 1);
            int Y = (int)Math.Pow(a, y) % p;
            int k1 = (int)Math.Pow(Y, x) % p;
            int k2 = (int)Math.Pow(X, y) % p;

            A.AppendLine(string.Format("p:   {0}", p));
            A.AppendLine(string.Format("a:   {0}", a));
            A.AppendLine(string.Format("x:   {0}", x));
            A.AppendLine(string.Format("Y:   {0}", Y));
            A.AppendLine(string.Format("k:   {0}", k1));
            A.AppendLine(string.Format("a^xy mod p:   {0}", (int)Math.Pow(a, x * y) % p));

            B.AppendLine(string.Format("p:   {0}", p));
            B.AppendLine(string.Format("a:   {0}", a));
            B.AppendLine(string.Format("y:   {0}", y));
            B.AppendLine(string.Format("X:   {0}", X));
            B.AppendLine(string.Format("k':   {0}", k2));
            B.AppendLine(string.Format("a^xy mod p:   {0}", (int)Math.Pow(a, x * y) % p));
        }

        public static int EulerFunction(int n)
        {
            int ret = 1;
            for (int i = 2; i * i <= n; ++i)
            {
                int p = 1;
                while (n % i == 0)
                {
                    p *= i;
                    n /= i;
                }
                if ((p /= i) >= 1) ret *= p * (i - 1);
            }
            return --n != 0 ? n * ret : ret;
        }

        public static List<int> GetPrimeNumbers(int maxValue, int minValue = 2)
        {
            if (minValue > maxValue)
            {
                throw new ArithmeticException("maxValue should be more or equal to minValue!");
            }
            var primeNumbers = new List<int>();
            List<int> a = Range(maxValue + 1);
            a[1] = 0;
            int i = 2;
            while (i <= maxValue)
            {
                if (a[i] != 0)
                {
                    primeNumbers.Add(a[i]);
                    foreach (int j in Range(maxValue + 1, i, i))
                    {
                        a[j] = 0;
                    }
                }
                i += 1;
            }
            return (from t in primeNumbers
                   where t >= minValue
                   select t).ToList();
        }

        public static List<int> Range(int stop, int start = 0, int step = 1)
        {
            if (step == 0)
            {
                throw new ArgumentException("step must be nonzero!");
            }
            if (start == stop)
            {
                throw new ArgumentException("stop must be different from start!");
            }
            if ((stop > start) && (step < 0))
            {
                throw new ArithmeticException("Infinity");
            }
            if ((stop < start) && (step > 0))
            {
                throw new ArithmeticException("Infinity");
            }
            var range = new List<int>();
            if (stop > start)
            {
                for (int i = start; i < stop; i += step)
                {
                    range.Add(i);
                }
            }
            else
            {
                for (int i = start; i > stop; i += step)
                {
                    range.Add(i);
                }
            }
            return range;
        }
    }
}