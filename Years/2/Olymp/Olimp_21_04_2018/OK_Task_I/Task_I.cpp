#include <iostream>

using namespace std;

int main()
{
	long long rows, cols;
	cin >> rows >> cols;


	if (rows > cols)
	{
		long long temp = cols;
		cols = rows;
		rows = temp;
	}


	
	long long vertical, horizontal;
	vertical = rows - 1;
	horizontal = cols - 2;

	long long count = 0;
		
	while(horizontal >= 1 && vertical >= 1)
	{
		//up
		if(vertical >= 1)
			count += vertical;
		else
			break;
		vertical--;
		//right
		if(horizontal >= 1)
			count += horizontal;
		else 
			break;
		horizontal--;
		//down
		if(vertical >= 1)
			count += vertical;
		else
			break;
		vertical--;
		//left
		if(horizontal >= 1)
			count += horizontal;
		else
			break;
		horizontal--;

	}

	if (rows == cols && rows%2==0 && cols%2==0)
		count++;

	cout << count;
	
	return 0;
}