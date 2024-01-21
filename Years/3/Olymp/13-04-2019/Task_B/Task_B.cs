using System;
using System.Collections.Generic;

namespace Task_B
{
    class Task_B
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string num = Console.ReadLine();
            string[] numbers = num.Split(' ');
            List<int> pos = new List<int>();
            foreach (var numb in numbers)
            {
                pos.Add(int.Parse(numb));
            }
            List<int> simPos = new List<int>();
            for (int i = 0; i < pos.Count - 1; i++)
            {
                if (pos[i] == pos[i + 1])
                {
                    simPos.Add(i);
                }
            }
            if (simPos.Count == 0)
                Console.WriteLine(0);
            else
            {
                if (simPos.Count == 1)
                {
                    Console.WriteLine(1);
                    if (simPos[0] < 1)
                    {
                        Console.WriteLine("{0} {1}", simPos[0] + 1, simPos[0] + 4);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1}", simPos[0], simPos[0] + 1);
                    }
                }
                else
                {
                    if (simPos.Count % 2 == 0)
                    {
                        Console.WriteLine(simPos.Count / 2);
                        for (int i = 0; i < simPos.Count - 1; i += 2)
                        {
                            Console.WriteLine("{0} {1}", simPos[i] + 1, simPos[i + 1] + 2);
                        }
                    }
                    else
                    {
                        Console.WriteLine(simPos.Count / 2 + 1);
                        for (int i = 0; i < simPos.Count - 1; i += 2)
                        {
                            Console.WriteLine("{0} {1}", simPos[i] + 1, simPos[i + 1] + 2);
                        }
                        Console.WriteLine("{0} {1}", simPos[simPos.Count - 1] + 1, simPos[0] + 1);
                    }
                }
            }
        }
    }
}