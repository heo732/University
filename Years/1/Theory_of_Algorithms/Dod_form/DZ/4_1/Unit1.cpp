//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <math.h>
#include <vector.h>
//---------------------------------------------------------------------------
int n=0;
//---------------------------------------------------------------------------
void Povtor(int *A,int n,int *&B,int &m)
{
  int i,j;
  m=0;
  bool f,k;
  
  for(i=0;i<n-1;i++)
  {
    f=false;
    for(j=i+1;j<n;j++)
      if(A[j]==A[i])
      {
        f=true;
        break;
      }
    k=false; 
    if(m>0)
      for(j=0;j<m;j++)
        if(B[j]==A[i])
        {
          k=true;
          break;
        }
    if(k==false && f==true)
    {
      B[m]=A[i];
      m++;
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
  ShowMessage("Задайте масив цілих чисел A(n). Програма перепише всі числа, що повторюються, з масиву А в масив В по одному разу.");
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnSizeClick(TObject *Sender)
{
  int i,j;
  
  n=StrToInt(edtSize->Text);
  stgIn->ColCount=n;
  stgOut->ColCount=n;
  for(i=0;i<n;i++)
  {
    stgIn->Cells[i][0]=IntToStr(i+1);
    stgOut->Cells[i][0]=IntToStr(i+1);
    stgIn->Cells[i][1]="";
    stgOut->Cells[i][1]="";
  }  
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnDoClick(TObject *Sender)
{
  int *A=NULL,*B=NULL;
  int i,m=0;
  
  A=(int*)calloc(n,sizeof(int));
  B=(int*)calloc(n,sizeof(int));
  for(i=0;i<n;i++)
    A[i]=StrToInt(stgIn->Cells[i][1]);
  
  Povtor(A,n,B,m);
  
  stgOut->ColCount=m;
  for(i=0;i<m;i++)  
    stgOut->Cells[i][1]=IntToStr(B[i]);    
  free(A);
  free(B);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnRandomClick(TObject *Sender)
{
  randomize();
  for(int i=0;i<n;i++)
      stgIn->Cells[i][1]=IntToStr(RandomValue(StrToInt(edtRandomL->Text),StrToInt(edtRandomR->Text)));
}
//---------------------------------------------------------------------------
