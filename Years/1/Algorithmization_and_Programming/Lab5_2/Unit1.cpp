//---------------------------------------------------------------------------
#pragma hdrstop
#pragma argsused
#include <iostream>
using namespace std;
#include <alloc.h>
#include <windows.h>
#include <stdio.h>
#include <string.h> 
//---------------------------------------------------------------------------
typedef struct OMovie
{
	char name[500];
	int seans;
	int tiket;
	double count_per_seans;	  
  OMovie *next;
}TMovie;
//---------------------------------------------------------------------------
void InputNotSort(TMovie *&Movie,TMovie *&Start,TMovie *&a)
{  
  if(Movie==NULL)
  {    
    Movie=a;
    Start=Movie;
  }  
  else
  {    
    Movie->next=a;
    Movie=Movie->next;
  }
}
//---------------------------------------------------------------------------
void InputWithSort(TMovie *&Movie,TMovie *&Start,TMovie *&a)
{		
	if(Start==NULL)
  {
    Movie=a;
    Start=Movie;
  }
  else
  {
    Movie=Start;
    if(Movie->count_per_seans<a->count_per_seans)
    {
      a->next=Movie;
      Movie=a;
      Start=Movie;
    }
    else
    {
      while(Movie->next->count_per_seans>a->count_per_seans && Movie->next!=NULL)
        Movie=Movie->next;
      a->next=Movie->next;
      Movie->next=a;
    }
  }  
}
//---------------------------------------------------------------------------
void PrintMovie(TMovie *Start)
{
  if(Start!=NULL)
  {  
    cout<<Start->name<<" "<<Start->seans<<" "<<Start->tiket<<" "<<Start->count_per_seans<<endl;
    if(Start->next!=NULL)
      PrintMovie(Start->next);      
  }  
}
//---------------------------------------------------------------------------
int main()
{
SetConsoleCP(1251);
SetConsoleOutputCP(1251);

TMovie *Movie=NULL,*MovieSort=NULL,*a=NULL,*b=NULL,*Start=NULL,*StartSort=NULL;
char c;

//читання записів
do
{
  cout<<"Бажаєте ввести запис? [1/0]: ";
  cin>>c;
  if(c=='1')
  {
    cout<<"Назва фільму | Сеанси | Білети"<<endl;    
    a=new TMovie;
    a->next=NULL;    
    b=new TMovie;
    b->next=NULL;    
    scanf("%s%d%d",&a->name,&a->seans,&a->tiket);
    if(a->seans==0)
      a->count_per_seans=0;
    else
      a->count_per_seans=(double)a->tiket/a->seans;
    strcpy(b->name,a->name);
    b->seans=a->seans;
    b->tiket=a->tiket;
    b->count_per_seans=a->count_per_seans;
    InputNotSort(Movie,Start,a);
    InputWithSort(MovieSort,StartSort,b);
  }
}  
while(c=='1');  
////////////////
cout<<endl<<"Вхідний масив:"<<endl<<"( Фільм | Сеанси | Білети | Середнє відвідування )"<<endl;
PrintMovie(Start);//друк всіх записів

cout<<endl<<"Впороядковано по середньому відвідуванню:"<<endl<<"( Фільм | Сеанси | Білети | Середнє відвідування )"<<endl;
PrintMovie(StartSort);

cout<<endl;
system("pause");
return 0;
}
//--------------------------------------------------------------------------- 