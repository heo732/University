//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "UAlpha.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "UMain.h"
#include "TParallelogram.h"
//---------------------------------------------------------------------------
TFormAlpha *FormAlpha;
//---------------------------------------------------------------------------
__fastcall TFormAlpha::TFormAlpha(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFormAlpha::Button1Click(TObject *Sender)
{
  TParallelogram P;
  P.SetLocks(true, true, false);

        if(
            P.SetBase(StrToFloat(FormMain->EditBase->Text)) &&
            P.SetHeight(StrToFloat(FormMain->EditHeight->Text)) &&
            P.SetSide(StrToFloat(FormMain->EditSide->Text)) &&
            P.SetAlpha(StrToFloat(FormMain->EditAlpha->Text)) //Must call last
          )
        {
          ///
          P.SetLocks(false, true, true);
          bool b = P.SetAlpha(90+P.GetBeta());
          ///

          P.SetColor(P.GetColorImage(FormMain->ImageColor));
          P.DrawInImage(FormMain->Image);

          FormMain->LabelPerimeter->Caption = FloatToStr(P.Perimeter());
          FormMain->LabelArea->Caption = FloatToStr(P.Area()) + " (кв.од.)";

          FormMain->EditHeight->Text = FloatToStr(P.GetHeight());
          FormMain->EditSide->Text = FloatToStr(P.GetSide());
          FormMain->EditAlpha->Text = FloatToStr(P.GetAlpha());

          ///
          FormMain->Enabled = true;
          FormAlpha->Close();
          ///
        }
}
//---------------------------------------------------------------------------
void __fastcall TFormAlpha::Button2Click(TObject *Sender)
{
  TParallelogram P;
  P.SetLocks(true, true, false);

        if(
            P.SetBase(StrToFloat(FormMain->EditBase->Text)) &&
            P.SetHeight(StrToFloat(FormMain->EditHeight->Text)) &&
            P.SetSide(StrToFloat(FormMain->EditSide->Text)) &&
            P.SetAlpha(StrToFloat(FormMain->EditAlpha->Text)) //Must call last
          )
        {
          ///
          P.SetLocks(false, true, true);
          bool b = P.SetAlpha(90-P.GetBeta());
          ///

          P.SetColor(P.GetColorImage(FormMain->ImageColor));
          P.DrawInImage(FormMain->Image);

          FormMain->LabelPerimeter->Caption = FloatToStr(P.Perimeter());
          FormMain->LabelArea->Caption = FloatToStr(P.Area()) + " (кв.од.)";

          FormMain->EditHeight->Text = FloatToStr(P.GetHeight());
          FormMain->EditSide->Text = FloatToStr(P.GetSide());
          FormMain->EditAlpha->Text = FloatToStr(P.GetAlpha());

          ///
          FormMain->Enabled = true;
          FormAlpha->Close();
          ///
        }
}
//---------------------------------------------------------------------------
