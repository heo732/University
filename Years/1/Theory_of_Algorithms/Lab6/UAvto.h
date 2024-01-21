//---------------------------------------------------------------------------
#ifndef UAvtoH
#define UAvtoH
#include <String.h>
#include <Classes.hpp>
//---------------------------------------------------------------------------
typedef struct
{
  String last;
  String first;
}TName;
//---------------------------------------------------------------------------
typedef struct
{
  String street;
  String house;
  String flat;
}TAddress;
//---------------------------------------------------------------------------
typedef struct OAvto
{
  int id;
  String number;
  String mark;
  TName name;
  TAddress address;
  String receipt;
  OAvto *prev;
  OAvto *next;
}TAvto;
//---------------------------------------------------------------------------
void FFirst();
void FPrev();
void FNext();
void FLast();
void FNew();
void FSave(TAvto);
void FDelete();
TAvto FGet();
bool FIsEnd();
void FFindID(int);
//---------------------------------------------------------------------------
#endif