using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotate2DPoint
{
    class Rotate2DPoint
    {
        static void Main(string[] args)
        {
            var values = new List<double>();
            foreach (var item in Console.ReadLine().Split(' '))
                values.Add(double.Parse(item));

            double x = values[0];
            double y = values[1];
            double angle = values[2];
            double x0 = values[3];
            double y0 = values[4];

            double newX = x0 + (x - x0) * Math.Cos(angle) - (y - y0) * Math.Sin(angle);
            double newY = y0 + (y - y0) * Math.Cos(angle) + (x - x0) * Math.Sin(angle);

            Console.Write(newX.ToString() + " " + newY.ToString());
        }
    }
}
