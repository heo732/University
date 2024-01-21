using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumArrayMembers
{
    class MinimumArrayMembers
    {
        static void Main(string[] args)
        {
            var members = new List<int>();

            foreach (var item in Console.ReadLine().Split(' '))
                members.Add(int.Parse(item));

            int needSum = members[0];
            int currentSum = 0;

            members.RemoveAt(0);
            members.RemoveAt(members.Count - 1);
            members.Sort();
            members.Reverse();

            int indexMembers = 0;
            int needQuantity = 0;

            while (currentSum <= needSum && indexMembers < members.Count)
            {
                needQuantity++;
                currentSum += members[indexMembers];
                indexMembers++;
            }

            if (currentSum <= needSum)
                needQuantity = -1;
            
            System.Console.Write(needQuantity);
        }
    }
}
