//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TForm_Main : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TEdit *Edit_A;
        TLabel *Label3;
        TEdit *Edit_B;
        TLabel *Label4;
        TEdit *Edit_Count;
        TButton *Button_Execute;
        TImage *Image1;
        TLabel *Label5;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall Button_ExecuteClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm_Main(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm_Main *Form_Main;
//---------------------------------------------------------------------------
#endif
