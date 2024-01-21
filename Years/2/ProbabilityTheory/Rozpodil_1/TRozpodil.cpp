//---------------------------------------------------------------------------
#pragma hdrstop
#include "TRozpodil.h"
#include <time.h>
#include "UMain.h"
#pragma package(smart_init)
//---------------------------------------------------------------------------
TRozpodil::TRozpodil(){
  count_exp = 0;
  count_x = 0;
  x = NULL;
  p = NULL;   
}
//---------------------------------------------------------------------------
TRozpodil::TRozpodil(unsigned int c_e, unsigned int c_x, int* x_){
  count_exp = c_e;
  count_x = c_x;
  x = x_;
  p = new double[count_x];
}
//---------------------------------------------------------------------------
TRozpodil::~TRozpodil(){
  if(x != NULL)delete x;
  if(p != NULL)delete p;
}
//---------------------------------------------------------------------------
bool TRozpodil::CarryOutExperiments(){

  if(count_x > 1){

    if(x[0] < 0){
      int tab = abs(x[0]);
      for(unsigned int i=0; i<count_x; i++)
        x[0] += tab;
    }

    double *x_t, min = x[0], max = x[count_x-1] - min;
    x_t = new double[count_x];
    for(unsigned int i=0; i<count_x; i++) x_t[i] = (double)(x[i] - min) / (double) max;

    unsigned int *zone;
    zone = new unsigned int[count_x-1];
    for(unsigned int i=0; i<count_x-1; i++) zone[i] = 0;

    srand(time(0));

    for(unsigned int i=0; i<count_exp; i++){
      double R = (double) rand();
      R /= RAND_MAX;

      for(unsigned int j=1; j<count_x; j++)
        if(x_t[j-1] < R && R <= x_t[j]){
          zone[j-1]++;
          break;
        }
    }
    //Form_Main->Caption = FloatToStr(x_t[0]) + "  " + FloatToStr(x_t[1]) + "  " + FloatToStr(x_t[2]);
    //Form_Main->Caption = IntToStr(x[0]) + "  " + IntToStr(x[1]);
    //Form_Main->Caption = IntToStr(zone[0]);
    if(x_t != NULL) delete x_t;

    p[0] = zone[0] / (double) count_exp;
    for(unsigned int i=1; i<count_x-1; i++){
      p[i] = zone[i] / (double) count_exp;
      for(int j=i-1; j>=0; j--)
        p[i] -= p[j];
    }

    p[count_x-1] = 1;
    for(int j=count_x-2; j>=0; j--)
      p[count_x-1] -= p[j];

    //Form_Main->Caption = FloatToStr(p[0]) + "  " + FloatToStr(p[1]);

    if(zone != NULL)delete zone;
    return true;
  }
  return false;
}
//---------------------------------------------------------------------------
double* TRozpodil::GetP(){
  return p;
}
//---------------------------------------------------------------------------
void TRozpodil::DrawFunctionToImage(TImage*& image){
  //
}
//---------------------------------------------------------------------------
