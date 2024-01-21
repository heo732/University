//---------------------------------------------------------------------------
#pragma hdrstop
#include "UTree.h"
#pragma package(smart_init)
#include <vector.h>
//---------------------------------------------------------------------------
void AddNode(TTree *&T,double d)
{
  if(T==NULL)
  {
    T=new TTree;
    T->left=NULL;
    T->right=NULL;
    T->data=d;
  }
  else
    if(d<T->data)
      AddNode(T->left,d);
    else
      AddNode(T->right,d);
}
//---------------------------------------------------------------------------
void DeleteTree(TTree *&T)
{
  if(T!=NULL)
  {
    DeleteTree(T->left);
    DeleteTree(T->right);
    delete T;
    T=NULL;
  }
}
//---------------------------------------------------------------------------
void PrintTree(TTree *T,int Rang,TStringGrid *&stg)
{
  if(T!=NULL)
  {
    PrintTree(T->left,Rang+1,stg);
    stg->Cells[stg->ColCount][Rang]=FloatToStr(T->data);
    stg->ColCount++;
    PrintTree(T->right,Rang+1,stg);
  }
}
//---------------------------------------------------------------------------
void CleanStringGrid(TStringGrid *&stg)
{
  int i,j;
  for(i=stg->FixedCols;i<stg->ColCount;i++)
    for(j=stg->FixedRows;j<stg->RowCount;j++)
      stg->Cells[i][j]="";
  stg->ColCount=2;  
}
//---------------------------------------------------------------------------
int TreeHeight(TTree *T)
{
  int k=0;
  if(T!=NULL)
    return max(TreeHeight(T->left),TreeHeight(T->right))+1;
  return k;
}
//---------------------------------------------------------------------------
double DobutokNodes(TTree *T)
{
  double k=1;
  if(T!=NULL)
    return DobutokNodes(T->left)*DobutokNodes(T->right)*T->data;
  return k;
}
//---------------------------------------------------------------------------
int RandomValue(int l,int r)
{
  return random(r-l+1)+l;
}
//---------------------------------------------------------------------------