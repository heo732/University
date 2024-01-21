using System;

namespace Lab_4
{
    class VectorUshort
    {
        protected ushort[] ArrayUShort;
        protected uint codeError;
        protected static uint num_vs = 0;

        public VectorUshort()
        {
            ArrayUShort = new ushort[1];
            ArrayUShort[0] = 0;
            num_vs++;
        }

        public VectorUshort(uint size)
        {
            ArrayUShort = new ushort[size];
            for (int i = 0; i < size; i++)
                ArrayUShort[i] = 0;
            num_vs++;
        }

        public VectorUshort(uint size, ushort value)
        {
            ArrayUShort = new ushort[size];
            for (int i = 0; i < size; i++)
                ArrayUShort[i] = value;
            num_vs++;
        }

        ~VectorUshort()
        {
            Console.WriteLine("Деструктор класу VectorUshort");
            num_vs--;
        }

        public void Resize(uint size)
        {
            ArrayUShort = new ushort[size];
            for (int i = 0; i < size; i++)
                ArrayUShort[i] = 0;
        }

        public void Read()
        {
            uint size = 0;
            Console.Write("Введіть розмір вектора: ");
            size = uint.Parse(Console.ReadLine());
            if (size > 0)
            {
                Resize(size);
                Console.WriteLine("Введіть елементи вектора:");
                char[] separator = new char[] {' ', '\t'};
                string[] elems = Console.ReadLine().Split(separator);
                for (uint i = 0; i < size; i++ )
                {
                    ArrayUShort[i] = ushort.Parse(elems[i]);
                }
            }
        }

        public void Write(string str = "")
        {
            Console.WriteLine(str);
            foreach (ushort i in ArrayUShort)
            {
                Console.Write("{0,4} ", i);                
            }
            Console.WriteLine();
        }

        public void Assign(ushort value)
        {
            for (uint i = 0; i < Length; i++ )
            {
                ArrayUShort[i] = value;
            }
        }

        public uint CountVectors()
        {
            return num_vs;
        }

        public uint Length
        {
            get
            {
                return (uint)ArrayUShort.Length;
            }
        }

        public uint Error
        {
            get
            {
                return codeError;
            }
            set
            {
                codeError = value;
            }
        }

        public ushort this[uint i]
        {
            get
            {
                if (i >= Length)
                {
                    codeError = 1;
                    return 0;
                }
                return ArrayUShort[i];
            }
            set
            {
                if (i >= Length)
                    codeError = 1;
                else
                    ArrayUShort[i] = value;
            }
        }

        public static VectorUshort operator ++(VectorUshort other)
        {
            VectorUshort temp = new VectorUshort(other.Length);
            for (uint i = 0; i < other.Length; i++)
            {
                temp[i] = other[i];
                temp[i]++;
            }
            return temp;
        }

        public static VectorUshort operator --(VectorUshort other)
        {
            VectorUshort temp = new VectorUshort(other.Length);
            for (uint i = 0; i < other.Length; i++)
            {
                temp[i] = other[i];
                temp[i]--;
            }
            return temp;
        }

        public static bool operator true(VectorUshort other)
        {
            if (other.Length != 0)
                return true;
            foreach (ushort i in other.ArrayUShort)
            {
                if (i == 0)
                    return false;
            }
            return true;
        }

        public static bool operator false(VectorUshort other)
        {
            if (other.Length != 0)
                return false;
            foreach (ushort i in other.ArrayUShort)
            {
                if (i == 0)
                    return true;
            }
            return false;
        }

        public static bool operator !(VectorUshort other)
        {
            return other.Length != 0 ? true : false;
        }

        public static VectorUshort operator ~(VectorUshort other)
        {
            VectorUshort temp = new VectorUshort(other.Length);
            for (uint i = 0; i < other.Length; i++)
            {
                temp[i] = (ushort)~other[i];
            }
            return temp;
        }

        public static VectorUshort operator +(VectorUshort a, VectorUshort b)
        {
            VectorUshort temp = new VectorUshort();
            if (a.Length > b.Length)
            {
                temp.Resize(a.Length);
                for (uint i = 0; i < a.Length; i++)
                    temp[i] = a[i];
            }
            else
            {
                temp.Resize(b.Length);
                for (uint i = 0; i < b.Length; i++)
                    temp[i] = b[i];
            }

            for (uint i = 0; i < Math.Min(a.Length, b.Length); i++)
                temp[i] = (ushort)(a[i] + b[i]);

            return temp;
        }

