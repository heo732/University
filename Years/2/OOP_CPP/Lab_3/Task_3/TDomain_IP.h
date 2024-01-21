//---------------------------------------------------------------------------
#ifndef TDomain_IPH
#define TDomain_IPH
//---------------------------------------------------------------------------
#include <string>
#include <iostream>
#include <fstream>
#include <Grids.hpp>
#include <Classes.hpp>

using namespace std;
//----------------------------------------
typedef struct OBase{
  string domain;
  string IP;
  OBase *next;
  OBase *prev;
}TBase;
//----------------------------------------
class TDomain_IP{

    TBase* field;

  public:

    TDomain_IP();
    //----------------------------------------
    ~TDomain_IP();
    //----------------------------------------
    void Erase();
    //----------------------------------------
    bool IsIn(string);
    //----------------------------------------
    TBase* operator [](unsigned int);
    //----------------------------------------
    unsigned int Size();
    //----------------------------------------
    void Add(string, string);
    //----------------------------------------
    void Remove(string);
    //----------------------------------------
    friend ofstream& operator << (ofstream&, TBase*&);
    //----------------------------------------
    friend ostream& operator << (ostream&, TBase*&);
    //----------------------------------------
    void WriteInFile(string);
    //----------------------------------------
    bool ReadFromFile(string);
    //----------------------------------------
    void WriteInGrid(TStringGrid*&);
    //----------------------------------------
    void ReadFromGrid(TStringGrid*&);
    //----------------------------------------
    void* operator new(size_t);
    //---------------------------------------------------------------------------
    void* operator new[](size_t);
    //---------------------------------------------------------------------------
    void operator delete(void*);
    //---------------------------------------------------------------------------
    void operator delete[](void*);
    //---------------------------------------------------------------------------
};
//---------------------------------------------------------------------------
#endif
