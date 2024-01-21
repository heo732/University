import com.sun.istack.internal.NotNull;

public class Linear1 implements IRoot
{

    protected double _a, _b;

    public Linear1()
    {
        _a = 0;
        _b = 0;
    }

    public Linear1(double a, double b)
    {
        _a = a;
        _b = b;
    }

    public Linear1(@NotNull Linear1 other)
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
        ret += '\n';
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
        if (obj instanceof Linear1)
            if (_a == ((Linear1) obj)._a && _b == ((Linear1) obj)._b)
                ret = true;
        return ret;
    }

}
