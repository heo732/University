//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
int N,x[100],y[100];
double sx,sy;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
StringGrid1->Cells[0][0]="N";
StringGrid1->Cells[1][0]="X";
StringGrid1->Cells[2][0]="Y";
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
N=StrToInt(Edit1->Text);
int i;
StringGrid1->RowCount=N+1;
for(i=1;i<=N;i++)
StringGrid1->Cells[0][i]=IntToStr(i);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button2Click(TObject *Sender)
{
int i;
sx=0; sy=0;
for(i=1;i<=N;i++)
{
sx+=StrToFloat(StringGrid1->Cells[1][i]);
sy+=StrToFloat(StringGrid1->Cells[2][i]);
x[i-1]=StrToFloat(StringGrid1->Cells[1][i]);
y[i-1]=StrToFloat(StringGrid1->Cells[2][i]);
}
Edit2->Text=FloatToStr(sx/N);
Edit3->Text=FloatToStr(sy/N);
sx=int(sx/N);
sy=int(sy/N);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button3Click(TObject *Sender)
{
int i;
Image1->Canvas->Pen->Color = clBlue;
Image1->Canvas->Pen->Width = 4;
Image1->Canvas->MoveTo(x[0],y[0]);
for(i=1;i<N;i++)
  Image1->Canvas->LineTo(x[i],y[i]);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button4Click(TObject *Sender)
{
Image1->Canvas->Brush->Color = clGreen;
Image1->Canvas->FloodFill(sx,sy,clBlue,fsBorder);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button5Click(TObject *Sender)
{
Image1->Canvas->Pen->Color = clWhite;
Image1->Canvas->Brush->Color = clWhite;
Image1->Canvas->Rectangle(0,0,Image1->Width,Image1->Height);
}
//---------------------------------------------------------------------------

