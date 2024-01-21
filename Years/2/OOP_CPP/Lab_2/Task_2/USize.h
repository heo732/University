//---------------------------------------------------------------------------

#ifndef USizeH
#define USizeH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TFormSize : public TForm
{
__published:	// IDE-managed Components
        TEdit *edtRowCount;
        TLabel *Label1;
        TEdit *edtColCount;
        TLabel *Label2;
        TButton *btnOk;
        TButton *btnClose;
        void __fastcall btnCloseClick(TObject *Sender);
        void __fastcall btnOkClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFormSize(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormSize *FormSize;
//---------------------------------------------------------------------------
#endif
