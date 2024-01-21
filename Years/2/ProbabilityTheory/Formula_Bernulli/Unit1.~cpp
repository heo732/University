//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
double factorial(unsigned int f){
	double res=1;
	for(unsigned int i=1; i<=f; i++)
		res *= i;

	return res;
}
//---------------------------------------------------------------------------
double stepin(double c, unsigned int s){
	double res=c;
	for(unsigned int i=1; i<s; i++)
		res *= c;

	return res;
}
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnClick(TObject *Sender)
{
  double res, c, p, q;
  unsigned int n, k;

  p = StrToFloat(edtP->Text);
  q = 1-p;
  n = StrToInt(edtN->Text);
  k = StrToInt(edtK->Text);

  res = stepin(p, k) * stepin(q, n-k) * factorial(n) / (factorial(k) * factorial(n-k));

  edtRez->Text = FloatToStr(res);
}
//---------------------------------------------------------------------------