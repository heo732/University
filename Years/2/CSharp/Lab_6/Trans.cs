using System;
using System.Collections.Generic;

namespace Lab_6
{

    public interface ITrans : IComparable, System.Collections.IComparer, ICloneable, System.Collections.IEnumerable, System.Collections.IEnumerator
    {

        string Brand { get; set; }
        string Number { get; set; }
        uint Speed { get; set; }
        uint _loadCapacity { get; set; }

        void Show();
        uint LoadCapacity();
        void ConsoleWrite();

    }

    public class Car : ITrans
    {
        public string Brand { get; set; }
        public string Number { get; set; }
        public uint Speed { get; set; }
        public uint _loadCapacity { get; set; }

        int index = -1;

        public uint LoadCapacity()
        {
            return _loadCapacity;
        }

        public void Show()
        {
            Console.WriteLine("About Car");
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Number: " + Number);
            Console.WriteLine("Speed: " + Speed.ToString());
            Console.WriteLine("LoadCapacity: " + LoadCapacity().ToString());
        }

        public void ConsoleWrite()
        {
            Console.Write("{0,15}\t{1,8}\t{2,5}\t{3,12}", Brand, Number, Speed, LoadCapacity());
        }

        public Car()
        {
            Brand = "";
            Number = "";
            Speed = 0 ;
            _loadCapacity = 0;
        }

        public Car(string brand, string number, uint speed, uint loadCapacity)
        {
            Brand = brand;
            Number = number;
            Speed = speed;
            _loadCapacity = loadCapacity;
        }

        public Car(Car other)
        {
            Brand = other.Brand;
            Number = other.Number;
            Speed = other.Speed;
            _loadCapacity = other._loadCapacity;
        }

        public int CompareTo(object obj)
        {
            ITrans temp = obj as ITrans;
            if (temp != null)
                return LoadCapacity().CompareTo(temp.LoadCapacity());
            return 0;
        }

        public int Compare(object o1, object o2)
        {
            ITrans temp1 = o1 as ITrans;
            ITrans temp2 = o2 as ITrans;
            if (temp1 != null && temp2 != null)
                return temp1.LoadCapacity().CompareTo(temp2.LoadCapacity());
            if (temp1 == null && temp2 != null)
                return -1;
            if (temp1 != null && temp2 == null)
                return 1;
            return 0;
        }

