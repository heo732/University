#pragma hdrstop
#pragma argsused
#include <stdio.h>
#include <conio.h>
#include <math.h>
//---------------------------------------------------------------------------
int main(int argc, char* argv[])
{
 float ax,ay,bx,by,cx,cy; float a,b,c,p,s1,s; int r;

 printf("Input ax,ay,bx,by: "); scanf("%f%f%f%f",&ax,&ay,&bx,&by);

   r=1; s=0;
   while (r==1)
   {
    printf("Vvedit koordynaty X ta Y nastupnogo dereva: ");
    scanf("%f%f",&cx,&cy);

    a=sqrt(((bx-ax)*(bx-ax))+((by-ay)*(by-ay)));
    b=sqrt(((cx-ax)*(cx-ax))+((cy-ay)*(cy-ay)));
    c=sqrt(((cx-bx)*(cx-bx))+((cy-by)*(cy-by)));

    p=(a+b+c)/2;
    s1=sqrt(p*(p-a)*(p-b)*(p-c));
    s=s+s1;

    ax=bx; ay=by; bx=cx; by=cy;

    printf("Vvedit 1 9kshcho byde nastypne derevo, inakshe 0: ");
    scanf("%d",&r);
   }

 printf("Plosh4a dil9nku= %0.4f\n",s);

getch();
return 0;
}
//---------------------------------------------------------------------------
 