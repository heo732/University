//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <fstream>
using namespace std;
//---------------------------------------------------------------------------
//-1 правильно
//>=0 номер першого неправильного елемента
short IsCorrect(unsigned short input[64])
{

  for(short i=0; i<64; i++)//цикл по елементах
  {
    unsigned short sum1 = 0, sum2 = 0, mask;

    for(unsigned short j=0; j<=5; j++)//цикл по бітах
    {
      mask = 1 << j;
      mask = input[i] & mask;
      mask >>= j;
      sum1 ^= mask;
    }
    mask = 1 << 14;
    mask = input[i] & mask;
    mask >>= 14;
    sum1 ^= mask;

    for(unsigned short j=6; j<=13; j++)//цикл по бітах
    {
      mask = 1 << j;
      mask = input[i] & mask;
      mask >>= j;
      sum2 ^= mask;
    }
    mask = 1 << 15;
    mask = input[i] & mask;
    mask >>= 15;
    sum2 ^= mask;

    if(!(sum1==0 && sum2==0))//якщо одна з сум непарна
      return i;
  }

  return -1;
}
//---------------------------------------------------------------------------
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnClick(TObject *Sender)
{
  unsigned short input[64];


  for(unsigned short i=0; i<64; i++)
    input[i] = 40600;
  input[20] = 40601;



  short res = IsCorrect(input);
  if(res == -1)
    edt->Text = "correct";
  else
    edt->Text = "incorrect - " + IntToStr(res);
}
//---------------------------------------------------------------------------