        public object Clone()
        {
            object ret = new Car(this);
            return ret;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current
        {
            get
            {
                switch (index)
                {
                    case 0: return Brand;
                    case 1: return Number;
                    case 2: return Speed;
                    case 3: return LoadCapacity();
                }
                return null;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public bool MoveNext()
        {
            if (index == 3)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

    }

    public class Motorbike : ITrans
    {
        public string Brand { get; set; }
        public string Number { get; set; }
        public uint Speed { get; set; }
        public uint _loadCapacity { get; set; }

        public bool StrollerAvailability { get; set; }

        int index = -1;

        public uint LoadCapacity()
        {
            if (StrollerAvailability)
                return _loadCapacity;
            return 0;
        }

        public void Show()
        {
            Console.WriteLine("About Motorbike");
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Number: " + Number);
            Console.WriteLine("Speed: " + Speed.ToString());
            Console.WriteLine("Stroller availability: " + StrollerAvailability.ToString());
            Console.WriteLine("LoadCapacity: " + LoadCapacity().ToString());
        }

        public void ConsoleWrite()
        {
            Console.Write("{0,15}\t{1,8}\t{2,5}\t{3,12}\t{4,30}", Brand, Number, Speed, LoadCapacity(), StrollerAvailability.ToString());
        }

        public Motorbike()
        {
            Brand = "";
            Number = "";
            Speed = 0;
            _loadCapacity = 0;
            StrollerAvailability = false;
        }

        public Motorbike(string brand, string number, uint speed, uint loadCapacity, bool strollerAvailability)
        {
            Brand = brand;
            Number = number;
            Speed = speed;
            _loadCapacity = loadCapacity;
            StrollerAvailability = strollerAvailability;
        }

        public Motorbike(Motorbike other)
        {
            Brand = other.Brand;
            Number = other.Number;
            Speed = other.Speed;
            _loadCapacity = other._loadCapacity;
            StrollerAvailability = other.StrollerAvailability;
        }

        public int CompareTo(object obj)
        {
            ITrans temp = obj as ITrans;
            if (temp != null)
                return LoadCapacity().CompareTo(temp.LoadCapacity());
            return 0;
        }

        public int Compare(object o1, object o2)
        {
            ITrans temp1 = o1 as ITrans;
            ITrans temp2 = o2 as ITrans;
            if (temp1 != null && temp2 != null)
                return temp1.LoadCapacity().CompareTo(temp2.LoadCapacity());
            if (temp1 == null && temp2 != null)
                return -1;
            if (temp1 != null && temp2 == null)
                return 1;
            return 0;
        }

        public object Clone()
        {
            object ret = new Motorbike(this);
            return ret;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current
        {
            get
            {
                switch (index)
                {
                    case 0: return Brand;
                    case 1: return Number;
                    case 2: return Speed;
                    case 3: return LoadCapacity();
                    case 4: return StrollerAvailability;
                }
                return null;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public bool MoveNext()
        {
            if (index == 4)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

    }

    public class Truck : ITrans
    {
        public string Brand { get; set; }
        public string Number { get; set; }
        public uint Speed { get; set; }
        public uint _loadCapacity { get; set; }

        public bool TrailerAvailability { get; set; }

        int index = -1;

        public uint LoadCapacity()
        {
            if (TrailerAvailability)
                return _loadCapacity * 2;
            return _loadCapacity;
        }

        public void Show()
        {
            Console.WriteLine("About Truck");
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Number: " + Number);
            Console.WriteLine("Speed: " + Speed.ToString());
            Console.WriteLine("Trailer availability: " + TrailerAvailability.ToString());
            Console.WriteLine("LoadCapacity: " + LoadCapacity().ToString());
        }

        public void ConsoleWrite()
        {
            Console.Write("{0,15}\t{1,8}\t{2,5}\t{3,12}\t{4,30}", Brand, Number, Speed, LoadCapacity(), TrailerAvailability.ToString());
        }

        public Truck()
        {
            Brand = "";
            Number = "";
            Speed = 0;
            _loadCapacity = 0;
            TrailerAvailability = false;
        }

        public Truck(string brand, string number, uint speed, uint loadCapacity, bool trailerAvailability)
        {
            Brand = brand;
            Number = number;
            Speed = speed;
            _loadCapacity = loadCapacity;
            TrailerAvailability = trailerAvailability;
        }

        public Truck(Truck other)
        {
            Brand = other.Brand;
            Number = other.Number;
            Speed = other.Speed;
            _loadCapacity = other._loadCapacity;
            TrailerAvailability = other.TrailerAvailability;
        }

        public int CompareTo(object obj)
        {
            ITrans temp = obj as ITrans;
            if (temp != null)
                return LoadCapacity().CompareTo(temp.LoadCapacity());
            return 0;
        }

        public int Compare(object o1, object o2)
        {
            ITrans temp1 = o1 as ITrans;
            ITrans temp2 = o2 as ITrans;
            if (temp1 != null && temp2 != null)
                return temp1.LoadCapacity().CompareTo(temp2.LoadCapacity());
            if (temp1 == null && temp2 != null)
                return -1;
            if (temp1 != null && temp2 == null)
                return 1;
            return 0;
        }

        public object Clone()
        {
            object ret = new Truck(this);
            return ret;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current
        {
            get
            {
                switch (index)
                {
                    case 0: return Brand;
                    case 1: return Number;
                    case 2: return Speed;
                    case 3: return LoadCapacity();
                    case 4: return TrailerAvailability;
                }
                return null;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public bool MoveNext()
        {
            if (index == 4)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

    }
}