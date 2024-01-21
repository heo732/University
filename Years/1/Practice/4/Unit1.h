//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class Tfrm : public TForm
{
__published:	// IDE-managed Components
        TImage *img;
        TEdit *edtDegree;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TButton *btnOxM;
        TButton *btnOxP;
        TButton *btnOyP;
        TButton *btnOyM;
        TButton *btnOzM;
        TButton *btnOzP;
        TEdit *edtCntV;
        TButton *btnSize;
        TButton *btnStart;
        TStringGrid *stgV;
        TStringGrid *stgG;
        TLabel *Label5;
        TLabel *Label7;
        TEdit *edtCntG;
        TLabel *Label8;
        TLabel *Label9;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall btnOxPClick(TObject *Sender);
        void __fastcall btnOxMClick(TObject *Sender);
        void __fastcall btnOyPClick(TObject *Sender);
        void __fastcall btnOyMClick(TObject *Sender);
        void __fastcall btnOzPClick(TObject *Sender);
        void __fastcall btnOzMClick(TObject *Sender);
        void __fastcall btnSizeClick(TObject *Sender);
        void __fastcall btnStartClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall Tfrm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tfrm *frm;
//---------------------------------------------------------------------------
#endif
