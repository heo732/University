using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4
{
    public struct Rozpodily
    {
        static Random random = new Random();

        public static int rozpodil_1_Poisson(double lambda)
        {
            double z = random.NextDouble();
            //
            double pi = Math.Exp(-lambda);
            //

            double s = pi;
            int nu = 0;

            while (z >= s)
            {
                nu++;

                //
                pi *= lambda / (double)nu;
                //

                s += pi;
            }

            return nu;
        }

        public static int rozpodil_2_Binom(double p, double alpha)
        {
            double z = random.NextDouble();

            //
            if (p == 0)
                p = 0.1;
            double pi = Math.Exp(alpha * Math.Log(p));
            //

            double s = pi;
            int nu = 0;

            while (z >= s)
            {
                nu++;

                //
                pi *= (alpha + (double)nu - 1) * (1 - p) / (double)nu;
                //

                s += pi;
            }

            return nu;
        }

        public static int rozpodil_3_Geometry(double p)
        {
            double z = random.NextDouble();

            //
            double pi = p;
            //

            double s = pi;
            int nu = 0;

            while (z >= s)
            {
                nu++;

                //
                pi *= (1 - p);
                //

                s += pi;
            }

            return nu;
        }

        public static int rozpodil_4_Binom(int n, double p)
        {

            int nu = 0;

            for (int i = 0; i < n; i++)
            {
                double z = random.NextDouble();
                if (z <= p)
                    nu++;
            }

            return nu;
        }

        public static double rozpodil_5_Exp(double lambda)
        {
            double y = random.NextDouble();
            if (y == 0)
                y = 0.000000000001;
            return -1.0 / lambda * Math.Log(y);
        }

        public static double rozpodil_6_Pareto(double lambda, double alpha)
        {
            double z = random.NextDouble();
            if (z == 0)
                z = 0.000000000001;
            return lambda * Math.Exp(-1.0 / alpha * Math.Log(z)) - lambda;
        }

        public static double rozpodil_7_Vidrizok(double a, double b)
        {
            double z = random.NextDouble();
            return (b - a) * z + a;
        }

        public static double rozpodil_8_Normal(double a, double sigma_2)
        {
            int n = 12;
            double sum = 0;
            for (int i = 0; i < n; i++)
                sum += random.NextDouble();
            sum -= (double)n / 2.0;
            if (sigma_2 <= 0)
                sigma_2 = 100;
            return sum * Math.Sqrt(sigma_2) + a;
        }

        public static double selectiveAverage(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i];
            sum /= (double)arr.Length;
            return sum;
        }

        public static double selectiveDispersion(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i] * arr[i];
            sum /= (double)arr.Length;
            return sum - selectiveAverage(arr) * selectiveAverage(arr);
        }
    }
}