#include <iostream>
#include <alloc.h>
#include <windows.h>
using namespace std;

double **a,elem,tmp;
int n,i,j,elem_i,elem_j;
char next;

void Input()
{
	cout<<"������ ����� ��������� �������: ";
	cin>>n;
	while(n<=0)
	{
		cout<<"����� �� ���� ����� �������� ������. ������ �����: ";
		cin>>n;
	}

	a=(double**)calloc(n,sizeof(double*));
	for(i=0;i<n;i++)
		a[i]=(double*)calloc(n,sizeof(double));
	cout<<"������ ������ �������: "<<endl;
	for(i=0;i<n;i++)
		for(j=0;j<n;j++)
			scanf("%lf",a[i]+j);	
}

void Output1()
{	
	cout<<endl<<endl<<"������� �������:"<<endl;
	for(i=0;i<n;i++)
	{
		for(j=0;j<n;j++)
			cout<<a[i][j]<<" ";
		cout<<endl;
	}


	cout<<endl;	
}

void Do()
{
	elem=a[0][0];
	for(i=0;i<n;i++)
		for(j=0;j<n;j++)
			if(a[i][j]>elem)
			{
				elem=a[i][j];
				elem_i=i;
				elem_j=j;
			}
	if(elem!=a[0][0])
	{
		if(elem_i==0 || elem_j==0)
			if(elem_i==0) //������������ �������
				for(i=0;i<n;i++)
				{
					tmp=a[i][0];
					a[i][0]=a[i][elem_j];
					a[i][elem_j]=tmp;
				}
			else          //������������ �����
				for(j=0;j<n;j++)
				{
					tmp=a[0][j];
					a[0][j]=a[elem_i][j];
					a[elem_i][j]=tmp;
				}	
		else
			{
				//������������ �������
				for(i=0;i<n;i++)
				{
					tmp=a[i][0];
					a[i][0]=a[i][elem_j];
					a[i][elem_j]=tmp;
				}
				Output1();
				//������������ �����
				for(j=0;j<n;j++)
				{
					tmp=a[0][j];
					a[0][j]=a[elem_i][j];
					a[elem_i][j]=tmp;
				}	
			}		
	}		
}

void Output2()
{	
	cout<<endl<<"������� �������:"<<endl;
	for(i=0;i<n;i++)
	{
		for(j=0;j<n;j++)
			cout<<a[i][j]<<" ";
		cout<<endl;
	}


	cout<<endl<<endl;
	for(i=0;i<n;i++)
	{
		free(a[i]);	
		a[i]=NULL;
	}
	free(a);
	a=NULL;
}

int main()
{
SetConsoleCP(1251);
SetConsoleOutputCP(1251);

cout<<"     /////  Lab 4 _ Home 2 _ Var 4  /////"<<endl<<endl<<endl;
Input();
Do();
Output2();

cout<<"������ ����������? [Y/y]: ";
cin>>next;
while(next=='y' || next=='Y')
{
	Input();
	Do();
	Output2();
	cout<<"������ ����������? [Y/y]: ";
	cin>>next;
}
return 0;
}
//--------------------------------------------------------------------------- 