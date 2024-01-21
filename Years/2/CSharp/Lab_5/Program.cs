using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_5
{
    class Program
    {
        static List<string> _brand;
        static Random _random;

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "C# | Lab_5 | Var_4";

            //--------------------------------------------------------------------
            Console.WriteLine("//----------------------------------------------------------------------------------------------------");
            
            Component[] wheel = new Component[4];
            wheel[0] = new Component(20, "Wheel_1", 500, "Honda", "10.10.2010");
            wheel[1] = new Component(20, "Wheel_2", 500, "Honda", "10.10.2010");
            wheel[2] = new Component(20, "Wheel_3", 500, "Honda", "10.10.2010");
            wheel[3] = new Component(20, "Wheel_4", 500, "Honda", "10.10.2010");

            Unit wheels = new Unit("Wheels", 2000, "Honda", "10.10.2010", wheel);
            Unit engine = new Unit("Engine", 5000, "Subaru", "04.11.2008");
            Unit[] units = new Unit[2];
            units[0] = new Unit(wheels);
            units[1] = new Unit(engine);

            Mechanism car = new Mechanism("Car", 10000, "Subaru", "05.03.2011", 2, units);

            car.Show();
            Console.WriteLine("//----------------------------------------------------------------------------------------------------");
            //--------------------------------------------------------------------           
            try
            {
                LoadBrand("Brand.txt");

                _random = new Random();

                int n = GetIntBetweenWithMessage(1, int.MaxValue, "Count of transport: ");

                Trans[] transport = new Trans[n];

                for (int i = 0; i < transport.Length; i++)
                {
                    switch (_random.Next(3))
                    {
                        case 0: //Car
                            {
                                transport[i] = new Car(GetRandomBrand(), GetRandomNumber(), uint.Parse(_random.Next(201).ToString()), uint.Parse(_random.Next(701).ToString()));
                                break;
                            }
                        case 1: //Motorbike
                            {
                                transport[i] = new Motorbike(GetRandomBrand(), GetRandomNumber(), uint.Parse(_random.Next(301).ToString()), uint.Parse(_random.Next(301).ToString()), Convert.ToBoolean(_random.Next(2)));
                                break;
                            }
                        case 2: //Truck
                            {
                                transport[i] = new Truck(GetRandomBrand(), GetRandomNumber(), uint.Parse(_random.Next(121).ToString()), uint.Parse(_random.Next(3001).ToString()), Convert.ToBoolean(_random.Next(2)));
                                break;
                            }
                    }
                }

                Console.WriteLine("Transport DATA:");
                Console.WriteLine("{0,10}\t{1,15}\t{2,8}\t{3,5}\t{4,12}\t{5,30}", "Type", "Brand", "Number", "Speed", "LoadCapacity", "(Stroller/Trailer)Availability");
                Console.WriteLine();
                foreach (var item in transport)
                {
                    if (item is Car)
                        Console.Write("{0,10}\t", "Car");
                    else if (item is Motorbike)
                        Console.Write("{0,10}\t", "Motorbike");
                    else if (item is Truck)
                        Console.Write("{0,10}\t", "Truck");
                    else
                        Console.Write("{0,10}\t", "---");

                    item.ConsoleWrite();

                    if (item is Car)
                        Console.Write("\t{0,30}", "---");

                    Console.WriteLine();
                }
                //--------------------------------------------------------------------
                Console.WriteLine("//----------------------------------------------------------------------------------------------------");

                uint minLoadCapacity = Convert.ToUInt32(GetIntBetweenWithMessage(0, int.MaxValue, "Load capacity MIN value: "));
                uint maxLoadCapacity;
                do
                {
                    maxLoadCapacity = Convert.ToUInt32(GetIntBetweenWithMessage(0, int.MaxValue, "Load capacity MAX value: "));
                }
                while (maxLoadCapacity < minLoadCapacity);

                Console.WriteLine("Filter transport DATA. Load capacity [{0},{1}] :", minLoadCapacity, maxLoadCapacity);
                Console.WriteLine("{0,10}\t{1,15}\t{2,8}\t{3,5}\t{4,12}\t{5,30}", "Type", "Brand", "Number", "Speed", "LoadCapacity", "(Stroller/Trailer)Availability");
                Console.WriteLine();
                foreach (var item in transport)
                {
                    if (item.LoadCapacity() >= minLoadCapacity && item.LoadCapacity() <= maxLoadCapacity)
                    {
                        if (item is Car)
                            Console.Write("{0,10}\t", "Car");
                        else if (item is Motorbike)
                            Console.Write("{0,10}\t", "Motorbike");
                        else if (item is Truck)
                            Console.Write("{0,10}\t", "Truck");
                        else
                            Console.Write("{0,10}\t", "---");

                        item.ConsoleWrite();

                        if (item is Car)
                            Console.Write("\t{0,30}", "---");

                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("//----------------------------------------------------------------------------------------------------");
            //--------------------------------------------------------------------
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        static int GetIntBetweenWithMessage(int left, int right, String message)
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
                catch (Exception)
                {
                }
            }
            while (flag == false || choose < left || choose > right);
            return choose;
        }

        static void LoadBrand(string fileName)
        {            
            StreamReader file = new StreamReader(fileName);
            _brand = new List<string>();
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                _brand.Add(line);
            }
            file.Close();
        }

        static string GetRandomBrand()
        {
            if (_brand.Count > 0)
                return _brand[_random.Next(_brand.Count)];
            return "";
        }

        static string GetRandomNumber()
        {
            string ret = "";
            string[] letter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                              "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", 
                              "Y", "Z" };
            
            ret += letter[_random.Next(letter.Length)];
            ret += letter[_random.Next(letter.Length)];
            for (int i = 0; i < 4; i++)
            {
                ret += _random.Next(10).ToString();
            }
            ret += letter[_random.Next(letter.Length)];
            ret += letter[_random.Next(letter.Length)];

            return ret;
        }
    }
}