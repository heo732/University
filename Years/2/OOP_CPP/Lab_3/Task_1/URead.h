//---------------------------------------------------------------------------

#ifndef UReadH
#define UReadH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class TFormRead : public TForm
{
__published:	// IDE-managed Components
        TButton *btnInitialize;
        TButton *btnRandomFill;
        TButton *btnReadFromFile;
        TRadioGroup *RadioGroup;
        TButton *btnClose;
        TOpenDialog *OpenDialog;
        void __fastcall btnCloseClick(TObject *Sender);
        void __fastcall btnInitializeClick(TObject *Sender);
        void __fastcall btnRandomFillClick(TObject *Sender);
        void __fastcall btnReadFromFileClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFormRead(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormRead *FormRead;
//---------------------------------------------------------------------------
#endif
