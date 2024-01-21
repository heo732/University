#include <iostream>
#include <string>

using namespace std;

int main()
{
	string word1, word2;
	cin >> word1;
	cin >> word2;

	if(word1.length() > word2.length())
	{
		string temp = word1;
		word1 = word2;
		word2 = temp;
	}

	for (int i = 0; i < word1.length()-word2.length(); i++)
	{
		word1 = '8' + word1;
	}

	unsigned int count = 0;
	for (int i = word1.length()-1; i >= 0; i--)
	{
		if (word1[i] != word2[i])
			break;
		else
			count++;
	}

	cout << count;

	system("pause");
	return 0;
}