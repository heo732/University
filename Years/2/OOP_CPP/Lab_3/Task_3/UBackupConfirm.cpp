//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "UBackupConfirm.h"
#include "UBackup.h"
#include "TDomain_IP.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm_BackupConfirm *Form_BackupConfirm;
//---------------------------------------------------------------------------
__fastcall TForm_BackupConfirm::TForm_BackupConfirm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm_BackupConfirm::FormClose(TObject *Sender,
      TCloseAction &Action)
{
  Form_Backup->Show();
  Form_Backup->Edit_Search->Text = "";
}
//---------------------------------------------------------------------------
void __fastcall TForm_BackupConfirm::Button_NoClick(TObject *Sender)
{
  Form_BackupConfirm->Close();
}
//---------------------------------------------------------------------------
void __fastcall TForm_BackupConfirm::Button_YesClick(TObject *Sender)
{
  TDomain_IP B;

  B.ReadFromFile("BASE.txt");
  B.Add(Grid->Cells[0][0].c_str(), Grid->Cells[1][0].c_str());
  B.WriteInFile("BASE.txt");

  B.ReadFromFile("BACKUP.txt");
  B.Remove(Grid->Cells[0][0].c_str());
  B.WriteInFile("BACKUP.txt");

  Form_BackupConfirm->Close();

  B.WriteInGrid(Form_Backup->Grid);
}
//---------------------------------------------------------------------------
