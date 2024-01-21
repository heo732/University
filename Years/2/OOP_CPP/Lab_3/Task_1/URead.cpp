//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "URead.h"
#include "UMain.h"
#include "UInitializeValue.h"
#include "VectorShort.h"
//---------------------------------------------------------------------------
TFormRead *FormRead;
//---------------------------------------------------------------------------
__fastcall TFormRead::TFormRead(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFormRead::btnCloseClick(TObject *Sender)
{
  FormRead->Close();
}
//---------------------------------------------------------------------------

void __fastcall TFormRead::btnInitializeClick(TObject *Sender)
{
  FormInitializeValue->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormRead::btnRandomFillClick(TObject *Sender)
{
  VectorShort v(FormMain->stg1->RowCount);
  v.RandomFilling();

  if(RadioGroup->ItemIndex == 0)
    v.PrintToStg(FormMain->stg1);
  else
    v.PrintToStg(FormMain->stg2); 
}
//---------------------------------------------------------------------------
void __fastcall TFormRead::btnReadFromFileClick(TObject *Sender)
{
  VectorShort v(FormMain->stg1->RowCount);

  if(OpenDialog->Execute()){
    String fname = OpenDialog->FileName;

    if(v.ReadFromFile(fname))

      if(RadioGroup->ItemIndex == 0)
        v.PrintToStg(FormMain->stg1);
      else
        v.PrintToStg(FormMain->stg2);

  else
    ShowMessage("Файл не знайдено");
  }
}
//---------------------------------------------------------------------------

