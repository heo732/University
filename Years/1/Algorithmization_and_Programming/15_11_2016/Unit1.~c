#pragma hdrstop
#pragma argsused
#include <stdio.h>
#include <conio.h>
//---------------------------------------------------------------------------
int main(int argc, char* argv[])
{

 int i,j,n,m,k,p,s;
 float a[40],b[50],c[20],w;
   printf("Input N,M: "); scanf("%d%d",&n,&m);
    printf("Input Array A: ");
    for (i=0;i<n;i++) scanf("%f",&a[i]);
   printf("Input Array B: ");
   for (i=0;i<m;i++) scanf("%f",&b[i]);

      k=0;
      for(i=0;i<n;i++)
      {
        p=0;  s=0;
            for(j=0;j<k;j++)
            if(a[i]==c[j]){p=1;break;}
        if(p==0)
                {
                 for(j=0;j<m;j++)
                 if(a[i]==b[j])s++;
                if(s>=3){c[k]=a[i];k++;}
                }
      }

//Bubbles
      for(i=k-1;i>0;i--)
      for(j=0;j<i;j++)
       if(c[j]>c[j+1])
       {w=c[j];
        c[j]=c[j+1];
        c[j+1]=w;
       }
//
 printf("\n");
 for (i=0;i<k;i++) printf("%0.2f ",c[i]);



getch();
return 0;
}
//---------------------------------------------------------------------------

 
