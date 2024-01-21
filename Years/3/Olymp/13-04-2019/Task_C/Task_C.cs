using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_C
{
    class Task_C
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            string[] lines = line.Split();
            List<int> tables = new List<int>();
            int CountOfMin = 0;
            foreach (var l in lines)
            {
                tables.Add(int.Parse(l));
            }
            do
            {
                int max = tables.Max();
                int min = tables.Min();
                tables.RemoveAll(p => p == min);
                for (int i = 0; i < tables.Count; i++)
                {
                    if (tables[i] == max)
                    {
                        tables[i] -= min;
                    }
                }
                CountOfMin++;
            }
            while (tables.Count != 0);
            Console.Write(CountOfMin);
        }
    }
}