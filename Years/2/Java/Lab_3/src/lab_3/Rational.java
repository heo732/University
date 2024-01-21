package lab_3;

public class Rational
{
    private int _a, _b;
    
    public Rational()
    {
        _a = 1;
        _b = 1;
        reduce();
    }
    
    public Rational(int a, int b)
    {
        _a = a;
        _b = (b != 0) ? b : 1;
        reduce();
    }
    
    public Rational(Rational t)
    {
        _a = t._a;
        _b = t._b;
    }
    
    public void setNumerator(int a)
    {
        _a = a;
        reduce();
    }
    
    public void setDenominator(int b)
    {
        _b = (b != 0) ? b : 1;
        reduce();
    }
    
    public int getNumerator()
    {
        return _a;
    }
    
    public int getDenominator()
    {
        return _b;
    }
    
    @Override
    public String toString()
    {
        String sign = (_a * _b < 0) ? "-" : "";
        
        if(_a == 0)
            return "0";
        if(Math.abs(_b) == 1)
            return sign + Integer.toString(Math.abs(_a));
        
        return sign + Integer.toString(Math.abs(_a)) + "/" + Integer.toString(Math.abs(_b));
    }
    
    public boolean equal(Rational t)
    {
        return this.toString().equals(t.toString());
    }
    
    /*private void reduce()
    {
        if(_a != 0)    
        {    
            int[] primeNumbers = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 
                37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 
                107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 
                179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 
                251, 257, 263, 269, 271};

            int index = 0;
            while(index < primeNumbers.length)
            {
                if(_a % primeNumbers[index] == 0 && _b % primeNumbers[index] == 0)
                {
                    _a /= primeNumbers[index];
                    _b /= primeNumbers[index];
                    index--;
                }
                index++;
            }
        }    
    }*/

    int NSD(int a, int b)
    {
        if(a % b == 0)
            return b;
        return NSD(b, a%b);
    }

    private void reduce()
    {
        int d = NSD(_a, _b);
        _a /= d;
        _b /= d;
    }
    
    public Rational multiply(Rational t)
    {
        Rational ret = new Rational(this);
        ret._a *= t._a;
        ret._b *= t._b;
        ret.reduce();
        return ret;
    }
    
    public Rational divide(Rational t)
    {
        Rational ret = new Rational(this);
        ret._a *= t._b;
        ret._b *= t._a;
        ret.reduce();
        return ret;
    }
    
    public Rational add(Rational t)
    {
        Rational r1 = new Rational(this);
        Rational r2 = new Rational(t);
        r1._a = (r1._a*r1._b < 0) ? -Math.abs(r1._a) : Math.abs(r1._a);
        r2._a = (r2._a*r2._b < 0) ? -Math.abs(r2._a) : Math.abs(r2._a);                
        r1._b = Math.abs(r1._b);        
        r2._b = Math.abs(r2._b);
        
        if(r1._b == r2._b)
        {
            return new Rational(r1._a + r2._a, r1._b);
        }   
        else
        {
            return new Rational(r1._a*r2._b + r2._a*r1._b, r1._b*r2._b);
        }
    }
    
    public Rational subtract(Rational t)
    {
        Rational r1 = new Rational(this);
        Rational r2 = new Rational(t);
        r1._a = (r1._a*r1._b < 0) ? -Math.abs(r1._a) : Math.abs(r1._a);
        r2._a = (r2._a*r2._b < 0) ? -Math.abs(r2._a) : Math.abs(r2._a);                
        r1._b = Math.abs(r1._b);        
        r2._b = Math.abs(r2._b);
        
        if(r1._b == r2._b)
        {
            return new Rational(r1._a - r2._a, r1._b);
        }   
        else
        {
            return new Rational(r1._a*r2._b - r2._a*r1._b, r1._b*r2._b);
        }
    }
    
    public boolean less(Rational t)
    {
        Rational r1 = new Rational(this);
        Rational r2 = new Rational(t);
        r1._a = (r1._a*r1._b < 0) ? -Math.abs(r1._a) : Math.abs(r1._a);
        r2._a = (r2._a*r2._b < 0) ? -Math.abs(r2._a) : Math.abs(r2._a);                
        r1._b = Math.abs(r1._b);        
        r2._b = Math.abs(r2._b);
        
        if(r1._b != r2._b)
        {
            r1._a *= r2._b;
            r2._a *= r1._b;
        } 
        
        return (r1._a < r2._a);
    }
    
}