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
class TFormMain : public TForm
{
__published:	// IDE-managed Components
        TStringGrid *stg1;
        TStringGrid *stg2;
        TButton *btnColCountPlus;
        TButton *btnColCountMinus;
        TButton *btnRowCountMinus;
        TButton *btnRowCountPlus;
        TButton *btnSize;
        TButton *btnRead;
        TButton *btnClear;
        TButton *btnAdd;
        TButton *btnSub;
        TButton *btnMultiply;
        TButton *btnLessOrNotEqual;
        TButton *btnMore;
        TButton *btnReverse;
        void __fastcall btnColCountPlusClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall btnColCountMinusClick(TObject *Sender);
        void __fastcall btnRowCountMinusClick(TObject *Sender);
        void __fastcall btnRowCountPlusClick(TObject *Sender);
        void __fastcall btnMoreClick(TObject *Sender);
        void __fastcall btnLessOrNotEqualClick(TObject *Sender);
        void __fastcall btnReverseClick(TObject *Sender);
        void __fastcall btnSizeClick(TObject *Sender);
        void __fastcall btnReadClick(TObject *Sender);
        void __fastcall btnClearClick(TObject *Sender);
        void __fastcall btnAddClick(TObject *Sender);
        void __fastcall btnSubClick(TObject *Sender);
        void __fastcall btnMultiplyClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFormMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormMain *FormMain;
//---------------------------------------------------------------------------
#endif
