import java.util.Comparator;

public class RootComparator implements Comparator<Root>
{

    public int compare(Root r1, Root r2)
    {
        double[] r1X = new double[]{};
        double[] r2X = new double[]{};

        String message1 = "", message2 = "";

        try
        {
            r1X = r1.calculateRoot();
        }
        catch (Throwable ex)
        {
            message1 = ex.getMessage();
        }

        try
        {
            r2X = r2.calculateRoot();
        }
        catch (Throwable ex)
        {
            message2 = ex.getMessage();
        }

        if (r1X.length == 0 && r2X.length == 0)
            return message1.compareTo(message2);

        if (r1X.length == 0 && r2X.length == 1)
            return -1;

        if (r1X.length == 1 && r2X.length == 0)
            return 1;

        if (r1X.length == 1 && r2X.length == 1)
            return Double.compare(r1X[0], r2X[0]);

        if (r1X.length == 2 && r2X.length == 2)
            return Double.compare(r1X[0]+r1X[1], r2X[0]+r2X[1]);

        if (r1X.length == 1 && r2X.length == 2)
            return -1;

        if (r1X.length == 2 && r2X.length == 1)
            return 1;

        if (r1X.length == 0 && r2X.length == 2)
            return -1;

        if (r1X.length == 2 && r2X.length == 0)
            return 1;

        return 0;
    }

}
