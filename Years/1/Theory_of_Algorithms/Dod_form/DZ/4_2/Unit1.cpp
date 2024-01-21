//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <vector.h>
//---------------------------------------------------------------------------
int n=0;
//---------------------------------------------------------------------------
void Perestanovka(TStringGrid *stgIn,TStringGrid *&stgBetween,TStringGrid *&stgOut,int n1)
{
  int elem,elemR=1,elemC=1;
  int i,j;
  
  elem=StrToInt(stgIn->Cells[1][1]);
  for(i=1;i<=n1;i++)
    for(j=1;j<=n1;j++)
    {
      if(StrToInt(stgIn->Cells[j][i])>elem)
      {
        elem=StrToInt(stgIn->Cells[j][i]);
        elemR=i;
        elemC=j;
      }
      stgOut->Cells[j][i]=stgIn->Cells[j][i];
    }  
  
  if(elemC==1)
  {
    for(i=0;i<=n1;i++)
    {      
      stgOut->Cells[i][elemR]=stgIn->Cells[i][1];
      stgOut->Cells[i][1]=stgIn->Cells[i][elemR];
    }
  }
  else
    if(elemR==1)
    {
      for(i=0;i<=n1;i++)
      {
        stgOut->Cells[elemC][i]=stgIn->Cells[1][i];
        stgOut->Cells[1][i]=stgIn->Cells[elemC][i];
      }
    }
    else
    {
      for(i=1;i<=n1;i++)
        for(j=1;j<=n1;j++)
          stgBetween->Cells[j][i]=stgIn->Cells[j][i];
      
      for(i=0;i<=n1;i++)
      {
        stgBetween->Cells[i][elemR]=stgIn->Cells[i][1];
        stgBetween->Cells[i][1]=stgIn->Cells[i][elemR];
      }
      
      for(i=1;i<=n1;i++)
        for(j=1;j<=n1;j++)
          stgOut->Cells[j][i]=stgBetween->Cells[j][i];
      
      for(i=0;i<=n1;i++)
      {
        stgOut->Cells[elemC][i]=stgBetween->Cells[1][i];
        stgOut->Cells[1][i]=stgBetween->Cells[elemC][i];
      }
    }
}
//---------------------------------------------------------------------------
int RandomValue(int l,int r)
{
  return random(r-l+1)+l;
}
//---------------------------------------------------------------------------
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::FormCreate(TObject *Sender)
{
  ShowMessage("Задайте квадратну матрицю А. Програма визначить перше входження максимального елемента матриці і перестановкою рядків та стовпчиків перетворить цю матрицю так, щоб максимальний елемент розмістився в лівому верхньому куті.");
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnSizeClick(TObject *Sender)
{
  int i,j;
  
  n=StrToInt(edtSize->Text);
  stgIn->RowCount=n+1;
  stgIn->ColCount=n+1;
  stgOut->RowCount=n+1;
  stgOut->ColCount=n+1;
  stgBetween->RowCount=n+1;
  stgBetween->ColCount=n+1;
  for(i=1;i<=n;i++)
  {
    stgIn->Cells[0][i]=IntToStr(i);
    stgIn->Cells[i][0]=IntToStr(i);
    stgOut->Cells[0][i]=IntToStr(i);
    stgOut->Cells[i][0]=IntToStr(i);
    stgBetween->Cells[0][i]=IntToStr(i);
    stgBetween->Cells[i][0]=IntToStr(i);
    for(j=1;j<=n;j++)
    {
      stgIn->Cells[j][i]="";
      stgOut->Cells[j][i]="";
      stgBetween->Cells[j][i]="";
    }
  }  
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnDoClick(TObject *Sender)
{  
  Perestanovka(stgIn,stgBetween,stgOut,n);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnRandomClick(TObject *Sender)
{
  randomize();
  for(int i=1;i<=n;i++)
    for(int j=1;j<=n;j++)
      stgIn->Cells[j][i]=IntToStr(RandomValue(StrToInt(edtRandomL->Text),StrToInt(edtRandomR->Text)));
}
//---------------------------------------------------------------------------
