using System;

namespace Lab_2_Theory_of_coding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Кількість робочих комбінацій.
            int Np = 4;
            // Довжина коду.
            int n = 3;

            Console.WriteLine("Кодові комбінації:\n V1=001;\n V2=010;\n V3=011;\n V4=100; ");
            int[] V1 = { 0, 0, 1 };
            int[] V2 = { 0, 1, 0 };
            int[] V3 = { 0, 1, 1 };
            int[] V4 = { 1, 0, 0 };
            int[][] V = new int[6][] { new int[3], new int[3], new int[3], new int[3], new int[3], new int[3] };
            for (int i = 0; i < 3; i++)
            {
                V[0][i] = V1[i] ^ V2[i];
                V[1][i] = V1[i] ^ V3[i];
                V[2][i] = V1[i] ^ V4[i];
                V[3][i] = V2[i] ^ V3[i];
                V[4][i] = V2[i] ^ V4[i];
                V[5][i] = V3[i] ^ V4[i];
            }
            Console.WriteLine();
            Console.WriteLine("Додавання за модулем 2 ");
            for (int i = 0; i < V.Length; i++)
            {
                Console.Write("V[" + i + "] ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(V[i][j] + "  ");
                }
            }
            Console.WriteLine();
            int[] d = new int[V.Length];
            for (int i = 0; i < V.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (V[i][j] == 1)
                        count++;
                }
                d[i] = count; //вектор кодових відстаней
            }
            Console.WriteLine();

            Console.WriteLine("Кодові відстані");
            for (int i = 0; i < d.Length; i++)
            {
                Console.Write("  d[" + i + "] " + d[i]);
            }
            Console.WriteLine();
            
            Console.WriteLine();
            int[,] kd = { { 0, 2, 1, 2 }, { 2, 0, 1, 2 }, { 1, 1, 0, 3 }, { 2, 2, 3, 0 } }; //таблиця кодових відстаней
            Console.WriteLine("Таблиця кодових відстаней");

            for (int i = 0; i < Np; i++)
            {
                for (int j = 0; j < Np; j++)
                {
                    Console.Write(kd[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            int[] Npi = new int[4]; //кількість робочих комбінацій, які знаходться на кодовій відстані D від i-тої робочї комбінації
            for (int l = 0; l < Np; l++)
            {
                for (int i = 0; i < Np; i++)
                {
                    int count = 0;
                    for (int j = 0; j < Np; j++)
                    {
                        if (kd[i, j] == 1)
                            count++;
                    }
                    Npi[i] = count;
                }
                for (int i = 0; i < Np; i++)
                {
                    int count = 0;
                    for (int j = 0; j < Np; j++)
                    {
                        if (kd[i, j] == 2)
                            count++;
                    }
                    Npi[i] = count;
                }
                for (int i = 0; i < Np; i++)
                {
                    int count = 0;
                    for (int j = 0; j < Np; j++)
                    {
                        if (kd[i, j] == 3)
                            count++;
                    }
                    Npi[i] = count; ;
                }
                for (int i = 0; i < Np; i++)
                {
                    int count = 0;
                    for (int j = 0; j < Np; j++)
                    {
                        if (kd[i, j] == 4)
                            count++;
                    }
                    Npi[i] = count;
                }
            }
            int[] NPi = { 4, 4, 6, 2, 0 };
            Console.WriteLine("Кількість робочих комбінацій");
            for (int i = 0; i < NPi.Length; i++)
            {
                Console.Write("   Npi[" + i + "] = " + NPi[i] +"\n");
            }
            Console.WriteLine();
            int temp = 0;
            
            for (int i = 0; i < NPi.Length; i++)
            {
                for (int j = 0; j < NPi.Length - 1; j++)
                {

                    if (NPi[j] > NPi[j + 1])
                    {
                        temp = NPi[j];
                        NPi[j] = NPi[j + 1];
                        NPi[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine();

            int[] NPi1 = { 4, 4, 6, 2, 0 };



            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Коефіцієнт невірних переходів Кнп \n"); //коефіцієнт невірних переходів
            int[] d1 = { 0, 1, 2, 3, 3 };
            double[] Cnd = new double[d1.Length]; //вибірка C з n по d 
            double[] knp = new double[d1.Length];
            for (int i = 0; i < d1.Length; i++)
            {
                Cnd[i] = Factorial(n) / (Factorial(d1[i]) * Factorial(n - d1[i]));
                knp[i] += (NPi1[i] / Cnd[i]);
                knp[i] *= 0.25;
                Console.WriteLine(knp[i]);
            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("У відсотках: \n");
            double[] per = new double[knp.Length];
            for (int i = 0; i < d1.Length; i++)
            {
                per[i] = (1 - knp[i]) * 100; //перевдення у %
                Console.WriteLine(per[i] + "%");
            }

            Console.ReadLine();
        }

        private static long Factorial(int n)
        {
            long x = 1;
            for (int i = 1; i <= n; i++)
                x *= i;
            return x;
        }
    }
}