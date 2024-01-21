using System;

namespace Task3
{
    class Factorial
    {
        static int factorial(int n)
        {
            if (n == 0)
                return 1;

            return n * factorial(n - 1);
        }

        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            Console.Write( factorial(n) );
        }
    }
}