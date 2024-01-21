//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "UMain.h"
#include "UTree.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <vector.h>
//---------------------------------------------------------------------------
TfrmMain *frmMain;
//---------------------------------------------------------------------------
__fastcall TfrmMain::TfrmMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
int N=0;
TTree *Tree=NULL;
//---------------------------------------------------------------------------
void __fastcall TfrmMain::FormCreate(TObject *Sender)
{
  frmMain->stgElements->Cells[0][0]="Елементи";  
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnSizeClick(TObject *Sender)
{
  N=StrToInt(edtSize->Text);
  frmMain->stgElements->RowCount=N+1;
  frmMain->stgTree->RowCount=N;
  for(int i=1;i<N;i++)  
    frmMain->stgTree->Cells[0][i]=IntToStr(i);
  frmMain->stgTree->Cells[0][0]="Root";
  CleanStringGrid(stgTree);
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnDoClick(TObject *Sender)
{  
  CleanStringGrid(stgTree);
  for(int i=1;i<=N;i++)
    AddNode(Tree,StrToFloat(frmMain->stgElements->Cells[0][i]));
  PrintTree(Tree,0,stgTree);
  frmMain->stgTree->RowCount=TreeHeight(Tree);
  frmMain->edtDobutok->Text=FloatToStr(DobutokNodes(Tree));
  DeleteTree(Tree);
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnRandomClick(TObject *Sender)
{
  int i;
  for(i=1;i<=N;i++)
    frmMain->stgElements->Cells[0][i]=IntToStr(RandomValue(StrToInt(edtRandomLeft->Text),StrToInt(edtRandomRight->Text)));
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::stgTreeDrawCell(TObject *Sender, int ACol,
      int ARow, TRect &Rect, TGridDrawState State)
{
  int x, y;
 
  x=Rect.Left+(Rect.Width()-stgTree->Canvas->TextWidth(stgTree->Cells[ACol][ARow]))/2;
  y=Rect.Top+(Rect.Height()-stgTree->Canvas->TextHeight(stgTree->Cells[ACol][ARow]))/2;
  if(ACol!=0)
  {
    stgTree->Canvas->FillRect(Rect);
    stgTree->Canvas->TextOut(x,y,stgTree->Cells[ACol][ARow]);
  }        
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::stgElementsDrawCell(TObject *Sender, int ACol,
      int ARow, TRect &Rect, TGridDrawState State)
{
  int x, y;
 
  x=Rect.Left+(Rect.Width()-stgElements->Canvas->TextWidth(stgElements->Cells[ACol][ARow]))/2;
  y=Rect.Top+(Rect.Height()-stgElements->Canvas->TextHeight(stgElements->Cells[ACol][ARow]))/2;
  stgElements->Canvas->FillRect(Rect);
  stgElements->Canvas->TextOut(x,y,stgElements->Cells[ACol][ARow]);
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnBalanceClick(TObject *Sender)
{
  CleanStringGrid(stgTree);
  for(int i=1;i<=N;i++)
    AddNode(Tree,StrToFloat(frmMain->stgElements->Cells[0][i]));

  BalanceTree(Tree);
  PrintTree(Tree,0,stgTree);

  frmMain->stgTree->RowCount=TreeHeight(Tree);
  DeleteTree(Tree);
}
//---------------------------------------------------------------------------

