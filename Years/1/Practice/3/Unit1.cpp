//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <stdio.h>
//---------------------------------------------------------------------------
bool IsPunct(char c)
{
  String punct = ".,!?:;' ";
  if(punct.Pos(c) > 0 || c == '\"' || c == '\n' || c == '\r' || c == '\0')
    return true;
  return false;
}
//---------------------------------------------------------------------------
void DeleteWords(String str1, String str2, String &strOut)
{
  int i, start, end, len, i1, start1, end1, len1;
  bool letter = false, letter1 = false;
  String word, word1;

  str1 += '\0';
  str2 += '\0';
  str1.Insert(' ', 1);
  str2.Insert(' ', 1);

  for(i = 1; i <= str2.Length(); i++)
  {
    switch(letter)
    {
      case false:
      {
        if(IsPunct(str2[i]))
          break;
        else
        {
          start = i;
          letter = true;
          break;
        }
      }
      case true:
      {
        if(!(IsPunct(str2[i])))
          break;
        else
        {
          end = i - 1;
          letter = false;
          len = end - start + 1;
          word = str2.SubString(start, len);
          for(i1 = 1; i1 <= str1.Length(); i1++)
            switch(letter1)
            {
              case false:
              {
                if(IsPunct(str1[i1]))
                  break;
                else
                {
                  start1 = i1;
                  letter1 = true;
                  break;
                }
              }
              case true:
              {
                if(!(IsPunct(str1[i1])))
                  break;
                else
                {
                  end1 = i1 - 1;
                  letter1 = false;
                  len1 = end1 - start1 + 1;
                  word1 = str1.SubString(start1, len1);
                  if(word == word1 && IsPunct(str1[start1-1]) && IsPunct(str1[end1+1]))
                  {
                    str1.Delete(start1, len1);
                    i1 = start1 - 1;
                  }
                  break;
                }
              }
            }
          break;
        }
      }
    }
  }
  str1.Delete(1, 1);
  strOut = str1;
}
//---------------------------------------------------------------------------
String nameFileIn1="", nameFileIn2="", nameFileOut="";
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnFileIn1Click(TObject *Sender)
{
  if(odl->Execute())
  {
    nameFileIn1 = odl->FileName;
    memIn1->Lines->LoadFromFile(nameFileIn1);
    lblNameFileIn1->Caption = nameFileIn1;
  }
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnFileIn2Click(TObject *Sender)
{
  if(odl->Execute())
  {
    nameFileIn2 = odl->FileName;
    memIn2->Lines->LoadFromFile(nameFileIn2);
    lblNameFileIn2->Caption = nameFileIn2;
  }
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnFileOutClick(TObject *Sender)
{
  if(sdl->Execute())
  {
    nameFileOut = sdl->FileName;
    lblNameFileOut->Caption = nameFileOut;
  } 
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnDoClick(TObject *Sender)
{
  if(nameFileIn1.Length()==0 || nameFileIn2.Length()==0 || nameFileOut.Length()==0)
    ShowMessage("Оберіть всі файли для опрацювання");
  else
  {
      String str1 = "", str2 = "", strOut = "";
      str1 = memIn1->Text;
      str2 = memIn2->Text;

      DeleteWords(str1, str2, strOut);

      memOut->Text = strOut;
      memOut->Lines->SaveToFile(nameFileOut);
   }
}
//---------------------------------------------------------------------------
