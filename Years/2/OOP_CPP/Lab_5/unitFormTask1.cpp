//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormTask1.h"
#include "unitMain.h"
#include "unitTask1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformTask1 *formTask1;
//---------------------------------------------------------------------------
Game game;
//---------------------------------------------------------------------------
__fastcall TformTask1::TformTask1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::buttonGoMainClick(TObject *Sender)
{
        formTask1->Hide();
        formMain->Show();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formMain->Show();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::buttonNewGameClick(TObject *Sender)
{
        int steps = 10, temp;
        if(TryStrToInt(comboBoxCountSteps->Text, temp) && StrToInt(comboBoxCountSteps->Text)>0)
        {
                steps = StrToInt(comboBoxCountSteps->Text);
                game.startGame(imageConsistentDeck1, imageConsistentDeck2,
                imageFreeDeck1, imageFreeDeck2,
                imageCurrentCard1, imageCurrentCard2,
                steps,
                labelStatus,
                labelCountPoints1, labelCountPoints2);
        }
        else
        {
                ShowMessage("Кількість ходів це додатнє число");
        }                                                   
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::imageConsistentDeck1MouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        game.doStep(Game::consistent, Y, imageConsistentDeck1);
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::imageFreeDeck1MouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        game.doStep(Game::free, Y, imageFreeDeck1);
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::imageConsistentDeck2MouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        game.doStep(Game::consistent, Y, imageConsistentDeck2);
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::imageFreeDeck2MouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        game.doStep(Game::free, Y, imageFreeDeck2);
}
//---------------------------------------------------------------------------

