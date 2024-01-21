//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UMain.h"
#include "MatrixShort.h"
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
  MatrixShort m(4, 4);
  m.PrintToStg(stg1);
  m.PrintToStg(stg2);
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnColCountPlus1Click(TObject *Sender)
{
  stg1->ColCount++;
  stg1->Cells[stg1->ColCount-1][0] = IntToStr(stg1->ColCount-1);
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnColCountMinus1Click(TObject *Sender)
{
  if(stg1->ColCount > 2) stg1->ColCount--;
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnRowCountMinus1Click(TObject *Sender)
{
  if(stg1->RowCount > 2) stg1->RowCount--;
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnRowCountPlus1Click(TObject *Sender)
{
  stg1->RowCount++;
  stg1->Cells[0][stg1->RowCount-1] = IntToStr(stg1->RowCount-1);
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnColCountMinus2Click(TObject *Sender)
{
  if(stg2->ColCount > 2) stg2->ColCount--;
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnColCountPlus2Click(TObject *Sender)
{
  stg2->ColCount++;
  stg2->Cells[stg2->ColCount-1][0] = IntToStr(stg2->ColCount-1);
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnRowCountMinus2Click(TObject *Sender)
{
  if(stg2->RowCount > 2) stg2->RowCount--;
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnRowCountPlus2Click(TObject *Sender)
{
  stg2->RowCount++;
  stg2->Cells[0][stg2->RowCount-1] = IntToStr(stg2->RowCount-1);
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
void __fastcall TFormMain::btnReverseClick(TObject *Sender)
{
  MatrixShort m1, m2, temp;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  temp = m1;
  m1 = m2;
  m2 = temp;

  m1.PrintToStg(stg1);
  m2.PrintToStg(stg2);
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnAddClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  m1 += m2;

  m1.PrintToStg(FormResult->stg);

  FormResult->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnSubClick(TObject *Sender)
{
  MatrixShort m1, m2;

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
void __fastcall TFormMain::btnMoreClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  if(m1 > m2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnLessClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  if(m1 < m2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnEqualClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  if(m1 == m2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnMoreEqualClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  if(m1 >= m2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnLessEqualClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  if(m1 <= m2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------d
void __fastcall TFormMain::btnNotEqualClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  if(m1 != m2)
    ShowMessage("TRUE");
  else
    ShowMessage("FALSE");
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnDivisionClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  m1 /= m2;

  m1.PrintToStg(FormResult->stg);

  FormResult->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnRemainderOfDivisionClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  m1 %= m2;

  m1.PrintToStg(FormResult->stg);

  FormResult->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnBitAddClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  m1 |= m2;

  m1.PrintToStg(FormResult->stg);

  FormResult->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnBitAddMod2Click(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  m1 ^= m2;

  m1.PrintToStg(FormResult->stg);

  FormResult->Show();
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::btnBitLandslideToRightClick(TObject *Sender)
{
  MatrixShort m1, m2;

  m1.ReadFromStg(stg1);
  m2.ReadFromStg(stg2);

  m1 >>= m2;

  m1.PrintToStg(FormResult->stg);

  FormResult->Show();
}
//---------------------------------------------------------------------------
