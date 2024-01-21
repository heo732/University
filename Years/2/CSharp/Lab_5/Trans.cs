using System;
using System.Collections.Generic;

namespace Lab_5
{

    public abstract class Trans
    {

        public string Brand { get; set; }
        public string Number { get; set; }
        public uint Speed { get; set; }
        public uint _loadCapacity { get; set; }

        public abstract void Show();
        public abstract uint LoadCapacity();
        public abstract void ConsoleWrite();

        public Trans()
        {
            Brand = "";
            Number = "";
            Speed = 0;
            _loadCapacity = 0;
        }

        public Trans(string brand, string number, uint speed, uint loadCapacity)
        {
            Brand = brand;
            Number = number;
            Speed = speed;
            _loadCapacity = loadCapacity;
        }

        public Trans(Trans other)
        {
            Brand = other.Brand;
            Number = other.Number;
            Speed = other.Speed;
            _loadCapacity = other._loadCapacity;
        }

    }

    public class Car : Trans
    {        

        public override uint LoadCapacity()
        {
            return _loadCapacity;
        }

        public override void Show()
        {
            Console.WriteLine("About Car");
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Number: " + Number);
            Console.WriteLine("Speed: " + Speed.ToString());
            Console.WriteLine("LoadCapacity: " + LoadCapacity().ToString());
        }

        public override void ConsoleWrite()
        {
            Console.Write("{0,15}\t{1,8}\t{2,5}\t{3,12}", Brand, Number, Speed, LoadCapacity());
        }

        public Car()
            : base()
        {
        }

        public Car(string brand, string number, uint speed, uint loadCapacity)
            : base(brand, number, speed, loadCapacity)
        {
        }

        public Car(Car other)
            : base(other.Brand, other.Number, other.Speed, other._loadCapacity)
        {
        }

    }

    public class Motorbike : Trans
    {

        public bool StrollerAvailability { get; set; }

        public override uint LoadCapacity()
        {
            if (StrollerAvailability)
                return _loadCapacity;
            return 0;
        }

        public override void Show()
        {
            Console.WriteLine("About Motorbike");
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Number: " + Number);
            Console.WriteLine("Speed: " + Speed.ToString());
            Console.WriteLine("Stroller availability: " + StrollerAvailability.ToString());
            Console.WriteLine("LoadCapacity: " + LoadCapacity().ToString());
        }

        public override void ConsoleWrite()
        {
            Console.Write("{0,15}\t{1,8}\t{2,5}\t{3,12}\t{4,30}", Brand, Number, Speed, LoadCapacity(), StrollerAvailability.ToString());
        }

        public Motorbike()
            : base()
        {
            StrollerAvailability = false;
        }

        public Motorbike(string brand, string number, uint speed, uint loadCapacity, bool strollerAvailability)
            : base(brand, number, speed, loadCapacity)
        {
            StrollerAvailability = strollerAvailability;
        }

        public Motorbike(Motorbike other)
            : base(other.Brand, other.Number, other.Speed, other._loadCapacity)
        {
            StrollerAvailability = other.StrollerAvailability;
        }

    }

    public class Truck : Trans
    {

        public bool TrailerAvailability { get; set; }

        public override uint LoadCapacity()
        {
            if (TrailerAvailability)
                return _loadCapacity * 2;
            return _loadCapacity;
        }

        public override void Show()
        {
            Console.WriteLine("About Truck");
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Number: " + Number);
            Console.WriteLine("Speed: " + Speed.ToString());
            Console.WriteLine("Trailer availability: " + TrailerAvailability.ToString());
            Console.WriteLine("LoadCapacity: " + LoadCapacity().ToString());
        }

        public override void ConsoleWrite()
        {
            Console.Write("{0,15}\t{1,8}\t{2,5}\t{3,12}\t{4,30}", Brand, Number, Speed, LoadCapacity(), TrailerAvailability.ToString());
        }

        public Truck()
            : base()
        {
            TrailerAvailability = false;
        }

        public Truck(string brand, string number, uint speed, uint loadCapacity, bool trailerAvailability)
            : base(brand, number, speed, loadCapacity)
        {
            TrailerAvailability = trailerAvailability;
        }

        public Truck(Truck other)
            : base(other.Brand, other.Number, other.Speed, other._loadCapacity)
        {
            TrailerAvailability = other.TrailerAvailability;
        }

    }
}