        public static VectorUshort operator +(VectorUshort a, ushort b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] + b);
            return temp;
        }

        public static VectorUshort operator -(VectorUshort a, VectorUshort b)
        {
            VectorUshort temp = new VectorUshort();
            if (a.Length > b.Length)
            {
                temp.Resize(a.Length);
                for (uint i = 0; i < a.Length; i++)
                    temp[i] = a[i];
            }
            else
            {
                temp.Resize(b.Length);
                for (uint i = 0; i < b.Length; i++)
                    temp[i] = b[i];
            }

            for (uint i = 0; i < Math.Min(a.Length, b.Length); i++)
                temp[i] = (ushort)(a[i] - b[i]);

            return temp;
        }

        public static VectorUshort operator -(VectorUshort a, ushort b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] - b);
            return temp;
        }

        public static VectorUshort operator *(VectorUshort a, VectorUshort b)
        {
            VectorUshort temp = new VectorUshort();
            if (a.Length > b.Length)
            {
                temp.Resize(a.Length);
                for (uint i = 0; i < a.Length; i++)
                    temp[i] = a[i];
            }
            else
            {
                temp.Resize(b.Length);
                for (uint i = 0; i < b.Length; i++)
                    temp[i] = b[i];
            }

            for (uint i = 0; i < Math.Min(a.Length, b.Length); i++)
                temp[i] = (ushort)(a[i] * b[i]);

            return temp;
        }

        public static VectorUshort operator *(VectorUshort a, ushort b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] * b);
            return temp;
        }

        public static VectorUshort operator /(VectorUshort a, VectorUshort b)
        {
            VectorUshort temp = new VectorUshort();
            if (a.Length > b.Length)
            {
                temp.Resize(a.Length);
                for (uint i = 0; i < a.Length; i++)
                    temp[i] = a[i];
            }
            else
            {
                temp.Resize(b.Length);
                for (uint i = 0; i < b.Length; i++)
                    temp[i] = b[i];
            }

            for (uint i = 0; i < Math.Min(a.Length, b.Length); i++)
                temp[i] = (ushort)(a[i] / b[i]);

            return temp;
        }

        public static VectorUshort operator /(VectorUshort a, ushort b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] / b);
            return temp;
        }

        public static VectorUshort operator %(VectorUshort a, VectorUshort b)
        {
            VectorUshort temp = new VectorUshort();
            if (a.Length > b.Length)
            {
                temp.Resize(a.Length);
                for (uint i = 0; i < a.Length; i++)
                    temp[i] = a[i];
            }
            else
            {
                temp.Resize(b.Length);
                for (uint i = 0; i < b.Length; i++)
                    temp[i] = b[i];
            }

            for (uint i = 0; i < Math.Min(a.Length, b.Length); i++)
                temp[i] = (ushort)(a[i] % b[i]);

            return temp;
        }

        public static VectorUshort operator %(VectorUshort a, ushort b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] % b);
            return temp;
        }

        public static VectorUshort operator |(VectorUshort a, VectorUshort b)
        {
            VectorUshort temp = new VectorUshort();
            if (a.Length > b.Length)
            {
                temp.Resize(a.Length);
                for (uint i = 0; i < a.Length; i++)
                    temp[i] = a[i];
            }
            else
            {
                temp.Resize(b.Length);
                for (uint i = 0; i < b.Length; i++)
                    temp[i] = b[i];
            }

            for (uint i = 0; i < Math.Min(a.Length, b.Length); i++)
                temp[i] = (ushort)(a[i] | b[i]);

            return temp;
        }

        public static VectorUshort operator |(VectorUshort a, ushort b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] | b);
            return temp;
        }

        public static VectorUshort operator ^(VectorUshort a, VectorUshort b)
        {
            VectorUshort temp = new VectorUshort();
            if (a.Length > b.Length)
            {
                temp.Resize(a.Length);
                for (uint i = 0; i < a.Length; i++)
                    temp[i] = a[i];
            }
            else
            {
                temp.Resize(b.Length);
                for (uint i = 0; i < b.Length; i++)
                    temp[i] = b[i];
            }

            for (uint i = 0; i < Math.Min(a.Length, b.Length); i++)
                temp[i] = (ushort)(a[i] ^ b[i]);

            return temp;
        }

        public static VectorUshort operator ^(VectorUshort a, ushort b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] ^ b);
            return temp;
        }

        public static VectorUshort operator &(VectorUshort a, VectorUshort b)
        {
            VectorUshort temp = new VectorUshort();
            if (a.Length > b.Length)
            {
                temp.Resize(a.Length);
                for (uint i = 0; i < a.Length; i++)
                    temp[i] = a[i];
            }
            else
            {
                temp.Resize(b.Length);
                for (uint i = 0; i < b.Length; i++)
                    temp[i] = b[i];
            }

            for (uint i = 0; i < Math.Min(a.Length, b.Length); i++)
                temp[i] = (ushort)(a[i] & b[i]);

            return temp;
        }

        public static VectorUshort operator &(VectorUshort a, ushort b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] & b);
            return temp;
        }
                
        public static VectorUshort operator >>(VectorUshort a, int b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] >> b);
            return temp;
        }

        public static VectorUshort operator <<(VectorUshort a, int b)
        {
            VectorUshort temp = new VectorUshort(a.Length);
            for (uint i = 0; i < a.Length; i++)
                temp[i] = (ushort)(a[i] << b);
            return temp;
        }

        public static bool operator ==(VectorUshort a, VectorUshort b)
        {
            if (a.Length != b.Length)
                return false;
            for (uint i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        }

        public static bool operator !=(VectorUshort a, VectorUshort b)
        {
            return a == b ? false : true;
        }

        public static bool operator >(VectorUshort a, VectorUshort b)
        {
            if (a.Length != b.Length)
                return false;
            for (uint i = 0; i < a.Length; i++)
                if (a[i] <= b[i])
                    return false;
            return true;
        }

        public static bool operator >=(VectorUshort a, VectorUshort b)
        {
            if (a.Length != b.Length)
                return false;
            for (uint i = 0; i < a.Length; i++)
                if (a[i] < b[i])
                    return false;
            return true;
        }

        public static bool operator <(VectorUshort a, VectorUshort b)
        {
            if (a.Length != b.Length)
                return false;
            for (uint i = 0; i < a.Length; i++)
                if (a[i] >= b[i])
                    return false;
            return true;
        }

        public static bool operator <=(VectorUshort a, VectorUshort b)
        {
            if (a.Length != b.Length)
                return false;
            for (uint i = 0; i < a.Length; i++)
                if (a[i] > b[i])
                    return false;
            return true;
        }
                
    }
}