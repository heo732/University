//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UMain.h"
#include "ClassMatrix.h"
#include "UResult.h"
#include "USize.h"
#include "URead.h"
#include "UClear.h"
#include "UMultiply.h"
#include "UInitializeValue.h"
#include "UMultOnValue.h"
//---------------------------------------------------------------------------
TFormMain *FormMain;
//---------------------------------------------------------------------------
__fastcall TFormMain::TFormMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------


void __fastcall TFormMain::btnColCountPlusClick(TObject *Sender)
{
  stg1->ColCount++;
  stg2->ColCount++;
  stg1->Cells[stg1->ColCount-1][0] = stg1->ColCount-1;
  stg2->Cells[stg2->ColCount-1][0] = stg2->ColCount-1;
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::FormCreate(TObject *Sender)
{
  for(unsigned int i=1; i<stg1->ColCount; i++){
    stg1->Cells[i][0] = IntToStr(i);
    stg1->Cells[0][i] = IntToStr(i);
    stg2->Cells[i][0] = IntToStr(i);
    stg2->Cells[0][i] = IntToStr(i);
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnColCountMinusClick(TObject *Sender)
{
  if(stg1->ColCount > 2){
    stg1->ColCount--;
    stg2->ColCount--;
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnRowCountMinusClick(TObject *Sender)
{
  if(stg1->RowCount > 2){
    stg1->RowCount--;
    stg2->RowCount--;
  }
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnRowCountPlusClick(TObject *Sender)
{
  stg1->RowCount++;
  stg2->RowCount++;
  stg1->Cells[0][stg1->RowCount-1] = stg1->RowCount-1;
  stg2->Cells[0][stg2->RowCount-1] = stg2->RowCount-1;
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnMoreClick(TObject *Sender)
{
  TMatrix m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  if(m1 > m2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnLessOrNotEqualClick(TObject *Sender)
{
  TMatrix m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  if(m1.LessOrNotEqual(m2))
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnReverseClick(TObject *Sender)
{
  TMatrix m1, m2, temp;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  temp = m1;
  m1 = m2;
  m2 = temp;

  m1.PrintToStg(stg1);
  m2.PrintToStg(stg2);
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnSizeClick(TObject *Sender)
{
  FormSize->Show();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnReadClick(TObject *Sender)
{
  FormRead->Show();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnClearClick(TObject *Sender)
{
  FormClear->Show();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnAddClick(TObject *Sender)
{
  TMatrix m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  m1 += m2;

  m1.PrintToStg(FormResult->stg);

  FormResult->Show();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnSubClick(TObject *Sender)
{
  TMatrix m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  m1 -= m2;

  m1.PrintToStg(FormResult->stg);

  FormResult->Show();
}
//---------------------------------------------------------------------------

void __fastcall TFormMain::btnMultiplyClick(TObject *Sender)
{
  FormMultiply->Show();      
}
//---------------------------------------------------------------------------


