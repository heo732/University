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
        TEdit *edtX0;
        TEdit *edtY0;
        TLabel *Label1;
        TLabel *Label2;
        TEdit *edtKx;
        TEdit *edtKy;
        TEdit *edtKz;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TEdit *edtAlpha;
        TEdit *edtH;
        TEdit *edtA;
        TEdit *edtB;
        TLabel *Label6;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label9;
        TButton *btnPaint;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall btnPaintClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall Tfrm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tfrm *frm;
//---------------------------------------------------------------------------
#endif
