import java.util.Comparator;

public class PoemsComparator implements Comparator<String>
{

    public int compare(String s1, String s2)
    {
        if (s1.length() == s2.length())
            return s1.compareTo(s2);
        return s1.length() > s2.length() ? 1 : -1;
    }

}
