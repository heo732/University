//---------------------------------------------------------------------------
#pragma hdrstop
#include "TParallelogram.h"
#pragma package(smart_init)
#include <math.h>
//---------------------------------------------------------------------------
TParallelogram::TParallelogram(){
  base = 10;
  height = 10;
  side = 10;
  color = clGreen;
}
//---------------------------------------------------------------------------
TParallelogram::TParallelogram(double b, double h, double s, TColor c){
  base = b;
  height = h;
  side = s;
  color = c;
}
//---------------------------------------------------------------------------
bool TParallelogram::SetBase(double b){
  if(b <= 0){
    ShowMessage("Основа має бути > 0");
    return false;
  }
  base = b;
  return true;
}
//---------------------------------------------------------------------------
bool TParallelogram::SetHeight(double h){
  if(h <= 0){
    ShowMessage("Висота має бути > 0");
    return false;
  }
  if(lockHeight == false){
    height = side * cos(beta/180*M_PI);
    return true;
  }
  height = h;
  return true;
}
//---------------------------------------------------------------------------
bool TParallelogram::SetSide(double s){
  if(s <= 0){
    ShowMessage("Бічна має бути > 0");
    return false;
  }
  if(s < height){
    ShowMessage("Бічна >= Висота");
    return false;
  }
  if(lockSide == false){
    side = height / cos(beta/180*M_PI);
    return true;
  }
  side = s;
  return true;
}
//---------------------------------------------------------------------------
bool TParallelogram::SetAlpha(double a){
  if(a <= 0){
    ShowMessage("Кут > 0");
    return false;
  }
  if(a >= 180){
    ShowMessage("Кут < 180");
    return false;
  }
  if(lockAlpha == false){
    beta = acos(height/side) / M_PI * 180;
    alpha = 90 - beta;
    return true;
  }
  alpha = a;
  beta = fabs(alpha - 90);
  return true;
}
//---------------------------------------------------------------------------
void TParallelogram::SetColor(TColor c){
  color = c;
}
//---------------------------------------------------------------------------
void TParallelogram::SetLocks(bool h, bool s, bool a){
  lockHeight = h;
  lockSide = s;
  lockAlpha = a;
}
//---------------------------------------------------------------------------
double TParallelogram::GetBase(){
  return base;
}
//---------------------------------------------------------------------------
double TParallelogram::GetHeight(){
  return height;
}
//---------------------------------------------------------------------------
double TParallelogram::GetSide(){
  return side;
}
//---------------------------------------------------------------------------
double TParallelogram::GetAlpha(){
  return alpha;
}
//---------------------------------------------------------------------------
double TParallelogram::GetBeta(){
  return beta;
}
//---------------------------------------------------------------------------
TColor TParallelogram::GetColor(){
  return color;
}
//---------------------------------------------------------------------------
double TParallelogram::Perimeter(){
  return (base + side) * 2;
}
//---------------------------------------------------------------------------
double TParallelogram::Area(){
  return base * height;
}
//---------------------------------------------------------------------------
TParallelogram& TParallelogram::operator = (TParallelogram& p){
  base = p.base;
  height = p.height;
  side = p.side;
  color = p.color;

  return *this;
}
//---------------------------------------------------------------------------
void TParallelogram::DrawInImage(TImage*& image){
  image->Picture->Bitmap = NULL;

  image->Canvas->Pen->Color = color;
  image->Canvas->Brush->Color = color;
  image->Canvas->Pen->Width = 1;

  double x, y, BaseOfTriangle;

  y = height / 2;
  BaseOfTriangle = sqrt((side * side) - (height * height));
  x = (base - BaseOfTriangle) / 2;

  int x0, y0;
  x0 = image->Width / 2;
  y0 = image->Height / 2;

  if(alpha <= 90){
    image->Canvas->MoveTo(x0-x-BaseOfTriangle, y0+y); //left down point
    image->Canvas->LineTo(x0-x, y0-y);
    image->Canvas->LineTo(x0+x+BaseOfTriangle, y0-y);
    image->Canvas->LineTo(x0+x, y0+y);
    image->Canvas->LineTo(x0-x-BaseOfTriangle, y0+y);
  }
  else{
    image->Canvas->MoveTo(x0-x, y0+y); //left down point
    image->Canvas->LineTo(x0-x-BaseOfTriangle, y0-y);
    image->Canvas->LineTo(x0+x, y0-y);
    image->Canvas->LineTo(x0+x+BaseOfTriangle, y0+y);
    image->Canvas->LineTo(x0-x, y0+y);
  }
  image->Canvas->FloodFill(x0, y0, color, fsBorder);
}
//---------------------------------------------------------------------------
void TParallelogram::FullFillImage(TImage*& image, TColor c){
  image->Canvas->Pen->Color = c;
  image->Canvas->Brush->Color = c;
  image->Canvas->Rectangle(0, 0, image->Width, image->Height);
}
//---------------------------------------------------------------------------
TColor TParallelogram::GetColorImage(TImage* image){
  return image->Canvas->Pixels[0][0];
}
//---------------------------------------------------------------------------
