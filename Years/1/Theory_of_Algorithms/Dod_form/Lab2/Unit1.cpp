//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <string>
using namespace std;
//---------------------------------------------------------------------------
int FindCount(string str,string word)//������� ������� �������� ����� word � ����� str
{
  int cnt=0;
  
  if(word!="" && str!="")
    while(str.find(word,0)!=string::npos)
    {
      str=str.substr(str.find(word,0)+word.size(),str.size()-str.find(word,0)+word.size());//��������� ������� �� ����� str ��������� �� ���� ��������� ���������� ����� word � ����� ����� �� ���� �����
      cnt++;
    }
    
  return cnt;  
}
//---------------------------------------------------------------------------
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::edtWordChange(TObject *Sender)
{
  string str,word;
    
  str=edtStr->Text.c_str();
  word=edtWord->Text.c_str();
    
  lblCount->Caption=IntToStr(FindCount(str,word));  
}
//---------------------------------------------------------------------------
void __fastcall TForm1::edtStrChange(TObject *Sender)
{
  string str,word;
    
  str=edtStr->Text.c_str();
  word=edtWord->Text.c_str();
    
  lblCount->Caption=IntToStr(FindCount(str,word));
}
//---------------------------------------------------------------------------