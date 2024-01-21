using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_6
{
    class Program
    {
        static List<string> _brand;
        static Random _random;

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "C# | Lab_6 | Var_4";
            //--------------------------------------------------------------------------------
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task_1");
            Console.WriteLine("----------------------------------------------------------------");

            IProduct product1 = new Component(30, "Колесо", 999, "Wolkswagen", "11.11.2011");
            product1.Show();

            IProduct product2 = new Unit("Двигун", 5000, "Citroen", "09.08.2006");
            product2.Show();

            Console.WriteLine("Колесо.CompareTo(Двигун) = " + product1.CompareTo(product2));

            Console.WriteLine("----------------------------------------------------------------");
            IProduct product3 = (Component) product1.Clone();
            Console.WriteLine("Clone of Колесо");
            product3.Show();

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("foreach in Колесо");
            foreach (var i in (Component)product1)
                Console.WriteLine(i);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task_2");
            Console.WriteLine("----------------------------------------------------------------");

            try
            {
                LoadBrand("Brand.txt");

                _random = new Random();

                int n = GetIntBetweenWithMessage(1, int.MaxValue, "Count of transport: ");

                ITrans[] transport = new ITrans[n];

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
                Console.WriteLine("----------------------------------------------------------------");

                uint minLoadCapacity = Convert.ToUInt32(GetIntBetweenWithMessage(0, int.MaxValue, "Load capacity MIN value: "));
                uint maxLoadCapacity;
                do
                {
                    maxLoadCapacity = Convert.ToUInt32(GetIntBetweenWithMessage(0, int.MaxValue, "Load capacity MAX value: "));
                }
                while (maxLoadCapacity < minLoadCapacity);

                Array.Sort(transport);

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

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Task_3");
            Console.WriteLine("----------------------------------------------------------------");



            //--------------------------------------------------------------------------------
            Console.Write("Press any key to continue . . .");
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
