//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "USize.h"
#include "UMain.h"
//---------------------------------------------------------------------------
TFormSize *FormSize;
//---------------------------------------------------------------------------
__fastcall TFormSize::TFormSize(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFormSize::btnCloseClick(TObject *Sender)
{
  FormSize->Close();      
}
//---------------------------------------------------------------------------

void __fastcall TFormSize::btnOkClick(TObject *Sender)
{
  if( TryStrToInt(edtRowCount->Text, 0) && TryStrToInt(edtColCount->Text, 0)
      && StrToInt(edtRowCount->Text)>0 && StrToInt(edtColCount->Text)>0
    )
  {
    unsigned int rows = StrToInt(edtRowCount->Text);
    unsigned int cols = StrToInt(edtColCount->Text);

    FormMain->stg1->RowCount = rows+1;
    FormMain->stg2->RowCount = rows+1;
    FormMain->stg1->ColCount = cols+1;
    FormMain->stg2->ColCount = cols+1;

    for(unsigned int i=1; i<=rows; i++){
      FormMain->stg1->Cells[0][i] = IntToStr(i);
      FormMain->stg2->Cells[0][i] = IntToStr(i);
    }

    for(unsigned int i=1; i<=cols; i++){
      FormMain->stg1->Cells[i][0] = IntToStr(i);
      FormMain->stg2->Cells[i][0] = IntToStr(i);
    }

    FormMain->Show();
    FormSize->Close();

  }
  else
    ShowMessage("Заповніть поля цілими додатніми значеннями");
}
//---------------------------------------------------------------------------

