#include <iostream>
#include <cstring>
#define LEN 100
#include <windows.h>
using namespace std;

bool isPunct(char a)
{
	char punct[]=".,!?:; -/[]{}()<>";
	int i;

	for(i=0;i<strlen(punct);i++)
	{
		if(a==punct[i])
		{
			return 1;
		}
	}
	return 0;
}

int main()
{
char s[LEN];
int len_s,i,start=-1,end=-1,slovo=0,j,q,z;
bool pos=0; // poch abo kinec slova shukaets9
bool vyluch=0; //peremyka4 na vydalenn9 povtornoho slova

SetConsoleCP(1251);
SetConsoleOutputCP(1251);

cout<<"/// 7. Vylu4enn9 povtornyh vhodzhen sliv ///"<<endl<<"Input Row: ";
cin.getline(s,LEN);
len_s=strlen(s);


for(i=0;i<len_s;i++)
{
	switch(pos)
	{
		case 0:
		{
			if(!(isPunct(s[i])))
			{
				start=i;
				end=i;
				pos=1;
				break;
			}
			else
				break;
		}
		case 1:
		{
			if(!(isPunct(s[i])))
			{
				end=i;
				break;
			}
			else
			{
				slovo=end-start;
				for(j=i;j<len_s;j++)
				{
					if(s[j]==s[start] && s[j+slovo]==s[end] && ((j+slovo==len_s-1)||(isPunct(s[j+slovo+1]))) && isPunct(s[j-1]))
					{
						q=0;
						for(z=j;z<=j+slovo;z++)
							if(s[z]==s[start+q])
							{
								vyluch=1;
								q++;
							}
							else
							{
								vyluch=0;
								break;
							}															
					}
					else
						continue;
					if(vyluch==1)
						{
							for(z=j;z<=j+slovo;z++)
								s[z]='\0';
							vyluch=0;
						}	
				}
				pos=0;
				break;
			}
		}
	}
}
cout<<"New Row:   ";
for(i=0;i<len_s;i++)
	if(s[i]=='\0')
		continue;
	else
		cout<<s[i];
cout<<endl;
system("pause");
return 0;
}
//---------------------------------------------------------------------------
 