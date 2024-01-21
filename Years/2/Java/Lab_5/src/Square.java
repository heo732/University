import com.sun.istack.internal.NotNull;
import static java.lang.Math.*;

public class Square extends Root implements Comparable<Square>
{

    protected double _a, _b, _c;

    public Square()
    {
        _a = 0;
        _b = 0;
        _c = 0;
    }

    public Square(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public Square(@NotNull Square other)
    {
        _a = other._a;
        _b = other._b;
        _c = other._c;
    }

    public double getA()
    {
        return _a;
    }

    public double getB()
    {
        return _b;
    }

    public double getC()
    {
        return _c;
    }

    public void setA(double a)
    {
        _a = a;
    }

    public void setB(double b)
    {
        _b = b;
    }

    public void setC(double c)
    {
        _c = c;
    }

    @Override
    public double[] calculateRoot() throws Exception
    {
        if (_a == 0)
        {
            if (_b == 0 && _c == 0)
                throw new Exception("Рівняння має безліч коренів");
            if (_b == 0)
                throw new Exception("Рівняння не має жодного кореня");
            return new double[] { -_c / _b };
        }

        if (_b == 0 && _c == 0)
        {
            return new double[] { 0 };
        }

        if (_c == 0)
        {
            return new double[] { 0, -_b / _a };
        }

        if (_b == 0)
        {
            if (-_c / _a < 0)
                throw new Exception("Рівняння не має жодного дійсного кореня");
            return new double[] { sqrt(-_c/_a), -sqrt(-_c/_a) };
        }

        double D = _b*_b - 4*_a*_c;

        if (D < 0)
            throw new Exception("Рівняння не має жодного дійсного кореня");
        if (D == 0)
            return new double[] { -_b / (2*_a) };
        return new double[] { (-_b + sqrt(D)) / (2*_a), (-_b - sqrt(D)) / (2*_a)};
    }

    @Override
    public String toString()
    {
        String ret = "";
        ret = _a + " * x^2 + " + _b + " * x + " + _c + " = 0";
        ret += System.getProperty("line.separator");

        try
        {
            double[] x = calculateRoot();
            if (x.length == 2)
            {
                ret += "x[1] = " + x[0];
                ret += System.getProperty("line.separator");
                ret += "x[2] = " + x[1];
            }
            else
            {
                ret += "x = " + x[0];
            }
        }
        catch (Exception ex)
        {
            ret += ex.getMessage();
        }

        return ret;
    }

    @Override
    public boolean equals(Object obj)
    {
        boolean ret = false;
        if (obj instanceof Square)
            if (_a == ((Square) obj)._a && _b == ((Square) obj)._b && _c == ((Square) obj)._c)
                ret = true;
        return ret;
    }

    @Override
    public int compareTo(Square another)
    {
        double[] thisX = new double[]{};
        double[] anotherX = new double[]{};

        String message1 = "", message2 = "";

        try
        {
            thisX = calculateRoot();
        }
        catch (Throwable ex)
        {
            message1 = ex.getMessage();
        }

        try
        {
            anotherX = another.calculateRoot();
        }
        catch (Throwable ex)
        {
            message2 = ex.getMessage();
        }

        if (thisX.length == 0 && anotherX.length == 0)
            return message1.compareTo(message2);

        if (thisX.length == 0 && anotherX.length == 1)
            return -1;

        if (thisX.length == 1 && anotherX.length == 0)
            return 1;

        if (thisX.length == 1 && anotherX.length == 1)
            return Double.compare(thisX[0], anotherX[0]);

        if (thisX.length == 2 && anotherX.length == 2)
            return Double.compare(thisX[0]+thisX[1], anotherX[0]+anotherX[1]);

        if (thisX.length == 1 && anotherX.length == 2)
            return -1;

        if (thisX.length == 2 && anotherX.length == 1)
            return 1;

        if (thisX.length == 0 && anotherX.length == 2)
            return -1;

        if (thisX.length == 2 && anotherX.length == 0)
            return 1;

        return 0;
    }
}