using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.InputEncoding = Encoding.Unicode;
                Console.OutputEncoding = Encoding.Unicode;
                Console.Title = "C# | Lab_4 | Var_4";
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                bool _continue = true;

                while (_continue)
                {
                    switch (chooseTask())
                    {
                        case 1:
                        {
                            Console.WriteLine("\n///////////////////\nЗавдання 1 | Romb\n///////////////////");
                            
                            Console.Write("Задайте ромб [a, d1, d2]: ");
                            Romb romb = new Romb();
                            romb = Console.ReadLine();
                            Console.Write("Введіть скаляр: ");
                            int scalar = int.Parse(Console.ReadLine());

                            if (romb.isRomb)
                            {
                                Console.WriteLine("Romb: " + (string)romb);
                                Console.WriteLine("Romb[0]: " + romb[0]);
                                Console.WriteLine("Romb[1]: " + romb[1]);
                                Console.WriteLine("Romb[2]: " + romb[2]);
                                Console.WriteLine("++Romb: " + (string)++romb);
                                Console.WriteLine("--Romb: " + (string)--romb);
                                Console.WriteLine("?isSquare: " + romb.isSquare);
                                Console.WriteLine("Romb * {0}: " + (string)(romb*scalar), scalar);
                            }
                            else
                                Console.WriteLine("Задана фігура не є ромбом");

                            break;
                        }
                        case 2:
                        {
                            Console.WriteLine("\n///////////////////\nЗавдання 2 | Vector\n///////////////////");
                            VectorUshort vector = new VectorUshort();
                            vector.Read();
                            vector.Write("Vector:");
                            
                            Console.WriteLine("Vector.Length: " + vector.Length);
                            vector[0] = vector[1];
                            vector.Write("Vector[0] = Vector[1]:");
                            vector++;
                            vector.Write("Vector++:");
                            vector--;
                            vector.Write("Vector--:");
                            Console.WriteLine("Vector?true:false :" + (vector ? true : false));
                            Console.WriteLine("!Vector?true:false :" + (!vector ? true : false));
                            vector = ~vector;
                            vector.Write("~Vector:");
                            vector = vector + vector;
                            vector.Write("Vector + Vector:");                            
                            vector = vector * vector;
                            vector.Write("Vector * Vector:");
                            vector = vector / vector;
                            vector.Write("Vector / Vector:");
                            vector = vector % vector;
                            vector.Write("Vector % Vector:");                            
                            vector = vector | vector;
                            vector.Write("Vector | Vector:");
                            vector = vector ^ vector;
                            vector.Write("Vector ^ Vector:");
                            vector = vector & vector;
                            vector.Write("Vector & Vector:");
                            vector = vector >> vector[0];
                            vector.Write("Vector >> Vector[0]:");
                            vector = vector << vector[0];
                            vector.Write("Vector << Vector[0]:");
                            Console.WriteLine("Vector==Vector?true:false :" + (vector==vector ? true : false));
                            Console.WriteLine("Vector>Vector?true:false :" + (vector>vector ? true : false));

                            vector = vector - vector;
                            vector.Write("Vector - Vector:");
                            vector.Assign(14);
                            vector.Write("Vector.Assign(14):");

                            break;
                        }
                        case 3:
                        {
                            Console.WriteLine("\n///////////////////\nЗавдання 3 | Matrix\n///////////////////");
                            MatrixUshort matrix1 = new MatrixUshort();
                            matrix1.Read();                            
                            MatrixUshort matrix2 = new MatrixUshort();
                            matrix2.Read();
                            matrix1.Write("Matrix1:");
                            matrix2.Write("Matrix2:");
                            (matrix1 * matrix2).Write("Matrix1 * Matrix2:");
                            Console.WriteLine("Matrix1[1, 0]: " + matrix1[1,0]);
                            Console.WriteLine("Matrix1[2]: " + matrix1[2]);
                            Console.WriteLine(matrix1.CountMatrix());
                            break;
                        }
                    }
                    Console.WriteLine("Натисніть [y] якщо бажаєте продовжити");
                    if (Console.ReadKey(true).KeyChar != 'y')
                        _continue = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey(true);
            }
        }
    
        public static byte chooseTask()
        {
            Console.Write("Оберіть завдання [1, 2, 3] : ");
            switch (Console.ReadKey(false).KeyChar)
            {
                case '1': Console.WriteLine(); return 1;
                case '2': Console.WriteLine(); return 2;
                case '3': Console.WriteLine(); return 3;
                default: Console.WriteLine(); break;
            }
            return 0;
        }

    }

    
}
