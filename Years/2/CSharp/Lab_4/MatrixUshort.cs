using System;

namespace Lab_4
{
    class MatrixUshort
    {
        protected ushort[,] ShortIntArray;
        protected int n, m;
        protected int codeError = 0;
        protected static int num_m = 0;

        public MatrixUshort()
        {
            ShortIntArray = new ushort[1,1];
            n = 1;
            m = 1;
            num_m++;
        }

        public MatrixUshort(int rows, int cols)
        {
            n = rows;
            m = cols;
            ShortIntArray = new ushort[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ShortIntArray[i, j] = 0;
                }
            }
            num_m++;
        }

        public MatrixUshort(int rows, int cols, ushort value)
        {
            n = rows;
            m = cols;
            ShortIntArray = new ushort[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ShortIntArray[i, j] = value;
                }
            }
            num_m++;
        }

        ~MatrixUshort()
        {
            Console.WriteLine("Деструктор класу MatrixUshort");
            num_m--;
        }

        public void Resize(int size1, int size2)
        {
            ShortIntArray = new ushort[size1, size2];
            n = size1;
            m = size2;
            for (int i = 0; i < size1; i++)
                for (int j = 0; j < size2; j++)
                    ShortIntArray[i,j] = 0;
        }

        public void Read()
        {
            int size1 = 0, size2 = 0;
            Console.Write("Введіть розміри матриці: ");
            char[] separator = new char[] { ' ', '\t' };
            string[] sizes = Console.ReadLine().Split(separator);
            size1 = int.Parse(sizes[0]);
            size2 = int.Parse(sizes[1]);
            if (size1 > 0 && size2 > 0)
            {
                Resize(size1, size2);
                Console.WriteLine("Введіть елементи матриці:");
                for (int i = 0; i < size1; i++)
                {
                    string[] elems = Console.ReadLine().Split(separator);
                    for (int j = 0; j < size2; j++)
                    {
                        ShortIntArray[i,j] = ushort.Parse(elems[j]);
                    }    
                }                
            }
        }

        public void Write(string str = "")
        {
            Console.WriteLine(str);
            for (int i = 0; i < n; i++, Console.WriteLine())
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,4} ", ShortIntArray[i,j]);
                }
            }
        }

        public void Assign(ushort value)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ShortIntArray[i,j] = value;    
                }                
            }
        }

        public int CountMatrix()
        {
            return num_m;
        }

        public int RowCount
        {
            get
            {
                return n;
            }
        }

        public int ColCount
        {
            get
            {
                return m;
            }
        }

        public int Error
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

        public ushort this[int i, int j]
        {
            get
            {
                if (i >= n || j >= m || i < 0 || j < 0)
                {
                    codeError = 1;
                    return 0;
                }
                return ShortIntArray[i, j];
            }
            set
            {
                if (i >= n || j >= m || i < 0 || j < 0)
                    codeError = 1;
                else
                    ShortIntArray[i, j] = value;
            }
        }

        public ushort this[int k]
        {
            get
            {
                if (k < 0 || k >= n*m)
                {
                    codeError = 1;
                    return 0;
                }
                return ShortIntArray[k/m, k%m];
            }
            set
            {
                if (k < 0 || k >= n * m)
                    codeError = 1;
                else
                    ShortIntArray[k/m, k%m] = value;
            }
        }

        public static MatrixUshort operator ++(MatrixUshort a)
        {
            MatrixUshort temp = new MatrixUshort(a.n, a.m);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    temp[i, j] = (ushort)(a[i, j] + 1);
                }
            }
            return temp;
        }

        public static MatrixUshort operator --(MatrixUshort a)
        {
            MatrixUshort temp = new MatrixUshort(a.n, a.m);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    temp[i, j] = (ushort)(a[i, j] - 1);
                }
            }
            return temp;
        }

        public static bool operator true(MatrixUshort a)
        {
            if (a.n != 0 && a.m != 0)
                return true;
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    if (a[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        public static bool operator false(MatrixUshort a)
        {
            if (a.n != 0 && a.m != 0)
                return false;
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    if (a[i, j] == 0)
                        return true;
                }
            }
            return false;
        }

        public static MatrixUshort operator *(MatrixUshort a, MatrixUshort b)
        {
            if (a.m != b.n)
                throw new Exception("Помилка множення. Матриці не узгоджені");
            MatrixUshort temp = new MatrixUshort(a.n, a.m);
            for(int i = 0; i < a.n; i++)
                for(int j = 0; j < b.m; j++)
                    for(int q = 0; q < a.n; q++)
                        temp[i, j] += (ushort)(a[i, q] * b[q, j]);
            return temp;
        }

        public static MatrixUshort operator *(MatrixUshort a, VectorUshort b)
        {
            if (a.m == 1)
            {
                MatrixUshort temp = new MatrixUshort(a.n, (int)b.Length);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < b.Length; j++)
                        temp[i, j] += (ushort)(a[i, 0] * b[(uint)j]);
                return temp;
            }

            if (a.m == b.Length)
            {
                MatrixUshort temp = new MatrixUshort(a.n, 1);
                for (int i = 0; i < a.n; i++)
                    for (int q = 0; q < a.m; q++)
                        temp[i, 0] += (ushort)(a[i, q] * b[(uint)q]);
                return temp;
            }

            return new MatrixUshort();
        }

        public static MatrixUshort operator *(MatrixUshort a, ushort b)
        {
            MatrixUshort temp = new MatrixUshort(a.n, a.m);
            for (int i = 0; i < temp.n; i++)
                for (int j = 0; j < temp.m; j++)
                    temp[i, j] = (ushort)(a[i, j] * b);
            return temp;  
        }
        /*
        MatrixShort MatrixShort::operator *(short& a){
  MatrixShort temp(*this);

  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] *= a;

  return temp;    
}
        */

    }
}