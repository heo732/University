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

string Lazha(long n)
{
	n++;
	string str = to_string(n);
	if(areRepeatInString(str) == false)
		return to_string(n);
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

		return str;

	}
}

long Bezotkaz(long n)
{
	bool flag = false;
	while(flag == false)
	{
		n++;
		string str = to_string(n);
		bool areRepeat = false;
		for (unsigned int i = 0; i < str.length()-1; i++)
		{
			if(str[i] == str[i+1])
			{
				areRepeat = true;
				break;
			}
		}
		if(areRepeat == false)
			flag = true;		
	}

	return n;
}

int main()
{
	long count;
	cout << "Count: ";
	cin >> count;

	cout << "Bezotkaz\tLazha" << endl;

	for (long i = 1; i <= count; i++)
	{
		cout << i << '\t' << Bezotkaz(i) << '\t' << Lazha(i);
		if(to_string(Bezotkaz(i)) != Lazha(i))
			break;
		/*if(to_string(Bezotkaz(i)) != Lazha(i))
			cout << "\t###";*/
		cout << endl;
	}

	

	system("pause");
	return 0;
}