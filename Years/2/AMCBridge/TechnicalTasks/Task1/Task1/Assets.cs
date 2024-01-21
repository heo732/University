using System;
using System.Collections.Generic;

namespace Task1
{
    interface IAssets
    {
        double Sum(int months);
    }

    class PrimaryMeans : IAssets
    {
        int price;
        int amount;
        double currentValue;

        public PrimaryMeans(int price, int amount)
        {
            this.price = price >= 0 ? price : 0;
            this.amount = amount >= 0 ? amount : 0;
            currentValue = price * amount;
        }

        public double Sum(int months)
        {
            currentValue -= price * amount * months / 10.0;
            currentValue = currentValue >= 0 ? currentValue : 0;
            return currentValue;
        }
    }

    class Products : IAssets
    {
        double price;
        int amount;
        int reductionCount = 1;

        public Products(int price, int amount)
        {
            this.price = price >= 0 ? price : 0;
            this.amount = amount >= 0 ? amount : 0;
        }

        public double Sum(int months)
        {
            double reduction = price * reductionCount * 0.02 * months;
            reductionCount++;

            price -= reduction;
            price = price >= 0 ? price : 0;
            
            return price * amount;
        }
    }

    class Currency : IAssets
    {
        double exchangeRate;
        int amount;

        public Currency(int exchangeRate, int amount)
        {
            this.exchangeRate = exchangeRate >= 0 ? exchangeRate : 0;
            this.amount = amount >= 0 ? amount : 0;
        }

        public double Sum(int months)
        {
            if (months % 2 == 0)
                exchangeRate *= 1.1;
            else
                exchangeRate *= 0.8;
            
            return exchangeRate * amount;
        }
    }

    class Assets
    {
        static void Main()
        {
            List<int> values = new List<int>();
            foreach (var value in Console.ReadLine().Split(' '))
                values.Add( Int32.Parse(value) );

            List<IAssets> assets = new List<IAssets>();

            int index = 0;
            while (values[index] != -1)
            {
                switch (values[index])
                {
                    case 1:
                        {
                            assets.Add(new PrimaryMeans(values[index+2], values[index+3]));
                            break;
                        }
                    case 2:
                        {
                            assets.Add(new Products(values[index + 2], values[index + 3]));
                            break;
                        }
                    case 3:
                        {
                            assets.Add(new Currency(values[index + 2], values[index + 3]));
                            break;
                        }
                }
                index += 4;
            }
            index++;

            List<int> months = new List<int>();

            while (values[index] != -1)
            {
                months.Add(values[index]);
                index++;
            }

            foreach (int m in months)
            {
                double sum = 0;
                foreach (var i in assets)
                    sum += i.Sum(m);
                Console.Write("{0:0.00} ", sum);
            }
            Console.Write("-1");
        }
    }
}