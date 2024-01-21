//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UInitializeValue.h"
#include "URead.h"
#include "UMain.h"
#include "ClassMatrix.h"
//---------------------------------------------------------------------------
TFormInitializeValue *FormInitializeValue;
//---------------------------------------------------------------------------
__fastcall TFormInitializeValue::TFormInitializeValue(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFormInitializeValue::btnCloseClick(TObject *Sender)
{
  FormInitializeValue->Close();
}
//---------------------------------------------------------------------------

void __fastcall TFormInitializeValue::btnOkClick(TObject *Sender)
{
  if(TryStrToInt(edtValue->Text, 0)){
    TMatrix m(FormMain->stg1->RowCount-1, FormMain->stg1->ColCount-1, StrToInt(edtValue->Text));

    if(FormRead->rgMatrix->ItemIndex == 0)
      m.PrintToStg(FormMain->stg1);
    else
      m.PrintToStg(FormMain->stg2);

    FormInitializeValue->Close();  
  }
  else
    ShowMessage("Заповніть поле цілим числом");
}
//---------------------------------------------------------------------------

