//---------------------------------------------------------------------------

#ifndef UAlphaH
#define UAlphaH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TFormAlpha : public TForm
{
__published:	// IDE-managed Components
        TButton *Button1;
        TButton *Button2;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFormAlpha(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormAlpha *FormAlpha;
//---------------------------------------------------------------------------
#endif
