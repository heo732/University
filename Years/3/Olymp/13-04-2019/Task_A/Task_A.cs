using System;

namespace Task_A
{
    class Task_A
    {
        static void Main(string[] args)
        {
            var values = Console.ReadLine().Split(' ');
            uint n = uint.Parse(values[0]);
            uint m = uint.Parse(values[1]);
            uint result = (uint)Math.Abs((long)n - (long)m);
            Console.Write(result);
        }
    }
}