//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <math.h>
//---------------------------------------------------------------------------
void OsiKoordynat(TImage *&img){
  img->Canvas->Pen->Color = clBlack;
  img->Canvas->Pen->Width = 3;

  img->Canvas->MoveTo(img->Width / 2, img->Height);
  img->Canvas->LineTo(img->Width / 2, 0);
  img->Canvas->LineTo(img->Width / 2 - 10, 10);
  img->Canvas->MoveTo(img->Width / 2, 0);
  img->Canvas->LineTo(img->Width / 2 + 10, 10);

  img->Canvas->MoveTo(0, img->Height / 2);
  img->Canvas->LineTo(img->Width, img->Height / 2);
  img->Canvas->LineTo(img->Width - 10, img->Height / 2 - 10);
  img->Canvas->MoveTo(img->Width, img->Height / 2);
  img->Canvas->LineTo(img->Width - 10, img->Height / 2 + 10);
}
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnCurveHClick(TObject *Sender)
{
  if(
    frm->edtPx1->Text.IsEmpty() ||
    frm->edtPy1->Text.IsEmpty() ||
    frm->edtPx2->Text.IsEmpty() ||
    frm->edtPy2->Text.IsEmpty() ||
    frm->edtRx1->Text.IsEmpty() ||
    frm->edtRy1->Text.IsEmpty() ||
    frm->edtRx2->Text.IsEmpty() ||
    frm->edtRy2->Text.IsEmpty()
    )
    ShowMessage("Заповніть всі поля");
  else{
    double Px1, Py1, Px2, Py2, Rx1, Ry1, Rx2, Ry2;
    double x0, y0;

    Px1 = StrToFloat(frm->edtPx1->Text);
    Py1 = StrToFloat(frm->edtPy1->Text);
    Px2 = StrToFloat(frm->edtPx2->Text);
    Py2 = StrToFloat(frm->edtPy2->Text);
    Rx1 = StrToFloat(frm->edtRx1->Text);
    Ry1 = StrToFloat(frm->edtRy1->Text);
    Rx2 = StrToFloat(frm->edtRx2->Text);
    Ry2 = StrToFloat(frm->edtRy2->Text);

    frm->img->Canvas->Pen->Color = clGreen;
    frm->img->Canvas->Pen->Width = 3;

    x0 = frm->img->Width / 2;
    y0 = frm->img->Height / 2;

    frm->img->Canvas->MoveTo(floor(x0 + Px1), floor(y0 - Py1));
    for(double t = 0; t <= 1; t+=0.01){
      int x, y;
      x = floor(x0 + Px1 * (2*t*t*t - 3*t*t + 1) + Px2 * (-2*t*t*t + 3*t*t) + Rx1 * (t*t*t - 2*t*t + t) + Rx2 * (t*t*t - t*t));
      y = floor(y0 - (Py1 * (2*t*t*t - 3*t*t + 1) + Py2 * (-2*t*t*t + 3*t*t) + Ry1 * (t*t*t - 2*t*t + t) + Ry2 * (t*t*t - t*t)));
      frm->img->Canvas->LineTo(x, y);        
    }
  }
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnCurveBClick(TObject *Sender)
{
  if(
    frm->edtPx1->Text.IsEmpty() ||
    frm->edtPy1->Text.IsEmpty() ||
    frm->edtPx2->Text.IsEmpty() ||
    frm->edtPy2->Text.IsEmpty() ||
    frm->edtRx1->Text.IsEmpty() ||
    frm->edtRy1->Text.IsEmpty() ||
    frm->edtRx2->Text.IsEmpty() ||
    frm->edtRy2->Text.IsEmpty()
    )
    ShowMessage("Заповніть всі поля");
  else{
    double Px1, Py1, Px2, Py2, Px3, Py3, Px4, Py4;
    double x0, y0;

    Px1 = StrToFloat(frm->edtPx1->Text);
    Py1 = StrToFloat(frm->edtPy1->Text);
    Px2 = StrToFloat(frm->edtPx2->Text);
    Py2 = StrToFloat(frm->edtPy2->Text);
    Px3 = StrToFloat(frm->edtRx1->Text);
    Py3 = StrToFloat(frm->edtRy1->Text);
    Px4 = StrToFloat(frm->edtRx2->Text);
    Py4 = StrToFloat(frm->edtRy2->Text);

    frm->img->Canvas->Pen->Color = clRed;
    frm->img->Canvas->Pen->Width = 3;

    x0 = frm->img->Width / 2;
    y0 = frm->img->Height / 2;

    frm->img->Canvas->MoveTo(floor(x0 + Px1), floor(y0 - Py1));
    for(double t = 0; t <= 1; t+=0.01){
      int x, y;
      x = floor(x0 + Px1 * (1-t)*(1-t)*(1-t) + 3*t * Px2 * (1-t)*(1-t) + 3*t*t * Px3 * (1-t) + t*t*t * Px4);
      y = floor(y0 - (Py1 * (1-t)*(1-t)*(1-t) + 3*t * Py2 * (1-t)*(1-t) + 3*t*t * Py3 * (1-t) + t*t*t * Py4));
      frm->img->Canvas->LineTo(x, y);        
    }
  }      
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnClearClick(TObject *Sender)
{
  frm->img->Picture->Bitmap = NULL;    
  OsiKoordynat(frm->img);  
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::FormCreate(TObject *Sender)
{
  OsiKoordynat(frm->img);      
}
//---------------------------------------------------------------------------