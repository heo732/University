//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <stdlib.h>
#include <alloc.h>
#include <time.h>
TForm1 *Form1;

int n=1,i;
double *a=NULL,time_out;

void SortSelection()
{
        int Imin,j;
        double tmp;
for(i=0;i<n-1;i++)
        {                
                Imin=i;
                for(j=i+1;j<n;j++)
                        if(a[Imin]>a[j])                              
                                Imin=j; 
                tmp=a[Imin];
                a[Imin]=a[i];
                a[i]=tmp;    
        } 
}

void FindLine(double elem)
{
        bool pos=false;
for(i=0;i<n;i++)
        if(a[i]==elem)
                {       
                        Form1->Out2->Text=IntToStr(i+1);
                        pos=true;
                        break;
                }
if(pos==false)
        Form1->Out2->Text="������� �� ��������";                
}

void FindBin(double elem)
{
        int start=0,end=n-1,center;
while(start!=end)
{
        center=(start+end)/2;
        if(a[center]<elem)
                start=center+1;
        else
                end=center;
}
if(a[end]==elem)
{
        Form1->Out2->Font->Size=11;
        Form1->Out2->Text=IntToStr(end+1);
}
else
{
        Form1->Out2->Font->Size=9;
        if(Form1->RadioGroup1->ItemIndex==0)
                Form1->Out2->Text="������� �� ��������. ��������� ������������ �����";
        else
                Form1->Out2->Text="������� �� ��������";
}        
}

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonCloseClick(TObject *Sender)
{  
Form1->Close();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonPrepareClick(TObject *Sender)
{
n=StrToInt(Form1->In1->Text);
if(n<=0)
	n=1;
Form1->StringGrid1->RowCount=n;
Form1->StringGrid2->RowCount=n;
for(i=0;i<n;i++)
        {
        Form1->StringGrid1->Cells[0][i]=i+1;
        Form1->StringGrid2->Cells[0][i]=i+1;
        }
}
//---------------------------------------------------------------------------
void __fastcall TForm1::ButtonRandomClick(TObject *Sender)
{ 
for(i=0;i<n;i++)
        Form1->StringGrid1->Cells[1][i]=IntToStr(random(999))+','+IntToStr(random(99));
}
//---------------------------------------------------------------------------
void __fastcall TForm1::ButtonDoClick(TObject *Sender)
{
time_out=clock(); 

a=(double*)malloc(n*sizeof(double));

for(i=0;i<n;i++)
        *(a+i)=StrToFloat(Form1->StringGrid1->Cells[1][i]);

if(Form1->RadioGroup1->ItemIndex==1)
{
        SortSelection();
        for(i=0;i<n;i++)
                Form1->StringGrid2->Cells[1][i]=FloatToStr(a[i]);
}
else
        for(i=0;i<n;i++)
                Form1->StringGrid2->Cells[1][i]="";
        
switch(Form1->RadioGroup2->ItemIndex)
        {
        case 0:
                {
                 FindLine(StrToFloat(Form1->In2->Text));
                 break;
                }
        case 1:
                {
                 FindBin(StrToFloat(Form1->In2->Text));
                 break;
                }
        }
                 
free(a);
a=NULL;
Form1->Out1->Text=FloatToStr((clock()-time_out)/1000.0);
}
//---------------------------------------------------------------------------