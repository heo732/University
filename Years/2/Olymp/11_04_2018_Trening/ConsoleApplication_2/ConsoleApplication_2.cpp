//#include <fstream>
#include <iostream>
#include <string>
//#include <vector>

using namespace std;

int main()
{
	long n;
	cin >> n;

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

	cout << n;

	system("pause");
	return 0;
}