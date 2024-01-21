using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray
{
    class SortArray
    {
        static void Main(string[] args)
        {
            var values = new List<int>();
            foreach (var item in Console.ReadLine().Split(' '))
                values.Add(int.Parse(item));

            int len = values[0];
            values.RemoveAt(0);
            values.Sort();

            Console.Write(len.ToString());
            foreach (var item in values)
                Console.Write(" " + item.ToString());
        }
    }
}
