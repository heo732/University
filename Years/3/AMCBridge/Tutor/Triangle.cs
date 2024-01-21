using System;
using System.Collections.Generic;

namespace Triangle
{
    public class Triangle
    {
        public static void Main(string[] args)
        {
            var values = new List<double>();
            foreach (var value in Console.ReadLine().Split(' '))
                values.Add(double.Parse(value));

            double a = values[0];
            double b = values[1];
            double c = values[2];

            double perimeter = a + b + c;
            double p = perimeter / 2.0;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            double radiusOfTheInscribedCircle = area / p;

            Console.Write(perimeter.ToString() + " " + area.ToString() + " " + radiusOfTheInscribedCircle.ToString());
        }
    }
}
