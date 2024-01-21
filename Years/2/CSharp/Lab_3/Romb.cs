using System;

namespace Lab_3
{
    class Romb
    {
        private int a = 5;
        private int d1 = 8;
        private int d2 = 6;

        public Romb()
        {
            a = 5;
            d1 = 8;
            d2 = 6;
        }
        
        public Romb(int a, int d1, int d2)
        {
            if (a + a > d2 && a + d2 > a && a + a > d1 && a + d1 > a)
            {
                this.a = a;
                this.d1 = d1;
                this.d2 = d2;
            }
        }

        public void printData()
        {
            if (this.isRomb)
            {
                Console.Write("Дана фiгура є ромбом\n");

                if (this.isSquare)
                    Console.Write("Цей ромб є квадратом\n");
                else
                    Console.Write("Цей ромб не є квадратом\n");

                Console.Write("Сторона: {0}\n", a);
                Console.Write("Дiагональ_1: {0}\n", d1);
                Console.Write("Дiагональ_2: {0}\n", d2);

                Console.Write("Периметр: {0}\n", this.perimeter());
                Console.Write("Площа: {0}\n", this.area());
            }
            else
                Console.Write("Дана фiгура не є ромбом\n");
        }

        public int perimeter()
        {
            return 4 * a;
        }

        public float area()
        {
            return (float)d1 * (float)d2 / (float)2;
        }

        public bool isRomb
        {
            get
            {
                return (d1*d1 + d2*d2 == 4*a*a) ? true : false;
            }
        }

        public bool isSquare
        {
            get
            {
                return (isRomb && d1 == d2) ? true : false;
            }
        }

        public int side
        {
            get
            {
                return a;
            }
            set
            {
                a = value > 0 && value <= int.MaxValue ? value : 5;
            }
        }

        public int diagonal1
        {
            get
            {
                return d1;
            }
            set
            {
                d1 = value > 0 && value <= int.MaxValue ? value : 8;
            }
        }

        public int diagonal2
        {
            get
            {
                return d2;
            }
            set
            {
                d2 = value > 0 && value <= int.MaxValue ? value : 8;
            }
        }

        public static bool operator ==(Romb t, Romb b)
        {
            return (t.a == b.a && t.d1 == b.d1 && t.d2 == b.d2) ? true : false;
        }

        public static bool operator !=(Romb t, Romb b)
        {
            return (t == b) ? false : true;
        }

        public static bool operator <(Romb t, Romb b)
        {
            return (t.area() < t.area()) ? true : false;
        }

        public static bool operator >(Romb t, Romb b)
        {
            return (!(t < b) && (t != b)) ? true : false;
        }

    }
}