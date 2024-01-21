using System;

namespace Task_L
{
    class Task_L
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] lines = line.Split();
            int n = int.Parse(lines[0]);
            int m = int.Parse(lines[1]);
            line = Console.ReadLine();
            lines = line.Split();
            int Counts = 0;
            List<int> list = new List<int>();
            List<string> per = new List<string>();
            foreach (var l in lines)
            {
                list.Add(int.Parse(l));
            }
            do
            {
                if (list.IndexOf(list.Max()) == list.Count - 1)
                {
                    list.RemoveAt(list.Count - 1);
                }
                else
                {
                    int index = -1;
                    for (int i = list.IndexOf(list.Max()); i < list.Count; i++)
                    {
                        if (list[i] < list.Max())
                        {
                            index = list.IndexOf(list[i]);
                        }
                    }
                    if (index != -1)
                        for (int i = list.IndexOf(list.Max()); i < index; i++)
                        {
                            int temp = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = temp;
                            per.Add((i + 2) + " " + (i + 1));
                            Counts++;
                        }
                }
            }
            while (list.Count != 0 && Counts != m);
            Console.WriteLine(Counts);
            per.Reverse();
            foreach (var p in per)
            {
                Console.WriteLine(p);
            }
        }
    }
}