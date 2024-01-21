/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package task_2;

import java.util.Scanner;

/**
 *
 * @author heo
 */ 
public class Task_2
{

    static Scanner in;
    
    static float [] Input()
    {        
        boolean flag = false;
        int n = 0;
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
        
        
        float []arr = new float[n*2];
        for(int i = 0; i < n*2; i++)
        {
            flag = false;
            while(flag == false)
            {
                System.out.print("a[" + (i+1) + "] = ");                                
                try
                {
                    arr[i] = Float.parseFloat(in.nextLine());
                    flag = true;
                }
                catch(NumberFormatException e) {}                        
            }
        }
        return arr;
    }
    
    static void Print(float[] arr)
    {
        for(int i = 0; i < arr.length; i++)
        {
            System.out.print(arr[i] + " ");
            if(i == arr.length/2 - 1)
                System.out.print("| ");        
        }            
        System.out.print("\n");
    }
            
    public static void main(String[] args)
    {
        in = new Scanner(System.in);
        float []arr = Input();
        System.out.print("\nПочатковий масив: ");
        Print(arr);
        
        float avarage = 0;
        for(int i = 0; i < arr.length/2; i++)
            avarage += arr[i];
        avarage /= arr.length/2;
        
        float sum = 0;
        for(int i = arr.length/2; i < arr.length; i++)
            if(arr[i] > avarage)
                sum += arr[i];
        
        System.out.print("Середнє арифметичне значення чисел A(1)..A(n) = " + avarage + "\n");
        System.out.print("Сума тих чисел iз A(n+1)..A(2n), якi перевищують середнє арифметичне = " + sum + "\n");        
    }
    
}
