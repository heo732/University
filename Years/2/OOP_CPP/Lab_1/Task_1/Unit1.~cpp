//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
char Shifr(char in)
{
  char out;
  unsigned int mask56 = 3 << 4;

  out = in ^ mask56;
  return out;
}
//---------------------------------------------------------------------------
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::memInChange(TObject *Sender)
{
  if(memIn->Text != "")
  {
    String strin, strout;

    memOut->Text = "";

    for(unsigned int j=0; j<memIn->Lines->Count; j++)
    {
      strin = memIn->Lines->Strings[j];
      strout = "";

      for(unsigned int i=1; i<=strin.Length(); i++)
      {
        if(strin[i] != ' ')
          strout += Shifr(strin[i]);
        else
          strout += strin[i];
      }

      memOut->Lines->Add(strout);
    }
  }
}
//---------------------------------------------------------------------------
