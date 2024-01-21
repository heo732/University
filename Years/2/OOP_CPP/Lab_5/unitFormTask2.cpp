//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormTask2.h"
#include "unitMain.h"
#include "unitTask2.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformTask2 *formTask2;
//---------------------------------------------------------------------------
Tree tree;
//---------------------------------------------------------------------------
__fastcall TformTask2::TformTask2(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformTask2::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formMain->Show();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask2::buttonGoMainClick(TObject *Sender)
{
        formMain->Show();
        formTask2->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask2::buttonRandomClick(TObject *Sender)
{
        Randomize();
        tree.add(-50 + (double)rand() / RAND_MAX * 100);
        tree.printStringGrid(stringGrid);        
}
//---------------------------------------------------------------------------
void __fastcall TformTask2::buttonAddClick(TObject *Sender)
{
        double temp;
        if(TryStrToFloat(edit->Text, temp))
        {
                tree.add(StrToFloat(edit->Text));
                tree.printStringGrid(stringGrid);
        }
        else
                ShowMessage("¬вед≥ть числове значенн€");
}
//---------------------------------------------------------------------------
void __fastcall TformTask2::buttonEraseClick(TObject *Sender)
{
        tree.erase();
        stringGrid->ColCount = 1;
        stringGrid->RowCount = 1;
        stringGrid->Cells[0][0] = "";        
}
//---------------------------------------------------------------------------

