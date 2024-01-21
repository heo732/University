using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Program
    {
        static byte ChooseTask() 
        {
            byte choise = 0;
            while (choise < 1 || choise > 6)
            {
                Console.Write("Select Task [1|2|3|4|5|6]: ");
                try 
                {
                    choise = byte.Parse(Console.ReadLine());
                } 
                catch(Exception e)
                {
                    //
                }
            }
            return choise;
        }

        static void Task1()         
        {
            double a=0, b=0;
            bool flag = false;
            while (flag == false)
            {
                Console.Write("Input a: ");
                try
                {
                    a = double.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            flag = false;
            while (flag == false)
            {
                Console.Write("Input b: ");
                try
                {
                    b = double.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            Console.Write("The arithmetic mean of the cubes of numbers = ");
            Console.Write((a*a*a+b*b*b)/2);
            Console.Write("\n\n");
        }

        static void Task2()
        {
            int m = 0, n = 0;
            bool flag = false;
            while (flag == false)
            {
                Console.Write("Input M: ");
                try
                {
                    m = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            flag = false;
            while (flag == false)
            {
                Console.Write("Input N: ");
                try
                {
                    n = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            if (m % n == 0)
                Console.Write("M / N = " + m / n);
            else
                Console.Write("M to N is not evenly divisible");
            Console.Write("\n\n");
        }

        static void Task3()
        {
            double x = 0, y = 0;
            bool flag = false;
            while (flag == false)
            {
                Console.Write("Input x: ");
                try
                {
                    x = double.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            flag = false;
            while (flag == false)
            {
                Console.Write("Input y: ");
                try
                {
                    y = double.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            if(x*x+y*y<64 && x*x+y*y>9 && x<0)
                Console.Write("Inside");
            else if (x*x+y*y>64 || x*x+y*y<9 || x>0)
                Console.Write("Outside");
            else
                Console.Write("On the border");
            Console.Write("\n\n");
        }

        static void Task4()
        {
            int k = 0;
            bool flag = false;
            while (flag == false || k<6 || k>14)
            {
                Console.Write("Input k (6<=k<=14): ");
                try
                {
                    k = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            switch (k) 
            {
                case 14: Console.Write("ace"); break;
                case 13: Console.Write("king"); break;
                case 12: Console.Write("queen"); break;
                case 11: Console.Write("jack"); break;
                case 10: Console.Write("ten"); break;
                case 9: Console.Write("nine"); break;
                case 8: Console.Write("eight"); break;
                case 7: Console.Write("seven"); break;
                case 6: Console.Write("six"); break;
            }
            Console.Write("\n\n");
        }

        static int Div(int a, int b) 
        {
            if (b != 0)
                return a / b;
            else
                throw new InvalidOperationException("Division by zero");
        }

        static void Task5()
        {
            int a = 0, b = 0;
            bool flag = false;
            while (flag == false)
            {
                Console.Write("Input a: ");
                try
                {
                    a = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            flag = false;
            while (flag == false)
            {
                Console.Write("Input b: ");
                try
                {
                    b = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            try 
            {
                Console.Write("a / b = " + Div(a, b));
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
            Console.Write("\n\n");
        }

        static void Task6()
        {
            double a = 0, b = 0;
            bool flag = false;
            while (flag == false)
            {
                Console.Write("Input a: ");
                try
                {
                    a = double.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            flag = false;
            while (flag == false)
            {
                Console.Write("Input b: ");
                try
                {
                    b = double.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            if (a * a + b * b != 0)
            {
                Console.Write("Result: ");
                Console.Write((a * b + (a - b) * (a + b) - 1) / (a * a + b * b) - 5);
            }
            else
                Console.Write("Division by zero");
            Console.Write("\n\n");
        }

        static void Main(string[] args)
        {
            Console.Write("Lab_1 | Var_4\n/////////////\n\n");            
            string next = "y";
            while (next[0] == 'y' || next[0] == 'Y') 
            {
                byte task = ChooseTask();
                switch (task) 
                {
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    case 4: Task4(); break;
                    case 5: Task5(); break;
                    case 6: Task6(); break;
                }                
                Console.Write("Would you like to continue? [y|n]: ");
                next = Console.ReadLine();
            }
        }
    }
}
