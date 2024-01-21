using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_2
{
    class Program
    {

        static int getIntBetweenWithMessage(int left, int right, String message)
        {
            bool flag = false;
            int choose = int.MaxValue;
            do
            {
                Console.Write(message);
                try
                {
                    choose = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception) { }
            }
            while (flag == false || choose < left || choose > right);
            return choose;
        }

        static int getIntWithMessage(String message)
        {
            bool flag = false;
            int value = 0;
            do
            {
                Console.Write(message);
                try
                {
                    value = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception) { }
            }
            while (flag == false);
            return value;
        }
        
        static float getFloatWithMessage(String message)
        {
            bool flag = false;
            float value = 0;
            do
            {
                Console.Write(message);
                try
                {
                    value = float.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception) { }
            }
            while (flag == false);
            return value;
        }

        static void chooseTask()
        {
            int task = getIntBetweenWithMessage(1, 4, "\nОберiть завдання [1|2|3|4]: ");            
            switch (task)
            {
                case 1: task1(); break;
                case 2: task2(); break;
                case 3: task3(); break;
                case 4: task4(); break;
            }
        }

        static void task1()
        {
            int task = getIntBetweenWithMessage(1, 2, "Ви працюватимете з одновимiрним масивом чи двовимiрним? [1|2]: ");                        
            switch (task)
            {
                case 1: task1_1(); break;
                case 2: task1_2(); break;
            }
        }

        static float[] inputArray_1()
        {
            int size = getIntBetweenWithMessage(1, int.MaxValue, "Введiть розмiр одновимiрного масиву: ");
            float[] array = new float[size];
            for (int i = 0; i < size; i++)
                array[i] = getFloatWithMessage("a["+i.ToString()+"] = ");
            return array;
        }

        static float[,] inputArray_2()
        {
            int size = getIntBetweenWithMessage(1, int.MaxValue, "Введiть розмiр двовимiрного масиву: ");
            float[,] array = new float[size,size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    array[i,j] = getFloatWithMessage("a[" + i.ToString() + "," + j.ToString() + "] = ");
            return array;
        }

        static int[][] inputArrayStairs()
        {
            int size = getIntBetweenWithMessage(1, int.MaxValue, "Введiть кiлькiсть рядкiв схiдчастого масиву: ");
            int[][] array = new int[size][];
            
            for (int i = 0; i < size; i++)
            {
                array[i] = new int[i + 1];
                for (int j = 0; j < array[i].Length; j++)
                    array[i][j] = getIntWithMessage("a[" + i.ToString() + "][" + j.ToString() + "] = ");
            }
                
            return array;
        }

        static void printArray(float[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0,5} ", array[i]);
            Console.Write("\n");
        }

        static void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0,5} ", array[i]);
            Console.Write("\n");
        }

        static void printArray(float[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++, Console.Write("\n"))
                for (int j = 0; j < array.GetLength(1); j++)    
                    Console.Write("{0,5} ", array[i,j]);
        }

        static void printArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++, Console.Write("\n"))
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write("{0,5} ", array[i][j]);
        }

        static void task1_1()
        {
            float[] array = inputArray_1();
            float key = getFloatWithMessage("Введiть число для порiвняння: ");
            Console.Write("\nВихiдний масив:\n");
            printArray(array);
            for (int i = 0; i < array.Length; i++)
                if (array[i] < key)
                    array[i] *= 2;
            Console.Write("Всi елементи, меншi заданого числа, збiльшено в два рази.\n");
            Console.Write("Результат:\n");
            printArray(array);
        }

        static void task1_2()
        {
            float[,] array = inputArray_2();
            float key = getFloatWithMessage("Введiть число для порiвняння: ");
            Console.Write("\nВихiдний масив:\n");
            printArray(array);
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i,j] < key)
                        array[i,j] *= 2;
            Console.Write("Всi елементи, меншi заданого числа, збiльшено в два рази.\n");
            Console.Write("Результат:\n");
            printArray(array);
        }

        static void task2()
        {
            float[] array = inputArray_1();
            Console.Write("\nВихiдний масив:\n");
            printArray(array);
            float max = array[0];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            array[index] = array[0];
            array[0] = max;
            Console.Write("Помiняно мiсцями максимальний елемент i перший.\n");
            Console.Write("Результат:\n");
            printArray(array);
        }

        static void task3()
        {
            float[,] array = inputArray_2();
            Console.Write("\nВихiдний масив:\n");
            printArray(array);
            float sum = 0;
            int cnt = 0;
            if(array.Length > 1)
                for (int i = 1; i < array.GetLength(0); i++)
                    for (int j = 0; j < i; j++)
                    {
                        sum += array[i, j];
                        cnt++;
                    }                    
            if(cnt != 0)
                sum /= cnt;
            Console.Write("Середнє арифметичне елементiв, розташованих пiд побiчною дiагоналлю: "+sum.ToString()+"\n");            
        }

        static void task4()
        {
            int[][] array = inputArrayStairs();
            Console.Write("\nВихiдний масив:\n");
            printArray(array);
            int[] arraySum = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    if (array[i][j] % 2 == 0 && array[i][j] > 0)
                        arraySum[j] += array[i][j];
            Console.Write("Для кожного стовпця пiдраховано суму парних додатних елементiв:\n");
            printArray(arraySum);
        }

        static void Main(string[] args)
        {
            Console.Write("C# | Lab_2 | Var_4\n\n");
            int next = 1;
            do
            {
                chooseTask();
                next = getIntBetweenWithMessage(0, 1, "Бажаєте продовжити? [0|1]: ");
            }
            while(next == 1);
        }
    }
}
