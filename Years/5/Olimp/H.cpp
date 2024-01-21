#include <iostream>
#include <vector>

using namespace std;

bool IsPrime(long num)
{
    int d = 2;
    while (d * d <= num && num % d != 0)
    {
        d += 1;
    }
    return d * d > num;
}

int main()
{
    long a;
    long b;
    cin >> a;
    cin >> b;

    int count = 0;

    for (int i = a; i <= b; i++)
    {
        if (i % 2 == 0)
        {
            count++;
        }
        else
        {
            if ((i >=4 && IsPrime(i - 2)) || i == 3)
            {
                count++;
            }
        }
    }

    cout << count;
}