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
        TEdit *edtSearch;
        TStringGrid *stgSearch;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall edtSearchChange(TObject *Sender);
        void __fastcall stgSearchSelectCell(TObject *Sender, int ACol,
          int ARow, bool &CanSelect);
private:	// User declarations
public:		// User declarations
        __fastcall TfrmSearch(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmSearch *frmSearch;
//---------------------------------------------------------------------------
#endif
