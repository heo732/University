#pragma hdrstop
#pragma argsused
//---------------------------------------------------------------------------
#include <stdio.h>
#include <conio.h>
//---------------------------------------------------------------------------
int main(int argc, char* argv[])
{
 float a,b,c;
 printf("Task_4: ");
 scanf("%f%f",&a,&b);

   c=(((a*b)+((a-b)*(a+b))-1)/((a*a)+(b*b)))-5;
   printf("Result: %0.4f",c);


        getch ();
        return 0;
}
//---------------------------------------------------------------------------
 