/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package task_4;

import java.util.Scanner;

/**
 *
 * @author heo
 */
public class Task_4
{
    
    static boolean IsPunct(char c)
    {
        if(" .,!?-+=_()[]{}<>;:".indexOf(c) != -1)
            return true;
        return false;
    }
    
    static String F1(String str_in)
    {
        String str = "";
        
        int index = 0;
        char mode = 0;/*0 - find begin of word; 1 - delete repeat of first letter*/
        char letter = 0;

        while(index < str_in.length())
        {
            while( index < str_in.length() && IsPunct(str_in.charAt(index)) )
            {
                str+=str_in.charAt(index);
                index++;
            }

            if ( index < str_in.length() )
            {
                letter = str_in.charAt(index);
                str+=letter;
                index++;
            }

            while( index < str_in.length() && !IsPunct(str_in.charAt(index)) && str_in.charAt(index)!=letter)
            {
                str+=str_in.charAt(index);
                index++;
            }
        }

        while(index < str_in.length())
        {
            switch(mode)
            {
                case 0:
                    if(!IsPunct(str_in.charAt(index)))
                    {
                        letter = str_in.charAt(index);
                        mode = 1;
                    }
                    str += str_in.charAt(index);
                    break;
                case 1:
                    if(IsPunct(str_in.charAt(index)))
                    {
                        str += str_in.charAt(index);
                        mode = 0;
                    }
                    else
                    {
                        if(str_in.charAt(index) != letter)
                            str += str_in.charAt(index);
                    }
                    break;
            }
            index++;
        }
        
        return str;
    }
    
    public static void main(String[] args)
    {
        Scanner in = new Scanner(System.in);
	    System.out.println("Input text:");
        String Text = in.nextLine();
        System.out.print("Result:\n");
        System.out.println(F1(Text));
        
        in.close();
    }
    
}
