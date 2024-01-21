import com.sun.istack.internal.NotNull;

import java.util.Comparator;

public class Linear extends Root implements Comparable<Linear>
{

    protected double _a, _b;

    public Linear()
    {
        _a = 0;
        _b = 0;
    }

    public Linear(double a, double b)
    {
        _a = a;
        _b = b;
    }

    public Linear(@NotNull Linear other)
    {
        _a = other._a;
        _b = other._b;
    }

    public double getA()
    {
        return _a;
    }

    public double getB()
    {
        return _b;
    }

    public void setA(double a)
    {
        _a = a;
    }

    public void setB(double b)
    {
        _b = b;
    }

    @Override
    public double[] calculateRoot() throws Exception
    {
        if (_a == 0 && _b == 0)
            throw new Exception("Рівняння має безліч коренів");
        if (_a == 0)
            throw new Exception("Рівняння не має жодного кореня");
        return new double[] { _b / _a };
    }

    @Override
    public String toString()
    {
        String ret = "";
        ret = _a + " * x = " + _b;
        ret += System.getProperty("line.separator");
        try
        {
            ret += "x = " + calculateRoot()[0];
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
        if (obj instanceof Linear)
            if (_a == ((Linear) obj)._a && _b == ((Linear) obj)._b)
                ret = true;
        return ret;
    }

    @Override
    public int compareTo(@NotNull Linear another)
    {
        double[] thisX = new double[0];
        double[] anotherX = new double[0];

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

        if (thisX.length == 1 && anotherX.length == 1)
            return Double.compare(thisX[0], anotherX[0]);

        if (thisX.length == 1 && anotherX.length == 0)
            return 1;

        if (thisX.length == 0 && anotherX.length == 1)
            return -1;

        return 0;
    }

}