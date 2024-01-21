//---------------------------------------------------------------------------

#ifndef unitFormTask2H
#define unitFormTask2H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TformTask2 : public TForm
{
__published:	// IDE-managed Components
        TButton *buttonGoMain;
        TButton *buttonRandom;
        TStringGrid *stringGrid;
        TEdit *edit;
        TButton *buttonAdd;
        TButton *buttonErase;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall buttonGoMainClick(TObject *Sender);
        void __fastcall buttonRandomClick(TObject *Sender);
        void __fastcall buttonAddClick(TObject *Sender);
        void __fastcall buttonEraseClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TformTask2(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformTask2 *formTask2;
//---------------------------------------------------------------------------
#endif
