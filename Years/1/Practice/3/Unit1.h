//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class Tfrm : public TForm
{
__published:	// IDE-managed Components
        TMemo *memIn1;
        TMemo *memIn2;
        TMemo *memOut;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TButton *btnFileIn1;
        TButton *btnFileIn2;
        TButton *btnFileOut;
        TLabel *Label5;
        TLabel *Label6;
        TButton *btnDo;
        TOpenDialog *odl;
        TSaveDialog *sdl;
        TLabel *lblNameFileIn1;
        TLabel *lblNameFileIn2;
        TLabel *lblNameFileOut;
        void __fastcall btnFileIn1Click(TObject *Sender);
        void __fastcall btnFileIn2Click(TObject *Sender);
        void __fastcall btnFileOutClick(TObject *Sender);
        void __fastcall btnDoClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall Tfrm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tfrm *frm;
//---------------------------------------------------------------------------
#endif
