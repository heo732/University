//---------------------------------------------------------------------------
#ifndef ClassH
#define ClassH
#include <Dialogs.hpp>
#include <Grids.hpp>
#include <iostream>
#include <fstream>
using namespace std;
//---------------------------------------------------------------------------
class VectorShort{
    short *elements;
    unsigned int size;

    char codeError; /*0 - good,
    1 - ����� �� ��� ������,
    2 - �������� ������ �������*/

    static unsigned int cntObjects;

  public:
    VectorShort(); //1el = 0;
    VectorShort(unsigned int); //[size]els=0;
    VectorShort(unsigned int, short); //[size]els=value;
    VectorShort(VectorShort&);
    ~VectorShort();

    unsigned int GetSize();
    unsigned int GetCntObjects();
    char GetCodeError();

    void PrintToStg(TStringGrid*&);
    bool ReadFromStg(TStringGrid*);//if(return 1)good
    void RandomFilling();
    bool ReadFromFile(String);//if(return 1)good

    VectorShort& operator ++ ();
    VectorShort& operator -- ();
    VectorShort& operator ++ (int);
    VectorShort& operator -- (int);
    bool operator ! ();
    VectorShort operator ~ ();
    VectorShort operator - ();
    VectorShort& operator = (VectorShort);
    VectorShort operator + (VectorShort&);
    VectorShort operator + (short);
    VectorShort operator - (VectorShort&);
    VectorShort operator - (short);
    VectorShort operator * (VectorShort&);
    VectorShort operator * (short);
    VectorShort operator / (VectorShort&);
    VectorShort operator / (short);
    VectorShort operator % (VectorShort&);
    VectorShort operator % (short);
    VectorShort operator | (VectorShort&);
    VectorShort operator | (short);
    VectorShort operator ^ (VectorShort&);
    VectorShort operator ^ (short);
    VectorShort operator & (VectorShort&);
    VectorShort operator & (short);
    VectorShort& operator += (VectorShort);
    VectorShort& operator += (short);
    VectorShort& operator -= (VectorShort);
    VectorShort& operator -= (short);
    VectorShort& operator *= (VectorShort);
    VectorShort& operator *= (short);
    VectorShort& operator /= (VectorShort);
    VectorShort& operator /= (short);
    VectorShort& operator %= (VectorShort);
    VectorShort& operator %= (short);
    VectorShort& operator |= (VectorShort);
    VectorShort& operator |= (short);
    VectorShort& operator ^= (VectorShort);
    VectorShort& operator ^= (short);
    VectorShort& operator &= (VectorShort);
    VectorShort& operator &= (short);
    friend istream& operator >> (istream&, VectorShort&);
    friend ostream& operator << (ostream&, VectorShort&);
    friend ifstream& operator >> (ifstream&, VectorShort&);
    friend ofstream& operator << (ofstream&, VectorShort&);
    bool operator == (VectorShort&);
    bool operator != (VectorShort&);
    bool operator > (VectorShort&);
    bool operator >= (VectorShort&);
    bool operator < (VectorShort&);
    bool operator <= (VectorShort&);

    short& operator [](unsigned int);
    void* operator new(size_t);
    void* operator new[](size_t);
    void operator delete(void*);
    void operator delete[](void*);
    long operator ()(VectorShort&);

    long  MultiplyScalar(VectorShort&);
};

#endif
