//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UMain.h"
#include "VectorShort.h"
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
void __fastcall TFormMain::FormCreate(TObject *Sender)
{
  for(int i=0; i<stg1->RowCount; i++){
    stg1->Cells[0][i] = IntToStr(i+1);
    stg2->Cells[0][i] = IntToStr(i+1);
  }
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnRowCountMinusClick(TObject *Sender)
{
  if(stg1->RowCount > 1){
    stg1->RowCount--;
    stg2->RowCount--;
  }
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnRowCountPlusClick(TObject *Sender)
{
  stg1->RowCount++;
  stg2->RowCount++;
  stg1->Cells[0][stg1->RowCount-1] = IntToStr(stg1->RowCount);
  stg2->Cells[0][stg2->RowCount-1] = IntToStr(stg2->RowCount);
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnMoreClick(TObject *Sender)
{
  VectorShort v1, v2;

  v1.ReadFromStg(stg1);
  v2.ReadFromStg(stg2);

  if(v1 > v2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnReverseClick(TObject *Sender)
{
  VectorShort v1, v2, temp;

  v1.ReadFromStg(stg1);
  v2.ReadFromStg(stg2);

  temp = v1;
  v1 = v2;
  v2 = temp;

  v1.PrintToStg(stg1);
  v2.PrintToStg(stg2);
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
  VectorShort v1, v2;  

  v1.ReadFromStg(stg1);
  v2.ReadFromStg(stg2);

  v1 += v2;

  v1.PrintToStg(FormResult->stg);
  FormResult->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnSubClick(TObject *Sender)
{
  VectorShort v1, v2;  

  v1.ReadFromStg(stg1);
  v2.ReadFromStg(stg2);

  v1 -= v2;

  v1.PrintToStg(FormResult->stg);
  FormResult->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnMultiplyClick(TObject *Sender)
{
  FormMultiply->Show();      
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnLessClick(TObject *Sender)
{
  VectorShort v1, v2;

  v1.ReadFromStg(stg1);
  v2.ReadFromStg(stg2);

  if(v1 < v2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnEqualClick(TObject *Sender)
{
  VectorShort v1, v2;

  if(v1.ReadFromStg(stg1) && v2.ReadFromStg(stg2))

  if(v1 == v2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------

