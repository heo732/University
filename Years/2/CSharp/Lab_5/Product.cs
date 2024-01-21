using System;
using System.Collections.Generic;

namespace Lab_5
{
    // Виріб
    public abstract class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public string DateOfManufacture { get; set; }

        public abstract void Show();

        public Product()
        {
            Name = "";
            Price = 0;
            Manufacturer = "";
            DateOfManufacture = "";
        }

        public Product(string name, int price, string manufacturer, string dateOfManufacture)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            DateOfManufacture = dateOfManufacture;
        }

        public Product(Product other)
        {
            Name = other.Name;
            Price = other.Price;
            Manufacturer = other.Manufacturer;
            DateOfManufacture = other.DateOfManufacture;
        }

        ~Product()
        {
            Console.WriteLine("Destructor of abstract class Product");
            Console.WriteLine();
        }
    }

    // Деталь
    public class Component : Product
    {
        public int Weight { get; set; }

        public override void Show()
        {
            Console.WriteLine("About the component");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price.ToString());
            Console.WriteLine("Weight: " + Weight.ToString());
            Console.WriteLine("Manufacturer: " + Manufacturer);
            Console.WriteLine("Date of manufacture: " + DateOfManufacture);
            Console.WriteLine();
        }

        public Component()
            : base()
        {
            Weight = 0;
        }

        public Component(int weight, string name, int price, string manufacturer, string dateOfManufacture)
            : base(name, price, manufacturer, dateOfManufacture)
        {
            Weight = weight;
        }

        public Component(Component other)
            : base(other.Name, other.Price, other.Manufacturer, other.DateOfManufacture)
        {
            Weight = other.Weight;
        }

        ~Component()
        {
            Console.WriteLine("Destructor of class Component");
            Console.WriteLine();
        }

    }

    // Вузол
    public class Unit : Product
    {
        public Component[] Components;

        public override void Show()
        {
            Console.WriteLine("About the unit");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price.ToString());
            Console.WriteLine("Manufacturer: " + Manufacturer);
            Console.WriteLine("Date of manufacture: " + DateOfManufacture);
            Console.WriteLine("Count of components: " + Components.Length.ToString());
            Console.WriteLine();
            foreach (var item in Components)
            {
                item.Show();
            }
        }

        public Unit()
            : base()
        {
            Components = new Component[0];
        }

        public Unit(string name, int price, string manufacturer, string dateOfManufacture, Component[] components)
            : base(name, price, manufacturer, dateOfManufacture)
        {
            Components = new Component[components.Length];
            for (uint i = 0; i < components.Length; i++)
            {
                Components[i] = new Component(components[i]);
            }
        }

        public Unit(string name, int price, string manufacturer, string dateOfManufacture)
            : base(name, price, manufacturer, dateOfManufacture)
        {
            Components = new Component[0];
        }

        public Unit(Unit other)
            : base(other.Name, other.Price, other.Manufacturer, other.DateOfManufacture)
        {
            Components = new Component[other.Components.Length];
            for (int i = 0; i < other.Components.Length; i++)
            {
                Components[i] = new Component(other.Components[i]);
            }
        }

        ~Unit()
        {
            Console.WriteLine("Destructor of class Unit");
            Console.WriteLine();
        }

    }

    public class Mechanism : Product
    {           
        public Unit[] Units;

        public uint NeedCountUnits { get; set; }        

        protected void Work()
        {
            if (Units.Length == NeedCountUnits)
                Console.WriteLine("Mechanism works");
            else
                Console.WriteLine("Mechnism does not work");            
        }

        public override void Show()
        {
            Console.WriteLine("About the mechanism");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Need count units: " + NeedCountUnits.ToString());
            Console.WriteLine("Current count of units: " + Units.Length.ToString());
            Work();
            Console.WriteLine();
            foreach (var item in Units)
            {
                item.Show();
            }
        }

        public Mechanism()
            : base()
        {
            Units = new Unit[0];
            NeedCountUnits = 0;
        }

        public Mechanism(string name, int price, string manufacturer, string dateOfManufacture, uint needCountUnits, Unit[] units)
            : base(name, price, manufacturer, dateOfManufacture)
        {
            NeedCountUnits = needCountUnits;
            Units = new Unit[units.Length];
            for (int i = 0; i < units.Length; i++)
            {
                Units[i] = new Unit(units[i]);
            }
        }

        public Mechanism(string name, int price, string manufacturer, string dateOfManufacture, uint needCountUnits)
            : base(name, price, manufacturer, dateOfManufacture)
        {
            NeedCountUnits = needCountUnits;
            Units = new Unit[0];
        }

        public Mechanism(Mechanism other)
            : base(other.Name, other.Price, other.Manufacturer, other.DateOfManufacture)
        {
            NeedCountUnits = other.NeedCountUnits;
            Units = new Unit[other.Units.Length];
            for (int i = 0; i < other.Units.Length; i++)
            {
                Units[i] = new Unit(other.Units[i]);
            }
        }

        ~Mechanism()
        {
            Console.WriteLine("Destructor of class Mechanism");
            Console.WriteLine();
        }

    }
}