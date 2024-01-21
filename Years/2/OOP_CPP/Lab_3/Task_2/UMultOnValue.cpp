//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UMultOnValue.h"
#include "UMultiply.h"
#include "UResult.h"
#include "MatrixShort.h"
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
    MatrixShort m;

    if(RadioGroup->ItemIndex == 0)
      m.ReadFromStg(FormMain->stg1);
    else
      m.ReadFromStg(FormMain->stg2);

    m *= StrToInt(edtValue->Text);
    m.PrintToStg(FormResult->stg);
    FormMultOnValue->Close();
    FormResult->Show();

  }
  else
    ShowMessage("Заповніть поле цілим числом");
}
//---------------------------------------------------------------------------
