//---------------------------------------------------------------------------
#pragma hdrstop
#pragma argsused
#include <stdio.h>
#include <conio.h>
#include <math.h>
//---------------------------------------------------------------------------
int main(int argc, char* argv[])
{
 int i,j,n,k,d,d1;
 int z,z1;
 int a[50][50],p;
/*
z - потрiбна к-сть крокiв  на поточному напрямку
z1 - дiйсна к-сть крокiв на поточному напрямку
d - кількість повних кіл
p - поточний елемент
*/
printf("SPIRAL\n");
printf("Input N: "); scanf("%d",&n);

    d=n/2;  if(d*2==n)d1=4; else d1=1; 
    z=n-1; i=0; j=0; p=1;
    for(k=0;k<d;k++)
    {
      for(z1=0;z1<z;z1++)
      {
       a[i][j]=p; 
       p++;
       j++;
      }
      for(z1=0;z1<z;z1++)
      {
       a[i][j]=p;
       p++;
       i++;
      }
      for(z1=0;z1<z;z1++)
      {
       a[i][j]=p;
       p++;
       j--;
      }
      for(z1=0;z1<z;z1++)
      {
       a[i][j]=p;
       p++;
       i--;
      }
     z-=2;
     i++;
     j++; 
    }
   if(d1==1)a[i][j]=p;
   

printf("\n");
 for(i=0;i<n;i++)
 {
  for(j=0;j<n;j++)
   printf("%3.0d ",a[i][j]);
  printf("\n");
 }

getch();        return 0;
}
//---------------------------------------------------------------------------

