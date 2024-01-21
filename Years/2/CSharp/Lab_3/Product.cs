using System;
using System.Collections.Generic;

namespace Lab_3
{
    // Виріб
    public abstract class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public string DateOfManufacture { get; set; }
        public abstract void Show();
    }

    // Деталь
    public class Component : Product
    {
        public override void Show()
        {
            Console.WriteLine("About the component");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price.ToString());
            Console.WriteLine("Manufacturer: " + Manufacturer);
            Console.WriteLine("Date of manufacture: " + DateOfManufacture);
        }
    }

    // Вузол
    public class Unit : Product
    {
        public Component[] Components = new Component[0];

        public override void Show()
        {
            Console.WriteLine("About the unit");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price.ToString());
            Console.WriteLine("Manufacturer: " + Manufacturer);
            Console.WriteLine("Date of manufacture: " + DateOfManufacture);
            Console.WriteLine("Count of components: " + Components.Length.ToString());
        }
    }

    public class Mechanism : Product
    {   
        public string Name { get; set; }
        
        public Unit[] Units = new Unit[0];

        public int NeedCountUnits { get; set; }        

        private void Work()
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
        }
    }
}