//---------------------------------------------------------------------------

#ifndef unitFormTask2H
#define unitFormTask2H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TformTask2 : public TForm
{
__published:	// IDE-managed Components
        TButton *Button4;
        TEdit *Edit1;
        TEdit *Edit2;
        TEdit *Edit3;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TEdit *Edit4;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *labelProbability;
        TButton *Button1;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Button4Click(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TformTask2(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformTask2 *formTask2;
//---------------------------------------------------------------------------
#endif
