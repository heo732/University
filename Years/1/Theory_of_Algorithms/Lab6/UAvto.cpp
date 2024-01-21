//---------------------------------------------------------------------------
#pragma hdrstop
#include "UAvto.h"
#include "UMain.h"
#pragma package(smart_init)
//---------------------------------------------------------------------------
TAvto *Avto=NULL;
int N=1;
//---------------------------------------------------------------------------
void FFirst()
{
  if(Avto!=NULL)
    while(Avto->prev!=NULL)
      Avto=Avto->prev;
}
//---------------------------------------------------------------------------
void FPrev()
{
  if(Avto!=NULL && Avto->prev!=NULL)
    Avto=Avto->prev;
}
//---------------------------------------------------------------------------
void FNext()
{
  if(Avto!=NULL && Avto->next!=NULL)
    Avto=Avto->next;
}
//---------------------------------------------------------------------------
void FLast()
{
  if(Avto!=NULL)
    while(Avto->next!=NULL)
      Avto=Avto->next;
}
//---------------------------------------------------------------------------
void FNew()
{
  TAvto *tmp;  
  
  if(Avto!=NULL)
  {
    FLast();
    tmp=new TAvto;
    tmp->prev=Avto;
    Avto->next=tmp;
    tmp->next=NULL;    
    tmp->id=N++;
    Avto=tmp;
  }
  else
  {
    Avto=new TAvto;
    Avto->prev=NULL;
    Avto->next=NULL;
    Avto->id=N++;
  }
}
//---------------------------------------------------------------------------
void FSave(TAvto a)
{
  if(Avto!=NULL)
  {    
    Avto->number=a.number;
    Avto->mark=a.mark;
    Avto->name.last=a.name.last;
    Avto->name.first=a.name.first;
    Avto->address.street=a.address.street;
    Avto->address.house=a.address.house;
    Avto->address.flat=a.address.flat;
    Avto->receipt=a.receipt;
  }
}
//---------------------------------------------------------------------------
void FDelete()
{
  TAvto *d;
  
  if(Avto!=NULL)
  {  
    if(Avto->prev!=NULL && Avto->next!=NULL)
    {
      Avto->prev->next=Avto->next;
      Avto->next->prev=Avto->prev;
      d=Avto;
      Avto=Avto->next;
      delete d;
    }
    else
      if(Avto->prev!=NULL && Avto->next==NULL)
      {
        d=Avto;
        Avto->prev->next=NULL;
        Avto=Avto->prev;
        delete d;
      }
      else
        if(Avto->prev==NULL && Avto->next!=NULL)
        {
          d=Avto;
          Avto->next->prev=NULL;
          Avto=Avto->next;
          delete d;
        }
        else
          if(Avto->prev==NULL && Avto->next==NULL)
          {
            delete Avto;
            Avto=NULL;
          }
  }      
}
//---------------------------------------------------------------------------
TAvto FGet()
{
  TAvto a;
  
  if(Avto!=NULL)
  {
    a.id=Avto->id;
    a.number=Avto->number;
    a.mark=Avto->mark;
    a.name.last=Avto->name.last;
    a.name.first=Avto->name.first;
    a.address.street=Avto->address.street;
    a.address.house=Avto->address.house;
    a.address.flat=Avto->address.flat;
    a.receipt=Avto->receipt;
  }
  else
  {
    a.id=NULL;
    a.number="";
    a.mark="";
    a.name.last="";
    a.name.first="";
    a.address.street="";
    a.address.house="";
    a.address.flat="";
    a.receipt="";
  }
  
  return a;
}
//---------------------------------------------------------------------------
bool FIsEnd()
{
  if(Avto->next==NULL)
    return true;
  else
    return false;
}
//---------------------------------------------------------------------------
void FFindID(int i)
{
  if(Avto!=NULL)
  {
    FFirst();
    while(Avto->id!=i && Avto->next!=NULL)
      FNext();
    FShow(FGet());
  }
}
//---------------------------------------------------------------------------