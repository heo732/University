//---------------------------------------------------------------------------
#pragma hdrstop
#pragma argsused
#include <stdio.h>
#include <conio.h>
//---------------------------------------------------------------------------
int main(int argc, char* argv[])
{
int m,n,i,j;
double a[30][20],b[20],c[20],s,s1;

  printf("K-st vydiv produktiv: "); scanf("%d",&m);
  printf("Vartist produktiv: \n");
  for(i=0;i<m;i++) scanf("%lf",&b[i]);
  printf("K-st pokuptsiv: "); scanf("%d",&n);
  printf("MAtruts9 pokupok: \n");
  for(i=0;i<n;i++)
  for(j=0;j<m;j++) scanf("%lf",&a[i][j]);
  printf("\n");
  printf("1) Na 9ky symy zataruvs9 kozhen pokypets:\n");
   for(i=0;i<n;i++)
   {
    s=0; for(j=0;j<m;j++)s+=a[i][j]*b[j];
    printf("[%0.0d]_%0.2lf ",i+1,s);
   }
  printf("\n"); 
  printf("2) Skilku prodyktiv kozhnogo vudy bylo kypleno\n");
   for(i=0;i<m;i++)
   {
    s=0; for(j=0;j<n;j++)s+=a[j][i];
    printf("[%0.0d]_%0.0lf ",i+1,s);
   }
  printf("\n");
  printf("3) Na 9ky symy bylo kypleno v magazuni prodyktiv tsogo dn9\n");
    s=0; for(j=0;j<m;j++)

    {s1=0; for(i=0;i<n;i++)s1+=a[i][j]*b[j]; s+=s1;};
    printf("%0.2lf",s);


getch();        return 0;
}
//---------------------------------------------------------------------------
 