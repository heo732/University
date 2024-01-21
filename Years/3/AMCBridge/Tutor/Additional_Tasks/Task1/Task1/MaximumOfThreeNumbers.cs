using System;
using System.Collections.Generic;

namespace Task1
{
    class MaximumOfThreeNumbers
    {
        static void Main()
        {
            List<int> values = new List<int>();
            foreach (var value in Console.ReadLine().Split(' '))
                values.Add( Int32.Parse(value) );

            Console.Write( Math.Max( values[0], Math.Max(values[1], values[2]) ) );
        }
    }
}