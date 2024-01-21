#include <iostream>
#include <alloc.h>
#include <windows.h>
using namespace std;

double *a,*b;
int n,i,j,k,index;
bool *mitka;
char next;

void Input()
{
	cout<<"Введіть кількість елементів вхідного масиву: ";
	cin>>n;
	while(n<=0)
	{
		cout<<"Кількість елементів має бути додатнім числом. Введіть щераз: ";
		cin>>n;
	}

	cout<<"Введіть вхідний масив чисел: ";
	a=(double*)calloc(n,sizeof(double));
	for(i=0;i<n;i++)
		scanf("%lf",a+i);
}

void Do()
{
	k=0;
	mitka=(bool*)calloc(n,sizeof(bool));
	for(i=0;i<n-1;i++)
	{
		mitka[i]=false;
		for(j=i+1;j<n;j++)
			if(mitka[j]==false && a[j]==a[i])
			{
				mitka[i]=true;
				mitka[j]=true;
			}
		if(mitka[i]==true)
			k++;		
	}
	mitka[n-1]=false;
	b=(double*)calloc(k,sizeof(double));
	index=0;
	for(i=0;i<n;i++)
		if(mitka[i]==true)
		{
			b[index]=a[i];
			index++;
		}
}

void Output()
{	
	if(k>0)
	{
		cout<<endl<<"Вихідний масив чисел, що повторюються у вхідному масиві: ";
		for(i=0;i<k;i++)
			cout<<b[i]<<" ";	
	}
	else
		if(n==1)
			cout<<endl<<"В масиві з одного елемента повторення неможливі";
		else			
			cout<<endl<<"У вхідному масиві не повторюється жоден елемент";
	

	cout<<endl<<endl;	
	free(a);
	a=NULL;
	free(mitka);
	mitka=NULL;
	free(b);
	b=NULL;
}

int main()
{
SetConsoleCP(1251);
SetConsoleOutputCP(1251);

cout<<"     /////  Lab 4 _ Home 1 _ Var 4  /////"<<endl<<endl<<endl;
Input();
Do();
Output();

cout<<"Бажаєте продовжити? [Y/y]: ";
cin>>next;
while(next=='y' || next=='Y')
{
	Input();
	Do();
	Output();
	cout<<"Бажаєте продовжити? [Y/y]: ";
	cin>>next;
}
return 0;
}
//---------------------------------------------------------------------------
 