#include <iostream>
#include <vector>

using namespace std;

unsigned short myLess(unsigned int a, unsigned int b)
{
	return a <= b ? 0 : 1;
}

unsigned short myMore(unsigned int a, unsigned int b)
{
	return a >= b ? 0 : 1;
}

int main()
{
	unsigned int in;
	unsigned int i[4];

	cin >> in;
	i[0] = in / 1000;
	i[1] = in / 100 - i[0]*10;
	i[2] = in / 10 - i[0]*100 - i[1]*10;
	i[3] = in -  i[0]*1000 - i[1]*100 - i[2]*10;

	vector<unsigned short> _min, _max;
	unsigned short min1, min2, min3, min4, max1, max2, max3, max4;
	//----------------------------------------------------------------
	min1 = myLess(i[myLess(i[0],i[1])], i[myLess(i[2],i[3])+2]) == 0 ? myLess(i[0],i[1]) : myLess(i[2],i[3])+2;
		
	for (int i = 0; i < 4; i++)
	{
		if (i != min1)
			_min.push_back(i);
	}

	min2 = myLess(i[myLess(i[_min[0]],i[_min[1]])==0?_min[0]:_min[1]], i[_min[2]]) == 0 ? myLess(i[_min[0]],i[_min[1]])==0?_min[0]:_min[1] : _min[2];
	
	_min.clear();

	for (int i = 0; i < 4; i++)
	{
		if (i != min1 && i != min2)
			_min.push_back(i);
	}

	min3 = myLess(i[_min[0]],i[_min[1]]) == 0 ? _min[0] : _min[1];

	_min.clear();

	for (int i = 0; i < 4; i++)
	{
		if (i != min1 && i != min2 && i != min3)
			_min.push_back(i);
	}

	min4 = _min[0];
	//----------------------------------------------------
	max1 = myMore(i[myMore(i[0],i[1])], i[myMore(i[2],i[3])+2]) == 0 ? myMore(i[0],i[1]) : myMore(i[2],i[3])+2;
		
	for (int i = 0; i < 4; i++)
	{
		if (i != max1)
			_max.push_back(i);
	}

	max2 = myMore(i[myMore(i[_max[0]],i[_max[1]])==0?_max[0]:_max[1]], i[_max[2]]) == 0 ? myMore(i[_max[0]],i[_max[1]])==0?_max[0]:_max[1] : _max[2];
	
	_max.clear();

	for (int i = 0; i < 4; i++)
	{
		if (i != max1 && i != max2)
			_max.push_back(i);
	}

	max3 = myMore(i[_max[0]],i[_max[1]]) == 0 ? _max[0] : _max[1];

	_max.clear();

	for (int i = 0; i < 4; i++)
	{
		if (i != max1 && i != max2 && i != max3)
			_max.push_back(i);
	}

	max4 = _max[0];
	//----------------------------------------------------
	if (i[min1] == 0)
	{
		if (i[min2] == 0)
		{
			if (i[min3] == 0)
			{
				unsigned short temp = min4;
				min4 = min1;
				min1 = temp;
			}
			else
			{
				unsigned short temp = min3;
				min3 = min1;
				min1 = temp;
			}
		}
		else
		{
			unsigned short temp = min2;
			min2 = min1;
			min1 = temp;
		}
	}		
	//----------------------------------------------------
	cout << i[min1] << i[min2] << i[min3] << i[min4] << " " << i[max1] << i[max2] << i[max3] << i[max4];

	//system("pause");
	return 0;
}

