//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <math.h>
#include <vector.h>
//---------------------------------------------------------------------------
double Func(double x,double y)
{
  return 3*cos(5*x)+2*sin(3*y)+10;
}  
//---------------------------------------------------------------------------
void Draw(int x0,int y0,int kx,int ky,int kz,double alpha,double h,int a,int b,TImage *&img)
{
  img->Canvas->Pen->Color=clBlack;
  img->Canvas->Pen->Width=3;
  img->Canvas->MoveTo(x0,y0);
  img->Canvas->LineTo(x0+(max(a,b)+500)*kx*cos(alpha),y0+(max(a,b)+500)*kx*sin(alpha));
  img->Canvas->MoveTo(x0,y0);
  img->Canvas->LineTo(x0+(max(a,b)+500)*ky,y0);
  img->Canvas->MoveTo(x0,y0);
  img->Canvas->LineTo(x0,y0-(max(a,b)+500)*kz);  
  
  double y,x,z;
  img->Canvas->Pen->Color=clGreen;
  img->Canvas->Pen->Width=1;
  for(y=0;y<=b;y+=h)
  {    
    for(x=0;x<=a;x+=0.1)
    {
      z=Func(x,y); 
      if(x==0)
        img->Canvas->MoveTo(x0+y*ky,y0-z*kz);
      else
        img->Canvas->LineTo(x0+y*ky+x*kx*cos(alpha),y0-z*kz+x*kx*sin(alpha));      
    }
  }  
  for(x=0;x<=b;x+=h)
  {    
    for(y=0;y<=a;y+=0.1)
    {
      z=Func(x,y);      
      if(y==0)
          img->Canvas->MoveTo(x0+x*kx*cos(alpha),y0-z*kz+x*kx*sin(alpha));
      else
        img->Canvas->LineTo(x0+y*ky+x*kx*cos(alpha),y0-z*kz+x*kx*sin(alpha));      
    }
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
void __fastcall Tfrm::FormCreate(TObject *Sender)
{
  edtX0->Text=IntToStr(img->Width/2);
  edtY0->Text=IntToStr(img->Height/2);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnPaintClick(TObject *Sender)
{
  int a,b,kx,ky,kz,x0,y0;
  double h,alpha;
  
  img->Picture->Bitmap=NULL;
  
  x0=StrToInt(edtX0->Text);
  y0=StrToInt(edtY0->Text);
  kx=StrToInt(edtKx->Text);
  ky=StrToInt(edtKy->Text);
  kz=StrToInt(edtKz->Text);
  alpha=StrToFloat(edtAlpha->Text)/180*M_PI;
  h=StrToFloat(edtH->Text);
  a=StrToInt(edtA->Text);
  b=StrToInt(edtB->Text);
  
  Draw(x0,y0,kx,ky,kz,alpha,h,a,b,img);
}
//---------------------------------------------------------------------------
