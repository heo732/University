using System;
using System.Collections.Generic;

namespace Task_H
{
    class Task_H
    {
        static void Main(string[] args)
        {
            var rating = new Dictionary<byte, uint>();
            Console.ReadLine();
            uint choosersCount = 0;
            foreach (var vote in Console.ReadLine().Split(' '))
            {
                byte candidat = byte.Parse(vote);
                if (rating.ContainsKey(candidat))
                {
                    rating[candidat]++;
                }
                else
                {
                    rating.Add(candidat, 1);
                }
                choosersCount++;
            }
            bool resBool = false;
            choosersCount /= 2;
            foreach (var item in rating.Values)
            {
                if (item > choosersCount)
                {
                    resBool = true;
                    break;
                }
            }
            Console.Write(resBool ? "YES" : "NO");
        }
    }
}