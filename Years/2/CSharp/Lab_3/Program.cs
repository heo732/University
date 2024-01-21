using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_3
{   
    class Program
    {   
        static void Main(string[] args)
        {
            Console.Title = "C# | Lab_3 | Var_4";
            
            Romb romb = new Romb();

            romb.side = getIntBetweenWithMessage(1, int.MaxValue, "Введiть довжину сторони: ");
            romb.diagonal1 = getIntBetweenWithMessage(1, int.MaxValue, "Введiть довжину першої дiагоналi: ");
            romb.diagonal2 = getIntBetweenWithMessage(1, int.MaxValue, "Введiть довжину другої дiагоналi: ");
            
            Console.Write("\n");
            romb.printData();
            Console.Write("\n\n\n");
            
            ////////////////////////////////////////////////


            Mechanism mechanism = new Mechanism();
            mechanism.NeedCountUnits = 3;
            mechanism.Name = "Car";
            mechanism.Units = new Unit[3];
            
            Component wheel = new Component();
            wheel.Name = "wheel";
            wheel.Manufacturer = "Honda";
            wheel.DateOfManufacture = "10.10.2010";
            wheel.Price = 1000;
            
            Unit wheels = new Unit();
            wheels.Name = "wheels";
            wheels.Components = new Component[4];
            wheels.Components[0] = wheels.Components[1] = wheels.Components[2] = wheels.Components[3] = wheel;

            mechanism.Units[0] = wheels;

            Unit engine = new Unit();
            engine.Name = "engine";
            engine.DateOfManufacture = "5.10.2010";
            engine.Price = 3000;
            mechanism.Units[1] = engine;

            Unit body = new Unit();
            engine.Name = "body";
            engine.DateOfManufacture = "5.8.2010";
            engine.Price = 2000;
            mechanism.Units[2] = engine;

            mechanism.Show();
            body.Show();
            engine.Show();
            wheels.Show();

            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }

        static int getIntBetweenWithMessage(int left, int right, String message)
        {
            bool flag = false;
            int choose = int.MaxValue;
            do
            {
                Console.Write(message);
                try
                {
                    choose = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception) { }
            }
            while (flag == false || choose < left || choose > right);
            return choose;
        }
    }
}