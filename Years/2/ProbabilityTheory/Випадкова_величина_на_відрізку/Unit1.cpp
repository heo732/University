//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "TMod.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm_Main *Form_Main;
//---------------------------------------------------------------------------
__fastcall TForm_Main::TForm_Main(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm_Main::FormCreate(TObject *Sender)
{
  Image1->Canvas->Brush->Color = clWhite;
  Image1->Canvas->Pen->Color = clWhite;
  Image1->Canvas->Rectangle(0, 0, Image1->Width, Image1->Height);      
}
//---------------------------------------------------------------------------
void __fastcall TForm_Main::Button_ExecuteClick(TObject *Sender)
{
  int tmp;
  if(!TryStrToInt(Edit_A->Text, tmp) || !TryStrToInt(Edit_B->Text, tmp) || !TryStrToInt(Edit_Count->Text, tmp))
    ShowMessage("Заповніть всі поля цілими числами");
  else{

    if(StrToInt(Edit_A->Text) >= StrToInt(Edit_B->Text))
      ShowMessage("a < b");
    else{

      if(StrToInt(Edit_Count->Text) <= 0)
        ShowMessage("Задайте кількість > 0");
      else{

        TMod M(StrToInt(Edit_A->Text), StrToInt(Edit_B->Text));
        M.Execute(Image1, StrToInt(Edit_Count->Text));

      }

    }

  }
}
//---------------------------------------------------------------------------
