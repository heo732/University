//---------------------------------------------------------------------------
#ifndef TParallelogramH
#define TParallelogramH
//---------------------------------------------------------------------------
#include <Dialogs.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TParallelogram{
    double base, height, side;
    double alpha; //Angle between base and side
    double beta; //Angle between height and side
    TColor color;

    bool lockSide, lockHeight, lockAlpha;

  public:

    TParallelogram();
    TParallelogram(double, double, double, TColor);
    ~TParallelogram(){};

    bool SetBase(double);
    bool SetHeight(double);
    bool SetSide(double);
    bool SetAlpha(double);
    void SetColor(TColor);
    void SetLocks(bool, bool, bool);

    double GetBase();
    double GetHeight();
    double GetSide();
    double GetAlpha();
    double GetBeta();
    TColor GetColor();

    double Perimeter();
    double Area();

    TParallelogram& operator = (TParallelogram&);

    void DrawInImage(TImage*&);
    void FullFillImage(TImage*&, TColor);
    TColor GetColorImage(TImage*);

};
//---------------------------------------------------------------------------
#endif
