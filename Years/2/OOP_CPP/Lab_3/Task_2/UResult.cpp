//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UResult.h"
#include "UMain.h"
#include "MatrixShort.h"
//---------------------------------------------------------------------------
TFormResult *FormResult;
//---------------------------------------------------------------------------
__fastcall TFormResult::TFormResult(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFormResult::btnCloseClick(TObject *Sender)
{
  FormResult->Close();      
}
//---------------------------------------------------------------------------
void __fastcall TFormResult::btnWrite1Click(TObject *Sender)
{
  MatrixShort m;

  m.ReadFromStg(FormResult->stg);

  m.PrintToStg(FormMain->stg1);

  FormMain->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormResult::btnWrite2Click(TObject *Sender)
{
  MatrixShort m;

  m.ReadFromStg(FormResult->stg);

  m.PrintToStg(FormMain->stg2);
  
  FormMain->Show();
}
//---------------------------------------------------------------------------

