package lab_3;

import java.util.Scanner;

public class Lab_3
{    
    private static Scanner in;
    
    public static void main(String[] args)
    {
        in = new Scanner(System.in);
        int a1 = getIntWithMessage("Введiть чисельник першого дробу: ");
        int b1 = getIntWithMessage("Введiть знаменник першого дробу: ");        
        int a2 = getIntWithMessage("Введiть чисельник другого дробу: ");
        int b2 = getIntWithMessage("Введiть знаменник другого дробу: ");
        in.close();
        
        Rational fraction1 = new Rational(a1, b1);
        Rational fraction2 = new Rational(a2, b2);
        
        System.out.println();
        System.out.println("Перший дрiб: " + fraction1.toString());
        System.out.println("Другий дрiб: " + fraction2.toString());
        
        System.out.println(fraction1.toString() + " + " + fraction2.toString()
        + " = " + fraction1.add(fraction2).toString());
        System.out.println(fraction1.toString() + " - " + fraction2.toString()
        + " = " + fraction1.subtract(fraction2).toString());
        System.out.println(fraction1.toString() + " * " + fraction2.toString()
        + " = " + fraction1.multiply(fraction2).toString());
        if(fraction2.toString().equals("0"))
            System.out.println(fraction1.toString() + " / " + fraction2.toString()
        + " = -");
        else
            System.out.println(fraction1.toString() + " / " + fraction2.toString()
        + " = " + fraction1.divide(fraction2).toString());
        
        System.out.println(fraction1.toString() + " == " + fraction2.toString()
        + " ?: " + fraction1.equal(fraction2));
        System.out.println(fraction1.toString() + " < " + fraction2.toString()
        + " ?: " + fraction1.less(fraction2));
    }   
    
    
    public static int getIntWithMessage(String message)
    {        
        boolean next = false;
        int ret = 0;
        while(next == false)
        {
            System.out.print(message);
            try
            {                
                String str = in.nextLine();
                ret = Integer.parseInt(str);
                next = true;
            }
            catch(NumberFormatException ex) {}
        }       
        return ret;
    }
}