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
  int temp;
  if( TryStrToInt(edtRowCount->Text, temp) && TryStrToInt(edtColCount->Text, temp)
      && StrToInt(edtRowCount->Text)>0 && StrToInt(edtColCount->Text)>0
    )
  {
    int n = StrToInt(edtRowCount->Text);
    int size = StrToInt(edtColCount->Text);

    FormMain->stg1->RowCount = n+1;
    FormMain->stg2->RowCount = n+1;
    FormMain->stg1->ColCount = size+1;
    FormMain->stg2->ColCount = size+1;

    for(int i=1; i<=n; i++){
      FormMain->stg1->Cells[0][i] = IntToStr(i);
      FormMain->stg2->Cells[0][i] = IntToStr(i);
    }

    for(int i=1; i<=size; i++){
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
