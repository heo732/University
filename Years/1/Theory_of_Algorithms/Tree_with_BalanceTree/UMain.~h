//---------------------------------------------------------------------------

#ifndef UMainH
#define UMainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TfrmMain : public TForm
{
__published:	// IDE-managed Components
        TEdit *edtSize;
        TLabel *Label1;
        TButton *btnSize;
        TStringGrid *stgElements;
        TButton *btnDo;
        TStringGrid *stgTree;
        TButton *btnRandom;
        TEdit *edtDobutok;
        TLabel *Label2;
        TEdit *edtRandomLeft;
        TEdit *edtRandomRight;
        TButton *btnBalance;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall btnSizeClick(TObject *Sender);
        void __fastcall btnDoClick(TObject *Sender);
        void __fastcall btnRandomClick(TObject *Sender);
        void __fastcall stgTreeDrawCell(TObject *Sender, int ACol,
          int ARow, TRect &Rect, TGridDrawState State);
        void __fastcall stgElementsDrawCell(TObject *Sender, int ACol,
          int ARow, TRect &Rect, TGridDrawState State);
        void __fastcall btnBalanceClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TfrmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmMain *frmMain;
//---------------------------------------------------------------------------
#endif
