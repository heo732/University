//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitMain.h"
#include "unitFormTask1.h"
#include "unitFormTask2.h"
#include "unitFormTask3.h"
#include "unitFormTask4.h"
#include "unitFormTask5.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformMain *formMain;
//---------------------------------------------------------------------------
__fastcall TformMain::TformMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformMain::buttonTask1Click(TObject *Sender)
{
        formMain->Hide();
        formTask1->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformMain::buttonTask2Click(TObject *Sender)
{
        formTask2->Show();
        formMain->Hide();        
}
//---------------------------------------------------------------------------

void __fastcall TformMain::buttonTask3Click(TObject *Sender)
{
        formTask3->Show();
        formMain->Hide();        
}
//---------------------------------------------------------------------------

void __fastcall TformMain::buttonTask4Click(TObject *Sender)
{
        formTask4->Show();
        formMain->Hide();
}
//---------------------------------------------------------------------------

void __fastcall TformMain::buttonTask5Click(TObject *Sender)
{
        formTask5->Show();
        formMain->Hide();
}
//---------------------------------------------------------------------------

