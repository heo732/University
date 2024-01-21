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
  if( TryStrToInt(edtRowCount->Text, temp) && StrToInt(edtRowCount->Text)>0 )
  {
    unsigned int rows = StrToInt(edtRowCount->Text);

    FormMain->stg1->RowCount = rows;
    FormMain->stg2->RowCount = rows;

    for(unsigned int i=0; i<rows; i++){
      FormMain->stg1->Cells[0][i] = IntToStr(i+1);
      FormMain->stg2->Cells[0][i] = IntToStr(i+1);
    }

    FormMain->Show();
    FormSize->Close();

  }
  else
    ShowMessage("��������� ���� ������ ��������� ����������");
}
//---------------------------------------------------------------------------

