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
class TForm_Main : public TForm
{
__published:	// IDE-managed Components
        TStringGrid *Grid;
        TButton *Button_Add;
        TButton *Button_Remove;
        TButton *Button_Backup;
        TLabel *Label1;
        TEdit *Edit_Search;
        void __fastcall Button_AddClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall Button_RemoveClick(TObject *Sender);
        void __fastcall Button_BackupClick(TObject *Sender);
        void __fastcall Edit_SearchChange(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm_Main(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm_Main *Form_Main;
//---------------------------------------------------------------------------
#endif
