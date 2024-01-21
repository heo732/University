//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UClear.h"
#include "UMain.h"
#include "ClassMatrix.h"
//---------------------------------------------------------------------------
TFormClear *FormClear;
//---------------------------------------------------------------------------
__fastcall TFormClear::TFormClear(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFormClear::btnCloseClick(TObject *Sender)
{
  FormClear->Close();      
}
//---------------------------------------------------------------------------

void __fastcall TFormClear::btnClear1Click(TObject *Sender)
{
  TMatrix m(FormMain->stg1->RowCount-1, FormMain->stg1->ColCount-1, 0);

  m.PrintToStg(FormMain->stg1);
}
//---------------------------------------------------------------------------

void __fastcall TFormClear::btnClear2Click(TObject *Sender)
{
  TMatrix m(FormMain->stg1->RowCount-1, FormMain->stg1->ColCount-1, 0);

  m.PrintToStg(FormMain->stg2);
}
//---------------------------------------------------------------------------

void __fastcall TFormClear::btnClearBothClick(TObject *Sender)
{
  TMatrix m(FormMain->stg1->RowCount-1, FormMain->stg1->ColCount-1, 0);

  m.PrintToStg(FormMain->stg1);
  m.PrintToStg(FormMain->stg2);
}
//---------------------------------------------------------------------------

