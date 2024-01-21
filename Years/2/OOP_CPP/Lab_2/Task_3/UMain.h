//---------------------------------------------------------------------------
#ifndef UMainH
#define UMainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Dialogs.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TFormMain : public TForm
{
__published:	// IDE-managed Components
        TColorDialog *ColorDialog;
        TImage *Image;
        TImage *ImageColor;
        TLabel *Label1;
        TEdit *EditBase;
        TEdit *EditHeight;
        TEdit *EditSide;
        TLabel *Label4;
        TButton *ButtonDraw;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *LabelPerimeter;
        TLabel *LabelArea;
        TRadioGroup *RadioGroupLocks;
        TEdit *EditAlpha;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall ButtonDrawClick(TObject *Sender);
        void __fastcall ImageColorClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFormMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormMain *FormMain;
//---------------------------------------------------------------------------
#endif
