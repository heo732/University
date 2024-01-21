using System;
using System.Collections.Generic;

namespace Task5
{
    class Subsequence
    {
        static void Main()
        {
            List<int> values = new List<int>();
            foreach (var value in Console.ReadLine().Split(' '))
                values.Add( Int32.Parse(value) );

            int n = values[0];
            List<int> A = new List<int>();
            for (int i = 1; i <= n; i++)
                A.Add(values[i]);

            int m = values[n + 1];
            List<int> B = new List<int>();
            for (int i = n+2; i < n+2+m; i++)
                B.Add(values[i]);

            bool result = true;
            int index = -1;

            for (int i = 0; i < B.Count; i++)
            {
                if (A.Contains(B[i]))
                {
                    int tempIndex = -1;

                    for (int j = 0; j < A.Count; j++)
                        if (B[i] == A[j] && j > index)
                        {
                            tempIndex = j;
                            break;
                        }

                    if (tempIndex != -1)
                        index = tempIndex;
                    else
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    result = false;
                    break;
                }
            }
                        
            Console.Write( result ? "1" : "0" );
        }
    }
}