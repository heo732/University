//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "UMain.h"
#include "TDomain_IP.h"
#include "UAdd.h"
#include "URemove.h"
#include "UBackup.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm_Main *Form_Main;
//---------------------------------------------------------------------------
__fastcall TForm_Main::TForm_Main(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm_Main::Button_AddClick(TObject *Sender)
{
  Form_Main->Hide();

  Form_Add->Edit_IP->Text = "";
  Form_Add->Edit_Domain->Text = "";

  Form_Add->Show();
}
//---------------------------------------------------------------------------

void __fastcall TForm_Main::FormCreate(TObject *Sender)
{
  TDomain_IP B;
  if(B.ReadFromFile("BASE.txt")){
    B.WriteInGrid(Grid);
  }
  else
    ShowMessage("Не вдалося відкрити файл 'BASE.txt'");
          
}
//---------------------------------------------------------------------------

void __fastcall TForm_Main::Button_RemoveClick(TObject *Sender)
{
  Form_Main->Hide();
  Form_Remove->Show();

  TDomain_IP B;
  B.ReadFromFile("BASE.txt");
  B.WriteInGrid(Form_Remove->Grid);
}
//---------------------------------------------------------------------------

void __fastcall TForm_Main::Button_BackupClick(TObject *Sender)
{
  Form_Main->Hide();
  Form_Backup->Show();

  TDomain_IP B;
  B.ReadFromFile("BACKUP.txt");
  B.WriteInGrid(Form_Backup->Grid);
}
//---------------------------------------------------------------------------
  
void __fastcall TForm_Main::Edit_SearchChange(TObject *Sender)
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

