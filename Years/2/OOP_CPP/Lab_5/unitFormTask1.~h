//---------------------------------------------------------------------------

#ifndef unitFormTask1H
#define unitFormTask1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TformTask1 : public TForm
{
__published:	// IDE-managed Components
        TButton *buttonGoMain;
        TImage *imageConsistentDeck1;
        TImage *imageFreeDeck1;
        TImage *imageFreeDeck2;
        TImage *imageConsistentDeck2;
        TImage *imageCurrentCard1;
        TImage *imageCurrentCard2;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *labelCountPoints1;
        TLabel *labelCountPoints2;
        TLabel *labelStatus;
        TComboBox *comboBoxCountSteps;
        TLabel *Label3;
        TButton *buttonNewGame;
        void __fastcall buttonGoMainClick(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall buttonNewGameClick(TObject *Sender);
        void __fastcall imageConsistentDeck1MouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall imageFreeDeck1MouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall imageConsistentDeck2MouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall imageFreeDeck2MouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
private:	// User declarations
public:		// User declarations
        __fastcall TformTask1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformTask1 *formTask1;
//---------------------------------------------------------------------------
#endif
