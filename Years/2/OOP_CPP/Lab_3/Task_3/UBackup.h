//---------------------------------------------------------------------------

#ifndef UBackupH
#define UBackupH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TForm_Backup : public TForm
{
__published:	// IDE-managed Components
        TStringGrid *Grid;
        TLabel *Label1;
        TEdit *Edit_Search;
        TButton *Button_Close;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall GridSelectCell(TObject *Sender, int ACol, int ARow,
          bool &CanSelect);
        void __fastcall Button_CloseClick(TObject *Sender);
        void __fastcall Edit_SearchChange(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm_Backup(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm_Backup *Form_Backup;
//---------------------------------------------------------------------------
#endif
