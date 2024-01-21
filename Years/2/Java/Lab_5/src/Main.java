import com.sun.org.apache.xml.internal.serialize.LineSeparator;

import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class Main
{

    public static void main(String[] args)
    {
        System.out.println("------------------------------------------------------------");
        System.out.println("Task_1");
        System.out.println("------------------------------------------------------------");

	    Scanner file1 = null, file2 = null;
	    FileWriter fileOut = null;

	    ArrayList<Linear> linearList = new ArrayList<Linear>();
	    ArrayList<Square> squareList = new ArrayList<Square>();

	    try
        {
            file1 = new Scanner(new FileReader("Linear.txt"));
            file2 = new Scanner(new FileReader("Square.txt"));

            Linear linear;
            Square square;

            while (file1.hasNextLine()) {
                String[] values = file1.nextLine().split(" ");
                linear = new Linear(Double.parseDouble(values[0]), Double.parseDouble(values[1]));
                linearList.add(linear);
            }
            while (file2.hasNextLine()) {
                String[] values = file2.nextLine().split(" ");
                square = new Square(Double.parseDouble(values[0]), Double.parseDouble(values[1]), Double.parseDouble(values[2]));
                squareList.add(square);
            }

            file1.close();
            file2.close();

            for(Linear i : linearList)
                System.out.println(i.toString() + "\n--------------------");
            System.out.println("\n--------------------");
            for(Square i : squareList)
                System.out.println(i.toString() + "\n--------------------");

            System.out.println("------------------------------------------------------------");
            System.out.println("Sort");
            System.out.println("------------------------------------------------------------");

            Collections.sort(linearList);
            Collections.sort(squareList);

            for(Linear i : linearList)
                System.out.println(i.toString() + "\n--------------------");
            System.out.println("\n--------------------");
            for(Square i : squareList)
                System.out.println(i.toString() + "\n--------------------");

            System.out.println("------------------------------------------------------------");
            System.out.println("Add and Sort");
            System.out.println("------------------------------------------------------------");

            double a, b, c;
            Scanner console = new Scanner(System.in);
            a = getDoubleWithMessage("a = ", console);
            b = getDoubleWithMessage("b = ", console);
            c = getDoubleWithMessage("c = ", console);
            linearList.add(new Linear(a, b));
            squareList.add(new Square(a, b, c));

            Collections.sort(linearList);
            Collections.sort(squareList);

            System.out.println("\n--------------------");
            for(Linear i : linearList)
                System.out.println(i.toString() + "\n--------------------");
            System.out.println("\n--------------------");
            for(Square i : squareList)
                System.out.println(i.toString() + "\n--------------------");

            System.out.println("------------------------------------------------------------");
            System.out.println("------------------------------------------------------------");

            linearList.remove(new Linear(a, b));
            squareList.remove(new Square(a, b, c));

            ArrayList<Root> rootList = new ArrayList<Root>();

            for (Linear i : linearList)
                rootList.add(i);
            for (Square i : squareList)
                rootList.add(i);

            Collections.sort(rootList, new RootComparator());

            fileOut = new FileWriter("RootList.txt");
            for (Root i : rootList)
                fileOut.write(i.toString() + System.getProperty("line.separator") + "--------------------" + System.getProperty("line.separator"));
            fileOut.close();

            System.out.println("Sort Root list saved in file 'RootList.txt'");
            System.out.println("------------------------------------------------------------");
            System.out.println("------------------------------------------------------------");
            System.out.println("Task_2");
            System.out.println("------------------------------------------------------------");

            ArrayList<String> poemsList = new ArrayList<String>();

            file1 = new Scanner(new FileReader("Poems.txt"));

            while (file1.hasNextLine())
                poemsList.add(file1.nextLine());
            file1.close();

            Collections.sort(poemsList, new PoemsComparator());

            fileOut = new FileWriter("PoemsSort.txt");
            for (String i : poemsList)
                fileOut.write(i.toString() + System.getProperty("line.separator"));
            fileOut.close();

            System.out.println("Poems list from file 'Poems.txt' was sorted and saved into file 'PoemsSort.txt'");
            System.out.println("------------------------------------------------------------");
        }
        catch (Throwable ex)
        {
            System.out.println(ex.getMessage());
        }
        finally
        {
	        file1.close();
            file2.close();
        }


    }

    public static double getDoubleWithMessage(String message, Scanner scanner)
    {
        boolean next = false;
        double ret = 0;
        while(next == false)
        {
            System.out.print(message);
            try
            {
                String str = scanner.nextLine();
                ret = Double.parseDouble(str);
                next = true;
            }
            catch(NumberFormatException ex) {}
        }
        return ret;
    }

}
