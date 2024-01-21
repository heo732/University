#include <iostream>
#include <alloc.h>
using namespace std;
#include <windows.h>
#define SIZE 30
typedef double Matrix[SIZE][SIZE];

ABtoC(int r,int ca,int cb,Matrix a,double **b,double *c)
{
int i,j;
double s1,s2;
for(i=0;i<r;i++)
{
	s1=0;
	s2=0;
	for(j=0;j<ca;j++)
		s1+=a[i][j];
	for(j=0;j<cb;j++)
		s2+=b[i][j];
	if(s1/ca<=s2/cb)
		c[i]=1;
	else
		c[i]=0;
}
}

int main()
{
SetConsoleCP(1251);
SetConsoleOutputCP(1251);
cout<<" ////   Lab4 21.04.2017   ////"<<endl
<<endl<<"За матрицями А і В , де матриця А має макс. розмір 30х30,"<<endl
<<"а матриця В має невизначені розміри,"<<endl
<<"створити вектор С, за правилом:"<<endl
<<"Сі = 1 , якщо середнє значення і-го рядка матриці А"<<endl
<<"не перевищує середнє арифм. і-го матриці В"<<endl
<<"Сі =0 в іншому випадку."<<endl<<endl
<<"Отримання вектора з двох матриць оформити у вигляді підпрограми."<<endl
<<"Для 1-ї матриці (і відповідного переданого параметру)"<<endl
<<"створити відповідний тип даних "<<endl
<<"Другу матрицю (і другий параметр) задати динамічно"
<<"(через подвійний вказівник)"<<endl
<<"Вектор - у довільному вигляді."<<endl<<endl
<<"Елементи матриць - дійсні"<<endl
<<"/////////////////////////////////////////////////////////////////////////////"<<endl;

Matrix a;
double **b,*c;
int r,ca,cb,i,j;
char choise='y';

while(choise=='y')
{
cout<<endl<<endl<<endl<<"Введіть кількість рядків матриць А та В: ";
scanf("%d",&r);
while(r<=0 || r>30)
{
	cout<<"Введіть значення в діапазоні [1,30]: ";
	scanf("%d",&r);
}

cout<<"Введіть кількість стовпців матриці А: ";
scanf("%d",&ca);
while(ca<=0 || ca>30)
{
	cout<<"Введіть значення в діапазоні [1,30]: ";
	scanf("%d",&ca);
}           

cout<<"Введіть кількість стовпців матриці B: ";
scanf("%d",&cb);
while(cb<=0)
{
	cout<<"Введіть додатнє значення: ";
	scanf("%d",&cb);
}

cout<<endl;
b=(double**)calloc(r,sizeof(double*));
for(i=0;i<r;i++)
	b[i]=(double*)calloc(cb,sizeof(double));
c=(double*)calloc(r,sizeof(double));

cout<<"Введіть матрицю А:"<<endl;
for(i=0;i<r;i++)
	for(j=0;j<ca;j++)
		scanf("%lf",&a[i][j]);
cout<<"Введіть матрицю B:"<<endl;
for(i=0;i<r;i++)
	for(j=0;j<cb;j++)
		scanf("%lf",b[i]+j);

ABtoC(r,ca,cb,a,b,c);

cout<<"(Результат) Вектор С: ";
for(i=0;i<r;i++)
	cout<<c[i]<<" ";
cout<<endl<<endl;

for(i=0;i<r;i++)
	free(b[i]);
free(b);
free(c);

cout<<"Бажаєте продовжити? [y/n]: ";
cin>>choise;
}

return 0;
}
//--------------------------------------------------------------------------- 