//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "UMain.h"
#include "TRozpodil.h"
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
void __fastcall TForm_Main::Button_DoClick(TObject *Sender)
{
  int* x;
  x = new int[StringGrid->ColCount];
  for(int i=0; i<StringGrid->ColCount; i++)
    x[i] = StrToInt(StringGrid->Cells[i][0]);

  TRozpodil R(StrToInt(Edit_Count_exp->Text), StringGrid->ColCount, x);

  R.CarryOutExperiments();
  double* P = R.GetP();

  for(int i=0; i<StringGrid->ColCount; i++)
    StringGrid->Cells[i][1] = FloatToStr(P[i]);
}
//---------------------------------------------------------------------------
void __fastcall TForm_Main::Button_MinusClick(TObject *Sender)
{
  if(StringGrid->ColCount > 2) StringGrid->ColCount--;
}
//---------------------------------------------------------------------------
void __fastcall TForm_Main::Button_PlusClick(TObject *Sender)
{
  StringGrid->ColCount++;
}
//---------------------------------------------------------------------------
int RandomInt(){
  int value = rand() % 20 - 10;
  return value;
}
//---------------------------------------------------------------------------
void __fastcall TForm_Main::Button_GenerateClick(TObject *Sender)
{
  srand(time(0));
  int R = RandomInt();
  int s = abs(RandomInt());

  StringGrid->Cells[0][0] = IntToStr(R);
  for(int i=1; i<StringGrid->ColCount; i++)
    StringGrid->Cells[i][0] = IntToStr( StrToInt(StringGrid->Cells[i-1][0]) + s );
}
//---------------------------------------------------------------------------

