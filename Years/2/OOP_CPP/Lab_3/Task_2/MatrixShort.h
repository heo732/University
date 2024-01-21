//---------------------------------------------------------------------------
#ifndef ClassH
#include "VectorShort.h"
#define ClassH

#include <Grids.hpp>
#include <fstream>
#include <iostream>
using namespace std;
//---------------------------------------------------------------------------
class MatrixShort{

  protected:

    VectorShort *ShortArray;
    int n, size;
    int codeError;/*0 - good,
    -1 - неправильне задання розміу матрці
    1 - вихід за межі матриці,
    2 - несумісні розміри матриць*/
    static int num_matrix;

  public:

    MatrixShort(){ShortArray = NULL; n=size=codeError = 0; num_matrix++;}
    MatrixShort(int);
    MatrixShort(int, int);
    MatrixShort(int, int, short);
    MatrixShort(MatrixShort&);

    int GetN(){return n;}
    int GetSize(){return size;}
    int GetCodeError(){return codeError;}

    ~MatrixShort(){delete ShortArray; ShortArray=NULL; num_matrix--;}

    MatrixShort& operator ++();
    MatrixShort& operator --();
    MatrixShort& operator ++(int);
    MatrixShort& operator --(int);
    bool operator !();
    MatrixShort& operator ~();
    MatrixShort& operator -();
    MatrixShort& operator =(MatrixShort);
    MatrixShort& operator =(short);
    MatrixShort operator +(MatrixShort&);
    MatrixShort operator +(short&);
    MatrixShort operator -(MatrixShort&);
    MatrixShort operator -(short&);
    MatrixShort operator *(MatrixShort&);
    MatrixShort operator *(VectorShort&);
    MatrixShort operator *(short&);
    MatrixShort operator /(MatrixShort&);
    MatrixShort operator /(short&);
    MatrixShort operator %(MatrixShort&);
    MatrixShort operator %(short&);
    MatrixShort& operator +=(MatrixShort&);
    MatrixShort& operator +=(short&);
    MatrixShort& operator -=(MatrixShort&);
    MatrixShort& operator -=(short&);
    MatrixShort& operator *=(MatrixShort&);
    MatrixShort& operator *=(VectorShort&);
    MatrixShort& operator *=(short&);
    MatrixShort& operator /=(MatrixShort&);
    MatrixShort& operator /=(short&);
    MatrixShort& operator %=(MatrixShort&);
    MatrixShort& operator %=(short&);
    MatrixShort operator |(MatrixShort&);
    MatrixShort operator |(short&);
    MatrixShort operator ^(MatrixShort&);
    MatrixShort operator ^(short&);
    MatrixShort operator &(MatrixShort&);
    MatrixShort operator &(short&);
    MatrixShort& operator >>=(MatrixShort&);
    MatrixShort& operator >>=(short&);
    MatrixShort& operator <<=(MatrixShort&);
    MatrixShort& operator <<=(short&);
    MatrixShort& operator |=(MatrixShort&);
    MatrixShort& operator |=(short&);
    MatrixShort& operator ^=(MatrixShort&);
    MatrixShort& operator ^=(short&);
    MatrixShort& operator &=(MatrixShort&);
    MatrixShort& operator &=(short&);
    bool operator ==(MatrixShort&);
    bool operator !=(MatrixShort&);
    bool operator >(MatrixShort&);
    bool operator >=(MatrixShort&);
    bool operator <(MatrixShort&);
    bool operator <=(MatrixShort&);
    VectorShort& operator [](int&);
    void* operator new(size_t);
    void* operator new[](size_t);
    void operator delete(void*);
    void operator delete[](void*);
    long operator()(MatrixShort&);
    friend istream& operator >> (istream&, MatrixShort&);
    friend ostream& operator << (ostream&, MatrixShort&);
    friend ifstream& operator >> (ifstream&, MatrixShort&);
    friend ofstream& operator << (ofstream&, MatrixShort&);

    void ReadFromStg(TStringGrid*&);
    void RandomFilling();
    bool ReadFromFile(String);

    void PrintToStg(TStringGrid*&);

};

#endif
