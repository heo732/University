#pragma hdrstop
#pragma argsused
#include <stdio.h>
#include <conio.h>
#define Size 100
//---------------------------------------------------------------------------
int main(int argc, char* argv[])
{

 int i,n,k; double a[Size],w;
   printf("N= "); scanf("%d",&n);
   printf("Input Array\n");
   for (i=0;i<n;i++) scanf("%lf",&a[i]);

      for(i=n-1;i>0;i--)
      for(k=0;k<i;k++)
       if(a[k]>a[k+1])
       {w=a[k];
        a[k]=a[k+1];
        a[k+1]=w;
       } 

 printf("\n");
 for (i=0;i<n;i++) printf("%0.0f ",a[i]);

getch();
return 0;
}
//---------------------------------------------------------------------------

