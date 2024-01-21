//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UMultiply.h"
#include "UMain.h"
#include "UMultOnValue.h"
#include "UResult.h"
#include "ClassMatrix.h"
//---------------------------------------------------------------------------
TFormMultiply *FormMultiply;
//---------------------------------------------------------------------------
__fastcall TFormMultiply::TFormMultiply(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFormMultiply::btnCloseClick(TObject *Sender)
{
  FormMultiply->Close();      
}
//---------------------------------------------------------------------------
void __fastcall TFormMultiply::btnMultMatrixClick(TObject *Sender)
{
  TMatrix m1, m2;

  m1.ReadFromStg(FormMain->stg1);
  m2.ReadFromStg(FormMain->stg2);

  m1 *= m2;
  if(m1.GetStan() == 2)
    ShowMessage("������� �� ���������");
  else{
    m1.PrintToStg(FormResult->stg);
    FormResult->Show();
  }  
}
//---------------------------------------------------------------------------

void __fastcall TFormMultiply::btnMultScalarClick(TObject *Sender)
{
  TMatrix m1, m2;

  m1.ReadFromStg(FormMain->stg1);
  m2.ReadFromStg(FormMain->stg2);

  long res = m1.MultiplyScalar(m2);

  ShowMessage(IntToStr(res));
}
//---------------------------------------------------------------------------

void __fastcall TFormMultiply::btnMultOnValueClick(TObject *Sender)
{
  FormMultOnValue->Show();      
}
//---------------------------------------------------------------------------
