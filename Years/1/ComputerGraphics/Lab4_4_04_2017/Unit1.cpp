//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#define SIZE 1000
TForm1 *Form1;

double x[SIZE],y[SIZE];
int n,i,q;

void FLine(double x1,double y1,double x2,double y2)
{
	int plus=0,minus=0,j;
        double a,b,c;	
a=y2-y1;
b=x1-x2;
c=y1*(x2-x1)-x1*(y2-y1);
for(j=0;j<n;j++)	
	if((a*x[j]+b*y[j]+c)>0)
    	    plus++;
	else
    	    if((a*x[j]+b*y[j]+c)<0)
        	        minus++;
if(plus==0 || minus==0)
	{
		Form1->Image1->Canvas->Pen->Color=clBlack;
		Form1->Image1->Canvas->Pen->Width=3;
		Form1->Image1->Canvas->MoveTo(x1,y1);
		Form1->Image1->Canvas->LineTo(x2,y2);
	}

}

void GetColor(int p)
{
        int r;
r=random(16);
switch(r)
	{	
		case 0:{Form1->Image1->Canvas->Pen->Color=clBlack; Form1->StringGrid1->Cells[3][p]="Black"; break;}
		case 1:{Form1->Image1->Canvas->Pen->Color=clMaroon; Form1->StringGrid1->Cells[3][p]="Maroon"; break;}
		case 2:{Form1->Image1->Canvas->Pen->Color=clGreen; Form1->StringGrid1->Cells[3][p]="Green"; break;}
		case 3:{Form1->Image1->Canvas->Pen->Color=clOlive; Form1->StringGrid1->Cells[3][p]="Olive"; break;}
		case 4:{Form1->Image1->Canvas->Pen->Color=clNavy; Form1->StringGrid1->Cells[3][p]="Navy"; break;}
		case 5:{Form1->Image1->Canvas->Pen->Color=clPurple; Form1->StringGrid1->Cells[3][p]="Purple"; break;}
		case 6:{Form1->Image1->Canvas->Pen->Color=clTeal; Form1->StringGrid1->Cells[3][p]="Teal"; break;}
		case 7:{Form1->Image1->Canvas->Pen->Color=clGray; Form1->StringGrid1->Cells[3][p]="Gray"; break;}
		case 8:{Form1->Image1->Canvas->Pen->Color=clSilver; Form1->StringGrid1->Cells[3][p]="Silver"; break;}
		case 9:{Form1->Image1->Canvas->Pen->Color=clRed; Form1->StringGrid1->Cells[3][p]="Red"; break;}
		case 10:{Form1->Image1->Canvas->Pen->Color=clLime; Form1->StringGrid1->Cells[3][p]="Lime"; break;}
		case 11:{Form1->Image1->Canvas->Pen->Color=clYellow; Form1->StringGrid1->Cells[3][p]="Yellow"; break;}
		case 12:{Form1->Image1->Canvas->Pen->Color=clBlue; Form1->StringGrid1->Cells[3][p]="Blue"; break;}
		case 13:{Form1->Image1->Canvas->Pen->Color=clFuchsia; Form1->StringGrid1->Cells[3][p]="Fuchsia"; break;}
		case 14:{Form1->Image1->Canvas->Pen->Color=clAqua; Form1->StringGrid1->Cells[3][p]="Aqua"; break;}
		case 15:{Form1->Image1->Canvas->Pen->Color=clMoneyGreen; Form1->StringGrid1->Cells[3][p]="MoneyGreen"; break;}
		case 16:{Form1->Image1->Canvas->Pen->Color=clSkyBlue; Form1->StringGrid1->Cells[3][p]="SkyBlue"; break;}
	}	
}

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
Form1->Close();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button4Click(TObject *Sender)
{
n=StrToInt(Form1->Edit1->Text);
Form1->StringGrid1->RowCount=n+1;
Form1->StringGrid1->Cells[1][0]="X";
Form1->StringGrid1->Cells[2][0]="Y";
Form1->StringGrid1->Cells[3][0]="Color";
for(i=1;i<=n;i++)
           Form1->StringGrid1->Cells[0][i]=i;

}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button3Click(TObject *Sender)
{
for(i=1;i<=n;i++)
        {
         Form1->StringGrid1->Cells[1][i]=random(600);
         Form1->StringGrid1->Cells[2][i]=random(600);
        }
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button2Click(TObject *Sender)
{
Form1->Image1->Picture->Bitmap=NULL;
for(i=1;i<=n;i++)
        {
         x[i-1]=StrToFloat(Form1->StringGrid1->Cells[1][i]);
         y[i-1]=StrToFloat(Form1->StringGrid1->Cells[2][i]);         
        }

for(i=0;i<n-1;i++)
	for(q=i+1;q<n;q++)
		FLine(x[i],y[i],x[q],y[q]);  

Form1->Image1->Canvas->Pen->Width=10;
for(i=0;i<n;i++)
        { 
         GetColor(i+1);       
         Form1->Image1->Canvas->MoveTo(x[i],y[i]);
         Form1->Image1->Canvas->LineTo(x[i],y[i]);
        }		      

}
//---------------------------------------------------------------------------
