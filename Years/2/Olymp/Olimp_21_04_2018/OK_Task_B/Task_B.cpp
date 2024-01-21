#include <iostream>
#include <string>
#include <vector>
#include <list>

using namespace std;

int main()
{
	string inputLine;
	cin >> inputLine;
		
	unsigned long _max = 1;

	for (int i = 0; i < inputLine.length(); i++)
	{
		string sub;
		if(i < inputLine.length()-1)
			sub = inputLine.substr(0, i) + inputLine.substr(i+1, inputLine.length()-i-1);
		else
			sub = inputLine.substr(0, i);

		unsigned long value = atol(sub.c_str());

		if (value > _max)
			_max = value;
	}

	cout << _max;
	
	return 0;
}