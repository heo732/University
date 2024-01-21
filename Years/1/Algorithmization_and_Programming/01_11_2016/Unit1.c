#pragma hdrstop
#pragma argsused
#include <stdio.h>
#include <conio.h>
#include <math.h>
//---------------------------------------------------------------------------
int main(int argc, char* argv[])
{
int n,i,z; double a,w,s,f,sa,sw; double x,y,e,m,sx,sy,sxy;

  printf("1) N= "); scanf("%d",&n);
  printf("Input a,w: "); scanf("%lf%lf",&a,&w);

 s=0; z=-1; f=1; sw=w; if (a!=0) sa=1/a; else sa=0;

     for (i=1;i<=n;i++) {
   z=z*(-1);
   sa=sa*a;
   sw=sw*w;
   f=f*(i+1);
   s=s+(z*cos(sa+sw))/f;
                        }

 printf("S1= %0.3lf\n",s);

 printf("\n");

 // 2

 printf("2)  E="); scanf("%lf",&e);

 printf("Input x,y: "); scanf("%lf%lf",&x,&y);
 if (((x==0)&&(y==0))||((x!=y)&&(fabs(x)==fabs(y))))
 do{
    printf("ERROR !\n"); printf("Input again x,y: ");
    scanf("%lf%lf",&x,&y);
   }
 while  (((x==0)&&(y==0))||((x!=y)&&(fabs(x)==fabs(y))));

 s=0; i=0; z=1; f=2; sx=x; if (y!=0) sy=1/y; else sy=0;
 if ((x==0)&&(y==0)) sxy=0; else sxy=1/(x+y);


 do {
   z=z*(-1);
   sx=sx*x;
   sy=sy*y*y;
   f=f*(i+3);
   sxy=sxy*(x+y);
   s=s+z*sx*sy/f/sxy;
   m=fabs(s); i++;
     }
 while (m>e) ;
 printf("S2= %0.3lf",s);
getch();        return 0;
}
//---------------------------------------------------------------------------
 