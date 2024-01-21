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
#include "VectorShort.h"
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
  VectorShort v1, v2;

  v1.ReadFromStg(FormMain->stg1);
  v2.ReadFromStg(FormMain->stg2);

  v1 *= v2;

  v1.PrintToStg(FormResult->stg);
  FormResult->Show();
}
//---------------------------------------------------------------------------

void __fastcall TFormMultiply::btnMultScalarClick(TObject *Sender)
{
  VectorShort v1, v2;

  v1.ReadFromStg(FormMain->stg1);
  v2.ReadFromStg(FormMain->stg2);

  long res = v1(v2);

  ShowMessage(IntToStr(res));  
}                       
//---------------------------------------------------------------------------

void __fastcall TFormMultiply::btnMultOnValueClick(TObject *Sender)
{
  FormMultOnValue->Show();      
}
//---------------------------------------------------------------------------

