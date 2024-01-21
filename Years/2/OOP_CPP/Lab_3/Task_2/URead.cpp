//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "URead.h"
#include "UMain.h"
#include "UInitializeValue.h"
#include "MatrixShort.h"
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
  MatrixShort m;
  switch(RadioGroup->ItemIndex){
    case 0:{m.ReadFromStg(FormMain->stg1); m.RandomFilling(); m.PrintToStg(FormMain->stg1); break;}
    case 1:{m.ReadFromStg(FormMain->stg2); m.RandomFilling(); m.PrintToStg(FormMain->stg2); break;}
  }
}
//---------------------------------------------------------------------------
void __fastcall TFormRead::btnReadFromFileClick(TObject *Sender)
{
  MatrixShort m;

  if(OpenDialog->Execute()){
    String fname = OpenDialog->FileName;

    switch(RadioGroup->ItemIndex){
      case 0:{m.ReadFromStg(FormMain->stg1);
              if(m.ReadFromFile(fname)) m.PrintToStg(FormMain->stg1);
              else ShowMessage("Файл не знайдено");
              break;
             }
      case 1:{m.ReadFromStg(FormMain->stg2);
              if(m.ReadFromFile(fname)) m.PrintToStg(FormMain->stg2);
              else ShowMessage("Файл не знайдено");
              break;
             }
    }
    
  }
}
//---------------------------------------------------------------------------
