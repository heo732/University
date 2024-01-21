//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#define constVertex 30
#include <math.h>

typedef struct
{
	double x,y,z;
}TDot;

typedef struct
{
	int cntVert;
	TDot arrDot[constVertex];
	bool rebra[constVertex][constVertex];
}TBody;

TBody B;

Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void FSize(int n)
{
	int i,j;
	B.cntVert=n;
	frm->stgVertex->RowCount=n+1;
	frm->stgRebra->RowCount=n+1;
	frm->stgRebra->ColCount=n+1;
	
	frm->stgVertex->Cells[1][0]="X";
	frm->stgVertex->Cells[2][0]="Y";
	frm->stgVertex->Cells[3][0]="Z";
	for(i=1;i<n+1;i++)
	{
		frm->stgVertex->Cells[0][i]=i;
		frm->stgRebra->Cells[0][i]=i;
		frm->stgRebra->Cells[i][0]=i;
		for(j=1;j<n+1;j++)
		{
			frm->stgVertex->Cells[i][j]="0";
			frm->stgRebra->Cells[i][j]="0";
		}
	}	
}
//---------------------------------------------------------------------------
void FInput(TBody &A)
{
	int i,j;
	
	for(i=0;i<A.cntVert;i++)
	{
		A.arrDot[i].x=StrToFloat(frm->stgVertex->Cells[1][i+1]);
		A.arrDot[i].y=StrToFloat(frm->stgVertex->Cells[2][i+1]);
		A.arrDot[i].z=StrToFloat(frm->stgVertex->Cells[3][i+1]);		
		for(j=0;j<A.cntVert;j++)
			if(frm->stgRebra->Cells[i+1][j+1]=="1")
				A.rebra[i][j]=true;
			else
				A.rebra[i][j]=false;
	}		
}
//---------------------------------------------------------------------------
void FDraw(TBody A,int xc,int yc)
{
	int i,j;
	
	frm->img->Picture->Bitmap=NULL;
	
	frm->img->Canvas->Pen->Color=clGreen;
	frm->img->Canvas->Pen->Width=3;
	for(i=0;i<A.cntVert;i++)
		for(j=0;j<A.cntVert;j++)
			if(A.rebra[i][j]==true)
			{
				frm->img->Canvas->MoveTo(xc+A.arrDot[i].y,yc-A.arrDot[i].z);
				frm->img->Canvas->LineTo(xc+A.arrDot[j].y,yc-A.arrDot[j].z);
			}
}
//---------------------------------------------------------------------------
void FRotate(TBody &A,double k,char c)
{	
	int i;
	double tmp1,tmp2;
	
	switch(c)
	{	
		case 'x':
		{
			for(i=0;i<A.cntVert;i++)
				{
					tmp1=A.arrDot[i].z*cos(k)-A.arrDot[i].y*sin(k);
					tmp2=A.arrDot[i].z*sin(k)+A.arrDot[i].y*cos(k);
					A.arrDot[i].z=tmp1;
					A.arrDot[i].y=tmp2;
				}
			break;	
		}
		case 'y':
		{
			for(i=0;i<A.cntVert;i++)
				{
					tmp1=A.arrDot[i].z*cos(k)-A.arrDot[i].x*sin(k);
					tmp2=A.arrDot[i].z*sin(k)+A.arrDot[i].x*cos(k);
					A.arrDot[i].z=tmp1;
					A.arrDot[i].x=tmp2;
				}
			break;	
		}
		case 'z':
		{
			for(i=0;i<A.cntVert;i++)
				{
					tmp1=A.arrDot[i].x*cos(k)-A.arrDot[i].y*sin(k);
					tmp2=A.arrDot[i].x*sin(k)+A.arrDot[i].y*cos(k);
					A.arrDot[i].x=tmp1;
					A.arrDot[i].y=tmp2;
				}
			break;	
		}
	}
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::FormCreate(TObject *Sender)
{
	FSize(10);
		
	frm->stgVertex->Cells[1][1]=60;
	frm->stgVertex->Cells[2][1]=-60;
	frm->stgVertex->Cells[3][1]=-100;
	
	frm->stgVertex->Cells[1][2]=60;
	frm->stgVertex->Cells[2][2]=45;
	frm->stgVertex->Cells[3][2]=-100;
	
	frm->stgVertex->Cells[1][3]=45;
	frm->stgVertex->Cells[2][3]=45;
	frm->stgVertex->Cells[3][3]=0;
	
	frm->stgVertex->Cells[1][4]=30;
	frm->stgVertex->Cells[2][4]=30;
	frm->stgVertex->Cells[3][4]=80;
	
	frm->stgVertex->Cells[1][5]=30;
	frm->stgVertex->Cells[2][5]=-30;
	frm->stgVertex->Cells[3][5]=80;
	
	frm->stgVertex->Cells[1][6]=45;
	frm->stgVertex->Cells[2][6]=60;
	frm->stgVertex->Cells[3][6]=-100;

	frm->stgVertex->Cells[1][7]=-60;
	frm->stgVertex->Cells[2][7]=60;
	frm->stgVertex->Cells[3][7]=-100;
	
	frm->stgVertex->Cells[1][8]=-60;
	frm->stgVertex->Cells[2][8]=-60;
	frm->stgVertex->Cells[3][8]=-100;
	
	frm->stgVertex->Cells[1][9]=-30;
	frm->stgVertex->Cells[2][9]=-30;
	frm->stgVertex->Cells[3][9]=80;
	
	frm->stgVertex->Cells[1][10]=-30;
	frm->stgVertex->Cells[2][10]=30;
	frm->stgVertex->Cells[3][10]=80;
	
	frm->stgRebra->Cells[1][2]="1";
	frm->stgRebra->Cells[1][5]="1";
	frm->stgRebra->Cells[1][8]="1";
	frm->stgRebra->Cells[2][3]="1";
	frm->stgRebra->Cells[2][6]="1";
	frm->stgRebra->Cells[3][4]="1";
	frm->stgRebra->Cells[3][6]="1";
	frm->stgRebra->Cells[4][5]="1";
	frm->stgRebra->Cells[4][10]="1";
	frm->stgRebra->Cells[5][9]="1";
	frm->stgRebra->Cells[6][7]="1";
	frm->stgRebra->Cells[8][7]="1";
	frm->stgRebra->Cells[8][9]="1";
	frm->stgRebra->Cells[9][10]="1";
	frm->stgRebra->Cells[10][7]="1";
	
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnOxRClick(TObject *Sender)
{
	FRotate(B,-(StrToFloat(frm->edtDegree->Text))/180*M_PI,'x');        
	FDraw(B,frm->img->Width/2,frm->img->Height/2);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnOxLClick(TObject *Sender)
{
	FRotate(B,(StrToFloat(frm->edtDegree->Text))/180*M_PI,'x');        
	FDraw(B,frm->img->Width/2,frm->img->Height/2);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnOyLClick(TObject *Sender)
{
	FRotate(B,(StrToFloat(frm->edtDegree->Text))/180*M_PI,'y');        
	FDraw(B,frm->img->Width/2,frm->img->Height/2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnOyRClick(TObject *Sender)
{
	FRotate(B,-(StrToFloat(frm->edtDegree->Text))/180*M_PI,'y');        
	FDraw(B,frm->img->Width/2,frm->img->Height/2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnOzRClick(TObject *Sender)
{
	FRotate(B,-(StrToFloat(frm->edtDegree->Text))/180*M_PI,'z');        
	FDraw(B,frm->img->Width/2,frm->img->Height/2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnOzLClick(TObject *Sender)
{

	FRotate(B,(StrToFloat(frm->edtDegree->Text))/180*M_PI,'z');        
	FDraw(B,frm->img->Width/2,frm->img->Height/2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnSizeClick(TObject *Sender)
{
	FSize(StrToInt(frm->edtSize->Text));
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnStartClick(TObject *Sender)
{	
	FInput(B);	
	FDraw(B,frm->img->Width/2,frm->img->Height/2);
}
//---------------------------------------------------------------------------