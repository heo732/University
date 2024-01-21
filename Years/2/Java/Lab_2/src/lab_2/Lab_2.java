package lab_2;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class Lab_2
{
    static private ArrayList<Integer> arrayInteger = new ArrayList<Integer>();
    static private ArrayList<Double> arrayDouble = new ArrayList<Double>();
    
    static boolean readArraysFromFile(String fileName)
    {
        try
            {
                BufferedReader inFile = new BufferedReader(new FileReader(fileName));                
                String line;
                
                while((line = inFile.readLine()) != null)
                {
                    try
                    {
                        arrayInteger.add(Integer.parseInt(line));
                    } 
                    catch(NumberFormatException ex)
                    {
                        try
                        {
                            arrayDouble.add(Double.parseDouble(line));
                        }
                        catch(NumberFormatException e) {}                        
                    }
                }
                
                inFile.close();
                return true;
            }
            catch(FileNotFoundException ex) 
            {
                System.out.print("Помилка. Файл не знайдено\n");
                return false;
            }
            catch(IOException ex)
            {
                System.out.print("Помилка читання файлу\n");
                return false;
            }
    }
    
    static boolean printArrayIntegerToFile(String fileName)
    {
        try
        {
            FileWriter outFile = new FileWriter(fileName);
            StringBuilder strB = new StringBuilder();
            Collections.sort(arrayInteger);
            for (Integer i : arrayInteger)
            {
                strB.append(i.toString()).append(System.getProperty("line.separator"));                
            }
            outFile.write(strB.toString());
            outFile.close();
            return true;
        }
        catch(IOException ex)
        {
           System.out.print("Помилка запису у файл <"+fileName+">\n");           
           return false;
        } 
    }
    
    static boolean printArrayDoubleToFile(String fileName)
    {
        try
        {
            FileWriter outFile = new FileWriter(fileName);
            StringBuilder strB = new StringBuilder();
            Collections.sort(arrayDouble);
            for (Double i : arrayDouble)
            {
                strB.append(i.toString()).append(System.getProperty("line.separator"));                
            }
            outFile.write(strB.toString());
            outFile.close();
            return true;
        }
        catch(IOException ex)
        {
           System.out.print("Помилка запису у файл <"+fileName+">\n");           
           return false;
        } 
    }
    
    public static long multOfInteger()
    {
        long mult = 1;
        for(Integer i : arrayInteger)
            mult *= i;
        return mult;
    }
    
    public static double sumOfDouble()
    {
        double sum = 0;
        for(Double i : arrayDouble)
            sum += i;
        return sum;
    }
    
    public static void main(String[] args)
    {        	
        System.out.print("JAVA | Lab_2 | Var_4\n\n");
        Scanner inConsole = new Scanner(System.in);
        String fileName;
        
        do
        {
            System.out.print("Введiть iм'я вхiдного файлу з числами: ");
            fileName = inConsole.next();
        }
        while(! readArraysFromFile(fileName));
        
        do
        {
            System.out.print("Введiть iм'я файлу для запису цiлих чисел: ");
            fileName = inConsole.next();
        }
        while(! printArrayIntegerToFile(fileName));
        
        do
        {
            System.out.print("Введiть iм'я файлу для запису дробових чисел: ");
            fileName = inConsole.next();
        }
        while(! printArrayDoubleToFile(fileName));
        
        inConsole.close();
        
        System.out.print("Сума дробових чисел: ");
        System.out.println(sumOfDouble());
        System.out.print("Добуток цiлих чисел: ");
        System.out.println(multOfInteger());
        
    }
}