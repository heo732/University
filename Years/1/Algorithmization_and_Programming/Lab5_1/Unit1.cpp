//---------------------------------------------------------------------------
#pragma hdrstop
#pragma argsused
#include <iostream>
using namespace std;
#include <alloc.h>
#include <windows.h>
#include <stdio.h>
//---------------------------------------------------------------------------
typedef struct
{
	char name[30];
	int seans;
	int tiket;
	double count_per_seans;	
}TMovie;
//---------------------------------------------------------------------------
void FSort(TMovie *&a,int n)
{
	int i,j;
	TMovie tmp;
	
	for(i=n-1;i>0;i--)
		for(j=0;j<i;j++)
			if(a[j].count_per_seans<a[i].count_per_seans)
			{
				tmp=a[j];
				a[j]=a[i];
				a[i]=tmp;
			}		
}
//---------------------------------------------------------------------------
int main()
{
SetConsoleCP(1251);
SetConsoleOutputCP(1251);

TMovie *arrMovie;
int i,n;

cout<<"������ ����� ������: ";
cin>>n;
while(n<1)
{
	cout<<"����� �� ���� ����� ������� ������! ������ �����: ";
	cin>>n;
}

arrMovie=(TMovie*)calloc(n,sizeof(TMovie));
for(i=0;i<n;i++)
{
	cout<<"������ ["<<i+1<<"] �����:"<<endl<<"( Գ��� | ������ | ������ )"<<endl;
	scanf("%s",&arrMovie[i].name);
	scanf("%d%d",&arrMovie[i].seans,&arrMovie[i].tiket);
	arrMovie[i].count_per_seans=arrMovie[i].tiket/arrMovie[i].seans;
}

cout<<endl<<"������� �����:"<<endl<<"( Գ��� | ������ | ������ | ������ ���������� )"<<endl;
for(i=0;i<n;i++)
{	
	cout<<arrMovie[i].name<<" "<<arrMovie[i].seans<<" "<<arrMovie[i].tiket<<" "<<arrMovie[i].count_per_seans<<endl;
}
cout<<endl;

FSort(arrMovie,n);

cout<<endl<<"������������� �� ���������� ����������:"<<endl<<"( Գ��� | ������ | ������ | ������ ���������� )"<<endl;
for(i=0;i<n;i++)
{	
	cout<<arrMovie[i].name<<" "<<arrMovie[i].seans<<" "<<arrMovie[i].tiket<<" "<<arrMovie[i].count_per_seans<<endl;
}
cout<<endl;

system("pause");
return 0;
}
//--------------------------------------------------------------------------- 