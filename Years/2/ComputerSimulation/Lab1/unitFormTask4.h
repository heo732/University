//---------------------------------------------------------------------------

#ifndef unitFormTask4H
#define unitFormTask4H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TformTask4 : public TForm
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
        TEdit *Edit3;
        TLabel *Label4;
        TEdit *Edit4;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Button4Click(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TformTask4(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformTask4 *formTask4;
//---------------------------------------------------------------------------
#endif
