//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "URead.h"
#include "UMain.h"
#include "UInitializeValue.h"
#include "ClassMatrix.h"
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
  TMatrix m(FormMain->stg1->RowCount-1, FormMain->stg1->ColCount-1, 0);
  m.RandomFilling();

  if(rgMatrix->ItemIndex == 0)
    m.PrintToStg(FormMain->stg1);
  else
    m.PrintToStg(FormMain->stg2);
}
//---------------------------------------------------------------------------

void __fastcall TFormRead::btnReadFromFileClick(TObject *Sender)
{
  TMatrix m(FormMain->stg1->RowCount-1, FormMain->stg1->ColCount-1, 0);

  if(odl->Execute()){
    String fname = odl->FileName;

    if(m.ReadFromFile(fname) == 1)
      ShowMessage("Файл не знайдено");
    else

      if(rgMatrix->ItemIndex == 0)
        m.PrintToStg(FormMain->stg1);
      else
        m.PrintToStg(FormMain->stg2);

  }
}
//---------------------------------------------------------------------------

