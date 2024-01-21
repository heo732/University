//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "UBackup.h"
#include "UMain.h"
#include "UBackupConfirm.h"
#include "TDomain_IP.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm_Backup *Form_Backup;
//---------------------------------------------------------------------------
__fastcall TForm_Backup::TForm_Backup(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm_Backup::FormClose(TObject *Sender,
      TCloseAction &Action)
{
  Form_Main->Show();
  TDomain_IP B;
  B.ReadFromFile("BASE.txt");
  B.WriteInGrid(Form_Main->Grid);
  Form_Main->Edit_Search->Text = "";
}
//---------------------------------------------------------------------------
void __fastcall TForm_Backup::GridSelectCell(TObject *Sender, int ACol,
      int ARow, bool &CanSelect)
{
  String d, i;
  d = Grid->Cells[1][ARow];
  i = Grid->Cells[2][ARow];

  Form_Backup->Hide();
  Form_BackupConfirm->Show();

  Form_BackupConfirm->Grid->Cells[0][0] = d;
  Form_BackupConfirm->Grid->Cells[1][0] = i;
}
//---------------------------------------------------------------------------

void __fastcall TForm_Backup::Button_CloseClick(TObject *Sender)
{
  Form_Backup->Close();      
}
//---------------------------------------------------------------------------

void __fastcall TForm_Backup::Edit_SearchChange(TObject *Sender)
{

  if(Edit_Search->Text != ""){
    TDomain_IP B, N;
    String search = Edit_Search->Text;
    B.ReadFromFile("BACKUP.txt");

    for(int i=0; i<B.Size(); i++)
      if( B[i]->domain.find(search.c_str()) != string::npos || B[i]->IP.find(search.c_str()) != string::npos )
        N.Add(B[i]->domain, B[i]->IP);

    N.WriteInGrid(Grid);
  }
  else{
    TDomain_IP B;
    B.ReadFromFile("BACKUP.txt");
    B.WriteInGrid(Grid);
  }

}
//---------------------------------------------------------------------------

