#include <iostream>
#include <string>

using namespace std;

bool IsPolindrom(long long value)
{
	string line = to_string(value);
	for (int i = 0, j = line.length()-1; i < line.length(), j >= 0; i++, j--)
	{
		if(line[i] != line[j])
			return false;
	}
	return true;
}

int main()
{
	long long n;
	cin >> n;

	long long index = 1;
	long long value = 1;

	while(index < n)
	{
		value++;
		if(IsPolindrom(value))
			index++;		
	}

	cout << value;

	return 0;
}