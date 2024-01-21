//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <Grids.hpp>
#include <Graphics.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TEdit *In1;
        TEdit *In2;
        TLabel *Label1;
        TLabel *Label2;
        TRadioGroup *RadioGroup1;
        TRadioGroup *RadioGroup2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TStringGrid *StringGrid1;
        TEdit *Out1;
        TEdit *Out2;
        TButton *ButtonPrepare;
        TButton *ButtonDo;
        TButton *ButtonClose;
        TStringGrid *StringGrid2;
        TButton *ButtonRandom;
        TImage *Image1;
        void __fastcall ButtonCloseClick(TObject *Sender);
        void __fastcall ButtonPrepareClick(TObject *Sender);
        void __fastcall ButtonRandomClick(TObject *Sender);
        void __fastcall ButtonDoClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
