//---------------------------------------------------------------------------

#ifndef unitFormExample8H
#define unitFormExample8H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TformExample8 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TButton *Button4;
        TStringGrid *StringGrid1;
        TButton *Button1;
        TEdit *Edit1;
        TEdit *Edit2;
        TLabel *Label3;
        TLabel *labelAverage;
        TLabel *Label4;
        TLabel *labelDispersion;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Button4Click(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TformExample8(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformExample8 *formExample8;
//---------------------------------------------------------------------------
#endif
