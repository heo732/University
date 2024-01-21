using System;

namespace Task_D
{
    class Task_D
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] answers = new string[n];
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] lines = line.Split(' ');
                int boys = int.Parse(lines[0]);
                int girls = int.Parse(lines[1]);
                int group = int.Parse(lines[2]);
                int maxInGroup = int.Parse(lines[3]);
                if (boys < group || girls < group || ((double)boys + (double)girls) / (double)group > maxInGroup)
                {
                    answers[i] = "NO";
                }
                else
                {
                    answers[i] = "YES";
                }
            }
            foreach (var ans in answers)
            {
                Console.WriteLine(ans);
            }
        }
    }
}