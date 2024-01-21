//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
int m,n;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------


void __fastcall TForm1::Button1Click(TObject *Sender)
{
n=StrToInt(Edit1->Text);
m=StrToInt(Edit2->Text);
StringGrid1->RowCount=n+1;
StringGrid1->ColCount=m+1;
StringGrid2->RowCount=n+1;
StringGrid2->ColCount=m+1;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button2Click(TObject *Sender)
{
int i,j;
double a[30][30],b[30][30];
double k;
k=0;
 for(i=0;i<m;i++)
 for(j=0;j<n;j++)
 {
    a[i][j]=StrToFloat(StringGrid1->Cells[j+1][i+1]);
    k+=a[i][j];
 }
 if((k/(m*n))>10)
   for(i=0;i<m;i++)
   for(j=0;j<n;j++)
     b[i][j]=a[i][j]/2;
 else
   for(i=0;i<m;i++)
   for(j=0;j<n;j++)
     b[i][j]=a[i][j]+5;

 for(i=0;i<m;i++)
 for(j=0;j<n;j++)
   StringGrid2->Cells[j+1][i+1]=FloatToStr(b[i][j]);
}
//---------------------------------------------------------------------------


