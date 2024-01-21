//---------------------------------------------------------------------------

#ifndef unitFormTask4H
#define unitFormTask4H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TformTask4 : public TForm
{
__published:	// IDE-managed Components
        TButton *buttonGoMain;
        TMemo *memoIn;
        TRadioGroup *RadioGroup1;
        TMemo *memoOut;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall buttonGoMainClick(TObject *Sender);
        void __fastcall memoInChange(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TformTask4(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformTask4 *formTask4;
//---------------------------------------------------------------------------
#endif
