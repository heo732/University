//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class Tfrm : public TForm
{
__published:	// IDE-managed Components
        TButton *btn;
        TLabel *Label1;
        TEdit *edtP;
        TLabel *Label2;
        TEdit *edtN;
        TLabel *Label3;
        TEdit *edtK;
        TLabel *Label5;
        TLabel *Label6;
        TEdit *edtRez;
        void __fastcall btnClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall Tfrm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tfrm *frm;
//---------------------------------------------------------------------------
#endif
