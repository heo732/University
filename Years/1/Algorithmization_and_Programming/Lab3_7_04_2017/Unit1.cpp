#include <iostream>
#include <conio.h>
#include <alloc.h>
using namespace std;

void FVector(int row,int col,double **A,int *B,int *C)
{
int i,j,count;

for(i=0;i<row;i++)
        {
        count=0;
        for(j=0;j<col;j++)
                if(A[i][j]<B[i])
                        count++;
                else
                        break;
        if(count==col)
                C[i]=0;
        else
                C[i]=1;
        }
}

int main()
{
double **a=NULL;
int *b=NULL,*c=NULL,m,n,i,j;

cout<<"m,n= ";
scanf("%d%d",&m,&n);

a=(double**)calloc(m, sizeof(double*));
for(i=0;i<m;i++)
         a[i]=(double*)calloc(n, sizeof(double));
cout<<"Matrix A:"<<endl;
for(i=0;i<m;i++)
        for(j=0;j<n;j++)
                scanf("%lf",a[i]+j);

b=(int*)calloc(m, sizeof(int));
c=(int*)calloc(m, sizeof(int));
cout<<"Vector B:"<<endl;
for(i=0;i<m;i++)
        scanf("%d",b+i);

FVector(m,n,a,b,c);
cout<<"Res C: ";
for(i=0;i<m;i++)
        printf("%d ",*(c+i));

for(i=0;i<m;i++)
        free(a[i]);
free(a);
free(b);
free(c);  

system("pause");
return 0;
}
//---------------------------------------------------------------------------
