//---------------------------------------------------------------------------

#ifndef unitFormTask1H
#define unitFormTask1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TformTask1 : public TForm
{
__published:	// IDE-managed Components
        TButton *Button4;
        TButton *Button1;
        TButton *Button2;
        TButton *Button3;
        TButton *Button5;
        TButton *Button6;
        TButton *Button7;
        TButton *Button8;
        TButton *Button9;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Button4Click(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
        void __fastcall Button3Click(TObject *Sender);
        void __fastcall Button5Click(TObject *Sender);
        void __fastcall Button6Click(TObject *Sender);
        void __fastcall Button7Click(TObject *Sender);
        void __fastcall Button8Click(TObject *Sender);
        void __fastcall Button9Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TformTask1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformTask1 *formTask1;
//---------------------------------------------------------------------------
#endif