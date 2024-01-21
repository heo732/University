using System;

namespace Lab_4
{
    class Romb
    {
        protected int a;
        protected int d1;
        protected int d2;

        public Romb()
        {
            a = 0;
            d1 = 0;
            d2 = 0;
        }
        
        public Romb(int a, int d1, int d2)
        {           
            this.a = a;
            this.d1 = d1;
            this.d2 = d2; 
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

        public int this [int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return a;
                    case 1: return d1;
                    case 2: return d2;                    
                }
                throw new Exception("Помилка індексації");
            }
            set
            {
                switch (i)
                {
                    case 0: { a = value; break; }
                    case 1: { d1 = value; break; }
                    case 2: { d2 = value; break; }
                    default: { throw new Exception("Помилка індексації");}
                }                
            }
        }

        public static Romb operator ++(Romb other)
        {
            Romb temp = new Romb(other.a + 1, other.d1 + 1, other.d2 + 1);
            return temp;
        }

        public static Romb operator --(Romb other)
        {
            Romb temp = new Romb(other.a - 1, other.d1 - 1, other.d2 - 1);
            return temp;
        }

        public static bool operator true(Romb other)
        {
            return other.isSquare;
        }

        public static bool operator false(Romb other)
        {
            return !other.isSquare;
        }

        public static Romb operator *(Romb other, int scalar)
        {
            Romb temp = new Romb(other.a * scalar, other.d1 * scalar, other.d2 * scalar);
            return temp;
        }

        public static implicit operator string(Romb other)
        {
            string ret = other.a.ToString() + " " + other.d1.ToString() + " " + other.d2.ToString();
            return ret;
        }

        public static implicit operator Romb(string str)
        {
            char[] separator = new char[] {' ', '\t'};
            string[] values = str.Split(separator);
            Romb temp = new Romb(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
            return temp;
        }
        
    }
}