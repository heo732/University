//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include <string>
using namespace std;
//---------------------------------------------------------------------------
//������� TRUE, ���� ��������� ���������� �������� - �����, ������ - FALSE
bool IsNumber(char c){
  if(
    c == '0' ||
    c == '1' ||
    c == '2' ||
    c == '3' ||
    c == '4' ||
    c == '5' ||
    c == '6' ||
    c == '7' ||
    c == '8' ||
    c == '9'
    )
    return true;
  return false;
}
//---------------------------------------------------------------------------
//������� TRUE, ���� � ���������� ����� ����������� ����� ���������� �����, ������ - FALSE
bool IsInputNaturalValue(string s){
  if(s[0] == '0')
    return false;
  if(s.size() == 0)
    return false;
  unsigned int cntNumbers=0,i;
  for(i = 0; i < s.size(); i++)
    if(IsNumber(s[i]))
      cntNumbers++;
  if(cntNumbers == s.size())
    return true;
  return false; 
}
//---------------------------------------------------------------------------
//������� �������� ���������� ���������
long double Factorial(unsigned int f){
  if(f > 2)
    return f * Factorial(f - 1);
  return f;
}
//---------------------------------------------------------------------------
//������� �������� ���������� ��������� ����
long double Sum(long double a, long double b, unsigned int k, unsigned int n){

  long double tmpA = a, tmpB = b;
  if(k != 1){
    tmpA = 0.3 * b + 0.2 * a;
    tmpB = a * a + b  * b;
  }
  a = tmpA;
  b = tmpB;

  long double s = 0;
  if(k < n)
    s = Sum(a, b, k+1, n);

  return a * b / Factorial(k + 1) + s;
}
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnDoClick(TObject *Sender)
{
  unsigned int n;

  if(IsInputNaturalValue(edtN->Text.c_str()))//���� ������� ���������� �����
    if(StrToInt(edtN->Text.c_str()) >= 1 && StrToInt(edtN->Text.c_str()) <= 15){
      n = StrToInt(edtN->Text);
      edtRes->Text = FloatToStr(Sum(1, 1, 1, n));
    }
    else
      ShowMessage("������ ���������� ����� � �������� [1; 15]");      
  else
    ShowMessage("������ ���������� �����!");
}
//---------------------------------------------------------------------------