#include <iostream>
#include <vector>

using namespace std;

bool Contains(vector<long> arr, long v)
{
    for (long i : arr)
    {
        if (i == v)
        {
            return true;
        }
    }
    return false;
}

bool IsSumOfPrimes(vector<long> primes, long target)
{
    for (int i = 0; i < primes.size(); i++)
    {
        long first = primes[i];
        long second = target - first;
        bool res = Contains(primes, second);
        if (res)
        {
            return true;
        }
    }
    return false;
}

vector<long> GetPrimes(long n)
{
    vector<long> primes = { 2, 3, 5, 7 };
    for (long i = 11; i <= n; i++)
    {
        bool  isPrime = true;
        for (long j : primes)
        {
            if (i % j == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
        {
            primes.push_back(i);
        }
        if (primes.size() > 350)
        {
            break;
        }
    }
    return primes;
}

int main()
{
    long a;
    long b;
    cin >> a;
    cin >> b;

    auto primes = GetPrimes(b - 2);

    long count = 0;
    for (int i = a; i <= b; i++)
    {
        if (IsSumOfPrimes(primes, i))
        {
            count++;
        }
    }

    cout << count;
}