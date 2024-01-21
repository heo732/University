//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class Tfrm : public TForm
{
__published:	// IDE-managed Components
        TImage *img;
        TButton *btnPaint;
        TEdit *edtLen;
        TEdit *edtStep;
        TLabel *Label1;
        TLabel *Label2;
        void __fastcall btnPaintClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall Tfrm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tfrm *frm;
//---------------------------------------------------------------------------
#endif
