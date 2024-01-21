//---------------------------------------------------------------------------

#ifndef unitFormExample5H
#define unitFormExample5H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TformExample5 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TButton *Button4;
        TStringGrid *StringGrid1;
        TButton *Button1;
        TEdit *Edit1;
        TLabel *Label2;
        TLabel *labelAverage;
        TLabel *Label3;
        TLabel *labelDispersion;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Button4Click(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TformExample5(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformExample5 *formExample5;
//---------------------------------------------------------------------------
#endif
