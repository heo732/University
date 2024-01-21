using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedMembers
{
    class SelectedMembers
    {
        static void Main(string[] args)
        {
            var values = new List<int>();

            foreach (var value in Console.ReadLine().Split(' '))
                values.Add(int.Parse(value));

            int k = values[0];
            values.RemoveAt(0); // k at the start of sequence
            values.RemoveAt(values.Count - 1); // -1 at the end of sequence

            if (values.Count > 0)
                Console.Write(values[0].ToString() + " ");

            int index = k;
            while (index < values.Count)
            {
                Console.Write(values[index].ToString() + " ");
                index += k;
            }

            Console.Write("-1");
        }
    }
}
