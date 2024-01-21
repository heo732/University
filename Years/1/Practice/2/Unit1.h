//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class Tfrm : public TForm
{
__published:	// IDE-managed Components
        TStringGrid *stg1;
        TStringGrid *stg2;
        TLabel *Label1;
        TLabel *Label2;
        TButton *btnFill;
        TButton *btnDo;
        TLabel *Label3;
        TEdit *edtOut;
        TEdit *edtSize1;
        TEdit *edtSize2;
        TLabel *Label4;
        TLabel *Label5;
        TButton *btnSizeStg;
        void __fastcall btnFillClick(TObject *Sender);
        void __fastcall btnDoClick(TObject *Sender);
        void __fastcall btnSizeStgClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall Tfrm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tfrm *frm;
//---------------------------------------------------------------------------
#endif
