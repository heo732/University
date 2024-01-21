#include <iostream>
#include <alloc.h>
#include <math.h>
#include <windows.h>
using namespace std;

double **a,f_max;
int m,n,i,j;
bool *j_max;

void FindMax()
{
	f_max=a[0][0];
	for(i=0;i<m;i++)
		for(j=0;j<n;j++)
			if(fabs(a[i][j])>f_max)				
				f_max=fabs(a[i][j]);
	for(i=0;i<m;i++)
		for(j=0;j<n;j++)
			if(fabs(a[i][j])==f_max)
				j_max[j]=true;			
}

void SortCols()
{
	int I,q;
	double tmp;
	for(j=0;j<n;j++)
		if(j_max[j]==true)
			for(i=0;i<m-1;i++)
			{
				I=i;
				for(q=i+1;q<m;q++)
					if(a[I][j]<a[q][j])
						I=q;
				tmp=a[I][j];
				a[I][j]=a[i][j];	
				a[i][j]=tmp;
			}	
	free(j_max);
	j_max=NULL;		
}

void PrintMatrix()
{
	for(i=0;i<m;i++)
	{
		for(j=0;j<n;j++)
			cout<<a[i][j]<<" ";
	free(a[i]);
	a[i]=NULL;	
	cout<<endl;
	}
	free(a);
	a=NULL;
}

int main()
{
SetConsoleCP(1251);
SetConsoleOutputCP(1251);	

cout<<"       /////  Lab 3 _ Home _ Var 4  /////"<<endl<<endl<<endl;
cout<<"������ ������ ������� (m,n): ";
cin>>m>>n;
while(m<=0 || n<=0)
{
	cout<<"������ ����� ���� ��������� �������. ������ �� �����: ";
	cin>>m>>n;
}

a=(double**)calloc(m,sizeof(double*));
for(i=0;i<m;i++)
	a[i]=(double*)calloc(n,sizeof(double));
j_max=(bool*)calloc(n,sizeof(bool));

cout<<"������ �������:"<<endl;
for(i=0;i<m;i++)
	for(j=0;j<n;j++)
		scanf("%lf",a[i]+j);
cout<<endl<<endl<<"������� �������:"<<endl;	

FindMax();
SortCols();
PrintMatrix();

system("pause");
return 0;
}
//---------------------------------------------------------------------------
 