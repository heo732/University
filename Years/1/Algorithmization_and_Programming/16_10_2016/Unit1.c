#pragma hdrstop
#pragma argsused
//---------------------------------------------------------------------------
#include <stdio.h>
#include <conio.h>
#include <math.h>

int main(int argc, char* argv[])
{
 float a,b,c,fa,fb,fc,ep;

   printf("Input a,b,ep:"); scanf("%f%f%f",&a,&b,&ep);
   do
   {
   fa=0.1/(a+1)-3;
   fb=0.1/(a+1)-3;
   c=(b+a)/2;
   fc=0.1/(c+1)-3;
   if (fa*fc<0) b=c; else a=c;
   if (fa*fc==0) {c=a; break;}
   if (fb*fc==0) {c=b; break;}
   }
   while (fabs(fc)>ep);
   printf("c= %0.4f\n",c);
   getch();
   return 0;

}
//---------------------------------------------------------------------------
 