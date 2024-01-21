//---------------------------------------------------------------------------
#ifndef ClassH
#define ClassH

#include <Grids.hpp>
//---------------------------------------------------------------------------
class TMatrix{
    short **pointer;
    unsigned int RowCount;
    unsigned int ColCount;

    char stan; /*0 - good,
    1 - вихід за межі матриці,
    2 - несумісні розміри матриць*/

    static unsigned int cntObjects;

  public:
    TMatrix(); //4x4 = 0;
    TMatrix(unsigned int); //NxN = 0;
    TMatrix(unsigned int, unsigned int, short); //NxM = value;
    ~TMatrix();

    void ReadFromStg(TStringGrid *);
    void RandomFilling();
    char ReadFromFile(String);//if(return 1)write "bad name file"

    void PrintToStg(TStringGrid *&) const;

    unsigned int GetRowCount() const;
    unsigned int GetColCount() const;
    char GetStan() const;
    unsigned int GetCntObjects() const;
    short GetElValue(unsigned int, unsigned int);//look stan

    void Assign(unsigned int, unsigned int, short);//look stan

    TMatrix& operator = (TMatrix&);
    TMatrix& operator += (TMatrix&);
    TMatrix& operator -= (TMatrix&);
    TMatrix& operator *= (TMatrix&);
    TMatrix& operator *= (short);
    long MultiplyScalar(TMatrix&);
    bool operator > (TMatrix&);
    bool operator < (TMatrix&);
    bool operator != (TMatrix&);
    bool LessOrNotEqual(TMatrix&);
    
};

#endif
