//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "URemove.h"
#include "UMain.h"
#include "URemoveConfirm.h"
#include "TDomain_IP.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm_Remove *Form_Remove;
//---------------------------------------------------------------------------
__fastcall TForm_Remove::TForm_Remove(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm_Remove::FormClose(TObject *Sender,
      TCloseAction &Action)
{ 
  Form_Main->Show();
  TDomain_IP B;
  B.ReadFromFile("BASE.txt");
  B.WriteInGrid(Form_Main->Grid);
  Form_Main->Edit_Search->Text = "";
}
//---------------------------------------------------------------------------
void __fastcall TForm_Remove::GridSelectCell(TObject *Sender, int ACol,
      int ARow, bool &CanSelect)
{
  String d, i;
  d = Grid->Cells[1][ARow];
  i = Grid->Cells[2][ARow];

  Form_Remove->Hide();
  Form_RemoveConfirm->Show();

  Form_RemoveConfirm->Grid->Cells[0][0] = d;
  Form_RemoveConfirm->Grid->Cells[1][0] = i;
}
//---------------------------------------------------------------------------

void __fastcall TForm_Remove::Button_CloseClick(TObject *Sender)
{
  Form_Remove->Close();
}
//---------------------------------------------------------------------------

void __fastcall TForm_Remove::Edit_SearchChange(TObject *Sender)
{

  if(Edit_Search->Text != ""){
    TDomain_IP B, N;
    String search = Edit_Search->Text;
    B.ReadFromFile("BASE.txt");

    for(int i=0; i<B.Size(); i++)
      if( B[i]->domain.find(search.c_str()) != string::npos || B[i]->IP.find(search.c_str()) != string::npos )
        N.Add(B[i]->domain, B[i]->IP);

    N.WriteInGrid(Grid);
  }
  else{
    TDomain_IP B;
    B.ReadFromFile("BASE.txt");
    B.WriteInGrid(Grid);
  }
  
}
//---------------------------------------------------------------------------

