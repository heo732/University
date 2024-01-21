//---------------------------------------------------------------------------

#ifndef unitFormMainH
#define unitFormMainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TformMain : public TForm
{
__published:	// IDE-managed Components
        TButton *Button1;
        TButton *Button2;
        TLabel *Label1;
        TStringGrid *StringGrid1;
        TLabel *Label2;
        TEdit *Edit1;
        TLabel *Label3;
        TStringGrid *StringGrid2;
        TLabel *Label4;
        TEdit *Edit2;
        TLabel *Label5;
        TButton *Button3;
        TStringGrid *StringGrid3;
        TRadioGroup *RadioGroup1;
        TEdit *Edit3;
        TLabel *Label6;
        TLabel *Label7;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
        void __fastcall Button3Click(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall RadioGroup1Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TformMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TformMain *formMain;
//---------------------------------------------------------------------------
#endif
