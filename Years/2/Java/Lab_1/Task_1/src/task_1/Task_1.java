/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package task_1;

import java.util.Scanner;
import java.io.*;

/**
 *
 * @author heo
 */
public class Task_1 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        
        Scanner in = new Scanner(System.in);
        float a_float = 0, b_float = 0;
        int a_int = 0, b_int = 0;
        
        boolean flag = false;
        while(flag == false)
        {
            try
            {
                System.out.print("Input a: ");
                a_float = Float.parseFloat(in.nextLine());
                flag = true;
            }
            catch(NumberFormatException e) {}
        }
        
        flag = false;
        while(flag == false)
        {
            try
            {
                System.out.print("Input b: ");
                b_float = Float.parseFloat(in.nextLine());
                flag = true;
            }
            catch(NumberFormatException e) {}
        }
                
        a_int = (int) a_float;
        b_int = (int) b_float;
                
        System.out.print("\n\n1) float -> float : ");
        System.out.print(res_float(a_float, b_float));
        System.out.print("\n2) int -> float : ");
        System.out.print(res_float(a_int, b_int));
        System.out.print("\n3) float -> int : ");
        System.out.print(res_int(a_float, b_float));
        System.out.print("\n");
    }
    //--------------------------------------------------------------------------
    public static float res_float(float a, float b){
        
        float ret = 0;
        
        if(a*b*b - 2*b != 0 && 3*a*a + 2 != 0){
			
            ret = (a*b - (a+b)*(a-b)) / (b*b*b*b + a*a*a) + 5*b;
        }
        
        return ret;
    }
    
    public static float res_float(int a, int b){
        
        float ret = 0;
        
        if(b*b*b*b + a*a*a != 0){
            ret = (a*b - (a+b)*(a-b)) / (b*b*b*b + a*a*a) + 5*b;
        }
        
        return ret;
    }
    
    public static int res_int(float a, float b){
        
        float ret = 0;
        
        if(b*b*b*b + a*a*a != 0){
            ret =  (a*b - (a+b)*(a-b)) / (b*b*b*b + a*a*a) + 5*b;
        }
        
        return (int) ret;
    } 
    
}
