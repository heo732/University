//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UInitializeValue.h"
#include "URead.h"
#include "UMain.h"
#include "VectorShort.h"
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
  int temp;
  if(TryStrToInt(edtValue->Text, temp)){
    VectorShort v(FormMain->stg1->RowCount, StrToInt(edtValue->Text));

    if(FormRead->RadioGroup->ItemIndex == 0)
      v.PrintToStg(FormMain->stg1);
    else
      v.PrintToStg(FormMain->stg2);

    FormInitializeValue->Close();
  }
  else
    ShowMessage("Заповніть поле цілим числом");
}
//---------------------------------------------------------------------------

