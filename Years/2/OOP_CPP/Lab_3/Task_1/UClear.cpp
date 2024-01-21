//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UClear.h"
#include "UMain.h"
#include "VectorShort.h"
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
  VectorShort v(FormMain->stg1->RowCount, 0);

  v.PrintToStg(FormMain->stg1);
}
//---------------------------------------------------------------------------

void __fastcall TFormClear::btnClear2Click(TObject *Sender)
{
  VectorShort v(FormMain->stg1->RowCount, 0);

  v.PrintToStg(FormMain->stg2);
}
//---------------------------------------------------------------------------

void __fastcall TFormClear::btnClearBothClick(TObject *Sender)
{
  VectorShort v(FormMain->stg1->RowCount, 0);

  v.PrintToStg(FormMain->stg1);
  v.PrintToStg(FormMain->stg2);
}
//---------------------------------------------------------------------------

