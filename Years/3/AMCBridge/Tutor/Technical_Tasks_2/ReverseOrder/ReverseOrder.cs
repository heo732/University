using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseOrder
{
    class ReverseOrder
    {
        static void Main(string[] args)
        {
            var array = new List<int>();
            foreach (var item in Console.ReadLine().Split(' '))
                array.Add(int.Parse(item));

            array.RemoveAt(array.Count - 1);
            array.Reverse();

            foreach (var item in array)
                Console.Write(item.ToString() + " ");

            Console.Write(-1);
        }
    }
}
