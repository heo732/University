//---------------------------------------------------------------------------
#ifndef TRozpodilH
#define TRozpodilH
#include <Classes.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TRozpodil{

    unsigned int count_exp;
    unsigned int count_x;
    int* x;
    double* p;

  public:

    TRozpodil();
    TRozpodil(unsigned int, unsigned int, int*);
    ~TRozpodil();

    bool CarryOutExperiments();
    double* GetP();
    void DrawFunctionToImage(TImage*&);
};
//---------------------------------------------------------------------------
#endif
