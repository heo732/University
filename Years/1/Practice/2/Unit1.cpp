//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <string>
using namespace std;
#include <vector>
//---------------------------------------------------------------------------
typedef struct OList{
  string text;
  OList *next;
}TypeList;
//---------------------------------------------------------------------------
//повертає TRUE, якщо переданий символьний параметр - цифра, інакше - FALSE
bool IsNumber(char c){
  if(
    c == '0' ||
    c == '1' ||
    c == '2' ||
    c == '3' ||
    c == '4' ||
    c == '5' ||
    c == '6' ||
    c == '7' ||
    c == '8' ||
    c == '9'
    )
    return true;
  return false;
}
//---------------------------------------------------------------------------
//повертає TRUE, якщо в переданому рядку знаходиться тільки натуральне число, інакше - FALSE
bool IsInputNaturalValue(string s){
  if(s[0] == '0')
    return false;
  if(s.size() == 0)
    return false;
  unsigned int cntNumbers=0,i;
  for(i = 0; i < s.size(); i++)
    if(IsNumber(s[i]))
      cntNumbers++;
  if(cntNumbers == s.size())
    return true;
  return false; 
}
//---------------------------------------------------------------------------
string RandomWord(){
  unsigned int r;  
  r = random(26);
  switch(r){
    case 0:{return "Milk";}
    case 1:{return "Shoe";}
    case 2:{return "Cheese";}
    case 3:{return "Pineapple";} 
    case 4:{return "Apple";}
    case 5:{return "Shrek";}
    case 6:{return "Dragon";}
    case 7:{return "Phone";}
    case 8:{return "Snake";}
    case 9:{return "Heart";}
    case 10:{return "Joy";}
    case 11:{return "Book";}
    case 12:{return "Lamp";}
    case 13:{return "Pen";}
    case 14:{return "Car";}
    case 15:{return "Table";}
    case 16:{return "Blade";}
    case 17:{return "Blood";}
    case 18:{return "Desk";}
    case 19:{return "Chair";}
    case 20:{return "Sofa";}
    case 21:{return "VHS";}
    case 22:{return "Keyboard";}
    case 23:{return "Mouse";}
    case 24:{return "Charge";}
    case 25:{return "Leaf";}
  }
}
//---------------------------------------------------------------------------
void RandomWordsInStg(TStringGrid *&stg, unsigned int rows){
  unsigned int i;  
  for(i = 0; i < rows; i++)
    stg->Cells[0][i] = RandomWord().c_str();
}
//---------------------------------------------------------------------------
//Додавання елемента у стек
void PushInStack(TypeList *&L, string word){
  if(L != NULL){
    TypeList *tmp;
    tmp = new TypeList;
    tmp->text = word;
    tmp->next = L;
    L = tmp;
  }
  else{
    L = new TypeList;
    L->text = word;
    L->next = NULL;
  }
}
//---------------------------------------------------------------------------
void DeleteStack(TypeList *&L){
  if(L != NULL){
    DeleteStack(L->next);
    delete L;
    L = NULL;
  }
}
//---------------------------------------------------------------------------
void Add_FromStg_ToStack(TStringGrid *stg, unsigned int rows, TypeList *&L){
  unsigned int i;
  for(i = 0; i < rows; i++)
    PushInStack(L, stg->Cells[0][i].c_str());
}
//---------------------------------------------------------------------------
bool IsWordInList(TypeList *L, string word){
  if(L != NULL){
    if(IsWordInList(L->next, word))
      return true;
    if(L->text == word)
      return true;
  }
  return false;
}
//---------------------------------------------------------------------------
void FromL1_IsInL1_NotInL2_ToEdit(TypeList *L1, TypeList *L2, TEdit *&edt){
  if(L1 != NULL){
    if(!(IsWordInList(L2, L1->text))){
      edt->Text = edt->Text + L1->text.c_str();
      edt->Text = edt->Text + " ";
    }
    FromL1_IsInL1_NotInL2_ToEdit(L1->next, L2, edt);
  }
}
//---------------------------------------------------------------------------
unsigned int SizeL1 = 2, SizeL2 = 5;
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnFillClick(TObject *Sender)
{
  randomize();
  RandomWordsInStg(stg1, SizeL1);
  RandomWordsInStg(stg2, SizeL2);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnDoClick(TObject *Sender)
{
  if(SizeL1 != 0 && SizeL2 != 0){
    TypeList *List1 = NULL, *List2 = NULL;
    Add_FromStg_ToStack(stg1, SizeL1, List1);
    Add_FromStg_ToStack(stg2, SizeL2, List2);
    edtOut->Text = "";
    FromL1_IsInL1_NotInL2_ToEdit(List1, List2, edtOut);
    DeleteStack(List1);
    DeleteStack(List2);
  }
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnSizeStgClick(TObject *Sender)
{
  if(IsInputNaturalValue(edtSize1->Text.c_str()) && IsInputNaturalValue(edtSize2->Text.c_str())){//Якщо введено натуральні значення
    SizeL1 = StrToInt(edtSize1->Text);
    SizeL2 = StrToInt(edtSize2->Text);
    stg1->RowCount = SizeL1;
    stg2->RowCount = SizeL2;
  }  
  else
    ShowMessage("Введіть натуральні значення!");
}
//---------------------------------------------------------------------------