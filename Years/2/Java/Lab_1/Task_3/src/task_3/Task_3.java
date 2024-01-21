/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package task_3;

import java.util.Scanner;

/**
 *
 * @author heo
 */
public class Task_3
{
    
    static Scanner in;
    
    static float [][] Input_Matrix(int n)
    {
        float [][]a = new float[n][n];
        System.out.print("Введiть матрицю А(n,n):\n");
        for(int i = 0; i < n; i++)
            for(int j = 0; j < n; j++)
            {
                boolean flag = false;
                while(flag == false)
                {   
                    System.out.print("a[" + (i+1) + "][" + (j+1) + "] = ");
                    try
                    {
                        a[i][j] = Float.parseFloat(in.nextLine());
                        flag = true;
                    }
                    catch(NumberFormatException e) {}
                }
                
            }
                
        return a;        
    }
    
    static void Print_Matrix(float[][] a)
    {
        for(int i = 0; i < a.length; i++)
        {
            for(int j = 0; j < a[i].length; j++)
                System.out.print(a[i][j] + " ");
            System.out.print("\n");
        }
    }
    
    static float[] Result_Vector(float[][] a)
    {
        float[] b = new float[a.length];
        for(int i = 0; i < a.length; i++)
        {
            float sum = 0;
            for(int j = 0; j < a[i].length; j++)
            {
                sum += a[i][j];
            }
            b[i] = sum / a[i].length;
        }
        return b;
    }
    
    static void Print_Vector(float[] b)
    {
        for(int i = 0; i < b.length; i++)
            System.out.print(b[i] + "\n");
    }
    
    public static void main(String[] args)
    {
        in = new Scanner(System.in);
        int n = 0;
        
        boolean flag = false;
        while(flag == false)
        {
            System.out.print("Введiть n: ");
            try
            {
                n = Integer.parseInt(in.nextLine());
                flag = true;
            }
            catch(NumberFormatException e) {}            
        }
        
        float[][] Matrix = Input_Matrix(n);
        System.out.print("\nПочаткова матриця:\n");
        Print_Matrix(Matrix);
        System.out.print("Вектор середнiх арифметичних значень рядкiв матрицi:\n");
        float[] Vector = Result_Vector(Matrix);
        Print_Vector(Vector);        
    }
    
}