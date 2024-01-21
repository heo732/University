//---------------------------------------------------------------------------
#ifndef TModH
#define TModH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <ExtCtrls.hpp>
#include <time.h>
#include <cmath>
//---------------------------------------------------------------------------
class TMod{

  int left, right;

public:

  TMod(int l, int r){
    if(l >= r){
      left = r - 1;
      right = r;
    }
    else{
      left = l;
      right = r;
    }
  }

  ~TMod(){}

  void Execute(TImage*& img, unsigned int cnt){
    img->Picture->Bitmap = NULL;
    img->Canvas->Pen->Color = clBlack;
    img->Canvas->Pen->Width = 3;

    int step_x, step_y;
    step_x = img->Width / 20;
    if(left >= 0)
      step_y = img->Height / (right + 4);
    else
      if(right <= 0)
        step_y = img->Height / (-left + 4);
      else
        step_y = img->Height / (right - left + 4);

    int x0, y0;
    x0 = 2 * step_x;
    if(left >= 0)
      y0 =  img->Height - 2*step_y;
    else
      y0 = img->Height - (-left+2)*step_y;

    //axes
    img->Canvas->MoveTo(x0-step_x, y0);
    img->Canvas->LineTo(img->Width-step_x, y0);
    img->Canvas->MoveTo(x0, img->Height-step_y);
    img->Canvas->LineTo(x0, step_y);

    img->Canvas->MoveTo(img->Width-step_x, y0);
    img->Canvas->LineTo(img->Width-step_x-5, y0-5);
    img->Canvas->MoveTo(img->Width-step_x, y0);
    img->Canvas->LineTo(img->Width-step_x-5, y0+5);

    img->Canvas->MoveTo(x0, step_y);
    img->Canvas->LineTo(x0-5, step_y+5);
    img->Canvas->MoveTo(x0, step_y);
    img->Canvas->LineTo(x0+5, step_y+5);

    for(int i=x0+step_x; i<=15*step_x + x0; i+=step_x){
      img->Canvas->MoveTo(i, y0-2);
      img->Canvas->LineTo(i, y0+2);
    }

    img->Canvas->MoveTo(x0+5*step_x, y0-5);
    img->Canvas->LineTo(x0+5*step_x, y0+5);
    img->Canvas->TextOutA(x0+5*step_x-10, y0+8, "0,33");

    img->Canvas->MoveTo(x0+10*step_x, y0-5);
    img->Canvas->LineTo(x0+10*step_x, y0+5);
    img->Canvas->TextOutA(x0+10*step_x-10, y0+8, "0,66");

    img->Canvas->MoveTo(x0+15*step_x, y0-5);
    img->Canvas->LineTo(x0+15*step_x, y0+5);
    img->Canvas->TextOutA(x0+15*step_x-2, y0+8, "1");

    for(int i=img->Height-step_y*2, j=left<0?left:0; i>=step_y*2; i-=step_y, j++){
      img->Canvas->MoveTo(x0-2, i);
      img->Canvas->LineTo(x0+2, i);
      img->Canvas->TextOutA(x0-18, i-6, IntToStr(j));
    }

    img->Canvas->TextOutA(x0+10, 0+step_y/2, "Y(w)");
    img->Canvas->TextOutA(img->Width-step_x*2, y0-20, "X(w)");
    //axes


    //points
    srand(time(0));
    img->Canvas->Pen->Color = clRed;
    for(int i=0; i<cnt; i++){
      double x, y;
      x = (double) rand();
      x /= RAND_MAX;
      y = (right-left) * x + left;

      img->Canvas->MoveTo(x0+step_x*x*15, y0-step_y*y);
      img->Canvas->LineTo(x0+step_x*x*15, y0-step_y*y);
    }
    //points

    //infinity
    img->Canvas->MoveTo(x0+step_x*15, y0-step_y*right);
    img->Canvas->LineTo(x0+step_x*15, 0);
    img->Canvas->MoveTo(x0, y0-step_y*left);
    img->Canvas->LineTo(x0, img->Height);
    //infinity
  }

};
//---------------------------------------------------------------------------
#endif
