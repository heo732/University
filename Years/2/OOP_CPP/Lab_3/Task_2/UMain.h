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
        TButton *btnColCountPlus1;
        TButton *btnColCountMinus1;
        TButton *btnRowCountMinus1;
        TButton *btnRowCountPlus1;
        TButton *btnSize;
        TButton *btnRead;
        TButton *btnClear;
        TButton *btnAdd;
        TButton *btnSub;
        TButton *btnMultiply;
        TButton *btnLess;
        TButton *btnMore;
        TButton *btnReverse;
        TButton *btnColCountPlus2;
        TButton *btnColCountMinus2;
        TButton *btnRowCountMinus2;
        TButton *btnRowCountPlus2;
        TButton *btnEqual;
        TButton *btnMoreEqual;
        TButton *btnLessEqual;
        TButton *btnNotEqual;
        TButton *btnBitAdd;
        TButton *btnRemainderOfDivision;
        TButton *btnDivision;
        TButton *btnBitAddMod2;
        TButton *btnBitLandslideToRight;
        void __fastcall btnColCountPlus1Click(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall btnColCountMinus1Click(TObject *Sender);
        void __fastcall btnRowCountMinus1Click(TObject *Sender);
        void __fastcall btnRowCountPlus1Click(TObject *Sender);
        void __fastcall btnMoreClick(TObject *Sender);
        void __fastcall btnLessClick(TObject *Sender);
        void __fastcall btnReverseClick(TObject *Sender);
        void __fastcall btnSizeClick(TObject *Sender);
        void __fastcall btnReadClick(TObject *Sender);
        void __fastcall btnClearClick(TObject *Sender);
        void __fastcall btnAddClick(TObject *Sender);
        void __fastcall btnSubClick(TObject *Sender);
        void __fastcall btnMultiplyClick(TObject *Sender);
        void __fastcall btnColCountMinus2Click(TObject *Sender);
        void __fastcall btnColCountPlus2Click(TObject *Sender);
        void __fastcall btnRowCountMinus2Click(TObject *Sender);
        void __fastcall btnRowCountPlus2Click(TObject *Sender);
        void __fastcall btnEqualClick(TObject *Sender);
        void __fastcall btnMoreEqualClick(TObject *Sender);
        void __fastcall btnLessEqualClick(TObject *Sender);
        void __fastcall btnNotEqualClick(TObject *Sender);
        void __fastcall btnDivisionClick(TObject *Sender);
        void __fastcall btnRemainderOfDivisionClick(TObject *Sender);
        void __fastcall btnBitAddClick(TObject *Sender);
        void __fastcall btnBitAddMod2Click(TObject *Sender);
        void __fastcall btnBitLandslideToRightClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFormMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormMain *FormMain;
//---------------------------------------------------------------------------
#endif
