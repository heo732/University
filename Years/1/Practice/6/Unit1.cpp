//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
void Kover(TImage *&img, int x1, int x2, int y1, int y2){
  int w, h;
  img->Canvas->Pen->Color = clBlack;
  img->Canvas->Brush->Color = clBlack;
  w = x2-x1;
  h = y2-y1;
  img->Canvas->Rectangle(x1 + w/3, y1 + h/3, x2 - w/3, y2 - h/3);
  w /= 3;
  h /= 3;
  if(w > 2){
    //три верхні
    Kover(img, x1, x1+w, y1, y1+h);
    Kover(img, x1+w, x1+2*w, y1, y1+h);
    Kover(img, x1+2*w, x1+3*w, y1, y1+h);
    //три нижні
    Kover(img, x1, x1+w, y1+2*h, y1+3*h);
    Kover(img, x1+w, x1+2*w, y1+2*h, y1+3*h);
    Kover(img, x1+2*w, x1+3*w, y1+2*h, y1+3*h);
    //лівий
    Kover(img, x1, x1+w, y1+h, y1+2*h);
    //правий
    Kover(img, x1+2*w, x1+3*w, y1+h, y1+2*h);
  }
}
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnPaintClick(TObject *Sender)
{ 
  int step = 0;
  double len = 0;

  frm->img->

  Kover(img, 0, img->Width, 0, img->Height);
}
//---------------------------------------------------------------------------
