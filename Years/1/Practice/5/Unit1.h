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
        TEdit *edtPy1;
        TLabel *Label1;
        TEdit *edtPx2;
        TEdit *edtPx1;
        TEdit *edtPy2;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *Label7;
        TLabel *Label8;
        TEdit *edtRx1;
        TEdit *edtRy1;
        TEdit *edtRx2;
        TEdit *edtRy2;
        TLabel *Label9;
        TLabel *Label10;
        TButton *btnCurveH;
        TButton *btnCurveB;
        TButton *btnClear;
        void __fastcall btnCurveHClick(TObject *Sender);
        void __fastcall btnCurveBClick(TObject *Sender);
        void __fastcall btnClearClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall Tfrm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tfrm *frm;
//---------------------------------------------------------------------------
#endif
