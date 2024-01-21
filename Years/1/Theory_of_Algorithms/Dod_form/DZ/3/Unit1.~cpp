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
void Sort(double **&A,int m,double MaxAbs)
{
  int i,j,k,Imax;
  double tmp;
  bool f;  
  
  for(j=0;j<m;j++)
  {
    f=false;
    for(i=0;i<m-1;i++)
      if(fabs(A[i][j])==MaxAbs)
      {
        f=true;
        break;
      }  
    if(f==true)  
      for(i=0;i<m-1;i++)
        {    		
          Imax=i;
          for(k=i+1;k<m;k++)
            if(A[Imax][j]<A[k][j])
              Imax=k;    			
          tmp=A[Imax][j];
          A[Imax][j]=A[i][j];
          A[i][j]=tmp;
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
  ShowMessage("Задайте матрицю Y(n,n). Програма методом вибору упорядкує за спаданням елементи всіх стовпчиків, у яких розміщені найбільші за модулем елементи матриці Y.");
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
  for(i=1;i<=n;i++)
  {
    stgIn->Cells[0][i]=IntToStr(i);
    stgIn->Cells[i][0]=IntToStr(i);
    stgOut->Cells[0][i]=IntToStr(i);
    stgOut->Cells[i][0]=IntToStr(i);
    for(j=1;j<=n;j++)
    {
      stgIn->Cells[j][i]="";
      stgOut->Cells[j][i]="";
    }
  }  
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnDoClick(TObject *Sender)
{
  double **A=NULL,MaxAbs=0;
  int i,j;
  
  A=(double**)calloc(n,sizeof(double*));
  for(i=0;i<n;i++)
  {
    A[i]=(double*)calloc(n,sizeof(double));
    for(j=0;j<n;j++)
    {
      A[i][j]=StrToFloat(stgIn->Cells[j+1][i+1]);
      if(fabs(A[i][j])>MaxAbs)
        MaxAbs=fabs(A[i][j]);
    }  
  }
  
  Sort(A,n,MaxAbs);
  
  for(i=0;i<n;i++)
  {
    for(j=0;j<n;j++)
      stgOut->Cells[j+1][i+1]=FloatToStr(A[i][j]);
    free(A[i]);
  }
  free(A);
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
