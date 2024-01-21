using System;

namespace Task2
{
    class ArithmeticProgressionNth
    {
        static void Main()
        {
            int a, d, n;
            string test = Console.ReadLine();
            string[] splitString = test.Split(' ');
            int[] ints = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int x;
                int.TryParse(splitString[i], out x);
                ints[i] = x;
            }

            a = ints[0];
            d = ints[1];
            n = ints[2];

            int result = 0;
            result = a + (n - 1) * d;
            Console.Write(result);
        }
    }
}