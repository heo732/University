//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "UMain.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include "TParallelogram.h"
#include "UAlpha.h"
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
  TParallelogram P;
  P.FullFillImage(ImageColor, clRed);
  P.FullFillImage(Image, clWhite);
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::ButtonDrawClick(TObject *Sender)
{
  TParallelogram P;
  long double t;


  if(TryStrToFloat(EditBase->Text, t) && TryStrToFloat(EditHeight->Text, t) && TryStrToFloat(EditSide->Text, t) && TryStrToFloat(EditAlpha->Text, t))
  {
    switch(RadioGroupLocks->ItemIndex){
      case 0:{ //lockHeight - false
        P.SetLocks(false, true, true);

        if(
            P.SetBase(StrToFloat(EditBase->Text)) &&
            P.SetSide(StrToFloat(EditSide->Text)) &&
            P.SetAlpha(StrToFloat(EditAlpha->Text)) &&
            P.SetHeight(StrToFloat(EditHeight->Text)) //Must call last
          )
        {
          P.SetColor(P.GetColorImage(ImageColor));
          P.DrawInImage(Image);

          LabelPerimeter->Caption = FloatToStr(P.Perimeter());
          LabelArea->Caption = FloatToStr(P.Area()) + " (кв.од.)";

          EditHeight->Text = FloatToStr(P.GetHeight());
          EditSide->Text = FloatToStr(P.GetSide());
          EditAlpha->Text = FloatToStr(P.GetAlpha());
        }
        break;
      }
      case 1:{//lockSide - false
        P.SetLocks(true, false, true);

        if(
            P.SetBase(StrToFloat(EditBase->Text)) &&
            P.SetAlpha(StrToFloat(EditAlpha->Text)) &&
            P.SetHeight(StrToFloat(EditHeight->Text)) &&
            P.SetSide(StrToFloat(EditSide->Text)) //Must call last
          )
        {
          P.SetColor(P.GetColorImage(ImageColor));
          P.DrawInImage(Image);

          LabelPerimeter->Caption = FloatToStr(P.Perimeter());
          LabelArea->Caption = FloatToStr(P.Area()) + " (кв.од.)";

          EditHeight->Text = FloatToStr(P.GetHeight());
          EditSide->Text = FloatToStr(P.GetSide());
          EditAlpha->Text = FloatToStr(P.GetAlpha());
        }
        break;
      }
      case 2:{//lockAlpha - false
        P.SetLocks(true, true, false);

        if(
            P.SetBase(StrToFloat(EditBase->Text)) &&
            P.SetHeight(StrToFloat(EditHeight->Text)) &&
            P.SetSide(StrToFloat(EditSide->Text)) &&
            P.SetAlpha(StrToFloat(EditAlpha->Text)) //Must call last
          )
        {
          FormAlpha->Button1->Caption = FloatToStr(90+P.GetBeta());
          FormAlpha->Button2->Caption = FloatToStr(90-P.GetBeta());

          FormAlpha->Show();
          FormMain->Enabled = false;
        }
        break;
      }
    }


  }
  else
    ShowMessage("Заповніть поля коректно");
}
//---------------------------------------------------------------------------
void __fastcall TFormMain::ImageColorClick(TObject *Sender)
{
  if(ColorDialog->Execute()){
    TParallelogram P;
    P.FullFillImage(ImageColor, ColorDialog->Color);
  }
}
//---------------------------------------------------------------------------
