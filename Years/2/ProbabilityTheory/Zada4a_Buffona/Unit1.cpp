//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <vector>
#include <ctime>
#include <math.h>
#include <time.h>
//---------------------------------------------------------------------------
//Генерація координат падіння голки
//0 <= x1 <= 2a;
//x2 на колі радіуса 2l
void generateNeedle(double a2, double l2, double &x1, double &x2){

  x1 = (double) rand();
  x1 /= RAND_MAX;
  x1 *= a2;

  double angle;
  angle = (double) rand();
  angle /= RAND_MAX;
  angle *= 2*M_PI;

  x2 = l2 * cos(angle);

  angle = angle * 180 / M_PI; // переведення в градуси

  if(angle > 90 && angle < 270)
    x2 = x1 - x2;
  else
    x2 = x1 + x2;

}
//---------------------------------------------------------------------------
//Функція перевірки перетину прямої голкою
bool isIntersection(double a2, double x2){

  if(x2 <= 0 || x2 >= a2)
    return true;
  return false;  
}
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnDoClick(TObject *Sender)
{
  double time1, time2;
  time1 = clock();

  unsigned long n, m=0;
  double l2, a2, x1, x2;
  long double p, Pi;

  if(edt2L->Text=="" || edt2A->Text=="" || edtN->Text=="")
    ShowMessage("Заповніть всі поля: 2l, 2a, n");
  else
    if(StrToFloat(edt2L->Text) >= StrToFloat(edt2A->Text))
      ShowMessage("2l < 2a !");
    else
    {
      l2 = StrToFloat(edt2L->Text);
      a2 = StrToFloat(edt2A->Text);
      n = StrToInt(edtN->Text);

      srand(time(0));

      for(unsigned long i=0; i<n; i++)
      {
        generateNeedle(a2, l2, x1, x2);
        if(isIntersection(a2, x2))
          m++;
      }


      if(m != 0)
      {
        //Pi = (double) l2 * n / m / a2 / 2;  //~1
        //Pi =  ((double) l2 * n) / (((double)a2/2) * m);  //~3
        //Pi =  (double) a2 / 2 / m * l2 * n;  //~80 000 000
        //Pi = ((double) l2 * n) * ((double)1/(((double)1/2)*a2*((double)1/m)));  //~5 000
        Pi = ((long double) l2 * n) / (((long double)a2/2) * m);
        edtPi->Text = FloatToStr(Pi);
      }
      else
        edtPi->Text = "m = 0";

      edtM->Text = IntToStr(m);

      p = (double) m / (double) n;
      edtP->Text = FloatToStr(p);

      time2 = clock();
      lblTime->Caption = FloatToStr((time2-time1)/1000.0);

    }

}
//---------------------------------------------------------------------------
