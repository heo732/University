using System;
using System.Collections.Generic;

namespace Lab_6
{
    // Виріб
    public interface IProduct : IComparable, ICloneable
    {
        string Name { get; set; }
        int Price { get; set; }
        string Manufacturer { get; set; }
        string DateOfManufacture { get; set; }

        void Show();
    }

    // Деталь
    public class Component : IProduct, IComparer<Component>, System.Collections.IEnumerable, System.Collections.IEnumerator
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public string DateOfManufacture { get; set; }
        public int Weight { get; set; }

        int index = -1;

        public void Show()
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
        {
            Name = "";
            Price = 0;
            Manufacturer = "";
            DateOfManufacture = "";
            Weight = 0;
        }

        public Component(int weight, string name, int price, string manufacturer, string dateOfManufacture)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            DateOfManufacture = dateOfManufacture;
            Weight = weight;
        }

        public Component(Component other)
        {
            Name = other.Name;
            Price = other.Price;
            Manufacturer = other.Manufacturer;
            DateOfManufacture = other.DateOfManufacture;
            Weight = other.Weight;
        }

        public int CompareTo(object obj)
        {
            IProduct temp = obj as IProduct;
            if (temp != null)
                return Price.CompareTo(temp.Price);
            return 0;
        }

        public int Compare(Component p1, Component p2)
        {
            return p1.Price.CompareTo(p2.Price);
        }

        public object Clone()
        {
            object ret = new Component(this);
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
                    case 0: return Name;
                    case 1: return Price;
                    case 2: return Manufacturer;
                    case 3: return DateOfManufacture;
                    case 4: return Weight;
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

    // Вузол
    public class Unit : IProduct, IComparer<Unit>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public string DateOfManufacture { get; set; }

        public Component[] Components;

        public void Show()
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
        {
            Name = "";
            Price = 0;
            Manufacturer = "";
            DateOfManufacture = "";
            Components = new Component[0];
        }

        public Unit(string name, int price, string manufacturer, string dateOfManufacture, Component[] components)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            DateOfManufacture = dateOfManufacture;

            Components = new Component[components.Length];
            for (uint i = 0; i < components.Length; i++)
            {
                Components[i] = new Component(components[i]);
            }
        }

        public Unit(string name, int price, string manufacturer, string dateOfManufacture)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            DateOfManufacture = dateOfManufacture;

            Components = new Component[0];
        }

        public Unit(Unit other)
        {
            Name = other.Name;
            Price = other.Price;
            Manufacturer = other.Manufacturer;
            DateOfManufacture = other.DateOfManufacture;

            Components = new Component[other.Components.Length];
            for (int i = 0; i < other.Components.Length; i++)
            {
                Components[i] = new Component(other.Components[i]);
            }
        }

        public int CompareTo(object obj)
        {
            IProduct temp = obj as IProduct;
            if (temp != null)
                return Price.CompareTo(temp.Price);
            return 0;
        }

        public int Compare(Unit p1, Unit p2)
        {
            return p1.Price.CompareTo(p2.Price);
        }

        public object Clone()
        {
            object ret = new Unit(this);
            return ret;
        }
    }

    public class Mechanism : IProduct, IComparer<Mechanism>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public string DateOfManufacture { get; set; }

        public Unit[] Units;

        public uint NeedCountUnits { get; set; }        

        protected void Work()
        {
            if (Units.Length == NeedCountUnits)
                Console.WriteLine("Mechanism works");
            else
                Console.WriteLine("Mechnism does not work");            
        }

        public void Show()
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
        {
            Name = "";
            Price = 0;
            Manufacturer = "";
            DateOfManufacture = "";

            Units = new Unit[0];
            NeedCountUnits = 0;
        }

        public Mechanism(string name, int price, string manufacturer, string dateOfManufacture, uint needCountUnits, Unit[] units)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            DateOfManufacture = dateOfManufacture;

            NeedCountUnits = needCountUnits;
            Units = new Unit[units.Length];
            for (int i = 0; i < units.Length; i++)
            {
                Units[i] = new Unit(units[i]);
            }
        }

        public Mechanism(string name, int price, string manufacturer, string dateOfManufacture, uint needCountUnits)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            DateOfManufacture = dateOfManufacture;

            NeedCountUnits = needCountUnits;
            Units = new Unit[0];
        }

        public Mechanism(Mechanism other)
        {
            Name = other.Name;
            Price = other.Price;
            Manufacturer = other.Manufacturer;
            DateOfManufacture = other.DateOfManufacture;

            NeedCountUnits = other.NeedCountUnits;
            Units = new Unit[other.Units.Length];
            for (int i = 0; i < other.Units.Length; i++)
            {
                Units[i] = new Unit(other.Units[i]);
            }
        }

        public int CompareTo(object obj)
        {
            IProduct temp = obj as IProduct;
            if (temp != null)
                return Price.CompareTo(temp.Price);
            return 0;
        }

        public int Compare(Mechanism p1, Mechanism p2)
        {
            return p1.Price.CompareTo(p2.Price);
        }

        public object Clone()
        {
            object ret = new Mechanism(this);
            return ret;
        }
    }
}