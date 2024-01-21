//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UMultOnValue.h"
#include "UMultiply.h"
#include "UResult.h"
#include "VectorShort.h"
#include "UMain.h"
//---------------------------------------------------------------------------
TFormMultOnValue *FormMultOnValue;
//---------------------------------------------------------------------------
__fastcall TFormMultOnValue::TFormMultOnValue(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFormMultOnValue::btnCloseClick(TObject *Sender)
{
  FormMultOnValue->Close();      
}
//---------------------------------------------------------------------------

void __fastcall TFormMultOnValue::btnOkClick(TObject *Sender)
{
  int temp;
  if(TryStrToInt(edtValue->Text, temp)){
    VectorShort v;

    if(RadioGroup->ItemIndex == 0)
      v.ReadFromStg(FormMain->stg1);
    else
      v.ReadFromStg(FormMain->stg2);

    v *= StrToInt(edtValue->Text);
    v.PrintToStg(FormResult->stg);
    FormMultOnValue->Close();
    FormResult->Show();

  }
  else
    ShowMessage("Заповніть поле цілим числом");
}
//---------------------------------------------------------------------------
