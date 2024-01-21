using System;
using System.Collections.Generic;

namespace Task2
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    class DistanceBetweenPointAndRay3D
    {
        static void Main()
        {           
            List<double> values = new List<double>();
            foreach (var value in Console.ReadLine().Split(' '))
                values.Add( Double.Parse(value) );

            Point point = new Point(values[0], values[1], values[2]);
            Point rayInitialPoint = new Point(values[3], values[4], values[5]);
            Point rayDirectionVector = new Point(values[6], values[7], values[8]);

            double distance = ( Math.Sqrt( 
                Math.Pow( (rayInitialPoint.Y-point.Y) * rayDirectionVector.Z - (rayInitialPoint.Z - point.Z) * rayDirectionVector.Y, 2) +
                Math.Pow((rayInitialPoint.X - point.X) * rayDirectionVector.Z - (rayInitialPoint.Z - point.Z) * rayDirectionVector.X, 2) +
                Math.Pow((rayInitialPoint.X - point.X) * rayDirectionVector.Y - (rayInitialPoint.Y - point.Y) * rayDirectionVector.X, 2)
                ) ) / ( Math.Sqrt(Math.Pow(rayDirectionVector.X, 2) + Math.Pow(rayDirectionVector.Y, 2) + Math.Pow(rayDirectionVector.Z, 2)) );
                        
            if ( 
                ( (Math.Pow(rayDirectionVector.X, 2) + Math.Pow(rayDirectionVector.Y, 2) + Math.Pow(rayDirectionVector.Z, 2)) >= 0 ? 1 : -1) 
                != 
                ( (rayDirectionVector.X * (point.X - rayInitialPoint.X) + rayDirectionVector.Y * (point.Y - rayInitialPoint.Y) + rayDirectionVector.Z * (point.Z - rayInitialPoint.Z)) >= 0 ? 1 : -1) 
                )
                distance = Math.Sqrt( Math.Pow(rayInitialPoint.X - point.X, 2) + Math.Pow(rayInitialPoint.Y - point.Y, 2) + Math.Pow(rayInitialPoint.Z - point.Z, 2));

            Console.Write(distance);
        }
    }
}