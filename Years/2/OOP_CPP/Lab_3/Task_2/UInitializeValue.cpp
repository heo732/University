//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UInitializeValue.h"
#include "URead.h"
#include "UMain.h"
#include "MatrixShort.h"
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
    MatrixShort m(FormMain->stg1->RowCount-1, FormMain->stg1->ColCount-1, StrToInt(edtValue->Text));

    if(FormRead->RadioGroup->ItemIndex == 0){
      m.ReadFromStg(FormMain->stg1);
      m = StrToInt(edtValue->Text);
      m.PrintToStg(FormMain->stg1);
    }
    else{
      m.ReadFromStg(FormMain->stg2);
      m = StrToInt(edtValue->Text);
      m.PrintToStg(FormMain->stg2);
    }

    FormInitializeValue->Close();
  }
  else
    ShowMessage("Заповніть поле цілим числом");
}
//---------------------------------------------------------------------------