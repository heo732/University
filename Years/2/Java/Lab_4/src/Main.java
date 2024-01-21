import java.util.Scanner;

public class Main
{

    public static void main(String[] args)
    {
        Scanner scanner = new Scanner(System.in);

        double a, b, c;

        System.out.println("Linear: a * x = b");
        System.out.println("Square: a * x^2 + b * x + c = 0");
        System.out.println("-----------------------------------------------");

        a = getDoubleWithMessage("a = ", scanner);
        b = getDoubleWithMessage("b = ", scanner);
        c = getDoubleWithMessage("c = ", scanner);
        System.out.println("-----------------------------------------------");

        Linear linear = new Linear(a, b);
        System.out.println(linear.toString());
        System.out.println("-----------------------------------------------");

        Square square = new Square(a, b, c);
        System.out.println(square.toString());
        System.out.println("-----------------------------------------------");

        IRoot iRoot = new Linear1(a, b);
        System.out.println(iRoot.toString());
        System.out.println("-----------------------------------------------");

        iRoot = new Square1(a, b, c);
        System.out.println(iRoot.toString());
        System.out.println("-----------------------------------------------");

        if (iRoot.equals(new Square1(a, b, c)))
            System.out.println("True");
        else
            System.out.println("False");
        System.out.println("-----------------------------------------------");

        scanner.close();
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