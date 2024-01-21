using System;
using System.Collections.Generic;

namespace Task4
{
    class SequenceOfDifferentPairs
    {
        static void Main()
        {
            var values = new List<long>();

            foreach (string value in Console.ReadLine().Split(' '))
                values.Add( Int64.Parse(value) );

            var pairs = new Dictionary<long, long>();
            var C = new List<long>();

            bool mode = false;
            for (int i = 0; i < values.Count; i++)
            {
                if (mode == false)
                { 
                    if (values[i] == -1)
                        mode = true;
                    else
                        if (values[i+1] != -1)
                            pairs.Add(values[i], values[++i]);
                }
                else
                {
                    if (values[i] != -1)
                        C.Add(values[i]);
                    else
                        break;
                }
            }

            foreach (var c in C)
            {
                if (pairs.ContainsKey(c))
                    Console.Write("{0} ", pairs[c]);
                else
                    Console.Write("0 ");
            }

            Console.Write("-1");
        }
    }
}