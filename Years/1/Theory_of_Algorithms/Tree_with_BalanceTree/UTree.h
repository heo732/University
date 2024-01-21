//---------------------------------------------------------------------------
#ifndef UTreeH
#define UTreeH
//---------------------
#include <Classes.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
typedef struct OTree
{
  double data;
  OTree *left;
  OTree *right;
}TTree;
//---------------------------------------------------------------------------
void AddNode(TTree *&T,double d);
void DeleteTree(TTree *&T);
void PrintTree(TTree *T,int Rang,TStringGrid *&stg);
void CleanStringGrid(TStringGrid *&stg);
int TreeHeight(TTree *T);
double DobutokNodes(TTree *T);
int RandomValue(int l,int r);
void BalanceTree(TTree *&T);
//---------------------------------------------------------------------------
#endif