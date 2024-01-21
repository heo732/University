using System;
using System.Text;

namespace TeoriyaInformatsiyiTaKoduvannyaLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int N = 3;
            var P = new double[N, N];

            var pA = new double[N];
            var pB = new double[N];

            double HA = 0;
            double HB = 0;

            P[0, 0] = 0.17;
            P[0, 1] = 0.2;
            P[0, 2] = 0.0;
            
            P[1, 0] = 0.2;
            P[1, 1] = 0.0;
            P[1, 2] = 0.0;

            P[2, 0] = 0.03;
            P[2, 1] = 0.15;
            P[2, 2] = 0.25;

            Console.WriteLine("Матриця сумісних ймовірностей \n");

            for (int ai = 0; ai < N; ai++, Console.WriteLine())
                for (int bj = 0; bj < N; bj++)
                {
                    pA[ai] += P[ai, bj];
                    pB[bj] += P[ai, bj];
                    Console.Write("\t" + P[ai, bj]);
                }

            Console.WriteLine("\n Розподіл ймовірностей джерела А (P[ai]):\n");

            for (int ai = 0; ai < N; ai++)
            {
                HA += pA[ai] * Math.Log(pA[ai], 2);
                Console.Write("\n" + pA[ai]);
            }

            HA = -HA;
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("\n Безумовна ентропія H(A) = " + HA);


            Console.WriteLine("\n Розподіл ймовірностей джерела В (P[ai]):\n");

            for (int bj = 0; bj < N; bj++)
            {
                HB += pB[bj] * Math.Log(pB[bj], 2);
                Console.Write("\n" + pB[bj]);
            }

            HB = -HB;


            Console.WriteLine();
            Console.WriteLine(" Безумовна ентропія H(B) = " + HB);

            Console.WriteLine();

            double[,] Paibj = new double[N, N];
            double[,] Pbjai = new double[N, N];

            for (int ai = 0; ai < N; ai++)
                for (int bj = 0; bj < N; bj++)
                {
                    Paibj[ai, bj] = P[ai, bj] / pB[bj];
                    Pbjai[ai, bj] = P[ai, bj] / pA[ai];
                }
            
            Console.WriteLine("\n Матриця умовних ймовірностей джерела А - p(ai/bj):\n");

            for (int ai = 0; ai < N; ai++, Console.WriteLine())
                for (int bj = 0; bj < N; bj++)
                {
                    Console.Write(Paibj[ai, bj].ToString().Length < 5 ? "\t" + Paibj[ai, bj] : "\t" + Paibj[ai, bj].ToString().Substring(0, 5));
                }

            Console.WriteLine("\n\n Матриця умовних ймовірностей джерела В - p(bj/ai):\n");

            for (int ai = 0; ai < N; ai++, Console.WriteLine())
                for (int bj = 0; bj < N; bj++)
                {
                    Console.Write(Pbjai[ai, bj].ToString().Length < 5 ? "\t" + Pbjai[ai, bj] : "\t" + Pbjai[ai, bj].ToString().Substring(0, 5));
                }

            double[] HAbj = new double[N];
            double[] HBai = new double[N];


            for (int ai = 0; ai < N; ai++)
            {
                HAbj[ai] = 0;
                HBai[ai] = 0;
            }

            for (int ai = 0; ai < N; ai++)
                for (int bj = 0; bj < N; bj++)
                {
                    if (Paibj[ai, bj] > 0)
                        HAbj[bj] += -(Paibj[ai, bj] * Math.Log(Paibj[ai, bj], 2));

                    if (Pbjai[ai, bj] > 0)
                        HBai[ai] += -(Pbjai[ai, bj] * Math.Log(Pbjai[ai, bj], 2));
                    
                }

            Console.WriteLine("\n Часткова умовна ентропія джерела А - H(A/bj):\n");

            for (int ai = 0; ai < N; ai++)
                {
                    Console.Write(HAbj[ai].ToString().Length < 5 ? "\t" + HAbj[ai] : "\t" + HAbj[ai].ToString().Substring(0, 5));
                }

            Console.WriteLine("\n\n Часткова умовна ентропія джерела В - H(B/ai):\n");

            for (int ai = 0; ai < N; ai++)
            {
                Console.Write(HBai[ai].ToString().Length < 5 ? "\t" + HBai[ai] : "\t" + HBai[ai].ToString().Substring(0, 5));
            }

            double HAB = 0, HBA = 0;

            for (int bj = 0; bj < N; bj++)
            {
                HAB += pB[bj] * HAbj[bj];
                HBA += pA[bj] * HBai[bj];
            }

            Console.WriteLine("\n\n Загальна умовна ентропія - H(A/B) = " + HAB.ToString().Substring(0, 5));
            Console.WriteLine("\n Загальна умовна ентропія - H(B/A) = " + HBA.ToString().Substring(0, 5));

            double Hab = 0;
            Hab = HA + HBA;

            Console.WriteLine("\n\n Ентропія об'єднання - H(A,B) = " + Hab.ToString().Substring(0, 5));

            double Hab1 = 0;
            Hab1 = HB + HAB;

            Console.WriteLine("\n\n Ентропія об'єднання (другий спосіб) - H(A,B) = " + Hab1.ToString().Substring(0, 5));

            Console.WriteLine("\n\n Висновок: кількість інформації, що припадає на пару повідомлень ai, bj = " + Hab1.ToString().Substring(0, 5) + " біт");

            double IAB = 0;
            IAB = HA - HAB;

            Console.WriteLine("\n\n Повна взаємна інформація I(A,B) = " + IAB.ToString().Substring(0, 5));

            Console.WriteLine("\n\n Висновок: кількість інформації, що містить в середньому символ на виході першого джерела про виникнення символів на виході другого джерела становить " + IAB.ToString().Substring(0, 5) + " біт");

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
