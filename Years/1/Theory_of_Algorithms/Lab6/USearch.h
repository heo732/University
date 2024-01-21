//---------------------------------------------------------------------------

#ifndef USearchH
#define USearchH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TfrmSearch : public TForm
{
__published:	// IDE-managed Components
        TStringGrid *stg;
        TEdit *edtSearch;
        TEdit *edtCount;
        TLabel *Label2;
        TButton *btnShawAll;
        TButton *btnSearch;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall btnShawAllClick(TObject *Sender);
        void __fastcall btnSearchClick(TObject *Sender);
        void __fastcall stgSelectCell(TObject *Sender, int ACol, int ARow,
          bool &CanSelect);
private:	// User declarations
public:		// User declarations
        __fastcall TfrmSearch(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmSearch *frmSearch;
//---------------------------------------------------------------------------
#endif