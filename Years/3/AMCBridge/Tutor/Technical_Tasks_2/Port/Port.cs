using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Port
{
    class Port
    {
        public interface IShip
        {
            int Profit();
        }

        public class Passenger : IShip
        {
            public int NumberOfPassengers { get; set; }

            public Passenger(int numberOfPassengers)
            {
                this.NumberOfPassengers = numberOfPassengers;
            }

            int IShip.Profit()
            {
                return 3 * NumberOfPassengers;
            }
        }

        public class Cargo : IShip
        {
            public int Weight { get; set; }

            public int Remaining { get; set; }

            public Cargo(int weight, int remaining)
            {
                this.Weight = weight;
                this.Remaining = remaining;
            }

            int IShip.Profit()
            {
                return 2 * Remaining + 5 * (Weight - Remaining);
            }
        }

        public class Yacht : IShip
        {
            public int NumberOfPassengers { get; set; }

            private bool isLeftThePort;

            public Yacht(int numberOfPassengers)
            {
                this.NumberOfPassengers = numberOfPassengers;
                isLeftThePort = false;
            }

            public void LeftThePort()
            {
                isLeftThePort = true;
            }

            int IShip.Profit()
            {
                return isLeftThePort ? 0 : 5 * NumberOfPassengers;
            }
        }

        static void Main(string[] args)
        {
            var inputValues = new List<int>();
            foreach (var item in Console.ReadLine().Split(' '))
                inputValues.Add(int.Parse(item));

            int index = 0;

            var ships = new Dictionary<int, IShip>();

            // Beginning information about ships.
            while (inputValues[index] != -1 && index < inputValues.Count)
            {
                switch (inputValues[index + 1])
                {
                    case 1:
                        {
                            ships.Add(inputValues[index], new Passenger(inputValues[index + 2]));
                            break;
                        }
                    case 2:
                        {
                            ships.Add(inputValues[index], new Cargo(inputValues[index + 2], 0));
                            break;
                        }
                    case 3:
                        {
                            ships.Add(inputValues[index], new Yacht(inputValues[index + 2]));
                            break;
                        }
                }
                index += 3;
            }

            index++; // Skip -1.
            // Information about the weight of cargo remaining on the ships.
            while (inputValues[index] != -1 && index < inputValues.Count)
            {
                ((Cargo)ships[inputValues[index]]).Remaining = inputValues[index + 1];
                index += 2;
            }

            index++; // Skip -1.
            // Information about yachts that left the port.
            while (inputValues[index] != -1 && index < inputValues.Count)
            {
                ((Yacht)ships[inputValues[index]]).LeftThePort();
                index++;
            }

            // Calculate total profit.
            int profit = 0;
            foreach (var item in ships)
                profit += item.Value.Profit();

            Console.Write(profit);
        }
    }
}
