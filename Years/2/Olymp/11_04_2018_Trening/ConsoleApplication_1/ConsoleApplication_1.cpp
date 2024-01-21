//#include <fstream>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

bool areRepeatInString(string str)
{
	for (unsigned int i = 0; i < str.length()-1; i++)
	{
		if(str[i] == str[i+1])
		{
			return true;
		}
	}
	return false;
}

int main()
{
	long n;
	cin >> n;

	

	n++;
	string str = to_string(n);
	if(areRepeatInString(str) == false)
		cout << n;
	else 
	{	
		long add = 1;
		int index = 1;
		for(int i = 0; i < str.length()-2; i++)
			add *= 10;
		for (int i = 0; i < str.length()-1; i++)
		{				
			if(str[i] == str[i+1])
				break;
			add /= 10;
			index++;
		}
		if(str[index] == '9' && str[index-1] == '9')
			n+= add*2;
		else
			n += add;
		index++;
		str = to_string(n);

		if(str.length() > 2)
		{
			char t = '0';
			if(str[index-1] == '0')
				t = '1';
			for (int i = index; i < str.length(); i++)
			{
				str[i] = t;
				switch (t)
				{
				case '0': t = '1'; break;
				case '1': t = '0'; break;
				}
			}
		}

		cout << str;

	}

	

	system("pause");
	return 0;
}

