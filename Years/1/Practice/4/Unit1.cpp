//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <math.h>
#define constV 30
#define constG 20
//---------------------------------------------------------------------------
typedef struct
{
	double x, y, z;
}TVertex;
//---------------------------------------------------------------------------
typedef struct
{
  double x, y, z;
}TNVector;
//---------------------------------------------------------------------------
typedef struct
{
	int cntV;
	TVertex V[constV];
  int cntG;
  TNVector NV[constG];
  int G[constG][constV];
}TBody;
//---------------------------------------------------------------------------
TBody B;
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void FSize(int v, int g)
{
	int i, j;
	B.cntV = v;
	B.cntG = g;
	frm->stgV->RowCount = v + 1;
	frm->stgG->RowCount = g;
	frm->stgG->ColCount = v;
	
	frm->stgV->Cells[1][0] = "X";
	frm->stgV->Cells[2][0] = "Y";
	frm->stgV->Cells[3][0] = "Z";

	for(i = 1; i < v+1; i++)
	{
		frm->stgV->Cells[0][i] = i;
		frm->stgV->Cells[1][i] = "0";
		frm->stgV->Cells[2][i] = "0";
		frm->stgV->Cells[3][i] = "0";
		for(j = 1; j < v+1; j++)
			frm->stgG->Cells[i-1][j-1] = "0";

	}	
}
//---------------------------------------------------------------------------
void FInput(TBody &A)
{
	int i,j;
	
	for(i = 0; i < A.cntV; i++)
	{
		A.V[i].x=StrToFloat(frm->stgV->Cells[1][i+1]);
		A.V[i].y=StrToFloat(frm->stgV->Cells[2][i+1]);
		A.V[i].z=StrToFloat(frm->stgV->Cells[3][i+1]);				
		
		for(j = 0; j < A.cntG; j++)
			A.G[j][i] = StrToInt(frm->stgG->Cells[i][j]);	
	}
	
	for(j = 0; j < A.cntG; j++)
	{
		TVertex P1, P2, P3;
// ��� ���� �������
  	        P1.x = A.V[A.G[j][1]-1].x;
		P1.y = A.V[A.G[j][1]-1].y;
		P1.z = A.V[A.G[j][1]-1].z;

		P2.x = A.V[A.G[j][2]-1].x;
		P2.y = A.V[A.G[j][2]-1].y;
		P2.z = A.V[A.G[j][2]-1].z;

		P3.x = A.V[A.G[j][3]-1].x;
		P3.y = A.V[A.G[j][3]-1].y;
		P3.z = A.V[A.G[j][3]-1].z;

		A.NV[j].x = (P2.y - P1.y) * (P3.z - P2.z) - (P2.z - P1.z) * (P3.y - P2.y);
		A.NV[j].y = - ((P2.x - P1.x) * (P3.z - P2.z) - (P2.z-P1.z) * (P3.x - P2.x));
		A.NV[j].z = (P2.x - P1.x) * (P3.y - P2.y) - (P2.y - P1.y) * (P3.x - P2.x);
	}			
}
//---------------------------------------------------------------------------
void FDraw(TBody A, int xc, int yc)
{
	int i, j;
	
	frm->img->Picture->Bitmap = NULL;	
	frm->img->Canvas->Pen->Color = clGreen;
	frm->img->Canvas->Pen->Width = 3;

	for(i = 0; i < A.cntG; i++)
		if(A.NV[i].x > 0)
		{
			frm->img->Canvas->MoveTo(xc + A.V[A.G[i][1]-1].y, yc - A.V[A.G[i][1]-1].z);
			for(j = 2; j <= A.G[i][0]; j++)
				frm->img->Canvas->LineTo(xc + A.V[A.G[i][j]-1].y, yc - A.V[A.G[i][j]-1].z);
			frm->img->Canvas->LineTo(xc + A.V[A.G[i][1]-1].y, yc - A.V[A.G[i][1]-1].z);
		}
}
//---------------------------------------------------------------------------
void FRotate(TBody &A, double k, char c)
{	
	int i;
	double tmp1, tmp2;
	
	switch(c)
	{	
		case 'x':
		{
			for(i = 0; i < A.cntV; i++)
				{
					tmp1 = A.V[i].z * cos(k) - A.V[i].y * sin(k);
					tmp2 = A.V[i].z * sin(k) + A.V[i].y * cos(k);
					A.V[i].z = tmp1;
					A.V[i].y = tmp2;
				}
			for(i = 0; i < A.cntG; i++)
				{
					tmp1 = A.NV[i].z * cos(k) - A.NV[i].y * sin(k);
					tmp2 = A.NV[i].z * sin(k) + A.NV[i].y * cos(k);
					A.NV[i].z = tmp1;
					A.NV[i].y = tmp2;
				}
			break;	
		}
		case 'y':
		{
			for(i = 0; i < A.cntV; i++)
				{
					tmp1 = A.V[i].z * cos(k) - A.V[i].x * sin(k);
					tmp2 = A.V[i].z * sin(k) + A.V[i].x * cos(k);
					A.V[i].z = tmp1;
					A.V[i].x = tmp2;
				}
			for(i = 0; i < A.cntG; i++)
				{
					tmp1 = A.NV[i].z * cos(k) - A.NV[i].x * sin(k);
					tmp2 = A.NV[i].z * sin(k) + A.NV[i].x * cos(k);
					A.NV[i].z = tmp1;
					A.NV[i].x = tmp2;
				}	
			break;	
		}
		case 'z':
		{
			for(i = 0; i < A.cntV; i++)
				{
					tmp1 = A.V[i].x * cos(k) - A.V[i].y * sin(k);
					tmp2 = A.V[i].x * sin(k) + A.V[i].y * cos(k);
					A.V[i].x = tmp1;
					A.V[i].y = tmp2;
				}
			for(i = 0; i < A.cntG; i++)
				{
					tmp1 = A.NV[i].x * cos(k) - A.NV[i].y * sin(k);
					tmp2 = A.NV[i].x * sin(k) + A.NV[i].y * cos(k);
					A.NV[i].x = tmp1;
					A.NV[i].y = tmp2;
				}	
			break;	
		}
	}
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::FormCreate(TObject *Sender)
{
	FSize(10, 7);
		
	frm->stgV->Cells[1][1] = 60;
	frm->stgV->Cells[2][1] = -60;
	frm->stgV->Cells[3][1] = -100;
	
	frm->stgV->Cells[1][2] = 60;
	frm->stgV->Cells[2][2] = 0;
	frm->stgV->Cells[3][2] = -100;
	
	frm->stgV->Cells[1][3] = 45;
	frm->stgV->Cells[2][3] = 45;
	frm->stgV->Cells[3][3] = -10;
	
	frm->stgV->Cells[1][4] = 30;
	frm->stgV->Cells[2][4] = 30;
	frm->stgV->Cells[3][4] = 80;
	
	frm->stgV->Cells[1][5] = 30;
	frm->stgV->Cells[2][5] = -30;
	frm->stgV->Cells[3][5] = 80;
	
	frm->stgV->Cells[1][6] = 0;
	frm->stgV->Cells[2][6] = 60;
	frm->stgV->Cells[3][6] = -100;

	frm->stgV->Cells[1][7] = -60;
	frm->stgV->Cells[2][7] = 60;
	frm->stgV->Cells[3][7] = -100;
	
	frm->stgV->Cells[1][8] = -60;
	frm->stgV->Cells[2][8] = -60;
	frm->stgV->Cells[3][8] = -100;
	
	frm->stgV->Cells[1][9] = -30;
	frm->stgV->Cells[2][9] = -30;
	frm->stgV->Cells[3][9] = 80;
	
	frm->stgV->Cells[1][10] = -30;
	frm->stgV->Cells[2][10] = 30;
	frm->stgV->Cells[3][10] = 80;
	
	frm->stgG->Cells[0][0] = "4";
	frm->stgG->Cells[1][0] = "5";
	frm->stgG->Cells[2][0] = "4";
	frm->stgG->Cells[3][0] = "10";
	frm->stgG->Cells[4][0] = "9";

	frm->stgG->Cells[0][1] = "5";
	frm->stgG->Cells[1][1] = "8";
	frm->stgG->Cells[2][1] = "7";
	frm->stgG->Cells[3][1] = "6";
	frm->stgG->Cells[4][1] = "2";
	frm->stgG->Cells[5][1] = "1";

	frm->stgG->Cells[0][2] = "4";
	frm->stgG->Cells[1][2] = "7";
	frm->stgG->Cells[2][2] = "8";
	frm->stgG->Cells[3][2] = "9";
	frm->stgG->Cells[4][2] = "10";

	frm->stgG->Cells[0][3] = "5";
	frm->stgG->Cells[1][3] = "6";
	frm->stgG->Cells[2][3] = "7";
	frm->stgG->Cells[3][3] = "10";
	frm->stgG->Cells[4][3] = "4";
	frm->stgG->Cells[5][3] = "3";

	frm->stgG->Cells[0][4] = "3";
	frm->stgG->Cells[1][4] = "3";
	frm->stgG->Cells[2][4] = "2";
	frm->stgG->Cells[3][4] = "6";

	frm->stgG->Cells[0][5] = "5";
	frm->stgG->Cells[1][5] = "1";
	frm->stgG->Cells[2][5] = "2";
	frm->stgG->Cells[3][5] = "3";
	frm->stgG->Cells[4][5] = "4";
	frm->stgG->Cells[5][5] = "5";

	frm->stgG->Cells[0][6] = "4";
	frm->stgG->Cells[1][6] = "1";
	frm->stgG->Cells[2][6] = "5";
	frm->stgG->Cells[3][6] = "9";
	frm->stgG->Cells[4][6] = "8";
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnOxPClick(TObject *Sender)
{
	FRotate(B, -(StrToFloat(frm->edtDegree->Text))/180*M_PI, 'x');        
	FDraw(B, frm->img->Width/2, frm->img->Height/2);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnOxMClick(TObject *Sender)
{
	FRotate(B, (StrToFloat(frm->edtDegree->Text))/180*M_PI, 'x');        
	FDraw(B, frm->img->Width/2, frm->img->Height/2);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnOyPClick(TObject *Sender)
{
	FRotate(B, (StrToFloat(frm->edtDegree->Text))/180*M_PI, 'y');        
	FDraw(B, frm->img->Width/2, frm->img->Height/2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnOyMClick(TObject *Sender)
{
	FRotate(B, -(StrToFloat(frm->edtDegree->Text))/180*M_PI, 'y');        
	FDraw(B, frm->img->Width/2, frm->img->Height/2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnOzPClick(TObject *Sender)
{
	FRotate(B, -(StrToFloat(frm->edtDegree->Text))/180*M_PI, 'z');        
	FDraw(B, frm->img->Width/2, frm->img->Height/2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnOzMClick(TObject *Sender)
{

	FRotate(B, (StrToFloat(frm->edtDegree->Text))/180*M_PI, 'z');        
	FDraw(B, frm->img->Width/2, frm->img->Height/2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnSizeClick(TObject *Sender)
{
	FSize(StrToInt(frm->edtCntV->Text), StrToInt(frm->edtCntG->Text));
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnStartClick(TObject *Sender)
{	
	FInput(B);	
	FDraw(B, frm->img->Width/2, frm->img->Height/2);
}
//---------------------------------------------------------------------------