using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_K
{
    internal class Task_K
    {
        private static void Main(string[] args)
        {
            var values = Console.ReadLine().Split(' ');
            uint n = uint.Parse(values[0]);
            uint m = uint.Parse(values[1]);
            uint k = uint.Parse(values[2]);
            values = Console.ReadLine().Split(' ');
            uint a = uint.Parse(values[0]);
            uint b = uint.Parse(values[1]);
            uint c = uint.Parse(values[2]);
            
            var vars = new List<ulong>
            {
                // Group tickets on max and once tickets
                (c * (ulong)(k > n ? 1 : (n / k))) + (k > n ? 0 : (n - (k * (n / k))) * m * (ulong)a),
                // Group tickets on max and unlim tickets
                (c * (ulong)(k > n ? 1 : (n / k))) + (k > n ? 0 : (n - (k * (n / k))) * (ulong)b),
                // Only unlim tickets
                b * (ulong)n,
                // Only once tickets
                n * m * (ulong)a
            };
            
            Console.Write(vars.Min());
        }
    }
}